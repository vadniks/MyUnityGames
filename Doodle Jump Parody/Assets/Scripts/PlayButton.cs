// Created by Vad Nik on Feb 23, 2019.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private Button bt;

    void Awake()
    {
        bt = gameObject.GetComponent<Button>();
        bt.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
