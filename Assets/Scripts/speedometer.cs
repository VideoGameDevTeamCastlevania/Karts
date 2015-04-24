using UnityEngine;
using System.Collections;

public class speedometer : MonoBehaviour {

	private GameObject vehicle;
	private float calibration; //calibrate the needle to rotate accurately

	// Use this for initialization
	void Start () {
		vehicle = GameObject.FindGameObjectWithTag ("Player");
		calibration = 3.275F; 
	}
	
	// Update is called once per frame
	void Update () {
		//move the needle as speed changes
		transform.eulerAngles = new Vector3 (0, 0, calibration * -vehicle.rigidbody.velocity.magnitude); 
	}
}
