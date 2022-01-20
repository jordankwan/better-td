using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeHire : MonoBehaviour {
    // Start is called before the first frame update
  [SerializeField] GameObject EMPLOYEE;
  // [SerializeField] GameObject BULLET;
  GameObject ENEMY;
  [SerializeField] GameObject RANGE;
  public GameObject green_clone;
  Camera CAM;
  [SerializeField] public static GameObject[] green_clone_arr;
  [SerializeField] public static int green_clone_ind;
  [SerializeField] Text TEXT;
  [SerializeField] GameObject MONEY;
  // Text text;
  // float time = 0f;
  // float reload = 1f;
  // elapsed += Time.deltaTime;
  
  void Start() {
    // text = TEXT.GetComponent<Text>();
    // Debug.Log("bruh");
    CAM = Camera.main;
    // TEXT.text = "e";
    //Debug.Log($"cost {gameObject.transform.GetChild(0).GetComponent<Text>().text}");
    // Debug.Log($"bef text: {TEXT.text }");
    // Debug.Log($"cost : {EMPLOYEE.GetComponent<Employee>().cost}");
    TEXT.text = $"Hire {EMPLOYEE.name}\n${EMPLOYEE.GetComponent<Employee>().cost}";
    // //Debug.Log($"sher {gameObject.transform.GetChild(0).GetComponent<Text>().text}");
    // Debug.Log($"aft text: {TEXT.text }");
    //TEXT.GetComponent<Text>().text += 
    green_clone = null;
    green_clone_ind = 0;
    green_clone_arr = new GameObject[123423];
    // InvokeRepeating("ShootAll", 0f, reload);
    
    // transform.Find("GreenBuy").GetComponent<Text
  }
  public void Click() {
    // Instantiate(GREEN,)
    if (MONEY.GetComponent<Money>().money >= EMPLOYEE.GetComponent<Employee>().cost) {


      green_clone = Instantiate(EMPLOYEE, new Vector3(0, 0, 0), Quaternion.identity);
      // Money.money -= Employee.cost; 


      // Vector3 mouse_pos = CAM.ScreenToWorldPoint(Input.mousePosition);
      // green_clone.transform.position = new Vector3(mouse_pos.x, mouse_pos.y, 0);
      green_clone.SetActive(true);
      green_clone.GetComponent<Employee>().range_clone = Instantiate(RANGE, gameObject.transform.position, Quaternion.identity);

      green_clone.GetComponent<Employee>().range_clone.SetActive(true);
      // green_clone.GetComponent<Employee>().range_clone = 
      green_clone.GetComponent<Employee>().SpawnRange();
    }


    // Debug.Log("HERE");
  }

  // Update is called once per frame

  void Update() {
    // time += Time.deltaTime;

    // if (time >= reload) {
    //   time = 0;
    //   
    // }
   // if (Input.GetKeyDown(KeyCode.Escape)) {
   //   
   //  // Debug.Log("Escape key was pressed");
   // } 
    if (Input.GetKeyDown(KeyCode.Escape)) {
      Destroy(green_clone.GetComponent<Employee>().range_clone);
      Destroy(green_clone);
      // Destroy(range_clone);
      green_clone = null;
     // Debug.Log("Escape key was pressed");
    } 

    if (green_clone != null) {
      Vector3 mouse_pos = CAM.ScreenToWorldPoint(Input.mousePosition);

      green_clone.transform.position = new Vector3(mouse_pos.x, mouse_pos.y, 0);
      green_clone.GetComponent<Employee>().range_clone.transform.position = new Vector3(mouse_pos.x, mouse_pos.y, 0);

      //green_clone.GetComponent<Employee>().spawn_range = true;
      //green_clone.GetComponent<Employee>().SpawnRange();

      if (Input.GetMouseButtonDown(0)) {
        // foreach (var e in green_clone.GetComponent<Employee>().collide_list) {
        //   // Debug.Log($"colList: {e.name}");
        // }
        //Debug.Log($"list {green_clone.GetComponent<Employee>().collide_list}");
        if (green_clone.GetComponent<Employee>().can_place) {
          MONEY.GetComponent<Money>().money -= EMPLOYEE.GetComponent<Employee>().cost;
          green_clone.GetComponent<Employee>().placed = true;
          // green_clone.GetComponent<Employee>().spawn_range = true;
          // green_clone.GetComponent<Employee>().SpawnRange();
          green_clone_arr[green_clone_ind++] = green_clone;
          green_clone = null;
        }
        
      }
    } 
  }
}
