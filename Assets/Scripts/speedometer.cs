using UnityEngine;
using System.Collections;

public class speedometer : MonoBehaviour {

	public GameObject vehicle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//move the needle as speed changes
		transform.eulerAngles = new Vector3 (0, 0, 3.275F * -vehicle.rigidbody.velocity.magnitude); 
	}
}
