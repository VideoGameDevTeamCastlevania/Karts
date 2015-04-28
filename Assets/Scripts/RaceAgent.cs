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
		WaypointObj = GameObject.FindGameObjectWithTag ("WaypointManagerTag");
		WaypointObj.GetComponent<WaypointManager> ();
		agent.angularSpeed = 10000;
		agent.speed = 45;
		agent.acceleration = 15;
		agent.baseOffset = 1.5f;
		agent.radius = 4.5f;
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
