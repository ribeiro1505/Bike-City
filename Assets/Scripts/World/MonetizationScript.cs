using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class MonetizationScript : MonoBehaviour{

    private BannerView bannerView;
    private InterstitialAd interstitial;

    void Start(){
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();
        this.RequestInterstitialAd();
    }

    private void RequestBanner(){
        string bannerAdUnitId;
        
        #if UNITY_ANDROID
            bannerAdUnitId = "ca-app-pub-3940256099942544/6300978111";
        #elif UNITY_IPHONE
            bannerAdUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
            bannerAdUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(bannerAdUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest bannerRequest = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(bannerRequest);
    }

    private void RequestInterstitialAd(){
        string interstitialAdUnitId;

        #if UNITY_ANDROID
            interstitialAdUnitId = "ca-app-pub-3940256099942544/1033173712";
        #elif UNITY_IPHONE
            interstitialAdUnitId = "ca-app-pub-3940256099942544/4411468910";
        #else
            interstitialAdUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(interstitialAdUnitId);

        // Create an empty ad request.
        AdRequest interstitialRequest = new AdRequest.Builder().Build();
        
        // Load the interstitial with the request.
        this.interstitial.LoadAd(interstitialRequest);
    }

    public void showAd(){
        if (this.interstitial.IsLoaded()) {
            this.interstitial.Show();
        }
    }

}
