using UnityEngine;
using System.Collections;

public class SoundOptions : MonoBehaviour {

	private float music_volume, sound_volume;
	
	private AudioSource music_source;
	private GameObject main_camera;
	

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
		music_volume = 1.0F;
		sound_volume = 1.0F;
	}
	
	// Update is called once per frame
	void Update () {
		main_camera = GameObject.FindWithTag ("MainCamera");
		music_source = main_camera.GetComponent<AudioSource> ();
		music_source.ignoreListenerVolume = true;
		AudioListener.volume = sound_volume;
		music_source.volume = music_volume;
	}
	
	public void setMusicVolume (float volume)
	{
		music_volume = volume;
	}
	
	public void setSoundVolume (float volume)
	{
		sound_volume = volume;
	}
}
