using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadIntArrayIdCharacterInfo : MonoBehaviour
{
    [System.Serializable]
    public class IntArrayWrapper
    {
        public int[] intArray;
    }
    // Đường dẫn của tệp JSON
    private string filePath;
    // Start is called before the first frame update
    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "IntArrayDataIdCharacterInfo.json");
        LoadIntegers();
    }

    private void LoadIntegers()
    {
        // Kiểm tra xem tệp có tồn tại không
        if (File.Exists(filePath))
        {
            // Đọc nội dung của tệp JSON
            string json = File.ReadAllText(filePath);

            // Chuyển đổi chuỗi JSON thành đối tượng IntArrayWrapper
            IntArrayWrapper loadedWrapper = JsonUtility.FromJson<IntArrayWrapper>(json);

            // Kiểm tra xem dữ liệu đã được tải thành công không
            int idTemp = PlayerPrefs.GetInt("IdTemporary");
            if (loadedWrapper != null && idTemp != 0)
            {
                // Lặp qua mảng int và in ra giá trị
                for (int i = 0; i < loadedWrapper.intArray.Length; i++)
                {
                    Game.game.ItemInfoInt.Add(loadedWrapper.intArray[i]);
                    // Debug.Log("Giá trị " + i + ": " + loadedWrapper.intArray[i]);
                }
            }
            else
            {
                Game.game.ItemInfoInt.Add(0);
                // Debug.Log("Dữ liệu không hợp lệ.");
            }
        }
        else
        {
            Debug.Log("Tệp không tồn tại: " + filePath);
        }
    }
}
