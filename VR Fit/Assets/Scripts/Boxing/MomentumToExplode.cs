using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Breakable))]
public class MomentumToExplode : MonoBehaviour {

	[Header("Which axis do you want to check?")]
	public bool x;
	public bool y;
	public bool z;

	[Header("How fast should they move to explode?")]
	public float explodeVelocity;

	public bool RightController;
	public bool LeftController;

	//Velocity Estimators
	private VelocityEstimator rightVelocityEstimator;
	private VelocityEstimator leftVelocityEstimator;

	//Controller Velocities
	private Vector3 rightControllerVelocity;
	private Vector3 leftControllerVelocity;

	private Rigidbody rb;

	private Breakable breakable;


	// Use this for initialization
	void Start() {
		rightVelocityEstimator = ControllerReference.RightFist.GetComponent<VelocityEstimator>();
		leftVelocityEstimator = ControllerReference.LeftFist.GetComponent<VelocityEstimator>();
		breakable = GetComponent<Breakable>();
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update() {
		rightControllerVelocity = rightVelocityEstimator.GetVelocityEstimate();
		leftControllerVelocity = leftVelocityEstimator.GetVelocityEstimate();


	}

	public void CheckToExplode() {
		if (RightController) {
			if (x)
				checkExplode(rightControllerVelocity.x);
			if (y)
				checkExplode(rightControllerVelocity.y);
			if (z)
				checkExplode(rightControllerVelocity.z);
		}
		if (LeftController) {
			if (x)
				checkExplode(leftControllerVelocity.x);
			if (y)
				checkExplode(leftControllerVelocity.y);
			if (z)
				checkExplode(leftControllerVelocity.z);
		}
	}



	private void FallObj() {
		rb.velocity = Vector3.zero;
		rb.useGravity = true;
		Destroy(gameObject, 5);
	}

	private void checkExplode(float speed) {
		if (speed > explodeVelocity) {
			breakable.Break();
			Debug.Log("Explode");
		} else {
			FallObj();
			Debug.Log("Fall");
		}
	}




}
