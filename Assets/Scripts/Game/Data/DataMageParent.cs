using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMageParent : MonoBehaviour
{
    [System.Serializable]
    public class Vector3ArrayWrapper
    {
        public Vector3[] vectorArray;
    }

    [System.Serializable]
    public class IntArrayWrapper
    {
        public int[] intArray;
    }


    public Transform ArrayPlayer;

    private void Awake()
    {
        InvokeRepeating("SaveData", 0, 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        if (ArrayPlayer.childCount > 0)
        {
            SavePositions();
            SaveIntegers();
        }
    }

    private void SavePositions()
    {
        // Tạo một mảng Vector3 để lưu trữ dữ liệu
        Vector3[] vectorArray = new Vector3[ArrayPlayer.childCount];

        // Lặp qua tất cả các con của ArrayPlayer và lưu vị trí vào mảng
        for (int i = 0; i < ArrayPlayer.childCount; i++)
        {
            Transform childTransform = ArrayPlayer.GetChild(i).transform;
            vectorArray[i] = childTransform.position;
        }

        // Tạo một đối tượng wrapper để chứa mảng Vector3
        Vector3ArrayWrapper wrapper = new Vector3ArrayWrapper
        {
            vectorArray = vectorArray
        };

        // Chuyển đổi đối tượng wrapper thành chuỗi JSON
        string json = JsonUtility.ToJson(wrapper);
        PlayerPrefs.SetString("PlayerDataVectorArray", json);
    }

    private void SaveIntegers()
    {
        int[] intArray = new int[ArrayPlayer.childCount];
        // Lặp qua tất cả các con của ArrayPlayer và lưu vị trí vào mảng
        for (int i = 0; i < ArrayPlayer.childCount; i++)
        {
            Transform childTransform = ArrayPlayer.GetChild(i).transform;
            intArray[i] = childTransform.GetComponent<Player>().indexMage;
        }

        // Tạo một đối tượng wrapper để chứa mảng số nguyên
        IntArrayWrapper wrapper = new IntArrayWrapper
        {
            intArray = intArray
        };
        // Chuyển đổi đối tượng wrapper thành chuỗi JSON
        string json = JsonUtility.ToJson(wrapper);
        PlayerPrefs.SetString("IdMageParent", json);
    }

    public void LoadData()
    {
        LoadIntegers();
        LoadPositions();
    }

    public void LoadPositions()
    {
        string jsonVectorArray = PlayerPrefs.GetString("PlayerDataVectorArray");
        // Chuyển đổi chuỗi JSON thành đối tượng Vector3ArrayWrapper
        Vector3ArrayWrapper loadedWrapper = JsonUtility.FromJson<Vector3ArrayWrapper>(jsonVectorArray);

        // Kiểm tra xem dữ liệu đã được tải thành công không
        if (loadedWrapper != null)
        {
            // Lặp qua mảng Vector3 và in ra vị trí
            for (int i = 0; i < loadedWrapper.vectorArray.Length; i++)
            {
                Game.game.LoadDataMage(loadedWrapper.vectorArray[i], i);
                // Transform childTransform = ArrayPlayer.GetChild(i).transform;
                // childTransform.position = loadedWrapper.vectorArray[i];
                // Debug.Log("Vị trí " + i + ": " + loadedWrapper.vectorArray[i]);
            }
        }
        else
        {
            Debug.Log("Dữ liệu Vector Array Mage không có");
        }
    }

    private void LoadIntegers()
    {
        string jsonIdArray = PlayerPrefs.GetString("IdMageParent");
        // Chuyển đổi chuỗi JSON thành đối tượng IntArrayWrapper
        IntArrayWrapper loadedWrapper = JsonUtility.FromJson<IntArrayWrapper>(jsonIdArray);

        // Kiểm tra xem dữ liệu đã được tải thành công không
        if (loadedWrapper != null)
        {
            // Lặp qua mảng int và in ra giá trị
            for (int i = 0; i < loadedWrapper.intArray.Length; i++)
            {
                Game.game.LoadDataMageId.Add(loadedWrapper.intArray[i]);
                // Debug.Log("Giá trị " + i + ": " + loadedWrapper.intArray[i]);
            }
        }
        else
        {
            Debug.Log("Dữ liệu Id Mage không có");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (ArrayPlayer.childCount > 0)
        {
            // SavePositions();
        }
    }
}
