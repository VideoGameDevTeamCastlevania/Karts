using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {
	public static Vector3 whereAmI;

	// Use this for initialization
	void Start () {
		whereAmI = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
