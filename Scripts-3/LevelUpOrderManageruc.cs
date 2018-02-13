using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class LevelUpOrderManageruc : MonoBehaviour {
	public List<Objectsuc> myActiveObjects;

	public GMuc gameManager;
	public ActionPackuc AP;
	public GameObject PopUp;



	public void initiate(List<Objectsuc> activeObjects){
		myActiveObjects = activeObjects;
		StartCoroutine (levelUp ());
	}

	IEnumerator levelUp(){

		for(int i=1;i<=myActiveObjects.Count;i++){
			yield return StartCoroutine (playLevelUpAnim (myActiveObjects[i-1]));
		}
		AP.isCheckingForInteractions = true;

		if (gameManager.getCounter() <= 0 && !AP.InteractionFieldIsNotFull) {
			gameManager.GameIsOver ();
		}
	}


	IEnumerator playLevelUpAnim(Objectsuc currentObject){
		//coroutine yaptım
		StartCoroutine(currentObject.setDecreaseLevel ());
		yield return new WaitForSeconds (1.55f);
		if (currentObject.getLevel () >= 0) {
			PopUp.transform.position = currentObject.transform.position;
			PopUp.transform.Translate (-3.98f, 3.23f, 0f);
			PopUp.gameObject.SetActive (true);
			yield return new WaitForSeconds (2.9f);
			PopUp.gameObject.SetActive (false);
		}
	}

}
