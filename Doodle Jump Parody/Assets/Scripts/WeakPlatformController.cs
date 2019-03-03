// Created by Vad Nik on Mar 3, 2019.

using UnityEngine;

public class WeakPlatformController : MonoBehaviour
{

    [SerializeField]
    GameObject wPlatform;

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject.Destroy(wPlatform);
    }
}
