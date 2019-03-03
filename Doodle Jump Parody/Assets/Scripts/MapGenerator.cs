// Created by Vad Nik on Feb 24, 2019.

using UnityEngine;
using System;
using UnityEditor;

public class MapGenerator : MonoBehaviour
{
    public static GameObject[] objects;

    public static void GenerateMap()
    {
        int length = (int) UnityEngine.Random.Range(0, 1300);

        objects = new GameObject[length+1];
        objects[0] = GameObject.FindGameObjectWithTag("platform");
        objects[1] = GameObject.FindGameObjectWithTag("coined_platform");

        for (int i = 2; i < length; i++)
        {
            int r = new System.Random().Next(1, 10);
            string rand;

            if (r == 1)
                rand = "coined_platform";
            else if (r == 2)
                rand = (new System.Random().Next(1, 3) == 1) ? "obstacle" : "obstacle_hor";
            else if (r == 3)
                rand = "w_platform";
            else
                rand = "platform";

            GameObject obj;

            //try
            //{
                obj = Instantiate(GameObject.FindWithTag(rand));
            //}
            //catch (ArgumentException)
            //{
            //    //print(ex.Message);

            //    string o = "";
            //    switch (rand)
            //    {
            //        case "platform":
            //            o = "platform_new";
            //            break;
            //        case "coined_platform":
            //            o = "Platform with coin";
            //            break;
            //        case "w_platform":
            //            o = "weak_platform";
            //            break;
            //    }

            //    UnityEngine.Object prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/" + o);
            //    obj = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
            //}

            obj.transform.SetPositionAndRotation(
                new Vector3(UnityEngine.Random.Range(-100, 100), UnityEngine.Random.Range(-5, 100), 0),
                Quaternion.Euler(new Vector3(0, 0, 0)));

            objects[i] = obj;
        }
    }
}
