using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
	public Button startButton;

	void Start(){
		Button btn = startButton.GetComponent<Button> ();
		btn.onClick.AddListener (LoadLevel1);
	
	}

	void LoadLevel1(){
		Application.LoadLevel ("Level1");
	}

}
