using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using TMPro;

public class ScoreCount : Score
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] float scoreMultiplier;
    bool shouldCount = true;
    float score;
    void Update () {
        if(!shouldCount) return;
        Count();
    }
    void Count() {
       score += Time.deltaTime * scoreMultiplier;
       scoreText.text = Mathf.FloorToInt(score).ToString();
    }
    public void CantCount(){
        shouldCount = false;
        SetNewBestScore(Mathf.FloorToInt(score));
    }
}
