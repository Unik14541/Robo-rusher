using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] TMP_Text curCoinText;
    int curCoin;
    
    private void UpdateUI() {
        curCoinText.text = curCoin.ToString();
    }
    void LoadCoin() {
        curCoin = PlayerPrefs.GetInt("CurrentCoinCount");
    }
    void SaveCoin() {
        PlayerPrefs.SetInt("CurrentCoinCount",curCoin);
    }
    public void AddCoin(int add) {
        curCoin+=add;
        UpdateUI();
        SaveCoin();
    }
    public bool IsCanSpend(int spendCoin){

        if(curCoin - spendCoin >= 0)
        {
            curCoin -= spendCoin;
            UpdateUI();
            SaveCoin();
            return true;
        }
        return false;
    }
    private void Awake() {
        LoadCoin();
        UpdateUI();
    }
    public void MinusCoin(int Coin) {
       if (curCoin - Coin >= 0) {

       }
       else{
        curCoin = 0;
        UpdateUI();
        SaveCoin();
       }
    }  
    public void GetAdsMoney() {
        FindObjectOfType<AddsManager>().ShowAd(this);
    }      
}
