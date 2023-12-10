using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnMage : MonoBehaviour
{
    public static BtnMage btnMage;
    public Transform ImgAds;
    public Text TextPrice;
    public double price, initialAmount;

    private void Awake()
    {
        btnMage = this;
        string textPrice = PlayerPrefs.GetString("Price");

        if (!string.IsNullOrEmpty(textPrice))
        {
            double retrievedPrice = double.Parse(textPrice);
            price = retrievedPrice;
        }
        else
        {
            price = initialAmount;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpText();

    }

    public void checkPrice()
    {
        price = price * 1.1f;
        PlayerPrefs.SetString("Price", $"{price}");
        UpText();
    }

    public void UpText()
    {
        TextPrice.transform.position = new Vector3(transform.position.x, transform.position.y - 41.02f, transform.position.z);
        string result = ShortenMoney.ConvertCoin(price);
        TextPrice.text = result;
    }

    public void OnClinkAds(bool bl)
    {
        ImgAds.gameObject.SetActive(bl);
        if (bl == true)
        {
            TextPrice.transform.position = new Vector3(transform.position.x + 35, transform.position.y - 41.02f, transform.position.z);
            TextPrice.text = $"Free";
        }
        else if (bl == false)
        {
            UpText();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // checkPrice();
    }
}
