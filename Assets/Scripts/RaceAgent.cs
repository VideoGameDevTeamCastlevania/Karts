using UnityEngine;
using System.Collections;

public class RaceAgent : MonoBehaviour {
	public GameObject targetWaypoint;
	public Vector3 targetPosition;
	public GameObject WaypointObj;
	public int distranceFromWaypoint = 10;
	private int waypointIndex  = 0;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.angularSpeed = 10000;
		WaypointObj.GetComponent<WaypointManager> ();
		targetWaypoint = WaypointObj.GetComponent<WaypointManager> ().Waypoints [waypointIndex];
		targetPosition = targetWaypoint.transform.position;
		agent.SetDestination (targetPosition);

	}
	
	// Update is called once per frame
	void Update () {
		if ((Vector3.Distance (transform.position, targetPosition) < distranceFromWaypoint) & (waypointIndex != WaypointObj.GetComponent<WaypointManager> ().Waypoints.Length - 1)) {
			waypointIndex += 1;
			targetWaypoint = WaypointObj.GetComponent<WaypointManager> ().Waypoints [waypointIndex];
			targetPosition = targetWaypoint.transform.position;
			agent.SetDestination (targetPosition);
		} else {
			if (waypointIndex == WaypointObj.GetComponent<WaypointManager> ().Waypoints.Length - 1) {
				targetWaypoint = WaypointObj.GetComponent<WaypointManager> ().Waypoints [waypointIndex];
				targetPosition = targetWaypoint.transform.position;
				agent.SetDestination (targetPosition);
				waypointIndex = 0;
			}
		}
	}
}
