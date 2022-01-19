using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> obj_list = new List<GameObject>();
    void Awake() {
      foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[]) {
        GetObjList(go);
      }
    }
    private void GetObjList(GameObject obj){
      if (obj == null) {
        return;
      }

      if (obj.activeSelf && obj.tag != "MainCamera" && obj.tag != "StartButton") {
        obj_list.Add(obj);
        obj.SetActive(false);
      }

      foreach (Transform child in obj.transform){
        if (child == null) {
            continue;
        }
          //child.gameobject contains the current child you can do whatever you want like add it to an array
        GameObject go = child.gameObject;
        if (go.activeSelf && go.tag != "MainCamera" && go.tag != "StartButton") {
          obj_list.Add(go);
          go.SetActive(false);
        }
        GetObjList(go);
      }
    }

    public void Click() {
      Debug.Log("clicked");
      foreach (GameObject go in obj_list) {
        go.SetActive(true);
      }

      gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
