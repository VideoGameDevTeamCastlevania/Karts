using UnityEngine;
using System.Collections;

public class SpinWheel : MonoBehaviour {

	public WheelCollider RL, RR, FL, FR;
	public Transform RRL, RRR, FFL, FFR, HEAD, LARM, RARM;
	private Rigidbody RB;
	public int toe, toe2, toe3;
	private float DontWaste;
	private WheelHit onleft, onright;
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
		RRL.Rotate (0,0,RL.rpm / 60 * -360 * Time.deltaTime);
		RRR.Rotate (0,0,RR.rpm / 60 * 360 * Time.deltaTime); 
		if (transform.gameObject.name == "GirlScout") {
			if (FL.steerAngle != DontWaste) {
				Vector3 turnL = FFL.localEulerAngles;
				turnL.x = FL.steerAngle; 
				FFL.localEulerAngles = turnL;
				turnL.x = FL.steerAngle - 180; 
				FFR.localEulerAngles = turnL;
				
				turnL.z = FL.steerAngle;
				turnL.x = FL.steerAngle/3 - 90;
				turnL.y = FL.steerAngle/5;
				HEAD.localEulerAngles = turnL;
				DontWaste = FL.steerAngle;
				
			}
		}
		if (transform.gameObject.name == "Marsian") {
				if (FL.steerAngle != DontWaste) {
						Vector3 turnL = FFL.localEulerAngles;
						turnL.x = FL.steerAngle; 
						FFL.localEulerAngles = turnL;
						turnL.x = FL.steerAngle - 180; 
						FFR.localEulerAngles = turnL;

						turnL.z = FL.steerAngle + 2;
						turnL.x = -FL.steerAngle + 2;
						turnL.y = FL.steerAngle;
						HEAD.localEulerAngles = turnL;
						DontWaste = FL.steerAngle;
				
				}
		}
		if (transform.gameObject.name == "Dog") {

			Vector3 turnL = FFL.localEulerAngles;
			turnL.x = FL.steerAngle; 
			FFL.localEulerAngles = turnL;
			turnL.x = FL.steerAngle - 180; 
			FFR.localEulerAngles = turnL;

				turnL = FFL.localEulerAngles;
				turnL.x = FL.steerAngle; 
				turnL.z = FL.steerAngle/5 + 2;
				turnL.x = -FL.steerAngle/.6f + 2;
				turnL.y = FL.steerAngle;
				HEAD.localEulerAngles = turnL;

				
			}
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




	// Update is called once per frame
void FixedUpdate () {
		//print (RR.rpm);
		//print ("V:" + RB.velocity.magnitude);
		if (Input.GetAxis ("Vertical") < 0 && FR.rpm > 10) {
						RR.brakeTorque = RL.brakeTorque = FL.brakeTorque = FR.brakeTorque = 75;
				} else {
						RR.brakeTorque = RL.brakeTorque = FL.brakeTorque = FR.brakeTorque = 0;
						if (FR.GetGroundHit (out onleft) && FL.GetGroundHit (out onright)) {
								if (onright.collider.gameObject.tag == "Road") {
										FR.motorTorque = (60 - (.8f * RB.velocity.magnitude)) * Input.GetAxis ("Vertical");
								} else {
										if(FR.rpm > 200)
											RR.brakeTorque = FR.brakeTorque = 100;
										FR.motorTorque = (20 - (.8f * RB.velocity.magnitude)) * Input.GetAxis ("Vertical");
								}
							
								if (onleft.collider.gameObject.tag == "Road") {
										FL.motorTorque = (60 - (.8f * RB.velocity.magnitude)) * Input.GetAxis ("Vertical");
								} else {
										if(FL.rpm > 200)
											RL.brakeTorque = FL.brakeTorque = 100;
										FL.motorTorque = (20 - (.8f * RB.velocity.magnitude)) * Input.GetAxis ("Vertical");
								}
						}
		}

			FL.steerAngle = (25 - (.3f * RB.velocity.magnitude)) * Input.GetAxis ("Horizontal");
			FR.steerAngle = (25 - (.3f * RB.velocity.magnitude)) * Input.GetAxis ("Horizontal");
				
		}

		
	}

