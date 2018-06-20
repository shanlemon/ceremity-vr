using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour {

    [SerializeField]
    private float destroyTimer;
    void Start()
    {
        Destroy(gameObject, destroyTimer);
    }
}
