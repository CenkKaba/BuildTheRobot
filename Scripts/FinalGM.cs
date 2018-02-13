using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalGM : MonoBehaviour {

	public GameObject finalUI;

	IEnumerator enableFinalUI(){
		yield return new WaitForSeconds (97f);
		finalUI.SetActive (true);
	}


	public void restartGame(){
		SceneManager.LoadScene ("MainScene");
	}

	public void exitGame (){
		Application.Quit();
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (enableFinalUI ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
