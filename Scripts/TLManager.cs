using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TLManager : MonoBehaviour {

	public List<Objects> myActiveObjects;
	public List<PlayableDirector> firstGuysTLs;
	public List<PlayableDirector> secondGuysTLs;
	public List<PlayableDirector> thirdGuysTLs;
	public List<PlayableDirector> fourthGuysTLs;
	public List<PlayableDirector> fifthGuysTLs;
	public List<PlayableDirector> sixthGuysTLs;

	int mainGuy;

	bool[] myArray = new bool[]{ false, false, false, false, false, false};

	public IEnumerator playTLs(List<Objects> activeObjects){
		myActiveObjects = activeObjects;
		mainGuy = myActiveObjects [0].guyNumber;
		myArray [mainGuy] = false;
		for(int i=2;i<=myActiveObjects.Count;i++){
			myArray[myActiveObjects[i-1].guyNumber] = true;
		}
		//to wait finish prev for loop just to be safe
		yield return new WaitForSeconds (1f);

		yield return StartCoroutine (initiateTLs ());


	}

	public IEnumerator initiateTLs(){
		
		if (mainGuy == 1) {
			for(int i=0;i<6;i++){
				if (myArray [i] == true && i!=1) {
					firstGuysTLs [i+1].Play ();
				}
			}
			yield return new WaitForSeconds (1f);
		} else if (mainGuy == 2) {
			for(int i=0;i<6;i++){
				if (myArray [i] == true && i!=2) {
					secondGuysTLs [i+1].Play ();
				}
			}
			yield return new WaitForSeconds (1f);
		} else if (mainGuy == 3) {
			for(int i=0;i<6;i++){
				if (myArray [i] == true && i!=3) {
					thirdGuysTLs [i+1].Play ();
				}
			}
			yield return new WaitForSeconds (1f);
		} else if (mainGuy == 4) {
			for(int i=0;i<6;i++){
				if (myArray [i] == true && i!=4) {
					fourthGuysTLs [i+1].Play ();
				}
			}
			yield return new WaitForSeconds (1f);
		} else if (mainGuy == 5) {
			for(int i=0;i<6;i++){
				if (myArray [i] == true && i!=5) {
					fifthGuysTLs [i+1].Play ();
				}
			}
		} else if (mainGuy == 6) {
			for(int i=0;i<6;i++){
				if (myArray [i] == true && i!=6) {
					sixthGuysTLs [i+1].Play ();
				}
			}
			yield return new WaitForSeconds (1f);
		} else {
			Debug.Log("Thast awkward. Main guy couldnt be found...");
			yield return new WaitForSeconds (1f);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
