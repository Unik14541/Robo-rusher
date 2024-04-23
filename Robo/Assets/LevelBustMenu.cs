using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelBustMenu : MonoBehaviour
{
    [SerializeField] TMP_Text levelBustText;

    void Start() {
        levelBustText.text = "level" + FindObjectOfType<GameBustEnemy>().GetMulEnemyHP().ToString();
    }
}
