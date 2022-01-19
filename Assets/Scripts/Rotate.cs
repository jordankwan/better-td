using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
      // transform.rotation =  
      // transform.up = new Vector3(0, 50, 0);
      transform.Rotate(new Vector3(50, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
