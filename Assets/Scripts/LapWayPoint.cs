using UnityEngine;
using System.Collections;

public class LapWayPoint : MonoBehaviour {

    public GameObject player;
    public GameObject AI1;
    public GameObject AI2;
    public GameObject AI3;
    public int WayPointIndex;


    private LapWayPointDataStore lapWayPoints;


    // Use this for initialization
	void Start () 
    {
        lapWayPoints = LapWayPointDataStore.Instance;
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent != null)
            Debug.Log("waypoint:" + WayPointIndex + " collided with " + other.gameObject.transform.parent.tag);
        else return;

        if (player != null && other.gameObject.transform.parent.gameObject == player.gameObject &&
            other.gameObject.name == "Body")
        {
            lapWayPoints.bumpWaypointCount(0, WayPointIndex);
        }
        else if (AI1 != null && other.gameObject.transform.parent.gameObject == AI1.gameObject &&
            other.gameObject.name == "Body")
        {
            lapWayPoints.bumpWaypointCount(1, WayPointIndex);
        }
        else if (AI2 != null && other.gameObject.transform.parent.gameObject == AI2.gameObject &&
            other.gameObject.name == "Body")
        {
            lapWayPoints.bumpWaypointCount(2, WayPointIndex);
        }
        else if (AI3 != null && other.gameObject.transform.parent.gameObject == AI3.gameObject &&
            other.gameObject.name == "Body")
        {
            lapWayPoints.bumpWaypointCount(3, WayPointIndex);
        }
        else
        {
            //Debug.Log(other.gameObject.name + " left the finish line. Parent:" + other.gameObject.transform.parent.name);
        }
    }
}
