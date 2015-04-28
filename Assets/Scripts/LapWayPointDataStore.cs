using UnityEngine;
using System.Collections;

public class LapWayPointDataStore {

    private int[][] waypoint_count;

    private GameObject[] karts;
    private int nextAIIndex;

    private static LapWayPointDataStore instance;

    public void setKartGameObject(GameObject go, int index)
    {
        karts[index] = go;
    }

    public int getKartIndex(GameObject go)
    {
        int ret = -1;
        for (int ii = 0; ii < 4; ++ii)
        {
            if (karts[ii] == go) return ii;
        }
        return ret;
    }

    public bool isKartNull(int index)
    {
        if (karts[index] == null) return true;
        else return false;
    }

    public bool isKartEqual(GameObject go, int index)
    {
        if (go == karts[index]) return true;
        else return false;
    }

    public void addKart(GameObject go)
    {
        // add this kart if it is not in the list
        // but only allow 4 karts total
        if (nextAIIndex < 4)
        {
            bool kartFound = false;
            for (int ii = 0; ii < 4; ++ii) if (karts[ii] == go) kartFound = true;

            if (!kartFound)
            {
                karts[nextAIIndex] = go;
                ++nextAIIndex;
            }
        }
    }

    public string getKartName(int index)
    {
        if (karts[index] != null)
            return karts[index].name;
        else return "Unknown Racer!";
    }

    public void bumpWaypointCount(int player, int index)
    {
        //Debug.Log("bumpWPC[" + player + "][" + index + "]");
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
        nextAIIndex = 1; // player is 0, the rest are AI

        karts = new GameObject[4];
        waypoint_count = new int[4][];
        for (int ii = 0; ii < 4; ++ii)
        {
            karts[ii] = null;

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
