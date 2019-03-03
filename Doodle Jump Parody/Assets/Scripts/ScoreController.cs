// Created by Vad Nik on Mar 3, 2019.

using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static Text score;
    public volatile static int scoreInt;
    
    void Start()
    {
        score = GameObject.FindWithTag("score").GetComponent<Text>();
        scoreInt = 0;
    }
}
