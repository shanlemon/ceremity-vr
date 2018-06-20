using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {

    [SerializeField]
    private GameObject deathObjectPrefab;
    [SerializeField]
    private float deathDelay = 0;
    [SerializeField]
    private Vector3 speed;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = speed;
    }
    private void Update()
    {
        if (transform.position.z < -5)
            Destroy(gameObject);
    }
    public void DoBreak()
    {
        GameObject obj = Instantiate(deathObjectPrefab, transform.position, Quaternion.identity);    
        Destroy(gameObject, deathDelay);
    }
}
