// Created by Vad Nik on Feb 24, 2019.

using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public static GameObject[] objects;

    public static void GenerateMap()
    {
        int length = (int)Random.Range(0, 1300);

        objects = new GameObject[length+1];
        objects[0] = GameObject.FindGameObjectWithTag("platform");
        objects[1] = GameObject.FindGameObjectWithTag("coined_platform");

        for (int i = 2; i < length; i++)
        {
            GameObject obj = Instantiate(GameObject.FindWithTag(
                (new System.Random().Next(1, 5) != 1) ? "platform" : "coined_platform"));

            obj.transform.SetPositionAndRotation(
                new Vector3(Random.Range(-100, 100), Random.Range(-5, 100), 0),
                Quaternion.Euler(new Vector3(0, 0, 0)));

            objects[i] = obj;
        }
    }
}
