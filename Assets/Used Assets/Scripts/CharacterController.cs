using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	public float initialSpeed = 7.0f;

	void Start(){
		Cursor.lockState = CursorLockMode.Locked;

	}

	void Update(){
		float speed;
		if (Input.GetKey ("left shift") || Input.GetKey ("right shift")) {
			speed = initialSpeed * 2;
		} else {
			speed = initialSpeed;
		}
		float translation = Input.GetAxis ("Vertical") * speed;
		float straffe = Input.GetAxis ("Horizontal") * speed;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;

		transform.Translate (straffe, 0, translation);

		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
