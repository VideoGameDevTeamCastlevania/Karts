using UnityEngine;
using System.Collections;

public class Persist : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
		foreach (Transform tr in transform) {
			tr.gameObject.AddComponent<Persist>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
