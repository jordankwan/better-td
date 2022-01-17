using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public enum EnemyType {
  // Delay,
  MetaKnight,
  LadyBug,
  None,
}


public class EnemyRound : MonoBehaviour {
  // Start is called before the first frame update
  [SerializeField] GameObject START_WAYPOINT;
  [SerializeField] GameObject META_KNIGHT;
  [SerializeField] GameObject LADY_BUG;
  public static List<List<string>> ROUND_ARR = new List<List<string>> {
    new List<string> {"l1 d3", "m5 d5.0", "d1", "m3 d3.0", "d5"},
    new List<string> {"m5 d1.0", "d0.5", "m3 d0.5", "d3"}
  };
  public static int curr_round = 0;
  // string wave_reg = @"^(?<type>.)(?<amount>\d+\.?\d+?)";
  string wave_reg = @"^((?<type_enemy>.)(?<amount_enemy>\d+) )?d(?<delay>\d+\.?\d*?)$";
  // Regex wave_reg = new Regex(@"^(?<type_enemy>.)(?<amount_enemy>\d+)(?<delay>d)(?<amount_delay>\d+)$");
  void Start() {

    StartCoroutine(StartSpawn());
  }

  IEnumerator StartSpawn() {

    foreach (List<string> round in ROUND_ARR) {
      yield return new WaitForSeconds(1f);
      foreach (string item in round) {
        //string item = ROUND_ARR[ind, jnd];
        Debug.Log(item);
    // foreach (string[] round in ROUND_ARR) {
    //   foreach (string item in round) {
        GroupCollection m = Regex.Match(item, wave_reg).Groups;
        EnemyType enemy_type = EnemyType.None;

        if (m["delay"].Value == "") {
          Debug.Log("some error with item parsing");
          Debug.Break();
        }

        Debug.Log("HERE");
       
        switch (m["type_enemy"].Value) {
          case "m":
            enemy_type = EnemyType.MetaKnight;
            break;
          case "l":
            enemy_type = EnemyType.LadyBug;
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
              case EnemyType.MetaKnight:
                enemy = META_KNIGHT;
                // Instantiate(MetaKnight,)
                // transform.position = /* ; */
                //var meta_knight_clone = Instantiate(META_KNIGHT, START_WAYPOINT.transform.position, Quaternion.identity);
                //meta_knight_clone.SetActive(true);
                break;
              case EnemyType.LadyBug:
                enemy = LADY_BUG;
                //meta_knight_clone = Instantiate(META_KNIGHT, START_WAYPOINT.transform.position, Quaternion.identity);
                //meta_knight_clone.SetActive(true);
                break;
              default:
                break;

              
            }

            Debug.Log($"enemy: {enemy}");

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

  }
  // Update is called once per frame
  void Update() {
         
        
      }
    } 
  }
}
