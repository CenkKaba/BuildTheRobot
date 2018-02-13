using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class RestartSc : MonoBehaviour {

	public PlayableDirector TL;

	public void initiateGame(){
		TL.Play ();
	}

	public void restartGame () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void loadThreeObjectsLevel(){
		SceneManager.LoadScene ("ThreeObjectsScene");
	}
	public void loadFourObjectsLevel(){
		SceneManager.LoadScene ("FourObjectsScene");
	}
	public void loadMainScene(){
		SceneManager.LoadScene ("MainScene");
	}

	public void quitGame(){
		Application.Quit ();
	}




}
