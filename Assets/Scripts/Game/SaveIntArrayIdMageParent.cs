using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveIntArrayIdMageParent : MonoBehaviour
{
    [System.Serializable]
    public class IntArrayWrapper
    {
        public int[] intArray;
    }
    // Đường dẫn của tệp JSON
    private string filePath;
    public Transform ArrayPlayer;
    // Start is called before the first frame update
    void Start()
    {
        ArrayPlayer = GameObject.Find("MageParent").transform;
        string newFolderPath = "Assets/Scripts/Data/";
        string newFilePath = Path.Combine(newFolderPath, "IntArrayDataIdMageParent.json");
        // Thiết lập đường dẫn tới tệp JSON
        // filePath = Path.Combine(Application.persistentDataPath, "IntArrayDataIdMageParent.json");
        filePath = newFilePath;

        // Gọi hàm để lưu dữ liệu
        // SaveIntegers();
    }

    public void UpSave()
    {
        if (ArrayPlayer.childCount > 0)
        {
            SaveIntegers();
        }
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

        // Ghi chuỗi JSON vào tệp
        File.WriteAllText(filePath, json);

        Debug.Log("Dữ liệu mảng số nguyên đã được lưu vào " + filePath);
    }
}
