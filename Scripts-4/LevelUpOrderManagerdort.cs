using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpOrderManagerdort : MonoBehaviour {
	public List<Objectsdort> myActiveObjects;

	public GMdort gameManager;
	public ActionPackdort AP;
	public GameObject PopUp;



	public void initiate(List<Objectsdort> activeObjects){

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


	IEnumerator playLevelUpAnim(Objectsdort currentObject){
		//coroutine yaptım
		StartCoroutine(currentObject.setDecreaseLevel ());
		yield return new WaitForSeconds (1.55f);
		if (currentObject.count!=100 && currentObject.getLevel () >= 0) {
			PopUp.transform.position = currentObject.transform.position;
			PopUp.transform.Translate (-3.98f, 3.23f, 0f);
			PopUp.gameObject.SetActive (true);
			yield return new WaitForSeconds (2.9f);
			PopUp.gameObject.SetActive (false);
		}
	}
}
