using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class StartGM : MonoBehaviour {
	public PlayableDirector PD;

	public void startGame(){
		StartCoroutine (delayStart ());
	}

	IEnumerator delayStart(){
		PD.Play ();
		yield return new WaitForSeconds(1.75f);
		SceneManager.LoadScene ("MainScene");
	}
}
