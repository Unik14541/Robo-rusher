using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScorMenu : Score
{
   [SerializeField] TMP_Text scoreText;

   void UpdateUI() {
    scoreText.text = bestScore.ToString();
   }
   private void Awake(){
    LoadScore();
    UpdateUI();
   }
}
