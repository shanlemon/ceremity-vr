using UnityEngine;

public class ParticleOnDestroy : MonoBehaviour {

	[SerializeField]
	private GameObject deathObjectPrefab;

	// Use this for initialization
	void Start() {
		GetComponent<Breakable>().OnDestroy += spawnParticle;
	}

	void spawnParticle() {
		GameObject obj = Instantiate(deathObjectPrefab, transform.position, Quaternion.identity);
	}
}
