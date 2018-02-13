using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPackuc : MonoBehaviour {

	public GMuc gameManager;

	public List<Objectsuc> activeObjects;
	public LevelUpOrderManageruc LevelManager;

	public Objectsuc baby ;
	public Objectsuc wood;
	public Objectsuc egg;

	public bool isCheckingForInteractions = false;

	public bool InteractionFieldIsNotFull = true;

	string selectedObjectName;



	//main function
	public IEnumerator handleLevelAndInteraction(string name){
		selectedObjectName = name;
		yield return new WaitForSeconds (0.1f);
		gameManager.getActiveButtons ();
		gameManager.disableButtons ();

		makeZeroLevelsNotAvailableForLevelUp ();
		levelUp ();

	}



	void makeZeroLevelsNotAvailableForLevelUp(){
		Objectsuc[] art =new Objectsuc[] {baby,wood,egg};
		for (int i = 0; i < 3; i++) {
			if (art [i].getLevel() == 0) {
				art [i].deactivateObject ();
			}
		}
	}

	public List <Objectsuc> levelupArray = new List<Objectsuc> ();

	void Awake(){
		levelupArray.Add (baby);
		levelupArray.Add (wood);
		levelupArray.Add (egg);
	}
	void Start(){

	}

	void levelUp(){
		activeObjects.Clear ();

		for (int i = 0; i < levelupArray.Count; i++) {
			if (levelupArray [i].isOnTheScreen && levelupArray [i].name == selectedObjectName) {
				activeObjects.Insert (0, levelupArray [i]);
			} else if (levelupArray [i].isOnTheScreen) {
				activeObjects.Add (levelupArray [i]);
			}
		}	
		LevelManager.initiate (activeObjects);
	}


	IEnumerator checkInteractions(){
		/*
		if (egg.getLevel () == 1 && egg.isOnTheScreen && baby.getLevel () < 4) {
			egg.deactivateObject ();
			InteractionFieldIsNotFull = false;

			egg.gameObject.SetActive (false);
			interactionList [0].SetActive (true);
			yield return new WaitForSeconds (11f);
			interactionList [0].SetActive (false);

			gameManager.enableButtons ();
		}	

		else if (egg.getLevel () == 0 && egg.isOnTheScreen && fish.getLevel () == 1) {
			egg.deactivateObject ();
			fish.deactivateObject ();
			InteractionFieldIsNotFull = false;

			yield return new WaitForSeconds (11f);
			fish.gameObject.SetActive (false);
			specialSprites [0].SetActive (false);
			interactionList [1].SetActive (true); 
			yield return new WaitForSeconds (7.5f);
			interactionList [1].SetActive (false);


			gameManager.enableButtons ();
		}
		else if (fish.getLevel () == 0 && egg.getLevel () == 1 && egg.isOnTheScreen) {
			egg.deactivateObject ();
			fish.deactivateObject ();
			InteractionFieldIsNotFull = false;

			egg.gameObject.SetActive (false);
			fish.gameObject.SetActive (false);
			interactionList [2].SetActive (true);
			yield return new WaitForSeconds (17f);
			interactionList [2].SetActive (false);

			gameManager.enableButtons ();
		} 
		else if (fish.getLevel () == 0 && fish.isOnTheScreen && box.getLevel () == 1 && box.isOnTheScreen) {
			box.deactivateObject ();
			fish.deactivateObject ();
			InteractionFieldIsNotFull = false;

			fish.gameObject.SetActive (false);
			box.gameObject.SetActive (false);
			interactionList [3].SetActive (true);
			yield return new WaitForSeconds (11f);
			interactionList [3].SetActive (false);

			gameManager.enableButtons ();
		} 
		else {
		*/			

		yield return new WaitForSeconds (0.001f);
		gameManager.enableButtons ();
		//	}

		if (gameManager.getCounter() <= 0) {
			Debug.Log ("Game is Over Called");
			gameManager.GameIsOver ();
		} 

	}

	void Update(){
		if (isCheckingForInteractions && InteractionFieldIsNotFull) {
			StartCoroutine (checkInteractions ());
			isCheckingForInteractions = false;
		} else if(isCheckingForInteractions && !InteractionFieldIsNotFull){
			isCheckingForInteractions = false;
			gameManager.enableButtons ();
		}
	}

}
