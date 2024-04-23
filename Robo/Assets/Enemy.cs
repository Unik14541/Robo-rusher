using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Enemy : MonoBehaviour
{
    [SerializeField] TMP_Text hpText;
    [SerializeField] int maxHP;
    [SerializeField] int curHP;
    private IPlayerDamage IplayerDMG;
    Animator anim;
    [SerializeField] int coinVictory;
    private void Start() {
       curHP = maxHP;
       FindObjectOfType<GameBustEnemy>().LevelBustEvent.AddListener(RecalculateHP);
       RecalculateHP();
    }
    void UpdateUI() {
        hpText.text = curHP.ToString();
    }
    void RecalculateHP(){
        curHP = maxHP;
        if (FindObjectOfType<GameBustEnemy>().GetMulEnemyHP() == 0) return; 
        curHP *= FindObjectOfType<GameBustEnemy>().GetMulEnemyHP();
        UpdateUI();
    }
    private void Awake() {
        RecalculateHP();
        IplayerDMG = FindObjectOfType<Playerdamage>().GetComponent<IPlayerDamage>();
        anim = GetComponentInChildren<Animator>();
    }
    void Die() {
        GetComponent<Collider>().enabled = false;
        anim.SetTrigger("die");     
        FindObjectOfType<Bank>().AddCoin(coinVictory); 
        FindObjectOfType<GameBustEnemy>().LevelBustEvent.RemoveListener(RecalculateHP);
        hpText.enableAutoSizing = false;
    }
    public void Attack() {
        anim.SetTrigger("attack");
        FindObjectOfType<Bank>().MinusCoin(coinVictory);
    }
    void TakeDamage(int damage) {
        anim.SetTrigger("hit");
        curHP -= damage;
        if (curHP <= 0) {
            curHP = 0;
            Die();
        }
        UpdateUI();
    }
    private void OnParticleCollision(GameObject other) {
        TakeDamage(IplayerDMG.GetPlayerDamage());
    }
}
