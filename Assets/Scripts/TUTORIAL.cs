using UnityEngine;
using System.Collections;

public class TUTORIAL : MonoBehaviour {
	public static bool turnL, turnR, gas, brake, off, complete, complete2, shutdown;
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
			turnL = turnR = gas = brake = off = complete = complete2 = shutdown = false;
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
			
		}
		
		
		
		// Update is called once per frame
		void FixedUpdate () {
				if (complete) {
						//print ("V:" + RB.velocity.magnitude);
					if(complete2){
						if (RB.velocity.magnitude > 1) {
								RR.motorTorque = (60 - (.8f * RB.velocity.magnitude)) * Input.GetAxis ("Vertical");
								RL.motorTorque = (60 - (.8f * RB.velocity.magnitude)) * Input.GetAxis ("Vertical");
						} else {
								RR.motorTorque = 100 * Input.GetAxis ("Vertical");
								RL.motorTorque = 100 * Input.GetAxis ("Vertical");
						}	
						}
			
					
						FL.steerAngle = (25 - (.3f * RB.velocity.magnitude)) * Input.GetAxis ("Horizontal");
						FR.steerAngle = (25 - (.3f * RB.velocity.magnitude)) * Input.GetAxis ("Horizontal");
			
				}
		}
		
		

	void OnGUI() {
		if (!shutdown) {
						//if (GUI.Button(new Rect(Screen.width/3.5f, Screen.height/2.5f, Screen.width/5, Screen.height/7), "Click"))
			
						GUI.skin.box.fontSize = 35;
						GUI.color = Color.red;
						if (!off && !complete) {
								GUI.Box (new Rect (Screen.width / 4, Screen.height / 10, Screen.width / 2, Screen.height / 5), "Welcome to the TUTORIAL!\n Hit any key to continue");
								if (Input.anyKeyDown) {
										off = true;
										GUI.enabled = false;
								}
						}
						if (off) {
								GUI.Box (new Rect (Screen.width / 4, Screen.height / 10, Screen.width / 2, Screen.height / 5), "Hold A to turn left");
								if (Input.GetKeyDown (KeyCode.A)) {
										turnL = true;
										GUI.enabled = false;
										off = false;
										complete = true;
								}
						}
						if (turnL) {
								GUI.Box (new Rect (Screen.width / 4, Screen.height / 10, Screen.width / 2, Screen.height / 5), "Hold D to turn right");
								if (Input.GetKeyDown (KeyCode.D)) {
										turnR = true;
										turnL = false;
										GUI.enabled = false;
								}
						}
						if (turnR) {
								GUI.Box (new Rect (Screen.width / 4, Screen.height / 10, Screen.width / 2, Screen.height / 5), "Hold S  to brake");
								if (Input.GetKeyDown (KeyCode.S)) {
										brake = true;
										turnR = false;
										GUI.enabled = false;
										complete2 = true;
								}
						}
						if (brake) {
								GUI.Box (new Rect (Screen.width / 4, Screen.height / 10, Screen.width / 2, Screen.height / 5), "Hold W to accelerate");
								if (Input.GetKeyDown (KeyCode.W)) {
										gas = true;
										brake = false;
										GUI.enabled = false;
								}
						}
						if (gas) {
								GUI.Box (new Rect (Screen.width / 4, Screen.height / 10, Screen.width / 2, Screen.height / 5), "Congratulations,\n now you can drive in circles \n and celebrate");
								StartCoroutine(callme());
								
									
						}
				}

	}
	IEnumerator callme() {
		yield return new WaitForSeconds(5);
		shutdown = true;

	}
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "lava") {
						transform.eulerAngles = new Vector3 (0, 190, 0);
						transform.position = new Vector3 (1090, 28, 1911);
				}
	}
}
