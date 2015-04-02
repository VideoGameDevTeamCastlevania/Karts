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
	
	// Update is called once per frame
	void FixedUpdate () 
    {
	    // make the car move forward
        wheel_RL.motorTorque = speed * Input.GetAxis("Vertical");
        wheel_RR.motorTorque = speed * Input.GetAxis("Vertical");

        wheel_RL.brakeTorque = 0.0f;
        wheel_RR.brakeTorque = 0.0f;

        // turn the car
        wheel_RL.steerAngle = -Input.GetAxis("Horizontal") * turning;
        wheel_RR.steerAngle = -Input.GetAxis("Horizontal") * turning;

        // Anti-roll
        AntiRoll(ref wheel_RL, ref wheel_RR, 5000.0f);
        AntiRoll(ref wheel_FL, ref wheel_FR, 5000.0f);

        // Joystick breaks
        float break_applied = Mathf.Abs(Input.GetAxisRaw("3rd axis"));
        if (break_applied > .1f)
        {
            wheel_RL.brakeTorque = brake * break_applied;
            wheel_RR.brakeTorque = brake * break_applied;
        }

        // keyboard brakes
        if (Input.GetKeyDown(KeyCode.Space))
        {
            wheel_RL.brakeTorque = brake;
            wheel_RR.brakeTorque = brake;
        }

        //velocity = wheel_RR.rigidbody.velocity.magnitude;
        velocity = rigidbody.velocity.magnitude;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F)) transform.Rotate(0f, 0f, 180f);

        hitStartLineCheck();

        float milesperhour = velocity * 0.000621371f * 60.0f * 60.0f;
        float minutes = Mathf.Floor(current_time / 60.0f);
        float seconds = current_time - minutes * 60.0f;
        output_text.text = milesperhour.ToString("0.00") + "m/h" + System.Environment.NewLine + "Lap Time:" + minutes + ":" + seconds + System.Environment.NewLine + "Lap Count:" + lapCount;
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

    void hitStartLineCheck()
    {
        WheelHit hit_FL;
        bool startline_FL = false;
        bool grounded_FL = wheel_FL.GetGroundHit(out hit_FL);
        if (grounded_FL && hit_FL.collider.transform.name == "StartLine")
            startline_FL = true;

        WheelHit hit_FR;
        bool startline_FR = false;
        bool grounded_FR = wheel_FR.GetGroundHit(out hit_FR);
        if (grounded_FR && hit_FR.collider.transform.name == "StartLine")
            startline_FR = true;

        WheelHit hit_RL;
        bool startline_RL = false;
        bool grounded_RL = wheel_RL.GetGroundHit(out hit_RL);
        if (grounded_RL && hit_RL.collider.transform.name == "StartLine")
            startline_RL = true;

        WheelHit hit_RR;
        bool startline_RR = false;
        bool grounded_RR = wheel_RR.GetGroundHit(out hit_RR);
        if (grounded_RR && hit_RR.collider.transform.name == "StartLine")
            startline_RR = true;

        if (!startline_hit && (startline_FR | startline_FL | startline_RR | startline_RL))
        {
            // this really needs to be debounced to prevent cheaters and accidental quick crossings
            startline_hit = true;

            Debug.Log("Starting New Lap");

            if (lapCount != 0)
            {
                tc.UpdateTimer();
                tc.calcAvg(tc.GetTime(), ref averageLapTime, ref minLapTime, ref maxLapTime);
                tc.ResetTimer();
            }
            else tc.StartTimer();
            ++lapCount;
        }
        else if (startline_hit && !startline_FR && !startline_FL && !startline_RR && !startline_RL)
        {
            startline_hit = false;
        }

        tc.UpdateTimer();
        current_time = tc.GetTime();
    }
}
