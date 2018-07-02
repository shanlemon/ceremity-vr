﻿using UnityEngine;

public class ControllerCollision : MonoBehaviour {

	void Start() {

	}

	void Update() {

	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag.Equals("Breakable")) {
			collider.GetComponent<Breakable>().DoBreak();
		}
	}
}
