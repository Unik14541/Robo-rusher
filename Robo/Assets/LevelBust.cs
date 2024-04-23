using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBust : GameBustEnemy
{
    private void Awake() {
        LoadMulEnemyHP();
    }
   private void LoadMulEnemyHP(){
       mulEnemyHP = PlayerPrefs.GetInt("MultiplyEnemyHP");
   }
   private void SaveMulEnemyHP(){
       PlayerPrefs.SetInt("MultiplyEnemyHP", mulEnemyHP);
   }
   public void AddBust(){
    mulEnemyHP++;
    SaveMulEnemyHP();
   }
}
