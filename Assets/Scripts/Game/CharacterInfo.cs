using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterInfo : MonoBehaviour
{
    [SerializeField]
    private Transform Content, Board;
    [SerializeField]
    private GameObject PrefabInfo;
    [SerializeField]
    private Transform Bar;
    [SerializeField]
    public Sprite[] SprChars;
    private string[] nameCharStr = { "Sun Blossom", "Sunflower", "Sunflora", "Bomb", "Snow Bomb", "Poison Bomb", "Bloom", "Blossom", "Death", "Nightmare", "Death Mage" };
    public bool isInfo;

    private void Awake()
    {
        isInfo = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        Bar.localPosition = new Vector3(-161, 308, 0);
    }

    public void CheckShow()
    {
        Game.game.CheckPause(false);
        Vector3 pos = GameObject.Find("ButtonInfo").transform.position;
        Board.position = pos;
        Board.DOMove(transform.position, 0.3f);
        LibraryMy.EffectScaleObjectOn(Board.transform, 0.3f, 1f);
        Show();
    }

    public void onClickButtonX()
    {
        Vector3 pos = GameObject.Find("ButtonInfo").transform.position;
        Board.transform.DOMove(pos, 0.3f);
        LibraryMy.EffectScaleObjectOff(Board.transform, 0.3f, 0, () => Off());
    }

    public void Off()
    {
        gameObject.SetActive(false);
        Game.game.CheckPause(true);
    }

    public void Show()
    {
        int max = StaticData.DamagePlayer.Length;
        for (int i = 0; i <= max; i++)
        {
            if (isInfo == true)
            {
                GameObject ob = Instantiate(PrefabInfo);
                ob.transform.SetParent(Content);
                ob.transform.localScale = Vector3.one;

            }
            ItemInfo itemInfo = Content.GetChild(i).GetComponent<ItemInfo>();
            itemInfo.ID = i;
            if (i < max)
            {
                if (i >= 0 && i < Game.game.ItemInfoInt.Count)
                {
                    int ItemInfoInt = Game.game.ItemInfoInt[i];
                    if (ItemInfoInt == itemInfo.ID)
                    {
                        itemInfo.ShowNewChar(ItemInfoInt, StaticData.DamagePlayer[ItemInfoInt], nameCharStr[ItemInfoInt]);
                    }
                }
                else
                {
                    // print("okokokokokokokkk");
                    itemInfo.CheckImgReview(i, nameCharStr[i]);
                }
            }
            else
            {
                itemInfo.CommingSoon();
            }
        }
        isInfo = false;
        // print(Content.childCount);
    }

    // public void OnClickShow(int id)
    // {
    //     int min = id == 0 ? 0 : StaticData.maxMelee + 1;
    //     int max = id == 0 ? StaticData.maxMelee + 1 : StaticData.maxRange + 1;
    //     int x = id == 0 ? 161 : -161;
    //     int count = 0;
    //     Bar.DOLocalMoveX(x, 0.5f);
    //     bool isLock = false;
    //     // Debug.Log("Max bang bao nhieu: " + max);
    //     for (int i = min; i < max + 1; i++)
    //     {
    //         GameObject item;
    //         if (Content.childCount <= count)
    //         {
    //             item = Instantiate(PrefabInfo);
    //             item.transform.SetParent(Content);
    //         }
    //         else
    //         {
    //             item = Content.GetChild(count).gameObject;
    //         }
    //         item.transform.localScale = new Vector3(1, 1, 1);
    //         if (i == max)
    //         {
    //             item.GetComponent<ItemInfo>().CommingSoon();
    //         }
    //         else
    //         {
    //             int Damage = StaticData.DamagePlayer[0];
    //             print("Damage: " + Damage);
    //         }
    //     }
    // }
}
