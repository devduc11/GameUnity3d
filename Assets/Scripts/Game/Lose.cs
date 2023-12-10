using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{
    public static Lose lose;
    public Transform Arrow, ButtonContinue, CoinEffect;
    public Text TextCoin, TextCoinReward;
    public double reward, coin, rewardsReceived;
    public bool startRotate = false;
    public bool isPauseOnClickClaim;

    private void Awake()
    {
        lose = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    public void check(double coin)
    {
        ButtonContinue.localScale = Vector3.zero;
        startRotate = true;
        isPauseOnClickClaim = true;
        this.coin = coin;
        string result = ShortenMoney.ConvertCoin(coin);
        TextCoin.text = result;
        Invoke("CheckShowButtonContinue", 2);
    }

    public void CheckShowButtonContinue()
    {
        LibraryMy.EffectScaleObjectOn(ButtonContinue, 0.3f, 1f, () => CancelCheckShowButtonContinue());
    }

    public void CancelCheckShowButtonContinue()
    {
        CancelInvoke("CheckShowButtonContinue");
    }


    public void OnButtonContinue()
    {
        // print(coin);
        // ButtonContinue.localScale = Vector3.zero;
        // gameObject.SetActive(false);
        SceneManager.LoadScene("Game");
        // PlayerPrefs.SetString("Coin", $"{coin}");
    }

    public void OnClickClaim()
    {
        if (isPauseOnClickClaim)
        {
            startRotate = false;
            GoogleAds.googleAds.CheckShowAdmobRewardEd(2);
            isPauseOnClickClaim = false;
        }
    }

    public void checkRewards()// gọi qua GoogleAds để trả thưởng
    {
        print(rewardsReceived);
        CoinEffect.gameObject.SetActive(true);
        PlayerPrefs.SetString("Coin", $"{rewardsReceived}");
        Game.game.UpdateCoin();
        DOVirtual.DelayedCall(1.5f, () =>
        {
            SceneManager.LoadScene("Game");
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (!startRotate) { return; }
        Arrow.Rotate(0, 0, -550 * Time.deltaTime);
        reward = Arrow.GetComponent<Arrow>().reward;
        rewardsReceived = coin * reward;
        string result = ShortenMoney.ConvertCoin(rewardsReceived);
        TextCoinReward.text = result;
        // for (int i = 0; i < 7; i++)
        // {
        //     Arrow.GetChild(i).rotation = listRotation[i];
        // }
    }
}
