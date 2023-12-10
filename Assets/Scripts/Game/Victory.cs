using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public static Victory victory;
    public Transform Arrow, ButtonContinue, CoinEffect;
    public Text TextCoin, TextCoinReward;
    public double reward, coin, rewardsReceived;
    public bool startRotate = false;
    public bool isPauseOnClickClaim;

    private void Awake()
    {
        victory = this;
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
        // ButtonContinue.localScale = Vector3.zero;
        // print(coin);
        Game.game.NextLevel();
        gameObject.SetActive(false);
        // CoinEffect.gameObject.SetActive(true);
        // PlayerPrefs.SetString("Coin", $"{coin}");
    }

    public void OnClickClaim()
    {
        if (isPauseOnClickClaim)
        {
            startRotate = false;
            GoogleAds.googleAds.CheckShowAdmobRewardEd(1);
            isPauseOnClickClaim = false;
        }
    }

    public void checkRewards()// gọi qua GoogleAds để trả thưởng
    {
        print(rewardsReceived);
        PlayerPrefs.SetString("Coin", $"{rewardsReceived}");
        Game.game.UpdateCoin();
        Game.game.NextLevel();
        gameObject.SetActive(false);
        CoinEffect.gameObject.SetActive(true);

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
