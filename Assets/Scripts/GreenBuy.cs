using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenBuy : MonoBehaviour {
    // Start is called before the first frame update
  [SerializeField] GameObject GREEN;
  [SerializeField] GameObject BULLET;
  [SerializeField] GameObject ENEMY;
  GameObject green_clone;
  Camera CAM;
  public GameObject[] green_clone_arr;
  public int green_clone_ind;
  // float time = 0f;
  float reload = 1f;
  // elapsed += Time.deltaTime;
  
  void Start() {
    CAM = Camera.main;
    green_clone = null;
    green_clone_ind = 0;
    green_clone_arr = new GameObject[123423];
    InvokeRepeating("ShootAll", 0f, reload);
    
    // transform.Find("GreenBuy").GetComponent<Text
  }
  public void Click() {
    // Instantiate(GREEN,)
    green_clone = Instantiate(GREEN, new Vector3(0, 0, 0), Quaternion.identity);
    green_clone.SetActive(true);


    // Debug.Log("HERE");
  }

  // Update is called once per frame
  void Fire(GameObject green_clone) {
    var bullet_clone = Instantiate(BULLET, green_clone.transform.position, Quaternion.identity);
    //bullet_clone.
    bullet_clone.transform.position = new Vector3(bullet_clone.transform.position.x, bullet_clone.transform.position.y, 0f);
    bullet_clone.SetActive(true);
    
    // green_clone 
  }
  
  void ShootAll() {
    foreach (GameObject green_clone in green_clone_arr) {
      ENEMY = GameObject.Find("MetaKnight(Clone)");
      if (green_clone != null && ENEMY != null && Vector2.Distance(ENEMY.transform.position, green_clone.transform.position) < 10) {
        Fire(green_clone);
      }
    }
  }

  void Update() {
    // time += Time.deltaTime;

    // if (time >= reload) {
    //   time = 0;
    //   
    // }

    if (green_clone != null) {
      Vector3 mouse_pos = CAM.ScreenToWorldPoint(Input.mousePosition);
      green_clone.transform.position = new Vector3(mouse_pos.x, mouse_pos.y, 0);

      if (Input.GetMouseButtonDown(0)) {
        green_clone_arr[green_clone_ind++] = green_clone;
        green_clone = null;
      }
    } 
  }
}
