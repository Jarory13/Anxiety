﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public bool gameOver = true;
 

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
		if (instance == null)
		{
			instance = this;
		} else {
			Destroy(this.gameObject);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
      
    }

    public void LoadLevel(string level) {
        SceneManager.LoadScene(level);
    }
}