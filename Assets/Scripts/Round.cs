using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Round : MonoBehaviour
{
    // Start is called before the first frame update
  public static int round = 0;
  bool last_round = false;
  [SerializeField] GameObject ENEMY_ROUND;
  [SerializeField] GameObject LIVES;
  [SerializeField] GameObject MONEY;

  void Start() {

  }
  
  public IEnumerator ShowRound() {
    // yield return new WaitForSeconds(0.1f);
    // Debug.Log("in here");
    //
    // for (int i = 0; i < 5; ++i) {
       

    if (round == EnemyRound.ROUND_ARR.Count- 1) {
      last_round = true;
      gameObject.GetComponent<Text>().text = "Last Round!";
      gameObject.GetComponent<Text>().color = Color.blue;
      gameObject.GetComponent<Text>().enabled = true;
      yield return new WaitForSeconds(2f);
      gameObject.GetComponent<Text>().enabled = false;
      last_round = false;
    } else {
      gameObject.GetComponent<Text>().enabled = true;
      yield return new WaitForSeconds(2f);
      gameObject.GetComponent<Text>().enabled = false;
    }

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
      // Debug.Log(round);
      if (!last_round) {
        if (LIVES.GetComponent<Lives>().lives <= 0) {
          PlayerPrefs.SetInt("Win", 0);
          SceneManager.LoadScene("GameOver");
          
          // gameObject.GetComponent<Text>().enabled = true;
          // GameObject.Find(".GetComponent<Text>().fontSize = 100;
          // gameObject.GetComponent<Text>().text = $"you are out of business";
          // gameObject.GetComponent<Text>().color = Color.blue;
          // StopCoroutine(ENEMY_ROUND.GetComponent<EnemyRound>().StartSpawn());
          // foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
          //   Destroy(enemy);
          // }
            
      } else if (ENEMY_ROUND.GetComponent<EnemyRound>().spawn_done && GameObject.FindWithTag("Enemy") == null) {
          PlayerPrefs.SetInt("Win", 1);
          SceneManager.LoadScene("GameOver");
          // SceneManager.LoadScene("GameOver");
          // gameObject.GetComponent<Text>().enabled = true;
          // gameObject.GetComponent<Text>().fontSize = 100;
          // gameObject.GetComponent<Text>().text = $"you are still in business good job";
          // gameObject.GetComponent<Text>().color = Color.blue;
        } else {
          gameObject.GetComponent<Text>().text = $"Round {round}";
          gameObject.GetComponent<Text>().color = Color.blue;
        }
      }
      // GetComponent<Text>.color = Color.red;  
    }
}
