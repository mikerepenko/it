using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public GameObject shop;

    public GameObject loading;
    private bool isLoading;
    private float timerLoading = 5.0f;

    public Text iconMoney;
    public Text iconScore;

    private AudioSource soundClick;
    private AudioSource soundMenu;
    private AudioSource soundLoading;
    private AudioSource soundRain;

    void Awake()
    {
        if (PlayerPrefs.GetInt("FirstGame") != 1)
        {
            PlayerPrefs.SetInt("Money", 0);
            PlayerPrefs.SetInt("Score", 0);

            PlayerPrefs.SetInt("Boots", 0);
            PlayerPrefs.SetInt("Bike", 0);
            PlayerPrefs.SetInt("Car", 0);
            PlayerPrefs.SetInt("Plane", 0);

            PlayerPrefs.SetInt("FirstGame", 1);
        }
    }

    void Start()
    {
        Time.timeScale = 1;

        soundClick = GameObject.Find("Sound_Click").GetComponent<AudioSource>();
        soundMenu = GameObject.Find("Sound_Menu").GetComponent<AudioSource>();
        soundLoading = GameObject.Find("Sound_Loading").GetComponent<AudioSource>();
        soundRain = GameObject.Find("Sound_Rain").GetComponent<AudioSource>();

        iconMoney.text = PlayerPrefs.GetInt("Money").ToString();
        iconScore.text = PlayerPrefs.GetInt("Score").ToString();
    }

    void Update()
    {
        if (isLoading)
        {
            timerLoading -= Time.deltaTime;

            if (timerLoading <= 0.0f)
            {
                SceneManager.LoadScene("Game");
            }
        }
    }

    public void Play()
    {
        soundClick.Play();
        soundMenu.Stop();
        soundRain.Stop();
        soundLoading.Play();

        isLoading = true;
        loading.SetActive(true);
    }

    public void Shop()
    {
        soundClick.Play();

        shop.SetActive(true);
    }

    public void Close()
    {
        soundClick.Play();

        shop.SetActive(false);
    }

    public void Score()
    {
        soundClick.Play();
    }
}