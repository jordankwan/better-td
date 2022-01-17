using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kirby : MonoBehaviour {
  // Start is called before the first frame update
  public bool spawn_range = true;
  [SerializeField] GameObject RANGE;
  public GameObject range_clone;
  public static int cost = 1;
  void Start() {

  }

  public void SpawnRange() {
    Debug.Log($"spanw range: {spawn_range}");
    if (spawn_range) {
      range_clone.SetActive(true);
      // range_clone = Instantiate(RANGE, gameObject.transform.position, Quaternion.identity);
      // range_clone.transform.localScale = new Vector2(10f, 10f);
      // range_clone.SetActive(true);
    } else {
      range_clone.SetActive(false);
      // Destroy(range_clone); 
    }

    // green_clone = Instantiate(GREEN, new Vector3(0, 0, 0), Quaternion.identity);
    // Debug.Log("HERE");
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetMouseButtonDown(0)) {
      Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

      RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
      if (hit.collider != null && hit.collider.gameObject == gameObject) {
        spawn_range = !spawn_range;
        SpawnRange();
        // hit.collider.gameObject.SpawnRange(); 
        // Debug.Log(hit.collider.gameObject.name);
        //hit.collider.attachedRigidbody.AddForce(Vector2.up);
      }
    }


  }
}
