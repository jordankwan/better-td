using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [Serializeable]
public class Kirby : MonoBehaviour {
  // Start is called before the first frame update
  public bool spawn_range = true;
  [SerializeField] GameObject RANGE;
  // [SerializeField] public static int cost;
  [SerializeField] public int cost = 50;
  public bool can_place = false;
  public List<GameObject> collide_list = new List<GameObject>();

  // [SerializeField] public static int cost;
  public GameObject range_clone;
  void Start() {
    transform.GetComponent<CircleCollider2D>().radius *= 0.75f;
  }



  public void SpawnRange() {
    // range_clone.
    Debug.Log($"range : {spawn_range}");
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

    collide_list.Add(col.gameObject);

    // Print the entire list to the console.
    
  }

  void OnTriggerExit2D(Collider2D col) {

    // Add the GameObject collided with to the list.
    //currentCollisions.Add(col.gameObject);

    collide_list.Remove(col.gameObject);

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
    foreach (GameObject go in collide_list) {
      if (go.tag == "Tower" || go.tag == "UI" || go.tag == "Path") {
        //can_place = true;
        return false;
        //print(gObject.name);
      }
    }

    return true;
  }

    // Update is called once per frame
    void Update() {
    can_place = CanPlace();
    // Debug.Log(can_place);
    if (Input.GetMouseButtonDown(0)) {
      Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

      RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
      if (hit.collider != null && can_place) {
        if (hit.collider.gameObject == gameObject) {

          spawn_range = !spawn_range;
          
          Debug.Log("you clicked me yay");
          SpawnRange();
        } else {
          spawn_range = false;
          SpawnRange();
        }
        // spawn_range = true;
      } else {
        for (int i = 0; i < GreenBuy.green_clone_ind; ++i) {
          // GameObject green_c = green
        // foreach (GameObject green_c in green_clone_arr) {
          if (GreenBuy.green_clone_arr[i] != null) {
            // Debug.Log($"greenc {green_c}");
            GreenBuy.green_clone_arr[i].GetComponent<Kirby>().spawn_range = false;
            GreenBuy.green_clone_arr[i].GetComponent<Kirby>().SpawnRange();
          }
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
