using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public enum EnemyType {
  // Delay,
  Fly,
  LadyBug,
  None,
  Connor,
}


public class EnemyRound : MonoBehaviour {
  // Start is called before the first frame update
  [SerializeField] GameObject START_WAYPOINT;
  [SerializeField] GameObject FLY;
  [SerializeField] GameObject LADY_BUG;
  [SerializeField] GameObject CONNOR;

  // Round RoundClass = new Round();
  // public int round = 0;
  // Round RoundClass = new Round();
  public static List<List<string>> ROUND_ARR = new List<List<string>> {
    new List<string> {"l1 d3", "f5 d5.0", "l2 d1", "d1", "f3 d3.0", "d5"},
    new List<string> {"f5 d1.0", "l4 d0.5", "d0.5", "f3 d0.5", "d3"},
    new List<string> {"f5 d0.5", "l3 d0.3", "d3", "f2 d0.5", "l1 d0.2"},
    new List<string> {"f10 d0.25", "d0.34"},
    new List<string> {"c1 d0"},
  };
  [SerializeField] GameObject ROUND;
  public static int curr_round = 0;
  public bool spawn_done = false;
  // string wave_reg = @"^(?<type>.)(?<amount>\d+\.?\d+?)";
  string wave_reg = @"^((?<type_enemy>.)(?<amount_enemy>\d+) )?d(?<delay>\d+\.?\d*?)$";
  // Regex wave_reg = new Regex(@"^(?<type_enemy>.)(?<amount_enemy>\d+)(?<delay>d)(?<amount_delay>\d+)$");
  void Start() {
    Debug.Log("text");
    Debug.Log(GameObject.Find("Round").GetComponent<Text>().text); 
    StartCoroutine("StartSpawn");
  }

  // void Update() {
  //   if (spawn_done && GameObject.FindWithTag("Enemy") == null) {
  //
  //     // foreach (GameObject go in START_GAME.GetComponent<StartGame>().col_list) {
  //     //
  //     // }
  //   }
  // }

  // IEnumerator DisplayRound() {
  //    
  //   yield return new WaitForSeconds(2f);
  // }

  public IEnumerator StartSpawn() {

    foreach (List<string> round in ROUND_ARR) {

      // GameObject.Find("Round").GetComponent<Text>().text = GameObject.Find
      yield return StartCoroutine(ROUND.GetComponent<Round>().ShowRound());
      // Round e = Camera.main.GetComponent<Round>(); 
      // StartCoroutine(Camera.main.GetComponent<Round>().DD());
      // GetComponent<Round>().DF();
      // (new Round()).DF();
      // new Round().DF();

      foreach (string item in round) {
        // StartCoroutine(Round.DisplayRound());
        // Round.StartCoroutine("DisplayRound");
        // StartCoroutine(Round.DisplayRound());
        Debug.Log(item);
        GroupCollection m = Regex.Match(item, wave_reg).Groups;
        EnemyType enemy_type = EnemyType.None;

        if (m["delay"].Value == "") {
          Debug.Log("some error with item parsing");
          Debug.Break();
        }

        // Debug.Log("HERE");
       
        switch (m["type_enemy"].Value) {
          case "f":
            enemy_type = EnemyType.Fly;
            break;
          case "l":
            enemy_type = EnemyType.LadyBug;
            break;
          case "c":
            enemy_type = EnemyType.Connor;
            break;
          default:
            break;
          // case "d":
            // enemy_type =
        }

        Debug.Log($"type: {enemy_type}");

       
        if (enemy_type != EnemyType.None) {
          for (int i = 0; i < int.Parse(m["amount_enemy"].Value); ++i) {
            GameObject enemy = null;
            switch (enemy_type) {
              //GameObject enemy;
              case EnemyType.Fly:
                enemy = FLY;
                // Instantiate(Fly,)
                // transform.position = /* ; */
                //var meta_knight_clone = Instantiate(FLY, START_WAYPOINT.transform.position, Quaternion.identity);
                //meta_knight_clone.SetActive(true);
                break;
              case EnemyType.LadyBug:
                enemy = LADY_BUG;
                //meta_knight_clone = Instantiate(FLY, START_WAYPOINT.transform.position, Quaternion.identity);
                //meta_knight_clone.SetActive(true);
                break;
              case EnemyType.Connor:
                enemy = CONNOR;
                break;
              default:
                break;

              
            }

            // Debug.Log($"enemy: {enemy}");

            if (enemy != null) {
              enemy = Instantiate(enemy, START_WAYPOINT.transform.position, Quaternion.identity);
              enemy.SetActive(true);
            }
            yield return new WaitForSeconds(float.Parse(m["delay"].Value));
          }
        } else {
          yield return new WaitForSeconds(float.Parse(m["delay"].Value));
        }
        // for ()

  // Update is called once per frame
         
        
      }
      // ++Round.round;
    }

    spawn_done = true;
  }
}
