using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {
	public float minSpeed;
	public float maxSpeed;
	public bool start;
	public bool end;
	public static Vector3 whereAmI;

	// Use this for initialization
	void Start () {
		whereAmI = transform.position;
		minSpeed = 10f;
		maxSpeed = 20f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
