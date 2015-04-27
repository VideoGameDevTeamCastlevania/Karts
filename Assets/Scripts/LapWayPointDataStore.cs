using UnityEngine;
using System.Collections;

public class LapWayPointDataStore {

    private int[][] waypoint_count;

    private static LapWayPointDataStore instance;

    public void bumpWaypointCount(int player, int index)
    {
        Debug.Log("bumpWPC[" + player + "][" + index + "]");
        waypoint_count[player][index] += 1;
    }

    public void clearWaypoints(int player)
    {
        for ( int ii=0; ii<3; ++ii )
            waypoint_count[player][ii] = 0;
    }

    public int getWaypointCount(int player, int index)
    {
        return waypoint_count[player][index];
    }

    public bool allWaypointsHit(int player)
    {
        if (waypoint_count[player][0] > 0 &&
            waypoint_count[player][1] > 0 &&
            waypoint_count[player][2] > 0 ) return true;
        else return false;
    }

    public void init()
    {
        waypoint_count = new int[4][];
        for (int ii = 0; ii < 4; ++ii)
        {
            waypoint_count[ii] = new int[3];
            for (int jj = 0; jj < 3; ++jj)
                waypoint_count[ii][jj] = 0;
        }
    }

    public LapWayPointDataStore()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public static LapWayPointDataStore Instance
    {
        get
        {
            if (instance == null)
            {
                new LapWayPointDataStore();

                instance.init();
            }

            return instance;
        }
	}
}
