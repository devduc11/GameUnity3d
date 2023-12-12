using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveIntArrayIdCharacterInfo : MonoBehaviour
{

    [System.Serializable]
    public class IntArrayWrapper
    {
        public int[] intArray;
    }
    // Đường dẫn của tệp JSON
    // private string filePath;
    // Start is called before the first frame update
    void Start()
    {
        // filePath = Path.Combine(Application.persistentDataPath, "IntArrayDataIdCharacterInfo.json");
    }

    public void SaveIntegers()
    {
        int[] intArray = new int[Game.game.ItemInfoInt.Count];
        for (int i = 0; i < Game.game.ItemInfoInt.Count; i++)
        {
            intArray[i] = Game.game.ItemInfoInt[i];
        }

        // Tạo một đối tượng wrapper để chứa mảng số nguyên
        IntArrayWrapper wrapper = new IntArrayWrapper
        {
            intArray = intArray
        };

        // Chuyển đổi đối tượng wrapper thành chuỗi JSON
        string json = JsonUtility.ToJson(wrapper);
        PlayerPrefs.SetString("IntArrayDataIdCharacterInfo", json);
        // // Ghi chuỗi JSON vào tệp
        // File.WriteAllText(filePath, json);

        // Debug.Log("Dữ liệu mảng số nguyên đã được lưu vào " + filePath);
    }
}
