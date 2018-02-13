using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using System;

public class ActionPackdort : MonoBehaviour {


	public GMdort gameManager;

	public List<Objectsdort> activeObjects;
	public LevelUpOrderManagerdort LevelManager;

	public Objectsdort baby ;
	public Objectsdort wood;
	public Objectsdort egg;
	public Objectsdort fish;

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
		Objectsdort[] art =new Objectsdort[] {baby,wood,egg,fish};
		for (int i = 0; i < 4; i++) {
			if (art [i].getLevel() == 0) {
				art [i].deactivateObject ();
			}
		}
	}

	public List <Objectsdort> levelupArray = new List<Objectsdort> ();

	void Awake(){
		levelupArray.Add (baby);
		levelupArray.Add (wood);
		levelupArray.Add (egg);
		levelupArray.Add (fish);
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
