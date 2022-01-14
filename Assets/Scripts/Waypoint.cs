using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    // Start is called before the first frame update
  public static Transform[] waypoint_arr = new Transform[45345];
  public static int waypoint_count = 0;

  void Start() {
    foreach (Transform waypoint in transform) {
      waypoint_arr[waypoint_count++] = waypoint;
    }   
  }

  // Update is called once per frame
  void Update() {
      
  }
}
