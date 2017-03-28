using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public bool gameOver = true;
 

	// Use this for initialization
	void Start () {
		//DontDestroyOnLoad(this.gameObject);
		//if (instance == null)
		//{
		//	instance = this;
		//} else {
		//	Destroy(this.gameObject);
		//}
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
      
    }

    public void LoadLevel(string level) {
        Debug.Log("Loading level");
        SceneManager.LoadScene(level);
    }

    public void quitGame() {
        Application.Quit();
    }
}
