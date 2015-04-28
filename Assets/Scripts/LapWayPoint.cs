using UnityEngine;
using System.Collections;

public class LapWayPoint : MonoBehaviour {

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
        { }
        //    Debug.Log("waypoint:" + WayPointIndex + " collided with " + other.gameObject.transform.parent.tag + " name:" + other.gameObject.transform.parent.name);
        else return;

        if (!lapWayPoints.isKartNull(0) && 
            lapWayPoints.isKartEqual(other.gameObject.transform.parent.gameObject, 0) && 
            other.gameObject.name == "GameObject")
        {
//            Debug.Log("Player hit waypoint:" + WayPointIndex);
            lapWayPoints.bumpWaypointCount(0, WayPointIndex);
        }
        else if (!lapWayPoints.isKartNull(1) &&
            lapWayPoints.isKartEqual(other.gameObject.transform.parent.gameObject, 1) &&
            other.gameObject.name == "GameObject")
        {
            lapWayPoints.bumpWaypointCount(1, WayPointIndex);
        }
        else if (!lapWayPoints.isKartNull(2) &&
            lapWayPoints.isKartEqual(other.gameObject.transform.parent.gameObject, 2) &&
            other.gameObject.name == "GameObject")
        {
            lapWayPoints.bumpWaypointCount(2, WayPointIndex);
        }
        else if (!lapWayPoints.isKartNull(3) &&
            lapWayPoints.isKartEqual(other.gameObject.transform.parent.gameObject, 3) &&
            other.gameObject.name == "GameObject")
        {
            lapWayPoints.bumpWaypointCount(3, WayPointIndex);
        }
        else
        {
            //Debug.Log(other.gameObject.name + " left the finish line. Parent:" + other.gameObject.transform.parent.name);
        }
    }
}
