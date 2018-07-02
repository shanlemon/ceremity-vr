using UnityEngine;

public class KillOnThreshold : MonoBehaviour {

	public enum Axis { x, y, z };
	public Axis Axes;

	[SerializeField]
	private float threshold;



	private void Update() {

		switch (Axes) {
			case Axis.x:
				if (transform.position.x < threshold)
					Destroy(gameObject);
				break;
			case Axis.y:
				if (transform.position.y < threshold)
					Destroy(gameObject);
				break;
			case Axis.z:
				if (transform.position.z < threshold)
					Destroy(gameObject);
				break;
		}

	}

}
