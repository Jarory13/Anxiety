using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float lerpRate;
	private Vector3 offset;
	public int score;

	void Start ()
	{
		offset = transform.position - player.transform.position;
	}

	void Update ()
	{
//		transform.position = player.transform.position + offset;
		follow();
	}

	void follow() {
		Vector3 pos = transform.position;
		Vector3 targetPos = player.transform.position + offset;
		pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
		transform.position = pos;
	}
}