using UnityEngine;
using System.Collections;

public class RaceAgent : MonoBehaviour {
	public GameObject targetWaypoint; // Next Waypoint 
	public Vector3 targetPosition; // Where the next target's position actually is.
	public GameObject WaypointObj; // Countainer for all Waypoint objects
	public int distranceFromWaypoint = 10; // Distance for when AI switches to next waypoint.
	private int waypointIndex  = 0; // Index for current waypoint.
	NavMeshAgent agent; // agent that it is attached it.

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		WaypointObj = GameObject.FindGameObjectWithTag ("WaypointManagerTag");
		WaypointObj.GetComponent<WaypointManager> ();
		agent.angularSpeed = 10000;
		agent.speed = 45; // 50 is where the player's speed limit is, but players control is less than that of AI.
		agent.acceleration = 12; // Seems to be exactly right for a competitive AI. 
		agent.baseOffset = 1.5f; // 2 literally makes the AI fly. Amazing.
		agent.radius = 4.5f; // Radius of collision box for AI.
		targetWaypoint = WaypointObj.GetComponent<WaypointManager> ().Waypoints [waypointIndex]; //Set taret to first waypoint.
		targetPosition = targetWaypoint.transform.position; // Get position.
		agent.SetDestination (targetPosition); // Set AI's  target to destination.

	}
	
	// Update is called once per frame
	void Update () {
		// Check distance, if near waypoint, switch target to next waypoint.
		if ((Vector3.Distance (transform.position, targetPosition) < distranceFromWaypoint) & (waypointIndex != WaypointObj.GetComponent<WaypointManager> ().Waypoints.Length - 1)) {
			waypointIndex += 1;
			targetWaypoint = WaypointObj.GetComponent<WaypointManager> ().Waypoints [waypointIndex];
			targetPosition = targetWaypoint.transform.position;
			agent.SetDestination (targetPosition);
		} else { //  If at the end, swtich index back to 0, and start again.
			if (waypointIndex == WaypointObj.GetComponent<WaypointManager> ().Waypoints.Length - 1) {
				targetWaypoint = WaypointObj.GetComponent<WaypointManager> ().Waypoints [waypointIndex];
				targetPosition = targetWaypoint.transform.position;
				agent.SetDestination (targetPosition);
				waypointIndex = 0;
			}
		}
	}
}
