using UnityEngine;
using Valve.VR.InteractionSystem;

public class ControllerReference : MonoBehaviour {


	[Header("Main Controllers")]
	public static GameObject RightController;
	public static GameObject LeftController;

	public static GameObject RightFist;
	public static GameObject LeftFist;

	//Velocity Estimators
	public static VelocityEstimator rightVelocityEstimator;
	public static VelocityEstimator leftVelocityEstimator;

	// Use this for initialization
	void Start() {
		Debug.Log("controller reference");
		RightController = transform.Find("RightController").gameObject;
		LeftController = transform.Find("LeftController").gameObject;

		RightFist = RightController.transform.Find("Right Fist").gameObject;
		LeftFist = LeftController.transform.Find("Left Fist").gameObject;

		rightVelocityEstimator = RightFist.GetComponent<VelocityEstimator>();
		leftVelocityEstimator = LeftFist.GetComponent<VelocityEstimator>();

	}

}
