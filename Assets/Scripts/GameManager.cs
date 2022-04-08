using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using AppodealAds.Unity.Api;
//using AppodealAds.Unity.Common;

public class GameManager : MonoBehaviour
{
    public Text iconMoney;
    public Text iconScore;

    private AudioSource soundClick;
    private AudioSource soundFinish;
    private AudioSource soundGame;
    private AudioSource soundCoin;

    private bool isGameOver = false;
    public GameObject gameOver;

    void Start()
    {
        Time.timeScale = 1;

        soundClick = GameObject.Find("Sound_Click").GetComponent<AudioSource>();
        soundFinish = GameObject.Find("Sound_Finish").GetComponent<AudioSource>();
        soundGame = GameObject.Find("Sound_Game").GetComponent<AudioSource>();
        soundCoin = GameObject.Find("Sound_Coin").GetComponent<AudioSource>();

        iconMoney.text = PlayerPrefs.GetInt("Money").ToString();
    }

    void Update()
    {
        if (!isGameOver)
        {
            Score();
        }
    }

    void Score()
    {
        iconScore.text = (int.Parse(iconScore.text) + 1).ToString();
    }

    public void AddMoney(int count)
    {
        soundCoin.Play();
        iconMoney.text = (int.Parse(iconMoney.text) + count).ToString();
    }

    public void GameOver()
    {
        soundGame.Stop();
        soundFinish.Play();

        isGameOver = true;
        gameOver.SetActive(true);
        Time.timeScale = 0;

        PlayerPrefs.SetInt("Score", int.Parse(iconScore.text));
        PlayerPrefs.SetInt("Money", int.Parse(iconMoney.text));
    }

    //Buttons
    public void Home()
    {
        soundClick.Play();
        SceneManager.LoadScene("Menu");
    }

    public void Replay()
    {
        SceneManager.LoadScene("Game");
    }
}
