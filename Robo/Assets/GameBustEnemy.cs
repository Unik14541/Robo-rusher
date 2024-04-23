using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameBustEnemy : MonoBehaviour
{
    [SerializeField] protected int mulEnemyHP = 1;
    public UnityEvent LevelBustEvent = new UnityEvent();

    public int GetMulEnemyHP()
    {
        return mulEnemyHP;
    }
    
}
