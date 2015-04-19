using UnityEngine;
using System.Collections;

public class speedometer : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.eulerAngles = new Vector3 (0, 0, 3.275F * -player.rigidbody.velocity.magnitude);
		// x' = xcos(theta) - ysin(theta)
		// y' = xsin(theta) - ycos(theta)
	}
}
