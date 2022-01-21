using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // initialize variables
    public static Transform[] waypoint_arr;
    public static int waypoint_count;

    // get all the waypoints and put them in the array
    void Start()
    {
        waypoint_count = 0;
        waypoint_arr = new Transform[45345];
        foreach (Transform waypoint in transform)
        {
            waypoint_arr[waypoint_count++] = waypoint;
        }
    }
}
