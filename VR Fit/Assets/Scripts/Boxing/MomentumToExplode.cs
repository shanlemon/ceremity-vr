using UnityEngine;
using Valve.VR.InteractionSystem;

public class MomentumToExplode : Breakable {

	[Header("Which axis do you want to check?")]
	public bool x;
	public bool y;
	public bool z;

	[Header("How fast should they move to explode?")]
	public float explodeVelocity;

	public bool RightController;
	public bool LeftController;

	//Controller Velocities
	private Vector3 rightControllerVelocity;
	private Vector3 leftControllerVelocity;

	private Rigidbody rb;

	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody>();
	}


	void FixedUpdate() {
		rightControllerVelocity = ControllerReference.rightVelocityEstimator.GetVelocityEstimate();
		leftControllerVelocity = ControllerReference.leftVelocityEstimator.GetVelocityEstimate();

		Debug.Log(ControllerReference.rightVelocityEstimator.GetVelocityEstimate());
		Debug.Log(ControllerReference.leftVelocityEstimator.GetVelocityEstimate());
	}

	public override void DoBreak() {
		float vel = GetTargetAxisVelocity();
		Debug.Log("Velocity was " + vel);
		if (checkExplode(vel)) {
			base.DoBreak();
		} else {
			FallObj();
		}
	}
	
	public float GetTargetAxisVelocity() {
		if (RightController) {
			if (x)
				return (rightControllerVelocity.x);
			if (y)
				return (rightControllerVelocity.y);
			if (z)
				return (rightControllerVelocity.z);
			
		}
		if (LeftController) {
			if (x)
				return (leftControllerVelocity.x);
			if (y)
				return (leftControllerVelocity.y);
			if (z)
				return (leftControllerVelocity.z);
		}
		string everything = "right: " + rightControllerVelocity.x + " " + rightControllerVelocity.y + " " + rightControllerVelocity.z + "\n left: " + leftControllerVelocity.x + " " + leftControllerVelocity.y + " " + leftControllerVelocity.z;
		Debug.Log("everything bad" + everything);
		return 0;
	}

	private bool checkExplode(float speed) {
		return speed >= explodeVelocity;
	}

	private void FallObj() {
		rb.velocity = Vector3.zero;
		rb.useGravity = true;
		Destroy(gameObject, 5);
	}

}
