using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeClownController : MonoBehaviour {

	public bool canRun = true;
	public Animator anim;
	public GameObject endPosition;
	public float walkSpeed;
	public float runSpeed;
	public float destroyAfter;

	private BoxCollider boxCollider; 

	private bool isMoving = false;


	void Start () {
		anim = GetComponent<Animator> ();
		boxCollider = GetComponent<BoxCollider> ();
		Vector3 startPos = transform.position;
	}

	void Update(){
		if (isMoving && transform.position != endPosition.transform.position) {
			if (canRun)
			this.transform.position = Vector3.Lerp (transform.position, endPosition.transform.position, runSpeed * Time.deltaTime);
			else this.transform.position = Vector3.Lerp (transform.position, endPosition.transform.position, walkSpeed * Time.deltaTime);
			}
	}

	void OnTriggerEnter (Collider other){

		if (canRun) {
			anim.SetTrigger ("isRunning");
		} else {
			anim.SetTrigger ("isWalking");
		}
		isMoving = true;
		StartCoroutine (DeleteObject ());
		boxCollider.enabled = false;
	}

	private IEnumerator DeleteObject(){
		yield return new WaitForSeconds (destroyAfter);
		gameObject.SetActive (false);
	}
}
