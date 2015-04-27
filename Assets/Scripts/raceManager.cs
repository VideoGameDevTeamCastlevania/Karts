using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class raceManager : MonoBehaviour {

    public GameObject player;
    public GameObject AI1;
    public GameObject AI2;
    public GameObject AI3;

    public Text output_text;

    public AudioSource countdown_sound;

    private TimerClass tc;

    private int player_lap_count;
    private int ai1_lap_count;
    private int ai2_lap_count;
    private int ai3_lap_count;

    private bool raceOver;

    private int raceMode; // 0 - waiting for player to start, 1 - start count down, 2 - race in progress
    private int countDown;
    private int winner;

    private LapWayPointDataStore lapWayPoints;

	// Use this for initialization
	void Start () 
    {
        lapWayPoints = LapWayPointDataStore.Instance;

        tc = (TimerClass)ScriptableObject.CreateInstance("TimerClass");
        tc.setAvgWindow(3);

        if (player == null) Debug.Log("player is NULL");
        if (AI1 == null) Debug.Log("AI1 is NULL");
        if (AI2 == null) Debug.Log("AI2 is NULL");
        if (AI3 == null) Debug.Log("AI3 is NULL");

        init();
    }
	
	// Update is called once per frame
	void Update () 
    {
	    // if raceOver pause the game with option to start over or pick another race or ...
        if (raceOver)
        {
            // do something...
        }

        if (raceMode == 0)
        {
            output_text.text = "Press spacebar to start the count down!";

            if (Input.GetKey(KeyCode.Space))
            {
                raceMode = 1;
                tc.StartTimer();

                countdown_sound.volume = 4f;
                countdown_sound.Play();
            }
        }
        else if (raceMode == 1)
        {
            tc.UpdateTimer();
            float current_time = tc.GetTime();
            if (countDown != 0 && current_time < 1f)
            {
                output_text.text = countDown.ToString();
            }
            else
            {
                if (countDown == 0)
                {
                    if (current_time < 1f)
                    {
                        output_text.text = "GO";
                        Time.timeScale = 1;
                    }
                    else
                    {
                        output_text.text = "";
                        raceMode = 2;
                    }
                }
                else
                {
                    tc.ResetTimer();
                    --countDown;
                    countdown_sound.Play();
                }
            }
        }
        else if (raceMode == 2)
        {
            // do something for the race while it is being ran...not sure what at this point
            if (raceOver)
            {
                switch (winner)
                {
                    case 1: output_text.text = "You won the race!";
                        break;
                    case 2: output_text.text = "AI1 won the race!";
                        break;
                    case 3: output_text.text = "AI2 won the race!";
                        break;
                    case 4: output_text.text = "AI3 won the race!";
                        break;
                }
            }
        }
	}

    void init()
    {
        player_lap_count = 0;
        ai1_lap_count = 0;
        ai2_lap_count = 0;
        ai3_lap_count = 0;

        raceOver = false;
        raceMode = 0;
        countDown = 3;
        winner = 0;

        lapWayPoints.init();

        Time.timeScale = 0;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent != null)
        { }
        //            Debug.Log("raceManager collided with " + other.gameObject.transform.parent.tag);
        else return;

        if (player != null &&
            other.gameObject.transform.parent.gameObject == player.gameObject &&
            other.gameObject.name == "Body" &&
            lapWayPoints.allWaypointsHit(0) == true)
        {
            lapWayPoints.clearWaypoints(0);
            ++player_lap_count;
            if (player_lap_count == 3 && raceOver == false)
            {
                raceOver = true;
                Debug.Log("You won the race!");
                winner = 1;
            }
            else
                Debug.Log("Player crossed the finish line! Lap:" + player_lap_count);
        }
        else if (AI1 != null &&
            other.gameObject.transform.parent.gameObject == AI1.gameObject &&
            other.gameObject.name == "Body" &&
            lapWayPoints.allWaypointsHit(1) == true)
        {
            //Debug.Log(other.gameObject.name + " crossed the finish line. Parent:" + other.gameObject.transform.parent.name + " leftLine:" + ai1_left_line);

            lapWayPoints.clearWaypoints(1);
            ++ai1_lap_count;
            if (ai1_lap_count == 3 && raceOver == false)
            {
                raceOver = true;
                Debug.Log("AI1 won the race!");
                output_text.text = "AI1 won the race!";
                winner = 2;
            }
            else
                Debug.Log("AI1 crossed the finish line! Lap:" + ai1_lap_count);
        }
        else if (AI2 != null &&
            other.gameObject.transform.parent.gameObject == AI2.gameObject &&
            other.gameObject.name == "Body" &&
            lapWayPoints.allWaypointsHit(2) == true)
        {
            lapWayPoints.clearWaypoints(2);
            ++ai2_lap_count;
            if (ai2_lap_count == 3 && raceOver == false)
            {
                raceOver = true;
                Debug.Log("AI2 won the race!");
                output_text.text = "AI2 won the race!";
                winner = 3;
            }
            else
                Debug.Log("AI2 crossed the finish line! Lap:" + ai2_lap_count);
        }
        else if (AI3 != null &&
            other.gameObject.transform.parent.gameObject == AI3.gameObject &&
            other.gameObject.name == "Body" &&
            lapWayPoints.allWaypointsHit(3) == true)
        {
            lapWayPoints.clearWaypoints(3);
            ++ai3_lap_count;
            if (ai3_lap_count == 3 && raceOver == false)
            {
                raceOver = true;
                Debug.Log("AI3 won the race!");
                output_text.text = "AI3 won the race!";
                winner = 4;
            }
            else
                Debug.Log("AI3 crossed the finish line! Lap:" + ai3_lap_count);
        }
        else
        {
            //Debug.Log(other.gameObject.name + " crossed the finish line. Parent:" + other.gameObject.transform.parent.name);
        }
    }
}
