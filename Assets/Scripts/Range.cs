using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour {
    // Start is called before the first frame update
  // public static Transform[] waypoint_arr = new Transform[45345];
  // public static int waypoint_count = 0;
  public bool can_attack = false;

  void Start() {

    gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    // Vector2 sprite_radius = gameObject.GetComponent<Renderer>().bounds.extents;
    // gameObject.GetComponent<CircleCollider2D>().radius = Math.Max(sprite_radius.y, sprite_radius.x); 
    // circleCollider.radius = spriteHalfSize.x > spriteHalfSize.y ? spriteHalfSize.x : spriteHalfSize.y;
    //
    // lastSprite = spriteRenderer.sprite;
    // Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
    // gameObject.GetComponent<BoxCollider2D>().radius = S;
    // gameObject.GetComponent<BoxCollider2D>().center = new Vector2 ((S.x / 2), 0);
    // gameObject.GetComponent<CircleCollider2D>().radius = gameObject.transform.lossyScale.y / 2;
    // Debug.Log(transform.lossyScale.y);
    // foreach (Transform waypoint in transform) {
    //   waypoint_arr[waypoint_count++] = waypoint;
    // }   
  }

  // Update is called once per frame
  //
  void OnTriggerExit2D(Collider2D collision) {
    // if (collision.gameObject.name == "MetaKnight(Clone") {
    Debug.Log("someone left the range");
    if (collision.gameObject.name == "MetaKnight(Clone)") {
      can_attack = false;
    }
    // }
      // if (collision.gameObject.tag == "RechargePoint")
      // {
      //     batteryLevel = Mathf.Min(batteryLevel + rechargeRate * Time.deltaTime, 100.0f);
      // }
  }

  // void OnTriggerEnter2D(Collider2D collision) {
  //   // Debug.Log($"you hit {collision.gameObject.name}");
  //   Debug.Log("someone entered into the range");
  //   if (collision.gameObject.name == "MetaKnight(Clone)") {
  //     // foreach (ContactPoint2D contact in collision.contacts) {
  //     //     Debug.DrawRay(contact.point, contact.normal, Color.white);
  //     // }
  //     can_attack = true;
  //   }
  //     // if (collision.gameObject.tag == "RechargePoint")
  //     // {
  //     //     batteryLevel = Mathf.Min(batteryLevel + rechargeRate * Time.deltaTime, 100.0f);
  //     // }
  // }

  void OnTriggerStay2D(Collider2D collision) {
    // Debug.Log($"you hit {collision.gameObject.name}");
    // Debug.Log("someone entered into the range");
    // Debug.Log($"someone in range {collision.gameObject.name}");
    if (collision.gameObject.name == "MetaKnight(Clone)") {
      // foreach (ContactPoint2D contact in collision.contacts) {
      //     Debug.DrawRay(contact.point, contact.normal, Color.white);
      // }
      can_attack = true;
    }
      // if (collision.gameObject.tag == "RechargePoint")
      // {
      //     batteryLevel = Mathf.Min(batteryLevel + rechargeRate * Time.deltaTime, 100.0f);
      // }
  }

  void Update() {
    // GameObject enemy = GameObject.Find("MetaKnight(Clone)");
    
    // if (enemy != null && Vector2.Distance(enemy.transform.position, transform.position) < transform.lossyScale.y / 2) {
    //   can_attack = true;
    // }  else {
    //   can_attack = false;
    // }
  }
}
