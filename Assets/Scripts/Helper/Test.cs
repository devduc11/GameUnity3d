using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // string text1 = "0";
        // string text2 = "1000000000000000000000000000000000000000000000000000000000000000000000000000000";

        // // Convert strings to integers and then add them
        // double result = double.Parse(text1) + double.Parse(text2);

        // // Convert the result back to string for printing
        // string text3 = result.ToString();
        // print(text3);

    }
    public int id;
    public List<int> ints = new List<int>() { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110 };
    public string text1;
    public void test()
    {
        // text1 = ints[id].ToString();
        if (string.IsNullOrEmpty(text1))
        {
            text1 = "0";
        }
        else
        {
            // Assuming text1 contains a valid number
            double currentValue = double.Parse(text1);
            currentValue += ints[10];
            text1 = currentValue.ToString();
        }
        print(text1);
        if (double.TryParse(text1, out double result1))
        {
            string result = ShortenMoney.ConvertCoin(result1);
            // Debug.Log(result);
        }

    }

    // Update is called once per frame
    void Update()
    {
        // test();
    }
}
