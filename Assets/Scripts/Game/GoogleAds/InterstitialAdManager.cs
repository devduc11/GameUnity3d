using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class InterstitialAdManager : MonoBehaviour
{
    [Header("Admob script :")]
    [SerializeField] private Admob admob;
    private InterstitialAd interstitialAd;
    private bool isAdLoading = false;

    private void Start()
    {
        RequestInterstitial();
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = admob.idInterstitial;
#elif UNITY_IPHONE
        string adUnitId = "your_ios_ad_unit_id";
#else
        string adUnitId = "unexpected_platform";
#endif

        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }

        // Khởi tạo InterstitialAd.
        interstitialAd = new InterstitialAd(adUnitId);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the interstitial with the request.
        interstitialAd.LoadAd(request);

        // Register for ad events
        interstitialAd.OnAdClosed += HandleInterstitialClosed;
        interstitialAd.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
    }

    public void ShowInterstitialAd()
    {
        if (interstitialAd != null && interstitialAd.IsLoaded() && !isAdLoading)
        {
            interstitialAd.Show();
        }
        else
        {
            // If ad is not loaded or is currently loading, request a new one
            RequestInterstitial();
        }
    }

    private void HandleInterstitialClosed(object sender, EventArgs args)
    {
        // Handle interstitial ad closed event (e.g., load a new ad).
        isAdLoading = false;
    }

    private void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        // Handle interstitial ad failed to load event.
        isAdLoading = false;
    }

}
