using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadIntArrayIdMageParent : MonoBehaviour
{
    [System.Serializable]
    public class IntArrayWrapper
    {
        public int[] intArray;
    }
    // Đường dẫn của tệp JSON
    private string filePath;
    public Transform ArrayPlayer;

    void Start()
    {
        ArrayPlayer = GameObject.Find("MageParent").transform;
        // string newFolderPath = "Assets/Scripts/Data/";
        // string newFilePath = Path.Combine(newFolderPath, "IntArrayDataIdMageParent.json");
        // Thiết lập đường dẫn tới tệp JSON
        filePath = Path.Combine(Application.persistentDataPath, "IntArrayDataIdMageParent.json");
        // filePath = newFilePath;

        // Gọi hàm để tải dữ liệu
        // LoadIntegers();
        Invoke("LoadIntegers", 0.1f);
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
            if (loadedWrapper != null && BtnMage.btnMage.price != BtnMage.btnMage.initialAmount)
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
                // Debug.Log("Dữ liệu không hợp lệ.");
            }
        }
        else
        {
            Debug.Log("Tệp không tồn tại: " + filePath);
        }
    }
}
