using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public enum EnemyType {
  // Delay,
  MetaKnight,
  None,
}


public class EnemyRound : MonoBehaviour {
  // Start is called before the first frame update
  [SerializeField] GameObject META_KNIGHT;
  public static string[,] ROUND_ARR = new string[,] {{"m5 d5.0", "d1", "m3 d3.0", "d5"}, {"m5 d1.0", "d0.5", "m3 d0.5", "d3"}};
  public static int curr_round = 0;
  // string wave_reg = @"^(?<type>.)(?<amount>\d+\.?\d+?)";
  string wave_reg = @"^((?<type_enemy>.)(?<amount_enemy>\d+) )?d(?<delay>\d+\.?\d*?)$";
  // Regex wave_reg = new Regex(@"^(?<type_enemy>.)(?<amount_enemy>\d+)(?<delay>d)(?<amount_delay>\d+)$");
  void Start() {

    StartCoroutine(StartSpawn());
  }

  IEnumerator StartSpawn() {

    for (int ind = 0; ind < ROUND_ARR.GetLength(0); ++ind) {
      yield return new WaitForSeconds(1f);
      for (int jnd = 0; jnd < ROUND_ARR.GetLength(1); ++jnd) {
        string item = ROUND_ARR[ind, jnd];
        Debug.Log(item);
    // foreach (string[] round in ROUND_ARR) {
    //   foreach (string item in round) {
        GroupCollection m = Regex.Match(item, wave_reg).Groups;
        EnemyType enemy_type = EnemyType.None;

        if (m["delay"].Value == "") {
          Debug.Log("some error with item parsing");
          Debug.Break();
        }
       
        switch (m["type_enemy"].Value) {
          case "m":
            enemy_type = EnemyType.MetaKnight;
            break;
          default:
            break;
          // case "d":
            // enemy_type =
        }
       
        if (enemy_type != EnemyType.None) {
          for(int i = 0; i < int.Parse(m["amount_enemy"].Value); ++i) {
            switch (enemy_type) {
              case EnemyType.MetaKnight:
                // Instantiate(MetaKnight,)
                var meta_knight_clone = Instantiate(META_KNIGHT, new Vector3(0, 0, 0), Quaternion.identity);
                meta_knight_clone.SetActive(true);
                break;
              default:
                break;
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
