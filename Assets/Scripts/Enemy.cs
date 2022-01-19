using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
  [SerializeField] public int health;
  [SerializeField] public float speed = 0.01f;
  [SerializeField] public int value;
    // Start is called before the first frame update
  [SerializeField] GameObject START_WAYPOINT;
  public bool slow = false;
  int waypoint_ind = 0;
  void Start() {
    // health = 100;
    // health = 10;
    // Debug.Log($"my health is {health}");
    transform.position = START_WAYPOINT.transform.position;
    gameObject.GetComponent<Collider2D>().enabled = false;
    gameObject.GetComponent<Collider2D>().enabled = true;
    // GameObject.Find("StartWaypoint").transform.position    
  }

  // Update is called once per frame
  void Update() {
    transform.position = Vector2.MoveTowards(transform.position, Waypoint.waypoint_arr[waypoint_ind].position, speed * Time.deltaTime);
    // Debug.Log($"pos: {transform.position} go: {Waypoint.waypoint_arr[waypoint_ind].position}");
    if (transform.position == Waypoint.waypoint_arr[waypoint_ind].position) {
      waypoint_ind += 1;
    }

    if (waypoint_ind == Waypoint.waypoint_count) {
      // Debug.Log($"oh no {health}");
      Lives.lives -= health;
      
      Destroy(gameObject);
    }
    // Debug.Log($"health: {health}");

      // transform.position = Vector2.MoveTowards(transform.position, ENEMY.transform.position, speed);
    if (health <= 0) {
      // Debug.Log($"dead {gameObject.name}");
      Money.money += value;
      Destroy(gameObject);
    }   
  }
}
