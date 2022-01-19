using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    // Start is called before the first frame update
  public static int round = 0;
  void Start() {

  }
  
  public IEnumerator ShowRound() {
    // yield return new WaitForSeconds(0.1f);
    // Debug.Log("in here");
    // for (int i = 0; i < 5; ++i) {
    gameObject.GetComponent<Text>().enabled = true;
    yield return new WaitForSeconds(2f);
    gameObject.GetComponent<Text>().enabled = false;
    if (round == 0) {
      // yield return new WaitForSeconds(1f);
      // int i = 0;
      for (int i = 0; i < 3; ++i) {
        Debug.Log("bruh");
        foreach (Transform path_arrow in GameObject.Find("PathArrowParent").transform) {

          path_arrow.gameObject.SetActive(true);

          // waypoint_arr[waypoint_count++] = waypoint;
        }
        yield return new WaitForSeconds(1f);
        foreach (Transform path_arrow in GameObject.Find("PathArrowParent").transform) {

          path_arrow.gameObject.SetActive(false);

          // waypoint_arr[waypoint_count++] = waypoint;
        }
        yield return new WaitForSeconds(0.5f);
      }


      yield return new WaitForSeconds(1f);
    }
    // Debug.Log("audi");
    round += 1;
  }

    // Update is called once per frame
    void Update() {
      Debug.Log(round);
      gameObject.GetComponent<Text>().text = $"Round {round}";
      gameObject.GetComponent<Text>().color = Color.blue;
      // GetComponent<Text>.color = Color.red;  
    }
}
