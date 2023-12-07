using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StaticData : MonoBehaviour
{
    public static int level = 0;
    public static int maxLevel = 0;
    public static bool game_start = false;
    public static bool loadding = true;
    public static int coin_reward = 0;
    public static bool no_ads = false;
    public static float[] Price_Ratio = new float[] { 1f, 1.25f, 2.08f, 1.307692308f, 1.838235294f };
    public static int[] Reward = new int[] { 40, 400, 640, 640, 6400, 3240, 32000, 10000, 10000, 102000, 250000, 518000, 960000, 1638000, 2624000, 4000000, 5856000, 8294000, 11000000, 15000000 };
    public static string[] List_ID = new string[] { "m1", "m2", "m3", "m4", "m5", "m6", "m7", "m8", "m9", "m10", "m11", "s1", "s2", "s3", "s4", "s5", "s6", "s7", "s8", "s9", "s10", "s11" };
    public static float[] ratioStage6win = new float[] { 0, 0 };
    public static float[] ratioStage6normal = new float[] { 0, 0 };
    public static int maxMelee = 10;
    public static int maxRange = 21;
    public static int levelShowFullAds = 0;
    public static int levelShowAdsInt = 0;
    public static bool removeMode = false;
    public static int typeAds = 0;
    public static string GetMethodName(UnityAction action)
    {
        return action.ToString();
    }
    public static int[] DamagePlayer = new int[] { 4, 10, 23, 54, 128, 304, 720, 1706, 4042, 9577, 22691 };
    
}
