using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Game_Manager : MonoBehaviour
{
    private int Score;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameObject playButton;
   
    [SerializeField] Player_Movement player;

   // [SerializeField] GameObject gameStart;
    [SerializeField] GameObject gameOver;

    [SerializeField] GameObject gameStart;
    [SerializeField] GameObject gameOverButton;
    Pipes_Movement pipesMovement;
    Pipes pipes;

    GameObject background;
    AudioSource backGroundSound;
    AudioSource gameOverSound;
    public  void Awake()
    {
     background = GameObject.Find("BackGround");
     backGroundSound = background.GetComponent<AudioSource>();
    
    }

    private void Start() 
   {
      Application.targetFrameRate = 60;
       gameOverSound = GetComponent<AudioSource>();
      Pause();
   }

   public void Play()
   {
        Time.timeScale = 1f;
        Score = 0;
        scoreText.text = Score.ToString();
       
        gameOver.SetActive(false);
        playButton.SetActive(false);
        gameOverButton.SetActive(false);
        player.enabled = true;
        GameStartText();
    }
   private void GameStartText()
   {
    gameStart.SetActive(true);
   }
    public void GameStartTextFade()
    {
      gameStart.SetActive(false);
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        Score++;
        scoreText.text = Score.ToString();
    }
    public void GameOver()
    {
        gameOverButton.SetActive(true);
        gameOver.SetActive(true);
        playButton.SetActive(true);
        gameOverSound.Play();
        GameStartTextFade();
        Pipes_Movement[] pipes = FindObjectsOfType<Pipes_Movement>();
        for(int i = 0 ; i< pipes.Length ;i++)
        {
              Destroy(pipes[i].gameObject);
        }

        Pause();

       
    } 
   public void BGM()
   {
   
    backGroundSound.Play();
   
   }
 
}
