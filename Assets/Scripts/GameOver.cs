using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      if (PlayerPrefs.GetInt("Score") == 1) {

        gameObject.GetComponent<Text>().fontSize = 100;
        gameObject.GetComponent<Text>().text = $"you are still in business good job";
        gameObject.GetComponent<Text>().color = Color.blue;
        // gameObject.GetComponent<Text>().text = ""
      } else {
        gameObject.GetComponent<Text>().fontSize = 100;
        gameObject.GetComponent<Text>().text = $"the insects ate all your fresh fruit!\nyou must find another job";
        gameObject.GetComponent<Text>().color = Color.blue;
      }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
