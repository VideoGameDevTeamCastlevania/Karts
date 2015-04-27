using UnityEngine;
using System.Collections;

public class SoundOptions : MonoBehaviour {

	private float music_volume, sound_volume;
	
	private AudioSource music_source;
	
	// Use this for initialization
	void Start () {
		music_volume = 1.0F;
		sound_volume = 1.0F;
		music_source = GetComponent<AudioSource> ();
		music_source.ignoreListenerVolume = true;
	}
	
	// Update is called once per frame
	void Update () {
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
