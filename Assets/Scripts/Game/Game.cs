using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using DG.Tweening;
using System.IO;
using UnityEngine.Networking;
[System.Serializable]
public class Enemy1
{
    public int type;
    public int quantity;
    public float delayTime;
    public float hp;
}

[System.Serializable]
public class Level
{
    public int level;
    public Enemy1[] enemies;
}

[System.Serializable]
public class LevelData
{
    public Level[] levels;
}
public class Game : MonoBehaviour
{
    public static Game game;
    public NewCharacter newCharacter;
    public BtnMage btnMage;
    public UiGame uiGame;
    public SaveVectorArrayMageParent saveVectorArrayMageParent;
    public SaveIntArrayIdMageParent saveIntArrayIdMageParent;
    public SaveIntArrayIdCharacterInfo saveIntArrayIdCharacterInfo;
    public Transform BoxParent, zombieParent, PosZombie, BulletParent;
    public GameObject[] MagePrefabs, zombiePrefab, effectPrefabs, BulletPrefabs;
    public int MageLevelUp;
    public int level;
    public LevelData levelData;
    public List<int> LoadDataMageId = new List<int>();
    public TextAsset textJSON;
    public double coin;
    public bool hackCoin = false;
    public List<int> ItemInfoInt = new List<int>();
    public int idTemporary;

    /* 
    int intValue; // Khai báo biến kiểu Int32
    long longValue; // Khai báo biến kiểu Int64 double
    short shortValue; // Khai báo biến kiểu Int16
     */
    private void Awake()
    {
        game = this;
        InvokeRepeating("HandleGameExit", 0, 1);
    }

    // Start is called before the first frame update
    void Start()
    {

        int idTemp = PlayerPrefs.GetInt("IdTemporary");
        if (idTemp == 0)
        {
            idTemporary = 0;
        }
        else if (idTemp > 0)
        {
            idTemporary = idTemp;
        }

        UpdateCoin();
        if (hackCoin == true)
        {
            coin = 350;
            PlayerPrefs.SetString("Coin", $"{coin}");
            uiGame.UpdateCoin(coin);
        }
        // UpLevel();
    }

    public void UpLevel()
    {
        // string json = System.IO.File.ReadAllText("Assets/Scripts/Data/Level.json");
        // Chuyển đổi JSON thành đối tượng LevelData
        // levelData = JsonUtility.FromJson<LevelData>(json);
        levelData = JsonUtility.FromJson<LevelData>(textJSON.text);
        int indexLevel = levelData.levels[level].level;
        // In ra thông tin của mỗi cấp độ
        foreach (var enemy in levelData.levels[level].enemies)
        {
            // Debug.Log("  Type: " + enemy.type + ", Quantity: " + enemy.quantity + ", Delay Time: " + enemy.delayTime);
            DOVirtual.DelayedCall(enemy.delayTime, () =>
            {
                for (int i = 0; i < enemy.quantity; i++)
                {
                    GameObject ob = Instantiate(zombiePrefab[enemy.type]);
                    int indexPos = Random.Range(0, PosZombie.childCount);
                    Vector3 pos = PosZombie.GetChild(indexPos).transform.position;
                    ob.transform.position = new Vector3(pos.x, ob.transform.position.y, pos.z);
                    ob.transform.SetParent(zombieParent);
                }
            });
        }
    }
    public void UpdateMageLevelUp(Vector3 pos, int indexMage)
    {
        if (indexMage == 0)
        {
            MageLevelUp = 1;
        }
        else if (indexMage == 1)
        {
            MageLevelUp = 2;
        }
        else if (indexMage == 2)
        {
            MageLevelUp = 3;
        }
        else if (indexMage == 3)
        {
            MageLevelUp = 4;
        }
        else if (indexMage == 4)
        {
            MageLevelUp = 5;
        }
        else if (indexMage == 5)
        {
            MageLevelUp = 6;
        }
        else if (indexMage == 6)
        {
            MageLevelUp = 7;
        }
        else if (indexMage == 7)
        {
            MageLevelUp = 8;
        }
        else if (indexMage == 8)
        {
            MageLevelUp = 9;
        }
        else if (indexMage == 9)
        {
            MageLevelUp = 10;
        }

        if (MageLevelUp < 10)
        {
            GameObject ob = Instantiate(MagePrefabs[MageLevelUp]);
            ob.transform.position = new Vector3(pos.x, ob.transform.position.y, pos.z);
            ob.transform.SetParent(GameObject.Find("MageParent").transform);
            int Damage = ob.GetComponent<Player>().Damage;
            checkNewCharacter(MageLevelUp, Damage);
        }

    }

    public void OnClinkBtnMage()
    {
        double price = btnMage.price;
        if (coin >= price)
        {
            Vector3 pos = Vector3.zero;
            if (GameObject.Find("MageParent").transform.childCount < BoxParent.childCount)
            {
                checkCoinBtnMage(price);
                btnMage.checkPrice();
                HashSet<Vector3> occupiedPositions = new HashSet<Vector3>();
                GameObject ob = Instantiate(MagePrefabs[0]);

                for (int i = 0; i < BoxParent.childCount; i++)
                {
                    Box box = BoxParent.GetChild(i).GetComponent<Box>();
                    if (box.isCheckBox == false && !occupiedPositions.Contains(BoxParent.GetChild(i).transform.position))
                    {
                        pos = BoxParent.GetChild(i).transform.position;
                        occupiedPositions.Add(pos); // Add the position to the HashSet
                        break; // Break out of the loop once a valid position is found
                    }
                }

                ob.transform.position = new Vector3(pos.x, ob.transform.position.y, pos.z);
                ShowEffect(ob.transform, 1);
                ob.transform.SetParent(GameObject.Find("MageParent").transform);
            }
        }
        else
        {
            // btnMage.OnClinkAds(true);
            print("ko du tien");
            checkAdsBtnMage();
        }
    }

    public void checkAdsBtnMage()// xem quảng cáo để thêmMage 
    {
        if (GameObject.Find("MageParent").transform.childCount < BoxParent.childCount)
        {

            List<Vector3> occupiedPositions = new List<Vector3>();
            for (int j = 0; j < 2; j++)
            {
                if (GameObject.Find("MageParent").transform.childCount < BoxParent.childCount)
                {
                    GameObject ob = Instantiate(MagePrefabs[0]);
                    Vector3 pos = FindUniquePosition(BoxParent, occupiedPositions);

                    ob.transform.position = new Vector3(pos.x, ob.transform.position.y, pos.z);
                    ShowEffect(ob.transform, 1);
                    ob.transform.SetParent(GameObject.Find("MageParent").transform);

                    occupiedPositions.Add(pos);
                }
            }

            // Function to find a unique position
            Vector3 FindUniquePosition(Transform parent, List<Vector3> occupiedPositions)
            {
                Vector3 pos = Vector3.zero;

                for (int i = 0; i < parent.childCount; i++)
                {
                    Box box = parent.GetChild(i).GetComponent<Box>();
                    if (box.isCheckBox == false && !occupiedPositions.Contains(parent.GetChild(i).position))
                    {
                        pos = parent.GetChild(i).position;
                        break;
                    }
                }
                return pos;
            }
        }
    }

    public void checkCoinBtnMage(double price)
    {
        double coinRemaining = coin - price;
        PlayerPrefs.SetString("Coin", $"{coinRemaining}");
        UpdateCoin();
    }

    public void UpdateCoin()
    {
        string textCon = PlayerPrefs.GetString("Coin");
        if (!string.IsNullOrEmpty(textCon))
        {
            coin = double.Parse(textCon);
            hackCoin = false;
        }
        else
        {
            hackCoin = true;
        }

        uiGame.UpdateCoin(coin);
    }

    public void ShowEffect(Transform transform, int index)
    {
        GameObject ob = Instantiate(effectPrefabs[index]);
        ob.transform.position = new Vector3(transform.position.x, ob.transform.position.y, transform.position.z);
        Destroy(ob, 1);
    }

    public void ShowBullet(Transform transform, int index, int Damage)
    {
        GameObject ob = Instantiate(BulletPrefabs[index]);
        ob.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ob.transform.SetParent(BulletParent);
        ob.transform.GetComponent<Bullet>().Damage = Damage;
        Destroy(ob, 1);
    }

    public void LoadDataMage(Vector3 pos, int index)
    {
        int id = LoadDataMageId[index];
        GameObject ob = Instantiate(MagePrefabs[id]);
        ob.transform.position = new Vector3(pos.x, ob.transform.position.y, pos.z);
        ob.transform.SetParent(GameObject.Find("MageParent").transform);
    }

    public void checkNewCharacter(int id, int Damage)
    {
        if (id > idTemporary)
        {
            newCharacter.gameObject.SetActive(true);
            newCharacter.check(id, Damage);
            idTemporary = id;
            PlayerPrefs.SetInt("IdTemporary", idTemporary);
            ItemInfoInt.Add(id);
            saveIntArrayIdCharacterInfo.SaveIntegers();
            DOVirtual.DelayedCall(1f, () =>
            {
                CheckPause(false);
            });
        }
    }

    public void CheckPause(bool bl)
    {
        for (int i = 0; i < GameObject.Find("MageParent").transform.childCount; i++)
        {
            Player player = GameObject.Find("MageParent").transform.GetChild(i).transform.GetComponent<Player>();
            if (bl == false)
            {
                player.AniIsIdle();
                player.isPause = false;
            }
            else if (bl == true)
            {
                player.AniIsAttack();
                player.isPause = true;
            }
        }

        for (int i = 0; i < BulletParent.childCount; i++)
        {
            Destroy(BulletParent.GetChild(i).gameObject);
        }
    }

    void Update()
    {
        double price = btnMage.price;
        if (coin >= price)
        {
            btnMage.OnClinkAds(false);
        }
        else
        {
            btnMage.OnClinkAds(true);
        }
        // Kiểm tra sự kiện thoát game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        }
        // HandleGameExit();
    }

    void OnApplicationQuit()
    {
        // Xử lý khi ứng dụng game đang thoát
        HandleGameExit();
    }

    void HandleGameExit()
    {
        saveVectorArrayMageParent.UpSave();
        saveIntArrayIdMageParent.UpSave();
        // Debug.Log("Thoát game"); // Thay thế bằng xử lý cụ thể của bạn khi người chơi thoát game
        // Có thể thực hiện lưu trạng thái, gửi điểm số, và các tác vụ khác trước khi thoát
    }
}
