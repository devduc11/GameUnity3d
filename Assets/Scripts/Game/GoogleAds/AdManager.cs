using System;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    private InterstitialAd interstitialAd;

    private void Start()
    {
        RequestInterstitial();
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "your_ios_ad_unit_id";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Khởi tạo InterstitialAd.
        this.interstitialAd = new InterstitialAd(adUnitId);

        // Tạo một yêu cầu quảng cáo trống.
        AdRequest request = new AdRequest.Builder().Build();

        // Tải quảng cáo interstitial với yêu cầu.
        this.interstitialAd.LoadAd(request);

        // Đăng ký cho sự kiện quảng cáo
        this.interstitialAd.OnAdClosed += HandleInterstitialClosed;
    }

    public void ShowInterstitialAd()
    {
        if (this.interstitialAd.IsLoaded())
        {
            this.interstitialAd.Show();
        }
        else
        {
            Debug.Log("Quảng cáo interstitial chưa sẵn sàng.");
        }
    }

    private void HandleInterstitialClosed(object sender, EventArgs args)
    {
        // Xử lý sự kiện quảng cáo interstitial đóng (ví dụ: tải quảng cáo mới).
        RequestInterstitial();
    }
}
