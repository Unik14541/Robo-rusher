using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AddsManager : MonoBehaviour
{
    [SerializeField] bool testMode = true;
    [SerializeField] int addCoinAd;
    Bank bank;
    public static AddsManager Instance;

#if UNITY_ANDROID
    string gameId = "5584175";
#elif UNITY_IOS    
    string gameId = "5584174";
#endif
    public int GetAddCoinAd() {
        return addCoinAd;
    }
    public void ShowAd(Bank bank)
    {
        this.bank = bank;
        Advertisement.Show("RewardedVideo");
    }

    public void OnUnityAdsReady(string id) {
        Debug.Log("Ad Ready");
    }
    public void OnUnityAdsDidStart(string id) {
        Debug.Log("Ad Started");
    }
    public void OnUnityAdsDidFinish(string id, ShowResult res) {
        switch (res){
            case ShowResult.Finished:
                bank.AddCoin(addCoinAd);
                break;
            case ShowResult.Skipped:
                Debug.Log(res.ToString());
                break;
            case ShowResult.Failed:
                Debug.Log(res.ToString());
                break;    
        }
    }
    private void Awake() 
    {
        
    }
}
