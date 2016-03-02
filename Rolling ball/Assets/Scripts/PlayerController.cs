﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public Text countText;
	public Text winText;
	private Rigidbody rb;
	private int count;
	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}
	 IEnumerator SpeedTime(){
		print (Time.time);
		yield return new WaitForSeconds(5.0f);
		print (Time.time);
	}
	void StopSpeed(){
		SpeedTime ();
		speed = 10;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("pick up")) {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
			if (count >= 11) {
				winText.text = "You win!";
			}
		}
		if (other.gameObject.CompareTag ("speed boost")) {
			other.gameObject.SetActive (false);
			speed = 20;




		}

	}

	void SetCountText(){
		countText.text = "Count: " + count.ToString();
	}
}
