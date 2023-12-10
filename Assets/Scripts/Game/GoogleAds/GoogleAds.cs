using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoogleAds : MonoBehaviour
{
    // public Text text;
    public static GoogleAds googleAds;
    [Header("Admob script :")]
    [SerializeField] private Admob admob;
    public InterstitialAdManager interstitialAdManager;

    public int IdReward;

    private void Awake()
    {
        googleAds = this;
        /* AdmobRewardAd */
        admob.OnRewardAdLoaded += OnRewardAdLoadedHandle;
        admob.OnRewardAdWatched += OnRewardAdWatchedHandle;
        /* AdmobBannerAd */
        CheckShowBannerAd();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    /* AdmobBannerAd */
    public void CheckShowBannerAd()
    {
        admob.OnInitComplete += () => admob.ShowBannerAd();

        //here you can use banner events:
        admob.OnBannerAdOpening += () =>
        {
            Debug.Log("Banner ad is clicked");
        };
    }

    /* AdmobRewardAd */
    public void CheckShowAdmobRewardEd(int Id)
    {
        IdReward = Id;
        OnWatchAdButtonClicked();
    }

    private void OnRewardAdLoadedHandle()
    {
        //ad is loaded
        admob.ShowRewardAd();
    }

    private void OnWatchAdButtonClicked()
    {
        print("Loading...");
        admob.RequestRewardAd();
    }

    private void OnRewardAdWatchedHandle(GoogleMobileAds.Api.Reward reward)
    {
        DOVirtual.DelayedCall(1f, () =>
        {
            // text.text = "trả thưởng";
            if (IdReward == 0)
            {
                Game.game.checkAdsBtnMage();
            }
            else if (IdReward == 1)
            {
                Victory.victory.checkRewards();
            }
            else if (IdReward == 2)
            {
                Lose.lose.checkRewards();
            }

            IdReward = -1;
        });
        print("trả thưởng");

    }

    /* AdmobInterstitialAd */
    public void ShowAdmobInterstitialAd()
    {
        interstitialAdManager.ShowInterstitialAd();
       
    }
}
