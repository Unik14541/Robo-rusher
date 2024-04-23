using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Playerdamage : MonoBehaviour, IPlayerDamage
{
   [SerializeField] int dmg;
   [SerializeField] TMP_Text dmgText;
   void Awake () {
    LoadDamage();
    UpdateUI();
   }
   void LoadDamage() {
    dmg = PlayerPrefs.GetInt("Damage");
   } 
   void SaveDamage() {
    PlayerPrefs.SetInt("Damage", dmg);
   }
   void UpdateUI() {
    dmgText.text = dmg.ToString();
   }
   public int GetPlayerDamage() {
    return dmg;
   }
   public void AddDamage(int addDamage) {
       dmg+=addDamage;
       SaveDamage();
       UpdateUI();
   }
}
