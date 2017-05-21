using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour {
	public Button mainMenuButton;
	// Use this for initialization
	void Start () {
		Button btn = mainMenuButton.GetComponent<Button> ();
		btn.onClick.AddListener (BackToStartScene);
	}
	
	void BackToStartScene(){
		Application.LoadLevel ("StartScene");
	}
		
}
