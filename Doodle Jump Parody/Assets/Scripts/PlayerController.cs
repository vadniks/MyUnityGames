// Created by Vad Nik on Feb 24, 2019.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using System;

public class PlayerController : MonoBehaviour
{
    private static readonly float SPEED = 20f;
    public static Rigidbody2D rb;
    private Thread mainThread;
    private bool isGravityScaleChanged = false;
    private Thread timerThread;
    //private bool isInteruptingTimer = false;
    private Vector3 defGravity;

    [SerializeField]
    GameObject gomc;

    [SerializeField]
    Button retry;

    [SerializeField]
    Button mainMenu;

    public static volatile bool isPlatformNearly = false;

    void Start()
    {
        defGravity = Physics2D.gravity;

        gomc.SetActive(false);

        rb = GetComponent<Rigidbody2D>();
        MapGenerator.GenerateMap();
        
        mainThread = Thread.CurrentThread;
    }

    private void OnTimerThread()
    {
        //while (mainThread.IsAlive)
        //{
        //    if (isInteruptingTimer)
        //    {
        //        isGravityScaleChanged = false;
        //        isInteruptingTimer = false;
        //        break;
        //    }

            //print("ott");

            isGravityScaleChanged = true;
            Thread.Sleep(500);
            isGravityScaleChanged = false;

            //print("ott2");
        //}
    }
    
    void FixedUpdate()
    {
        //float moveY = Input.GetAxis("Vertical");
        //rb.MovePosition(rb.position + Vector2.up * moveY * SPEED * Time.deltaTime);

        float moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * moveX * SPEED * Time.deltaTime);

        if (isPlatformNearly)
        {
            //Vector3 t = transform.position;
            //transform.position = Vector3.Lerp(t, new Vector3(t.x, t.y + 5, t.z), 1);

            //rb.velocity += 8 * Vector2.up;

            //isPlatformNearly = false;

            //rb.MovePosition(rb.position + Vector2.up * Input.GetAxis("Vertical") * SPEED * Time.deltaTime);

            //rb.AddForce(Vector2.up * 8000);
            //isAddForceCalling = false;

            //if (timerThread == null)
                timerThread = new Thread(new ThreadStart(OnTimerThread));

            //if (!timerThread.IsAlive)
                timerThread.Start();

            //if (isGravityScaleChanged)
            //{
            //    print("changed");
            //    Physics2D.gravity = new Vector3(defGravity.x, -20, defGravity.z);
            //}
            //else
            //{
            //    print("!changed");
            //    Physics2D.gravity = defGravity;
            //}

                //ChangeGravity();

        }

        ChangeGravity();

        //else if (isGravityScaleChanged)
        //    isInteruptingTimer = true;

        if (rb.position.y <= -10)
        {
            //isInteruptingTimer = true;
            //isGravityScaleChanged = false;

            DisplayGameOverMenu();
        }
    }

    private void ChangeGravity()
    {
        if (isGravityScaleChanged)
        {
            //print("changed");
            Physics2D.gravity = new Vector3(defGravity.x, -10, defGravity.z);
            rb.gravityScale = -50;
        }
        else
        {
            //print("!changed");
            Physics2D.gravity = defGravity;
            rb.gravityScale = 25;
        }
    }

    private void DisplayGameOverMenu()
    {
        GameObject.FindWithTag("player").SetActive(false);

        //foreach (GameObject i in MapGenerator.objects)
        //    i.SetActive(false);

        //GameObject gomc = Transform.Instantiate(GameObject.FindWithTag("game_over_menu"));
        gomc.transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.Euler(
            new Vector3(0, 0, 0)));

       
        retry.onClick.AddListener(
             () => {
                 //print("retry bt");

                 Transform.Destroy(gomc);
                 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
             });
            
        mainMenu.onClick.AddListener(
             () => {
                //print("main menu bt");

                Transform.Destroy(gomc);
                SceneManager.LoadScene("MainMenuScene");
             });
                    

        gomc.SetActive(true);
    }
}
