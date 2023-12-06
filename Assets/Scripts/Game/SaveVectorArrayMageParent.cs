using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveVectorArrayMageParent : MonoBehaviour
{
    [System.Serializable]
    public class Vector3ArrayWrapper
    {
        public Vector3[] vectorArray;
    }
    public Transform ArrayPlayer;
    // Đường dẫn của tệp JSON
    private string filePath;
    // Start is called before the first frame update
    void Start()
    {
        ArrayPlayer = GameObject.Find("MageParent").transform;
        // Thiết lập đường dẫn tới tệp JSON
        // filePath = Path.Combine(Application.persistentDataPath, "VectorArrayDataMageParent.json");
        // Đường dẫn mới bạn muốn lưu trữ tệp JSON
        string newFolderPath = "Assets/Scripts/Data/";
        string newFilePath = Path.Combine(newFolderPath, "VectorArrayDataMageParent.json");

        // Kiểm tra xem thư mục có tồn tại chưa, nếu không thì tạo mới
        if (!Directory.Exists(newFolderPath))
        {
            Directory.CreateDirectory(newFolderPath);
        }
        filePath = newFilePath;

        // Gọi hàm để lưu dữ liệu
    }

    public void UpSave()
    {
        if (ArrayPlayer.childCount > 0)
        {
            SavePositions();
        }
    }

    // Update is called once per frame
    void Update()
    {

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

        // Ghi chuỗi JSON vào tệp
        File.WriteAllText(filePath, json);

        // Debug.Log("Dữ liệu Vector3 đã được lưu vào " + filePath);
    }
}
