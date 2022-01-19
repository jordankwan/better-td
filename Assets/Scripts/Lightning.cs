using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {
  // Start is called before the first frame update
  [SerializeField] GameObject ENEMY;
  Vector3 move_vec;
  [SerializeField] float speed;
  // float speed = 0.01f;
  [SerializeField] public bool freeze;
  [SerializeField] public float slow_mult;
  [SerializeField] public float slow_time;
  int damage = 1;

  void Start() {
    gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

  }
  void OnBecameInvisible() {
    Destroy(gameObject);
  }
  // Update is called once per frame
  void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.tag == "Enemy") {

      if (freeze && ENEMY.GetComponent<Enemy>().slow == false) {
        StartCoroutine(Slow());
        //ENEMY.GetComponent<Enemy>().speed *= ;
      }
      
      ENEMY.GetComponent<Enemy>().health -= damage;
      // Debug.Log($"enemy health {ENEMY.GetComponent<MetaKnight>().health}");
      // ENEMY.health -= 50;

      Destroy(gameObject);
    }
    
    // Destroy()
    // Debug.Log($"HERE {col}");  
      //Stuff that happens when the collider collides with something
   
  }

  IEnumerator Slow() {
    float orig_speed = ENEMY.GetComponent<Enemy>().speed;
    ENEMY.GetComponent<Enemy>().speed *= slow_mult;
    ENEMY.GetComponent<Enemy>().slow = true;
    yield return new WaitForSeconds(slow_time);
    ENEMY.GetComponent<Enemy>().speed = orig_speed;
    ENEMY.GetComponent<Enemy>().slow = false;
  }
  // void OnTriggerEnter(Collider other) {
  //   Debug.Log(other);
  //  // if (other.transform.tag == "Goal")
  //            // Do stuff
  // }
  void Update() {
    //ENEMY = GameObject.FindWithTag("Enemy");

    Vector3 current_pos = transform.position;
    float min_dist = 99999;

    foreach (GameObject en in GameObject.FindGameObjectsWithTag("Enemy")) {
      float dist = Vector3.Distance(en.transform.position, current_pos);
      if (ENEMY.GetComponent<Enemy>().slow == false || dist < min_dist) {
        ENEMY = en;
        min_dist = dist;
      }
    }
    //return tMin;

    //foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
    //  if (enemy)
    //}

    //if (ENEMY == null) {
    //  ENEMY = GameObject.FindGameObjectsWithTag("Enemy");
    //}

    if (ENEMY != null) {
      Vector3 pos_old = transform.position;      
      transform.position = Vector2.MoveTowards(transform.position, ENEMY.transform.position, speed * Time.deltaTime);
      move_vec = (transform.position - pos_old).normalized * speed;
      transform.right = ENEMY.transform.position - transform.position; 
      // transform.LookAt(ENEMY.transform, Vector3.down);
      // if (transform.position == ENEMY.transform.position) {
        // ENEMY.health -= 50;
      // }
    } else {
      transform.position += move_vec;
      // transform.velocity = move_vec;
      // gameObject.velocity = move_vecg 
    }
  }
}
