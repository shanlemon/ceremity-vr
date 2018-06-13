using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassSound : MonoBehaviour {

    public AudioClip clip;
    public AudioSource source;
	void Start () {
        source = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("p")) source.Play();
	}
    private void OnCollisionEnter(Collision collision)
    {
        source.Play();
    }
}
