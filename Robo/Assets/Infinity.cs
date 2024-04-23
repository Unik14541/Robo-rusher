using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Infinity : GameBustEnemy
{
    private void AddBustLevel() {
        mulEnemyHP++;
        LevelBustEvent.Invoke();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<BustActivator>() != null) {
            BustActivator curBustActivator = other.GetComponent<BustActivator>();
            if(curBustActivator.IsUse() == false) {
                 AddBustLevel();
                 other.GetComponent<BustActivator>().UseBust();
            }
        }
    }
}
