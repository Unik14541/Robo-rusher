using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WhatsAddButton : MonoBehaviour
{
    [SerializeField] TMP_Text coinText;
    [SerializeField] Button buttonAdCoin;
    private void Start() {
        coinText.text = FindObjectOfType<AddsManager>().GetAddCoinAd().ToString();
        Bank bank = FindObjectOfType<Bank>();
        buttonAdCoin.onClick.AddListener(bank.GetAdsMoney);
    }
}
