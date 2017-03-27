using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainSpawner : MonoBehaviour {

	public GameObject[] arrows;
	public float SpawnTime;
	private BoxCollider2D box;
	public float force;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		box = GetComponent<BoxCollider2D> ();
		StartSpawningPaint ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartSpawningPaint() {
		InvokeRepeating("SpawnPaint", 1.0f, SpawnTime);
	}

	public void StopSpawningPaint()
	{
		CancelInvoke("SpawnPaint");
	}

	void SpawnPaint() {
		float range = box.size.x / 2;
		range = 20;
		GameObject arrow = arrows [Random.Range (0, 3)];
	
		GameObject newArrow = Instantiate(arrow, 
			new Vector3(Random.Range(-range,range), transform.position.y-2, 0),
			Quaternion.Euler(45, 45, 0));

		rb = newArrow.GetComponent<Rigidbody2D> ();
		rb.AddForce(new Vector3(Random.Range(-force, force), -force, 0));
	}
}
