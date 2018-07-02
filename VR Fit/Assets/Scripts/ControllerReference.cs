using UnityEngine;

public class ControllerReference : MonoBehaviour {


	[Header("Main Controllers")]
	public static GameObject RightController;
	public static GameObject LeftController;

	public static GameObject RightFist;
	public static GameObject LeftFist;

	// Use this for initialization
	void Start() {
		RightController = transform.Find("RightController").gameObject;
		LeftController = transform.Find("LeftController").gameObject;

		RightFist = RightController.transform.Find("Right Fist").gameObject;
		LeftFist = LeftController.transform.Find("Left Fist").gameObject;

	}

}
