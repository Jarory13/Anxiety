using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

    public GameOverManager instance;
    public Text gameOverText;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
    }
    
	// Use this for initialization
	void Start () {
        gameOverText.text = ScoreManager.instance.score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        gameOverText.text = ScoreManager.instance.score.ToString();
    }
}
