using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class carControl : MonoBehaviour {

    private TimerClass tc;
    private int lapCount;
    private float fastestTime;

    private float averageLapTime;
    private float minLapTime;
    private float maxLapTime;
    private float current_time;

    private bool startline_hit;
    private float startline_time;

    public WheelCollider wheel_FL;
    public WheelCollider wheel_FR;
    public WheelCollider wheel_RL;
    public WheelCollider wheel_RR;

    public float speed   = 25;
    public float brake   = 30;
    public float turning = 15;
    public float antiroll = 5000;

    public Text output_text;

    private float velocity;

	// Use this for initialization
	void Start () 
    {
        Vector3 moveForward = new Vector3(0f, 0f, 1.0f);
        rigidbody.centerOfMass += moveForward;

        startline_hit = false;
        startline_time = 0.0f;

        tc = (TimerClass)ScriptableObject.CreateInstance("TimerClass");
        lapCount = 0;
        fastestTime = 0.0f;

        averageLapTime = 0.0f;
        minLapTime = 9999999.0f;
        maxLapTime = 0.0f;

        tc.setAvgWindow(3);

        startline_hit = false;
        startline_time = 61.0f;
    }
	
	// Physics Update will be called by the engine as needed based on frame rates 
	void FixedUpdate () 
    {
	    // make the car move forward
        wheel_RL.motorTorque = speed * Input.GetAxis("Vertical") /* * Time.deltaTime */;
        wheel_RR.motorTorque = speed * Input.GetAxis("Vertical") /* * Time.deltaTime */;

        wheel_RL.brakeTorque = 0.0f;
        wheel_RR.brakeTorque = 0.0f;

        // turn the car
        wheel_RL.steerAngle = -Input.GetAxis("Horizontal") * turning /* * Time.deltaTime */;
        wheel_RR.steerAngle = -Input.GetAxis("Horizontal") * turning /* * Time.deltaTime */;

        // Anti-roll
        AntiRoll(ref wheel_RL, ref wheel_RR, antiroll);
        AntiRoll(ref wheel_FL, ref wheel_FR, antiroll);

        // Joystick breaks
        float break_applied = Mathf.Abs(Input.GetAxisRaw("3rd axis"));
        if (break_applied > .1f)
        {
            wheel_RL.brakeTorque = brake * break_applied /* * Time.deltaTime*/;
            wheel_RR.brakeTorque = brake * break_applied /* * Time.deltaTime*/;
        }

        // keyboard brakes
        if (Input.GetKey(KeyCode.Space))
        {
            wheel_RL.brakeTorque = brake * 1f /* * Time.deltaTime*/;
            wheel_RR.brakeTorque = brake * 1f /* * Time.deltaTime*/;
        }

        //velocity = wheel_RR.rigidbody.velocity.magnitude;
        velocity = rigidbody.velocity.magnitude;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F)) transform.Rotate(0f, 0f, 180f);

        //hitStartLineCheck();
        tc.UpdateTimer();
        current_time = tc.GetTime();

        float milesperhour = velocity * 0.000621371f * 60.0f * 60.0f;
        float minutes = Mathf.Floor(current_time / 60.0f);
        float seconds = current_time - minutes * 60.0f;

        float fast_m = Mathf.Floor(minLapTime / 60.0f);
        float fast_s = minLapTime - fast_m * 60.0f;
        
        if ( minLapTime != 9999999.0f)
            output_text.text = milesperhour.ToString("0.00") + "m/h" + 
                System.Environment.NewLine + "Lap  Time:" + minutes + ":" + seconds.ToString("00.00") + 
                System.Environment.NewLine + "Best Time:" + fast_m + ":" + fast_s.ToString("00.00") +
                System.Environment.NewLine + "Lap Count:" + lapCount;
        else
            output_text.text = milesperhour.ToString("0.00") + "m/h" + 
                System.Environment.NewLine + "Lap Time:" + minutes + ":" + seconds.ToString("00.00") +
                System.Environment.NewLine + "Lap Count:" + lapCount;
    }

    void AntiRoll (ref WheelCollider WheelL, ref WheelCollider WheelR, float AntiRoll)
    {
        // Source code taken from the website listened below
        //
        // http://forum.unity3d.com/threads/how-to-make-a-physically-real-stable-car-with-wheelcolliders.50643/
        //
        // http://www.edy.es/dev/vehicle-physics/live-demo
        //

        WheelHit hit;
        float travelL = 1.0f;
        float travelR = 1.0f;
     
        bool groundedL = WheelL.GetGroundHit(out hit);
        if (groundedL)
        {
            if (hit.collider.transform.name == "StartLine")
                Debug.Log("Hit the StartLine");

            travelL = (-WheelL.transform.InverseTransformPoint(hit.point).y - WheelL.radius) / WheelL.suspensionDistance;
        }
     
        bool groundedR = WheelR.GetGroundHit(out hit);
        if (groundedR)
            travelR = (-WheelR.transform.InverseTransformPoint(hit.point).y - WheelR.radius) / WheelR.suspensionDistance;
     
        var antiRollForce = (travelL - travelR) * AntiRoll;

        if (groundedL)
        {
            rigidbody.AddForceAtPosition(WheelL.transform.up * -antiRollForce, WheelL.transform.position);
        }
        if (groundedR)
        {
            rigidbody.AddForceAtPosition(WheelR.transform.up * antiRollForce, WheelR.transform.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (lapCount != 0)
        {
            tc.UpdateTimer();
            tc.calcAvg(tc.GetTime(), ref averageLapTime, ref minLapTime, ref maxLapTime);
            tc.ResetTimer();
        }
        else tc.StartTimer();
        ++lapCount;
    }
}
