using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    // Start is called before the first frame update
    // public int e = 0;
    [SerializeField] public int lives;
    [SerializeField] public GameObject bruh;
    void Start() {

    }

    // Update is called once per frame
    void Update() {
      gameObject.GetComponent<Text>().text = $"Fresh Fruits: {lives}";
      gameObject.GetComponent<Text>().color = Color.red;
      // GetComponent<Text>.color = Color.red;  
    }
}
