using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class GameManager : MonoBehaviour {

    public Transform cubeB;
    public Transform cubeR;
    public Transform textNice;
    public Transform textGreat;
    public Transform textAmazing;
    public Transform textFantastic;
    public Transform textOutstanding;
    public Transform textUnbelievable;

    public Text scoretextPlayer1;
    public Text scoretextPlayer2;

    private System.Random randomDirection;

    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;

    public jump Player1Jump;
    public jump Player2Jump;

    public Canvas StartCanvas;
    public Camera maincam;

    // Use this for initialization
    void Start () {
        randomDirection = new System.Random();
        foreach(String device in Microphone.devices)
        {
          //  Debug.Log(device);
        }

        GameObject pl1 = GameObject.Find("player1");
        Player1Jump = (jump)pl1.GetComponent(typeof(jump));
        //Player1Jump.Jump();

        GameObject pl2 = GameObject.Find("player2");
        Player2Jump = (jump)pl2.GetComponent(typeof(jump));
       // Player2Jump.Jump();


    }

    // Update is called once per frame
    void Update () {
        
    }

    public void spawnPoint()
    {
        double directionChoice = randomDirection.NextDouble() * (3.6 - 1.4) + 1.4; 

        Instantiate(cubeR, new Vector3(11, (float)directionChoice, 0), Quaternion.identity);

        
        double directionChoice2 = randomDirection.NextDouble() * (-1.4 - -3.6) + -3.6;
        Instantiate(cubeB, new Vector3(11, (float)directionChoice2, 0), Quaternion.identity);
    }


    public void addScorePlayer1()
    {
        scorePlayer1++;
        scoretextPlayer1.text = "Score: " + scorePlayer1;

        //heigth is the y cordinate
        ShowFeedbackText(scorePlayer1, (float) 2.5);       
    }

    public void addScorePlayer2()
    {
        scorePlayer2++;
        scoretextPlayer2.text = "Score: " + scorePlayer2;

        //heigth is the y cordinate
        ShowFeedbackText(scorePlayer2, (float) -2.5);
    }

    public void JumpPlayer1(int allPlayers)
    {
        Player1Jump.Jump(allPlayers);
        scoretextPlayer1.text = "Score: " + scorePlayer1;
    }

    public void JumpPlayer2(int allPlayers)
    {
        Player2Jump.Jump(allPlayers);
        scoretextPlayer2.text = "Score: " + scorePlayer2;
    }

    public void StartGame()
    {
        StartCanvas.gameObject.SetActive(false);
        AudioPeer audiopeer = maincam.gameObject.AddComponent<AudioPeer>();
        maincam.gameObject.GetComponent<AudioSource>().Play();
    }


    public void ShowFeedbackText(int score, float height)
    {
        switch (score)
        {
            case 50:
                Instantiate(textNice, new Vector3(0, height, -1), Quaternion.identity);
                break; //optional
            case 100:
                Instantiate(textGreat, new Vector3(0, height, -1), Quaternion.identity);
                break; //optional
            case 200:
                Instantiate(textAmazing, new Vector3(0, height, -1), Quaternion.identity);
                break; //optional
//            case 300:
//                Instantiate(textFantastic, new Vector3(0, height, -1), Quaternion.identity);
//                break; //optional
//            case 400:
//                Instantiate(textOutstanding, new Vector3(0, height, -1), Quaternion.identity);
//                break; //optional
//           case 500:
//                Instantiate(textUnbelievable, new Vector3(0, height, -1), Quaternion.identity);
//                break; //optional
        }
    }
}
