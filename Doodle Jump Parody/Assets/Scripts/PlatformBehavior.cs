// Created by Vad Nik on Feb 25, 2019.

using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D col)
    {
        //print("ote2 platform");

        if (transform.position.y < GameObject.FindGameObjectWithTag("player").transform.position.y)
            PlayerController.isPlatformNearly = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        PlayerController.isPlatformNearly = false;
    }
}
