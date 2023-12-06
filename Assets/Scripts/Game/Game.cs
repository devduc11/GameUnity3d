using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using DG.Tweening;

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
    public SaveVectorArrayMageParent saveVectorArrayMageParent;
    public Transform BoxParent, zombieParent, PosZombie, BulletParent;
    public GameObject[] MagePrefabs, zombiePrefab, effectPrefabs, BulletPrefabs;
    public int MageLevelUp;
    public int level;
    public LevelData levelData;

    private void Awake()
    {
        game = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // UpLevel();
    }

    public void UpLevel()
    {
        string json = System.IO.File.ReadAllText("Assets/Scripts/Data/Level.json");

        // Chuyển đổi JSON thành đối tượng LevelData
        levelData = JsonUtility.FromJson<LevelData>(json);
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
            MageLevelUp = 7;
        }
        GameObject ob = Instantiate(MagePrefabs[MageLevelUp]);
        ob.transform.position = new Vector3(pos.x, ob.transform.position.y, pos.z);
        ob.transform.SetParent(GameObject.Find("MageParent").transform);
    }

    Vector3 pos;
    public void OnClinkBtnMage()
    {
        if (GameObject.Find("MageParent").transform.childCount < BoxParent.childCount)
        {
            GameObject ob = Instantiate(MagePrefabs[0]);
            for (int i = 0; i < BoxParent.childCount; i++)
            {
                Box box = BoxParent.GetChild(i).GetComponent<Box>();
                if (box.isCheckBox == false)
                {
                    pos = BoxParent.GetChild(i).transform.position;
                }
            }
            ob.transform.position = new Vector3(pos.x, ob.transform.position.y, pos.z);
            ShowEffect(ob.transform, 1);
            ob.transform.SetParent(GameObject.Find("MageParent").transform);
        }
    }

    public void ShowEffect(Transform transform, int index)
    {
        GameObject ob = Instantiate(effectPrefabs[index]);
        ob.transform.position = new Vector3(transform.position.x, ob.transform.position.y, transform.position.z);
        Destroy(ob, 1);
    }

    public void ShowBullet(Transform transform, int index)
    {
        GameObject ob = Instantiate(BulletPrefabs[index]);
        ob.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ob.transform.SetParent(BulletParent);
        Destroy(ob, 1);
    }

    public void LoadMage(Vector3 pos)
    {
        GameObject ob = Instantiate(MagePrefabs[0]);
        ob.transform.position = new Vector3(pos.x, ob.transform.position.y, pos.z);
        ob.transform.SetParent(GameObject.Find("MageParent").transform);
    }

    void Update()
    {
        // Kiểm tra sự kiện thoát game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HandleGameExit();
        }
    }

    void OnApplicationQuit()
    {
        // Xử lý khi ứng dụng game đang thoát
        saveVectorArrayMageParent.UpSave();
        HandleGameExit();
    }

    void HandleGameExit()
    {
        Debug.Log("Thoát game"); // Thay thế bằng xử lý cụ thể của bạn khi người chơi thoát game
        // Có thể thực hiện lưu trạng thái, gửi điểm số, và các tác vụ khác trước khi thoát
    }
}
