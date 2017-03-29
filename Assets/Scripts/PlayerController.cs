using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public GameObject player;
	public GameObject paintSpawner;
	public GameObject platform;
	public GameObject shield;
	public float movespeed;
	public float upforce;
	private Rigidbody2D rb;
    private int jumpCount = 0;
	private bool canJump = true;

	// Use this for initialization
	void Start () {
		rb = player.GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
			moveUp ();
		} else if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			moveLeft ();
		} else if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			moveRight ();
		} else if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
			createShield ();
		} else if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
	}


	public void moveUp(){
        if (jumpCount < 4)
        {
            rb.AddForce(new Vector3(0, upforce, 0));
            jumpCount++;
        }
	}
	public void moveRight(){
		rb.AddForce(new Vector3(movespeed, 0, 0));
	}
	public void moveLeft(){
		rb.AddForce(new Vector3(-movespeed, 0, 0));
	}

	public void createShield(){

		var newOne = Instantiate (shield, 
			             new Vector3 (transform.position.x, transform.position.y + 2, 0),
			             Quaternion.Euler (-90, 30, 0));
		Destroy(newOne.gameObject, 1);
	}



	void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "DeadZone")
        {
            paintSpawner.GetComponent<PainSpawner>().StopSpawningPaint();
            ScoreManager.instance.StopScore();
            SceneManager.LoadScene("GameOver");
        }
	}

	void OnCollisionEnter2D (Collision2D other) 
	{
		
		if (other.gameObject.tag == "Platform") {
            jumpCount = 0;
		}

	}

	void OnCollisionExit2D (Collision2D other) 
	{
		if (other.gameObject.tag == "Platform") {
            
		}
	}
}
