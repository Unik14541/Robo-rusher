using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageShop : MonoBehaviour
{
    [SerializeField] int countAddDamage;
    [SerializeField] TMP_Text damageCostText;
    [SerializeField] int damageCost;
    [SerializeField] int AddDamage;
    Bank bank;
    Playerdamage playerdamage;
    void Start() {
        LoadDamageCost();
        bank = FindObjectOfType<Bank>();
        playerdamage = FindObjectOfType<Playerdamage>();
        UpdateUI();
    }
    void LoadDamageCost() {
        damageCost = PlayerPrefs.GetInt("DamageCost");
    }
    void SaveDamageCost() {
        PlayerPrefs.SetInt("DamageCost", damageCost);
    }
    private void UpdateUI() {
        damageCostText.text = damageCost.ToString();
    }
    public void BuyDamage() {
        if(bank.IsCanSpend(damageCost))
        {
             playerdamage.AddDamage(countAddDamage);
             damageCost += AddDamage;
             SaveDamageCost();
             UpdateUI();
        }
    }
}
