// Created by Vad Nik on Mar 3, 2019.

using UnityEngine;
using System.Threading;
using System;

public class CoinedController : MonoBehaviour
{

    [SerializeField]
    GameObject coin;

    private Thread currentThread;
    private Thread coinAnimTimer;
    private Vector3 pos;
    private Quaternion rot;
    private bool isAnimNeeded = false;
    private bool coinHasBeenDestroyed = false;

    void Start()
    {
        pos = coin.transform.position;
        rot = coin.transform.rotation;

        currentThread = Thread.CurrentThread;

        //coinAnimTimer = new Thread(OnCoinAnim);
        //coinAnimTimer.Start();
    }

    [Obsolete("eating too much resources")]
    private void OnCoinAnim()
    {
        while (currentThread.IsAlive)
        {
            rot.x++;
            rot.y++;
            isAnimNeeded = true;
            Thread.Sleep(50);
            isAnimNeeded = false;

            Thread.Sleep(700);

            rot.x--;
            rot.y--;
            isAnimNeeded = true;
            Thread.Sleep(50);
            isAnimNeeded = false;
        }
    }

    void Update()
    {
        if (isAnimNeeded)
            coin.transform.SetPositionAndRotation(pos, rot);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!coinHasBeenDestroyed)
        {
            ScoreController.score.text = (++ScoreController.scoreInt).ToString();
            
            GameObject.Destroy(coin);
        }
        coinHasBeenDestroyed = true;
    }
}
