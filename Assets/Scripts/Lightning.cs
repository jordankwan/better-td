using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour {
  // Start is called before the first frame update
  [SerializeField] GameObject ENEMY;
  Vector3 move_vec;
  [SerializeField] float speed;
  // float speed = 0.01f;
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
      ENEMY.GetComponent<Enemy>().health -= damage;
      // Debug.Log($"enemy health {ENEMY.GetComponent<MetaKnight>().health}");
      // ENEMY.health -= 50;

      Destroy(gameObject);
    }
    
    // Destroy()
    // Debug.Log($"HERE {col}");  
      //Stuff that happens when the collider collides with something
   
  }
  // void OnTriggerEnter(Collider other) {
  //   Debug.Log(other);
  //  // if (other.transform.tag == "Goal")
  //            // Do stuff
  // }
  void Update() {
    ENEMY = GameObject.FindWithTag("Enemy");
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
