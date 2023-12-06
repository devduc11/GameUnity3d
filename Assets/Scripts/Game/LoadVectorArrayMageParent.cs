using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadVectorArrayMageParent : MonoBehaviour
{
    [System.Serializable]
    public class Vector3ArrayWrapper
    {
        public Vector3[] vectorArray;
    }

    // Đường dẫn của tệp JSON
    private string filePath;
    public Transform ArrayPlayer;
    // Start is called before the first frame update
    void Start()
    {
        ArrayPlayer = GameObject.Find("MageParent").transform;
        // Thiết lập đường dẫn tới tệp JSON
        // filePath = Path.Combine(Application.persistentDataPath, "VectorArrayData.json");
        string newFolderPath = "Assets/Scripts/Data/";
        string newFilePath = Path.Combine(newFolderPath, "VectorArrayDataMageParent.json");
        filePath = newFilePath;
        LoadPositions();
    }

    private void LoadPositions()
    {
        // Kiểm tra xem tệp có tồn tại không
        if (File.Exists(filePath))
        {
            // Đọc nội dung của tệp JSON
            string json = File.ReadAllText(filePath);

            // Chuyển đổi chuỗi JSON thành đối tượng Vector3ArrayWrapper
            Vector3ArrayWrapper loadedWrapper = JsonUtility.FromJson<Vector3ArrayWrapper>(json);

            // Kiểm tra xem dữ liệu đã được tải thành công không
            if (loadedWrapper != null)
            {
                // Lặp qua mảng Vector3 và in ra vị trí
                for (int i = 0; i < loadedWrapper.vectorArray.Length; i++)
                {
                    Game.game.LoadMage(loadedWrapper.vectorArray[i]);
                    // Transform childTransform = ArrayPlayer.GetChild(i).transform;
                    // childTransform.position = loadedWrapper.vectorArray[i];
                    Debug.Log("Vị trí " + i + ": " + loadedWrapper.vectorArray[i]);
                }
            }
            else
            {
                Debug.Log("Dữ liệu không hợp lệ.");
            }
        }
        else
        {
            Debug.Log("Tệp không tồn tại: " + filePath);
        }
    }
}
