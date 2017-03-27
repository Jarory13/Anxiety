using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text text;
    public int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Use this for initialization
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + score;
    }

  

    public void StopScore()
    {
        PlayerPrefs.SetInt("Score", score);
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }


    }
}