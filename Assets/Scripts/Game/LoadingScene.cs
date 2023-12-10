using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.IO;

public class LoadingScene : MonoBehaviour
{
    public RectTransform progress;
    bool canConnect = false;
    float maxSize = 0;
    // Start is called before the first frame update
    void Start()
    {
        maxSize = progress.parent.GetComponent<RectTransform>().sizeDelta.x;
        progress.sizeDelta = new Vector2(0, 65);
        progress.DOSizeDelta(new Vector2(maxSize - 7, 65), 4).OnComplete(() =>
        {
            SceneManager.LoadScene("Game");
        });
    }

}
