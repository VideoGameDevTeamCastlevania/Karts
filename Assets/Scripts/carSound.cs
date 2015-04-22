using UnityEngine;
using System.Collections;

public class carSound : MonoBehaviour {
	
	public AudioSource audio_engine;
	public AudioSource audio_idle;

	private float speed;

	// Use this for initialization
	void Start () {
		audio_engine.Play ();
		audio_idle.Play ();
	}

	// Update is called once per frame
	void Update () {
		speed = rigidbody.velocity.magnitude;
		if (speed < 2.0F) {
			audio_idle.mute = false;
			audio_engine.mute = true;
		}
		else {
			audio_idle.mute = true;
			audio_engine.mute = false;
		}

		audio_engine.pitch = Mathf.Clamp (Mathf.Log10 (rigidbody.velocity.magnitude), 0.5F, 3);
	}
}
