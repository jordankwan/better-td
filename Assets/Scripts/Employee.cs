using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [Serializeable]
public class Employee : MonoBehaviour {
  // Start is called before the first frame update
  public bool spawn_range = true;
  [SerializeField] GameObject RANGE;
  // [SerializeField] public static int cost;
  [SerializeField] public int cost;
  public bool can_place = false;
  [SerializeField] public GameObject BULLET;
  public List<Transform> collide_list = new List<Transform>();
  [SerializeField] public float reload;
  GameObject ENEMY;
  public bool placed = false;

  // [SerializeField] public static int cost;
  public GameObject range_clone;
  void Start() {
    transform.GetComponent<CircleCollider2D>().radius *= 0.75f;

    InvokeRepeating("Shoot", 0f, reload);
  }


  void Fire(GameObject green_clone) {
    // Debug.Log($"b name: {BULLET.name}");
    var bullet_clone = Instantiate(green_clone.GetComponent<Employee>().BULLET, green_clone.transform.position, Quaternion.identity);
    //bullet_clone. bullet_clone.transform.position = new Vector3(bullet_clone.transform.position.x, bullet_clone.transform.position.y, 0f);
    bullet_clone.SetActive(true);
   
    // green_clone 
  }
  
  void Shoot() {
    // foreach (GameObject green_clone in green_clone_arr) {
      if (placed) {
        ENEMY = GameObject.FindWithTag("Enemy");
        // Debug.Log(ENEMY);
        if (gameObject != null && ENEMY != null && range_clone.GetComponent<Range>().can_attack) {
          // Debug.Log("fireing");
          // Debug.Log(ENEMY.transform.position);
          // Debug.Log(green_clone.transform.position);
          Fire(gameObject);
        }
      }
      //ENEMY = GameObject.Find("MetaKnight(Clone)");
    // }
  }


  public void SpawnRange() {
    // range_clone.
    // Debug.Log($"range : {spawn_range}");
    range_clone.GetComponent<SpriteRenderer>().enabled = spawn_range; 
    // if (spawn_range) {
    //   // range_clone = Instantiate(RANGE, gameObject.transform.position, Quaternion.identity);
    //   // range_clone.transform.localScale = new Vector2(10f, 10f);
    //   // range_clone.SetActive(true);
    // } else {
    //   // range_clone.SetActive(false);
    //   // Destroy(range_clone); 
    // }

    // green_clone = Instantiate(GREEN, new Vector3(0, 0, 0), Quaternion.identity);
    // Debug.Log("HERE");
  }

  

  void OnTriggerEnter2D(Collider2D col) {

    // Add the GameObject collided with to the list.
    //currentCollisions.Add(col.gameObject);

    collide_list.Add(col.gameObject.transform);

    // Print the entire list to the console.
    
  }

  void OnTriggerExit2D(Collider2D col) {

    // Add the GameObject collided with to the list.
    //currentCollisions.Add(col.gameObject);

    collide_list.Remove(col.gameObject.transform);

    //// Print the entire list to the console.
    //foreach (GameObject go in collide_list) {
    //  if (go.tag == "Tower" || go.tag == "UI" || go.tag == "Path") {
    //    can_place = true;
    //    return;
    //    print(gObject.name);
    //  }
    //}
  }

  public bool CanPlace() {
    // Component colliders = gameObject.GetComponentsInChildren(Collider);
    foreach (Transform tra in collide_list) {
      if (tra != null) {
        GameObject go = tra.gameObject;
        if (go.tag == "Tower" || go.tag == "UI" || go.tag == "Path") {
          //can_place = true;
          return false;
          //print(gObject.name);
        }
      }
    }

    return true;
  }

    // Update is called once per frame
  void Update() {
    can_place = CanPlace();

    if (can_place) {
      range_clone.GetComponent<SpriteRenderer>().color = new Color32(58, 58, 58, 165);
    } else {
      range_clone.GetComponent<SpriteRenderer>().color = new Color32(159, 58, 58, 165);
    }
    // Debug.Log(can_place);
    if (Input.GetMouseButtonDown(0)) {
      Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

      RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
      if (hit.collider != null && can_place) {
        if (hit.collider.gameObject == gameObject) {

          spawn_range = !spawn_range;
          
          // Debug.Log("you clicked me yay");
          SpawnRange();
        } else {
          spawn_range = false;
          SpawnRange();
        }
        // spawn_range = true;
      } else {
        for (int i = 0; i < EmployeeHire.green_clone_ind; ++i) {
          // GameObject green_c = green
        // foreach (GameObject green_c in green_clone_arr) {
          if (EmployeeHire.green_clone_arr[i] != null) {
            // Debug.Log($"greenc {green_c}");
            EmployeeHire.green_clone_arr[i].GetComponent<Employee>().spawn_range = false;
            EmployeeHire.green_clone_arr[i].GetComponent<Employee>().SpawnRange();
          }
        }
      // if (hit.collider != null && ) {
      //   // hit.collider.gameObject.SpawnRange(); 
      //   // Debug.Log(hit.collider.gameObject.name);
      //   //hit.collider.attachedRigidbody.AddForce(Vector2.up);
      // } else {
      // }
      }
    }
  }
}
