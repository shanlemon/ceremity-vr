using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField]
    private float size = 1f;
    [SerializeField]
    private GameObject breakablePrefab;
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Spawn(1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Spawn(2);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Spawn(3);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            Spawn(4);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            Spawn(5);
        if (Input.GetKeyDown(KeyCode.Alpha6))
            Spawn(6);
        if (Input.GetKeyDown(KeyCode.Alpha7))
            Spawn(7);
        if (Input.GetKeyDown(KeyCode.Alpha8))
            Spawn(8);
        if (Input.GetKeyDown(KeyCode.Alpha9))
            Spawn(9);
    }

    private void Spawn(int key)
    {
        int row = (key - 1) % 3;
        int col = (key - 1) / 3;
        float x = row * size - size;
        float y = col * size + size;
        Instantiate(breakablePrefab, transform.position + new Vector3(x, y, 0), Quaternion.identity);

    }
}
