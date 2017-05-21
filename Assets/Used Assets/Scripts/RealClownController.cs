using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
	public class RealClownController : MonoBehaviour {

		public GameObject player;
		public bool isReal = true;

		public Animator anim;
		private FirstPersonController firstPersonController;
		private BoxCollider boxCollider;

		// Use this for initialization
		void Start () {
			anim = GetComponent<Animator> ();
			firstPersonController = player.GetComponent<FirstPersonController> ();
			boxCollider = GetComponent<BoxCollider> ();
		}

		void OnTriggerEnter (Collider other){
			anim.SetTrigger ("isTurningAround");
			if (isReal) {
				StartCoroutine (Die ());
			} else
				StartCoroutine (DollReveal ());

		}

		private IEnumerator Die(){
			firstPersonController.isDying = true;
			yield return new WaitForSeconds (1.2f);
			float rotateAngle = - player.transform.rotation.y;
			Quaternion target = Quaternion.Euler (0, rotateAngle, 0);
			this.transform.rotation = Quaternion.Slerp (transform.rotation, target, 0.1f); 
			anim.SetTrigger ("isScaring");
			yield return new WaitForSeconds (2f);
			Application.LoadLevel ("Level1");
		}

		private IEnumerator DollReveal(){
			firstPersonController.isDying = true;
			anim.SetTrigger ("isFallingOff");
			yield return new WaitForSeconds (2f);
			boxCollider.enabled = false;
			firstPersonController.isDying = false;
		}
	}
}