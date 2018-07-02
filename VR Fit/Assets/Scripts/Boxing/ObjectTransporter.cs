using UnityEngine;

public class ObjectTransporter : MonoBehaviour {

	[SerializeField]
	private Vector3 speed;

	private Rigidbody rb;

	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody>();
		rb.velocity = speed;
	}

	// Update is called once per frame
	void Update() {

	}
}
