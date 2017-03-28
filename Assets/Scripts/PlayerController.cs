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

	private bool canJump = false;

	// Use this for initialization
	void Start () {
		rb = player.GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (canJump && (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow))) {
			moveUp ();
		} else if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			moveLeft ();
		} else if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			moveRight ();
		} else if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
			createShield ();
		}
	}


	public void moveUp(){
		rb.AddForce(new Vector3(0, upforce, 0));
	}
	public void moveRight(){
		rb.AddForce(new Vector3(movespeed, 0, 0));
	}
	public void moveLeft(){
		rb.AddForce(new Vector3(-movespeed, 0, 0));
	}
	public void createShield(){
//		Destroy(Instantiate(shield, 
//			new Vector3(transform.position.x, transform.position.y+2, 0),
//			Quaternion.Euler(-90, 30, 0))
//		as Transform;
//		(newShield.gameObject, 5);

		var newOne = Instantiate (shield, 
			             new Vector3 (transform.position.x, transform.position.y + 2, 0),
			             Quaternion.Euler (-90, 30, 0));
		Destroy(newOne.gameObject, 1);
	}



	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "DeadZone") {
			Debug.Log ("Deadzoned");
			paintSpawner.GetComponent<PainSpawner> ().StopSpawningPaint ();
            ScoreManager.instance.StopScore();
            SceneManager.LoadScene("GameOver");
		}

	}

	void OnCollisionEnter2D (Collision2D other) 
	{
		
		if (other.gameObject.tag == "Platform") {
			canJump = true;
		}

	}

	void OnCollisionExit2D (Collision2D other) 
	{
		if (other.gameObject.tag == "Platform") {
			canJump = false;
		}
	}
}
