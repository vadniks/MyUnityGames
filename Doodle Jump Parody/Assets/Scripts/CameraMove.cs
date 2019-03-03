// Created by Vad Nik on Feb 25, 2019.

using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    
    void Update()
    {
        transform.position = new Vector3(
            player.transform.position.x, 
            player.transform.position.y, 
            -10f);
    }
}
