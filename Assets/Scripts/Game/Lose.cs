using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : MonoBehaviour
{

    public Transform Arrow, ButtonContinue;
    public Text TextCoin, TextCoinReward;
    public double reward, coin, rewardsReceived;
    public bool startRotate = false;
    // Start is called before the first frame update
    void Start()
    {
        startRotate = true;
        coin = 10;
        check();
    }

    public void check()
    {
        string result = ShortenMoney.ConvertCoin(coin);
        TextCoin.text = result;
        Invoke("CheckShowButtonContinue", 2);
    }

    public void CheckShowButtonContinue()
    {
        LibraryMy.EffectScaleObjectOn(ButtonContinue, 0.3f, 1f);
    }

    public void OnButtonContinue()
    {
        print(coin);
        // PlayerPrefs.SetString("Coin", $"{coin}");
    }

    public void OnClickClaim()
    {
        startRotate = false;
        print(rewardsReceived);
        // PlayerPrefs.SetString("Coin", $"{rewardsReceived}");
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
