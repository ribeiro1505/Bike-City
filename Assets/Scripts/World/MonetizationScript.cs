using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class MonetizationScript : MonoBehaviour{

    string AndroidID = "3824201";
    string placementId = "banner";
    bool testMode = true;

    void Start(){
        Advertisement.Initialize(AndroidID, testMode);
        Advertisement.Banner.SetPosition (BannerPosition.BOTTOM_CENTER);
        StartCoroutine(ShowBannerWhenInitialized());
    }

    IEnumerator ShowBannerWhenInitialized () {
        while (!Advertisement.isInitialized) {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show (placementId);
    }

    public void showAd(){
        Advertisement.Show();
    }

}
