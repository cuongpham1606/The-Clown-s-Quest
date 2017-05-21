using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

	void OnTriggerEnter (Collider other){
		StartCoroutine (Die ());
	}

	private IEnumerator Die(){
		yield return new WaitForSeconds (0.2f);
		Application.LoadLevel (Application.loadedLevel);
	}
}
