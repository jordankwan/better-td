using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenBuy : MonoBehaviour {
    // Start is called before the first frame update
  [SerializeField] GameObject KIRBY;
  [SerializeField] GameObject BULLET;
  GameObject ENEMY;
  [SerializeField] GameObject RANGE;
  public GameObject green_clone;
  Camera CAM;
  [SerializeField] public static GameObject[] green_clone_arr;
  [SerializeField] public static int green_clone_ind;
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
    if (Money.money >= KIRBY.GetComponent<Kirby>().cost) {


      green_clone = Instantiate(KIRBY, new Vector3(0, 0, 0), Quaternion.identity);
      // Money.money -= Kirby.cost; 


      // Vector3 mouse_pos = CAM.ScreenToWorldPoint(Input.mousePosition);
      // green_clone.transform.position = new Vector3(mouse_pos.x, mouse_pos.y, 0);
      green_clone.SetActive(true);
      green_clone.GetComponent<Kirby>().range_clone = Instantiate(RANGE, gameObject.transform.position, Quaternion.identity);

      green_clone.GetComponent<Kirby>().range_clone.SetActive(true);
      // green_clone.GetComponent<Kirby>().range_clone = 
      green_clone.GetComponent<Kirby>().SpawnRange();
    }


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
      //ENEMY = GameObject.Find("MetaKnight(Clone)");
      ENEMY = GameObject.FindWithTag("Enemy");
      // Debug.Log(ENEMY);
      if (green_clone != null && ENEMY != null && green_clone.GetComponent<Kirby>().range_clone.GetComponent<Range>().can_attack) {
        // Debug.Log("fireing");
        // Debug.Log(ENEMY.transform.position);
        // Debug.Log(green_clone.transform.position);
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
      green_clone.GetComponent<Kirby>().range_clone.transform.position = new Vector3(mouse_pos.x, mouse_pos.y, 0);

      //green_clone.GetComponent<Kirby>().spawn_range = true;
      //green_clone.GetComponent<Kirby>().SpawnRange();

      if (Input.GetMouseButtonDown(0)) {
        foreach (var e in green_clone.GetComponent<Kirby>().collide_list) {
          Debug.Log($"colList: {e.name}");
        }
        //Debug.Log($"list {green_clone.GetComponent<Kirby>().collide_list}");
        if (green_clone.GetComponent<Kirby>().can_place) {
          Money.money -= KIRBY.GetComponent<Kirby>().cost;
          green_clone.GetComponent<Kirby>().spawn_range = true;
          green_clone.GetComponent<Kirby>().SpawnRange();
          green_clone_arr[green_clone_ind++] = green_clone;
          green_clone = null;
        }
        
      }
    } 
  }
}
