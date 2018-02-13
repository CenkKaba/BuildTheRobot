using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GM : MonoBehaviour {

	public GameObject SuccessfullyOver;
	public int counter;
	public bool isCorrectOrder = false;
	public bool isGameOver = false;

	public GameObject GameOverUICanvas;
	public RandomGameOverText GenerateText;

	public Objects baby;
	public Objects wood;


	public List<Button> Buttons;
	public List<Button> activeButtons;

	public List<GameObject> levelTexts;


	public void getActiveButtons(){
		for(int i=1; i<=Buttons.Count ; i++){
			if (Buttons[i-1].interactable) {
				activeButtons.Add (Buttons [i - 1]);
			}
		}
	}

	public void disableButtons (){
		for(int i=1; i<=activeButtons.Count ; i++){
			activeButtons [i - 1].interactable = false;

		}	
	}

	public void enableButtons (){
		for(int i=1; i<=activeButtons.Count ; i++){
			activeButtons [i - 1].interactable = true;
		}	
		activeButtons.Clear ();
	}
		
	public void GameIsOver(){
		isGameOver = true;
		if (baby.getLevel () == 0 && wood.getLevel () == 0) {
			isCorrectOrder = true;
		}
	}

	public int getCounter(){
		return counter;
	}

	public void decreaseCOunter(){
		counter--;
	}
	
	// Use this for initialization
	void Awake () {
		isCorrectOrder = false;
		isGameOver = false;
	}

	IEnumerator turnButtons(){
		for (int i = 1; i <= 2; i++) {
			yield return new WaitForSeconds (1f);
			levelTexts[i-1].SetActive (true);
		}
	}


	void playFinalScene(){
		SuccessfullyOver.SetActive (true);
	}
	
	void Update () {
		if (isGameOver && !isCorrectOrder) {
			GameOverUICanvas.SetActive (true);
			GenerateText.GenerateChangeText ();
			StartCoroutine (turnButtons ());
		} else if (isGameOver && isCorrectOrder) {
			// Play the final scene;
			isGameOver=false;
			playFinalScene ();
		}
	}
}
