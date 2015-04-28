using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class raceManager : MonoBehaviour {

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
    private string winner_string;
    private string lap_string;
    private bool show_lap_count;

    private LapWayPointDataStore lapWayPoints;

	// Use this for initialization
	void Start () 
    {
        lapWayPoints = LapWayPointDataStore.Instance;

        tc = (TimerClass)ScriptableObject.CreateInstance("TimerClass");
        tc.setAvgWindow(3);

        init();

        if (lapWayPoints.isKartNull(0)) Debug.Log("player is NULL");
        if (lapWayPoints.isKartNull(1)) Debug.Log("AI1 is NULL");
        if (lapWayPoints.isKartNull(2)) Debug.Log("AI2 is NULL");
        if (lapWayPoints.isKartNull(3)) Debug.Log("AI3 is NULL");
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

                // grab the player by the tag
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null) lapWayPoints.setKartGameObject(player, 0);

                Debug.Log("Player Index:" + lapWayPoints.getKartIndex(player));
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
                output_text.text = winner_string;
            }
            else if (lap_string != "")
            {
                if (show_lap_count == false)
                {
                    tc.ResetTimer();
                    show_lap_count = true;
                }
                else
                {
                    tc.UpdateTimer();
                    float current_time = tc.GetTime();
                    Debug.Log("timer:" + current_time);
                    if (current_time < 5f)
                    {
                        output_text.text = lap_string;
                    }
                    else
                    {
                        show_lap_count = false;
                        lap_string = "";
                        output_text.text = lap_string;
                    }
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

        lap_string = "";

        show_lap_count = false;

        lapWayPoints.init();

        Time.timeScale = 0;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent != null)
        { }
        //            Debug.Log("raceManager collided with " + other.gameObject.transform.parent.tag + " Name:" + other.gameObject.transform.parent.name);
        else return;

        // check to see if the kart has been added to the kart list yet
        //  the collider has to be "Body"
        if (other.gameObject.name == "GameObject")
        {
            lapWayPoints.addKart(other.gameObject.transform.parent.gameObject);
        }

        if ( !lapWayPoints.isKartNull(0) &&
            lapWayPoints.isKartEqual(other.gameObject.transform.parent.gameObject, 0) &&
            other.gameObject.name == "GameObject" &&
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
                //Debug.Log("Player crossed the finish line! Lap:" + player_lap_count);
                lap_string = "Lap " + player_lap_count;
        }
        else if (!lapWayPoints.isKartNull(1) &&
            lapWayPoints.isKartEqual(other.gameObject.transform.parent.gameObject, 1) &&
            other.gameObject.name == "GameObject" &&
            lapWayPoints.allWaypointsHit(1) == true)
        {
            //Debug.Log(other.gameObject.name + " crossed the finish line. Parent:" + other.gameObject.transform.parent.name + " leftLine:" + ai1_left_line);

            lapWayPoints.clearWaypoints(1);
            ++ai1_lap_count;
            if (ai1_lap_count == 3 && raceOver == false)
            {
                raceOver = true;
                Debug.Log(lapWayPoints.getKartName(1) + " won the race!");
                winner_string = lapWayPoints.getKartName(1) + " won the race!";
                winner = 2;
            }
            else
                //    Debug.Log(lapWayPoints.getKartName(1) + " crossed the finish line! Lap:" + ai1_lap_count);
                lap_string = lapWayPoints.getKartName(1) + " is on lap " + ai1_lap_count;
        }
        else if (!lapWayPoints.isKartNull(2) &&
            lapWayPoints.isKartEqual(other.gameObject.transform.parent.gameObject, 2) &&
            other.gameObject.name == "GameObject" &&
            lapWayPoints.allWaypointsHit(2) == true)
        {
            lapWayPoints.clearWaypoints(2);
            ++ai2_lap_count;
            if (ai2_lap_count == 3 && raceOver == false)
            {
                raceOver = true;
                Debug.Log(lapWayPoints.getKartName(2) + " won the race!");
                winner_string = lapWayPoints.getKartName(2) + " won the race!";
                winner = 3;
            }
            else
            //    Debug.Log(lapWayPoints.getKartName(2) + " crossed the finish line! Lap:" + ai2_lap_count);
                lap_string = lapWayPoints.getKartName(2) + " is on lap " + ai2_lap_count;
        }
        else if (!lapWayPoints.isKartNull(3) &&
            lapWayPoints.isKartEqual(other.gameObject.transform.parent.gameObject, 3) &&
            other.gameObject.name == "GameObject" &&
            lapWayPoints.allWaypointsHit(3) == true)
        {
            lapWayPoints.clearWaypoints(3);
            ++ai3_lap_count;
            if (ai3_lap_count == 3 && raceOver == false)
            {
                raceOver = true;
                Debug.Log(lapWayPoints.getKartName(3) + " won the race!");
                winner_string = lapWayPoints.getKartName(3) + " won the race!";
                winner = 4;
            }
            else
            //    Debug.Log(lapWayPoints.getKartName(3) + " crossed the finish line! Lap:" + ai3_lap_count);
                lap_string = lapWayPoints.getKartName(3) + " is on lap " + ai3_lap_count;
        }
        else
        {
            //Debug.Log(other.gameObject.name + " crossed the finish line. Parent:" + other.gameObject.transform.parent.name);
        }
    }
}
