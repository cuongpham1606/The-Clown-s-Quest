using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class NextLevel : MonoBehaviour {

		public GameObject player;

		private FirstPersonController firstPersonController;

		void Start () {
			firstPersonController = player.GetComponent<FirstPersonController> ();
		}

		void OnTriggerEnter (Collider other){
			StartCoroutine (LoadNextLevel ());
		}

		private IEnumerator LoadNextLevel(){
			firstPersonController.isDying = true;
			yield return new WaitForSeconds (2f);
			int i = Application.loadedLevel;
			Application.LoadLevel(i + 1);
		}
	}
}
