using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectsdort : MonoBehaviour {

	public GameObject Genel;
	ActionPackdort actio;
	public GameObject transferInitialDataAnim;

	public int guyNumber;
	public int myLevel =4 ;
	public bool isOnTheScreen = false; 
	public int selectedObject;

	public Objectsdort bir;
	public Objectsdort iki;
	public Objectsdort uc;
	public Objectsdort dort;

	public int count=1;

	public List <Sprite> LevelsOfObject = new List<Sprite> ();

	public List <GameObject> FirstsTimeline;
	public List <GameObject> SecondsTimeline;
	public List <GameObject> ThirdsTimeline;
	public List <GameObject> FourthsTimeline;


	public int getLevel (){
		return myLevel;
	}

	public void initiateFileTransferAnim(){
		StartCoroutine (transferInitialData ());
	}

	public IEnumerator transferInitialData(){
		transferInitialDataAnim.transform.position = gameObject.transform.position;
		transferInitialDataAnim.transform.Translate (-2.78f, 1.03f, 0f);
		transferInitialDataAnim.gameObject.SetActive (true);
		yield return new WaitForSeconds (1.55f);
		transferInitialDataAnim.gameObject.SetActive (false);
	}


	public void setSelectedObject(int i)
	{
		selectedObject = i;
	}


	public void FileAnimation()
	{		

		if (selectedObject == 1)
		{
			if (iki.isOnTheScreen)
			{
				FirstsTimeline [0].SetActive (true);
			}

			if (uc.isOnTheScreen)
			{
				FirstsTimeline [1].SetActive (true);
			}

			if (dort.isOnTheScreen)
			{
				FirstsTimeline [2].SetActive (true);
			}
			selectedObject = 0;
		}

		if (selectedObject == 2)
		{
			if (uc.isOnTheScreen)
			{
				SecondsTimeline [0].SetActive (true);
			}

			if (dort.isOnTheScreen)
			{
				SecondsTimeline [1].SetActive (true);
			}
			selectedObject = 0;
		}

		if (selectedObject == 3)
		{

			if (iki.isOnTheScreen)
			{
				ThirdsTimeline [0].SetActive (true);
				iki.deactivateObject ();
				iki.count = 100;
			}

			if (dort.isOnTheScreen)
			{
				ThirdsTimeline [1].SetActive (true);
			}
			selectedObject = 0;
		}

		if (selectedObject == 4)
		{

			if (iki.isOnTheScreen)
			{
				FourthsTimeline [0].SetActive (true);
			}

			if (uc.isOnTheScreen)
			{
				FourthsTimeline [1].SetActive (true);
				uc.deactivateObject ();
				uc.count = 100;
			}
			selectedObject = 0;
		}
	}

	public IEnumerator setDecreaseLevel (){

		yield return StartCoroutine (spriteChange ());
		FileAnimation ();
		if (count != 100) {
			if (myLevel > 0) {
				myLevel--;
			}
		}	
	}

	public IEnumerator spriteChange(){
		yield return new WaitForSeconds (1.5f);
		if (count <= LevelsOfObject.Count) {
			this.GetComponent<SpriteRenderer> ().sprite = LevelsOfObject [count - 1];
			count++;
		}

	}

	public void ClickMe(){
		activateObject ();
		StartCoroutine (actio.handleLevelAndInteraction (gameObject.name));
	}   

	public void displayLevel(){
		Debug.Log ("I am " + name + " and my level is: " + myLevel);
	}

	void activateObject(){
		isOnTheScreen = true;
	}

	//this is not deactivate as SetActive(false) but is a block for further levelling up
	public void deactivateObject(){
		isOnTheScreen = false;
	}

	void Awake(){
		actio = Genel.GetComponent<ActionPackdort> ();
	}
}
