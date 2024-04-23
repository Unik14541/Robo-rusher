using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Coin : MonoBehaviour
{
   [SerializeField] AudioClip collectSound;
   [SerializeField] TMP_Text addCoin;
   [SerializeField] int maxCoin;
   [SerializeField] int minCoin;
   int coinCost;
   private void Awake() {
      coinCost = Random.Range(minCoin, maxCoin);
      if(addCoin)
        addCoin.text = coinCost.ToString();
   }
   private void OnTriggerEnter(Collider other) {
    if (other.GetComponent<Playermove>())
    {
        FindObjectOfType<Bank>().AddCoin(coinCost);
        if(collectSound)
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        Destroy(gameObject);
    }
   }
}
