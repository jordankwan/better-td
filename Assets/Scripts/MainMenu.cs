using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    // public List<GameObject> obj_list = new List<GameObject>();
    void Awake() {
      // foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[]) {
      //   GetObjList(go);
      // }
    }
    public void Click() {
      SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update() {
        
    }
}

