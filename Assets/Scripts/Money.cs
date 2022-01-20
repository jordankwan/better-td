
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int money = 100;
    void Start() {


    }

    // Update is called once per frame
    void Update() {
      gameObject.GetComponent<Text>().text = $"Money: {money}";
      gameObject.GetComponent<Text>().color = Color.red;
      // GetComponent<Text>.color = Color.red;  
    }
}
