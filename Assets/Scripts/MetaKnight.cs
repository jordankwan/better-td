using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaKnight : MonoBehaviour {
  public int health = 100;
  float speed = 0.01f;
    // Start is called before the first frame update
  [SerializeField] GameObject START_WAYPOINT;
  int waypoint_ind = 0;
  void Start() {
    transform.position = START_WAYPOINT.transform.position;
    // GameObject.Find("StartWaypoint").transform.position    
  }

  // Update is called once per frame
  void Update() {
    transform.position = Vector2.MoveTowards(transform.position, Waypoint.waypoint_arr[waypoint_ind].position, speed);
    // Debug.Log($"pos: {transform.position} go: {Waypoint.waypoint_arr[waypoint_ind].position}");
    if (transform.position == Waypoint.waypoint_arr[waypoint_ind].position) {
      waypoint_ind += 1;
    }

    if (waypoint_ind == Waypoint.waypoint_count) {
      Debug.Log("oh no");
      Lives.lives -= 1;
      Destroy(gameObject);
    }
    // Debug.Log($"health: {health}");

      // transform.position = Vector2.MoveTowards(transform.position, ENEMY.transform.position, speed);
    if (health <= 0) {
      Debug.Log("dead");
      Destroy(gameObject);
    }   
  }
}
