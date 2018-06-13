using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectEmissionControl : MonoBehaviour {



    [Header("Emitter Settings")]
    public Vector3 startPos = new Vector3(0, 0, 0);
    [Header("Projectile Settings")]
    public GameObject breakable;
    public GameObject wall;
    public float wallLength = 5.0f;
    [Header("General Emission Settings")]
    public Vector3 velocity = new Vector3(0, 0, 5.0f);
    public float seperation = 2.0f;
    public float minFrequency = 0.25f;
    public float maxFrequency = 0.5f;
    [Range(1.0f, 20.0f)]
    public float difficulty = 1.0f;
    public bool stop = false;
    [Header("Breakble Emission Settings")]
    public int count = 9;
    public Vector3[] points;
    public int minBreakableCount = 0; //inclusive
    public int maxBreakableCount = 3; //exclusive
    [Header("Wall Emission Settings")]
    public Vector3[] wallPointsVertical;
    public Vector3[] wallPointsHorizontal;
    public float wallInitialFrequency = 0.075f;        //out of 1
    public float verticalVersusHorizontalWalls = 0.5f; //out of 1
    public float wallRepeatChance = 0.5f;
    public int minWallCount = 1; //inclusive
    public int maxWallCount = 2; //exclusive

    private float currentFrequency;
    private float wallFreqInitial;
    private HashSet<Vector3> current = new HashSet<Vector3>();
    private Vector3 thisPosition;
    private GameObject thisOne;
    private bool isWall;
    private bool isBreakable;
    private bool verticalWall;
    private bool horizontalWall;
    private Vector3 wallScale;

    void Start () {

        transform.position = startPos;
        points = new Vector3[count];
        wallFreqInitial = wallInitialFrequency;
        wallScale = new Vector3(1 + (seperation / 2), seperation * Mathf.Sqrt(count), wallLength);
        
        velocity = velocity * difficulty;
        minFrequency = minFrequency * difficulty;
        maxFrequency = maxFrequency * difficulty;
     
        EmissionPointsSquare();
        WallEmissionPoints();
        StartCoroutine(Emitter());
    }
	
    IEnumerator Emitter()
    {

        while (!stop) 
        {
            currentFrequency = Random.Range(minFrequency, maxFrequency);
            isBreakable = Random.Range(0.0f, 0.99f) > wallInitialFrequency;
            isWall = !isBreakable;

            if (isBreakable)
            {
                wallInitialFrequency = wallFreqInitial;
                FillFromArray(current, points, Random.Range(minBreakableCount, maxBreakableCount));
                EmitBreakables(current);
            }
            else
            {
                verticalWall = Random.Range(0.0f, 0.99f) > verticalVersusHorizontalWalls;
                horizontalWall = !verticalWall;
                FillFromArray(current, verticalWall ? wallPointsVertical : wallPointsHorizontal, Random.Range(minWallCount, maxWallCount));
                EmitWall(current, verticalWall);

                if(Random.Range(0.0f, 1.0f) > wallRepeatChance) wallInitialFrequency = 0.0f;
                else wallInitialFrequency = 1.0f;
            }

            yield return new WaitForSeconds(1.0f / currentFrequency);
           
        }
        
    }
    void EmitWall(HashSet<Vector3> hashSet, bool vertical)
    {
        while(hashSet.Count > 0)
        {
            Quaternion angleChange = vertical ? Quaternion.Euler(0f, 0f, 0f) : Quaternion.Euler(0f, 0f, 90f);
            thisOne = Instantiate(wall, hashSet.First() + transform.TransformPoint(0f, 0f, 0f), gameObject.transform.rotation * angleChange);
            thisOne.transform.localScale = wallScale;
            thisOne.GetComponent<Rigidbody>().velocity = velocity;
            hashSet.Remove(hashSet.First());
        }
        
    }

    void EmitBreakables(HashSet<Vector3> hashSet)
    {
        while(hashSet.Count > 0)
        {
            thisOne = Instantiate(breakable, hashSet.First() + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            thisOne.GetComponent<Rigidbody>().velocity = velocity;
            hashSet.Remove(hashSet.First());
        }
        
    }

    void FillFromArray(HashSet<Vector3> hashSet, Vector3[] arr, int targetAmount)
    {
        while (hashSet.Count > 0) hashSet.Remove(hashSet.First());
        while (hashSet.Count < targetAmount) hashSet.Add(arr[(int)Random.Range(0f, arr.Length)]);
    }    

    void EmissionPointsSquare()            
    {
        int col, row;
        col = row = (int)Mathf.Sqrt(count);
        int index = 0;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                points[index] = startPos + new Vector3(seperation * i, seperation * j, 0f);
                index++;
            }
        }
    
    }

    void WallEmissionPoints() //must be run after spawnPointsSquare
    {
        int middle =  ((int)Mathf.Sqrt(count) - 1) / 2;
        int rows =  (int)Mathf.Sqrt(count);
        wallPointsVertical = new Vector3[rows];
        wallPointsHorizontal = new Vector3[rows];
        for(int i = 0; i < rows; i++)
        {
            wallPointsVertical[i] = startPos + new Vector3(seperation * i, seperation * middle, 0f);
            wallPointsHorizontal[i] = startPos + new Vector3(seperation * middle, seperation * i, 0f);
        }
    }


}
