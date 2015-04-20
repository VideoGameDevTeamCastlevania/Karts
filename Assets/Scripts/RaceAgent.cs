using UnityEngine;
using System.Collections;

public class RaceAgent : MonoBehaviour {
	public GameObject targetWaypoint;
	public Vector3 targetPosition;
	public GameObject WaypointObj;
	public int distranceFromWaypoint;
	private int waypointIndex  = 0;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.angularSpeed = 360;
		WaypointObj.GetComponent<WaypointManager> ();
		targetWaypoint = WaypointObj.GetComponent<WaypointManager> ().Waypoints [waypointIndex];
		targetPosition = targetWaypoint.transform.position;
		agent.SetDestination (targetPosition);

	}
	
	// Update is called once per frame
	void Update () {
		if ((Vector3.Distance(transform.position, targetPosition) < distranceFromWaypoint)) { //& (targetWaypoint.GetComponent<Waypoint>().end == false)) {
			waypointIndex += 1;
			targetWaypoint = WaypointObj.GetComponent<WaypointManager> ().Waypoints [waypointIndex];
			targetPosition = targetWaypoint.transform.position;
			agent.SetDestination (targetPosition);
		}
	}
}
