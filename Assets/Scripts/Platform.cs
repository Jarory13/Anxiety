using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	private int health = 6;
	//Use the fadder to track how much the alpha channel should descrease on hit
	private float fadder = 0.2f;
	private Renderer rend;


	// Use this for initialization
	void Start () {
		rend = this.gameObject.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D other) 
	{
		
		if (other.gameObject.tag == "Paint") {
			//Get a reference to the Paint's material 
			Renderer otherRend = other.gameObject.GetComponent<Renderer>();

			//Create a slighlty more tranparent color
			Color newColor = new Color (otherRend.material.color.r, otherRend.material.color.g,
				                 otherRend.material.color.b, otherRend.material.color.a - fadder);

			Color newEmission = new Color (otherRend.material.color.r- fadder, otherRend.material.color.g- fadder,
                otherRend.material.color.b - fadder, otherRend.material.color.a - fadder);

			//Let the platform lose some of it's health
			health--;

		
			//Let's set our platform's color to be the same as the new color 
			
			rend.material.SetColor("_EmissionColor",
				newEmission);

			rend.material.SetColor("_Color",
				newColor);
							

			fadder = fadder + 0.1f;
			if (fadder > 1.0f) {
				fadder = 0.2f;
			}

	
		}
		if (health <= 0) {
			Destroy (gameObject);
		}
	}

}
