using UnityEngine;
using System.Collections;

public class SpinWheel : MonoBehaviour {

	public WheelCollider RL, RR, FL, FR;
	public Transform RRL, RRR, FFL, FFR, HEAD, LARM, RARM;
	private Rigidbody RB;
	public int toe, toe2, toe3;
	private float DontWaste;
	// Use this for initialization
	void Start () {
		RB = GetComponent<Rigidbody> ();
		Vector3 y = RB.centerOfMass;
		y.y = -1.3f;
		RB.centerOfMass = y;
		DontWaste = FL.steerAngle;
	}
	void Update(){

		FFL.Rotate (0,0,FL.rpm / 60 * -360 * Time.deltaTime);
		FFR.Rotate (0,0,FR.rpm / 60 * 360 * Time.deltaTime); 
		if(FL.steerAngle != DontWaste) {
						Vector3 turnL = FFL.localEulerAngles;
						turnL.y = FL.steerAngle - 90; 
						FFL.localEulerAngles = turnL;
						turnL.y = FL.steerAngle + 90; 
						FFR.localEulerAngles = turnL;

						turnL.z = FL.steerAngle + 2;
						turnL.x = -FL.steerAngle + 2;
						turnL.y = FL.steerAngle;
						HEAD.localEulerAngles = turnL;
						DontWaste = FL.steerAngle;
						print (Time.deltaTime);
				}
			//WheelHit slide;
			//FR.GetGroundHit( slide );
			
			// if the slip of the tire is greater than 2.0, and the slip prefab exists, create an instance of it on the ground at
			// a zero rotation.
			//if ( Mathf.Abs( slide.sidewaysSlip ) > .8 )
			//{
				//skid.gameObject.active = true;
			//}
			//else if ( Mathf.Abs( slide.sidewaysSlip ) <= .75 )
			//{
				//skid.gameObject.active = false;
			//}
}



	// Update is called once per frame
void FixedUpdate () {

		//print ("V:" + RB.velocity.magnitude);
		if (RB.velocity.magnitude > 1) {
						RR.motorTorque = (60 - (.8f * RB.velocity.magnitude)) * Input.GetAxis ("Vertical");
						RL.motorTorque = (60 - (.8f * RB.velocity.magnitude)) * Input.GetAxis ("Vertical");
				} else {
			RR.motorTorque = 100 *Input.GetAxis ("Vertical");
			RL.motorTorque = 100 * Input.GetAxis ("Vertical");
		}	
				


			FL.steerAngle = (25 - (.3f * RB.velocity.magnitude)) * Input.GetAxis ("Horizontal");
			FR.steerAngle = (25 - (.3f * RB.velocity.magnitude)) * Input.GetAxis ("Horizontal");
				
		}

		
	}

