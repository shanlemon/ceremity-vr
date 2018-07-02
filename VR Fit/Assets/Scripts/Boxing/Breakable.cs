using System;
using UnityEngine;

[RequireComponent(typeof(MomentumToExplode))]
public class Breakable : MonoBehaviour {


	[SerializeField]
	private float deathDelay = 0;

	private MomentumToExplode mte;

	public event Action OnDestroy = delegate { };

	public void DoBreak() {
		OnDestroy();
	}

	public void Break() {
		Destroy(gameObject, deathDelay);
	}
}
