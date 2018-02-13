using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class LevelUpOrderManager : MonoBehaviour {

	public List<Objects> myActiveObjects;

	public GM gameManager;
	public ActionPack AP;
	public GameObject PopUp;



	public void initiate(List<Objects> activeObjects){
		
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


	IEnumerator playLevelUpAnim(Objects currentObject){

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
