using UnityEngine;
using System.Collections;

public class carSound : MonoBehaviour {
	
	public AudioSource audio_engine;
	private float speed;

	// Use this for initialization
	void Start () {
		audio_engine.Play ();
	}

	// Update is called once per frame
	void Update () {
		speed = rigidbody.velocity.magnitude;
		audio_engine.pitch = Mathf.Clamp (Mathf.Log10 (rigidbody.velocity.magnitude), 0.5F, 3);
	}
}
