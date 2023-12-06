using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class ShortenMoney
{
    public static string ConvertCoin(double coin)
    {
        string text;

        if (coin < 1e3)
        {
            text = Math.Round(coin).ToString();
        }
        else if (coin >= 1e3 && coin < 1e6)
        {
            text = Math.Round(coin / 1e3, 1).ToString() + "K";
        }
        else if (coin >= 1e6 && coin < 1e9)
        {
            text = Math.Round(coin / 1e6, 1).ToString() + "M";
        }
        else if (coin >= 1e9 && coin < 1e12)
        {
            text = Math.Round(coin / 1e9, 1).ToString() + "B";
        }
        else if (coin >= 1e12 && coin < 1e15)
        {
            text = Math.Round(coin / 1e12, 1).ToString() + "T";
        }
        else if (coin >= 1e15 && coin < 1e18)
        {
            text = Math.Round(coin / 1e15, 1).ToString() + "a";
        }
        else if (coin >= 1e18 && coin < 1e21)
        {
            text = Math.Round(coin / 1e18, 1).ToString() + "b";
        }
        else if (coin >= 1e21 && coin < 1e24)
        {
            text = Math.Round(coin / 1e21, 1).ToString() + "c";
        }
        else if (coin >= 1e24 && coin < 1e27)
        {
            text = Math.Round(coin / 1e24, 1).ToString() + "d";
        }
        else if (coin >= 1e27 && coin < 1e30)
        {
            text = Math.Round(coin / 1e27, 1).ToString() + "e";
        }
        else if (coin >= 1e30 && coin < 1e33)
        {
            text = Math.Round(coin / 1e30, 1).ToString() + "f";
        }
        else if (coin >= 1e33 && coin < 1e36)
        {
            text = Math.Round(coin / 1e33, 1).ToString() + "g";
        }
        else if (coin >= 1e36 && coin < 1e39)
        {
            text = Math.Round(coin / 1e36, 1).ToString() + "h";
        }
        else if (coin >= 1e39 && coin < 1e42)
        {
            text = Math.Round(coin / 1e39, 1).ToString() + "i";
        }
        else if (coin >= 1e42 && coin < 1e45)
        {
            text = Math.Round(coin / 1e42, 1).ToString() + "j";
        }
        else if (coin >= 1e45 && coin < 1e48)
        {
            text = Math.Round(coin / 1e45, 1).ToString() + "k";
        }
        else if (coin >= 1e48 && coin < 1e51)
        {
            text = Math.Round(coin / 1e48, 1).ToString() + "l";
        }
        else if (coin >= 1e51 && coin < 1e54)
        {
            text = Math.Round(coin / 1e51, 1).ToString() + "m";
        }
        else if (coin >= 1e54 && coin < 1e57)
        {
            text = Math.Round(coin / 1e54, 1).ToString() + "n";
        }
        else if (coin >= 1e57 && coin < 1e60)
        {
            text = Math.Round(coin / 1e57, 1).ToString() + "o";
        }
        else if (coin >= 1e60 && coin < 1e63)
        {
            text = Math.Round(coin / 1e60, 1).ToString() + "p";
        }
        else if (coin >= 1e63 && coin < 1e66)
        {
            text = Math.Round(coin / 1e63, 1).ToString() + "q";
        }
        else if (coin >= 1e66 && coin < 1e69)
        {
            text = Math.Round(coin / 1e66, 1).ToString() + "r";
        }
        else if (coin >= 1e69 && coin < 1e72)
        {
            text = Math.Round(coin / 1e69, 1).ToString() + "s";
        }
        else if (coin >= 1e72 && coin < 1e75)
        {
            text = Math.Round(coin / 1e72, 1).ToString() + "t";
        }
        else if (coin >= 1e75 && coin < 1e78)
        {
            text = Math.Round(coin / 1e75, 1).ToString() + "u";
        }
        else if (coin >= 1e78 && coin < 1e81)
        {
            text = Math.Round(coin / 1e78, 1).ToString() + "v";
        }
        else if (coin >= 1e81 && coin < 1e84)
        {
            text = Math.Round(coin / 1e81, 1).ToString() + "w";
        }
        else if (coin >= 1e84 && coin < 1e87)
        {
            text = Math.Round(coin / 1e84, 1).ToString() + "x";
        }
        else if (coin >= 1e87 && coin < 1e90)
        {
            text = Math.Round(coin / 1e87, 1).ToString() + "y";
        }
        else
        {
            text = Math.Round(coin / 1e90, 1).ToString() + "z";
        }

        return text;
    }
}
