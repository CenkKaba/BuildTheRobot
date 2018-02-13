using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour {

	public GameObject Genel;
	ActionPack actio;

	public int guyNumber;
	public int myLevel =4 ;
	public bool isOnTheScreen = false; 

	public int count=1;

	public Objects bir;
	public Objects iki;

	public GameObject TL;
	public GameObject transferInitialDataAnim;
	public int selectedObject = 0;

	public List <Sprite> LevelsOfObject = new List<Sprite> ();

	public int getLevel (){
		return myLevel;
	}


	public void initiateFileTransferAnim(){
		StartCoroutine (transferInitialData ());
	}

	public IEnumerator transferInitialData(){
		transferInitialDataAnim.transform.position = gameObject.transform.position;
		transferInitialDataAnim.transform.Translate (-3.35f, 1.3f, -3f);
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
				TL.SetActive (true);
			}
			selectedObject = 0;
		}
	}

	public IEnumerator setDecreaseLevel (){
		//kendininkini change sonra WAİT sonra aktifleri check sonra timelinelarını oynat sonra biraz aralı
		//onları oynat

		yield return StartCoroutine (spriteChange ());
		FileAnimation ();

		if (myLevel > 0) {
			myLevel--;
		}	
	}

	public IEnumerator spriteChange(){
		yield return new WaitForSeconds (2f);
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
		actio = Genel.GetComponent<ActionPack> ();
	}

}
