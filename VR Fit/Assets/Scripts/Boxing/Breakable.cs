using System;
using UnityEngine;

public class Breakable : MonoBehaviour {


	[SerializeField]
	private float deathDelay = 0;
	
	public event Action OnDestroy = delegate { };

	public virtual void DoBreak() {
		OnDestroy();
		Destroy(gameObject, deathDelay);
	}

}
