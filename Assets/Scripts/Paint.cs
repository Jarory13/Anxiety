using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "DeadZone") {
			Destroy (gameObject);
		} else if (col.gameObject.tag == "Shield"){
			Destroy (gameObject);
            ScoreManager.instance.score++;
			Debug.Log (ScoreManager.instance.score);
		}
	}


	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Platform") {
			Destroy (gameObject, 0.05f);
		}else if (col.gameObject.tag == "Player") {
			Destroy (gameObject);
			ScoreManager.instance.score++;
			Debug.Log (ScoreManager.instance.score);
		}
	}
}
