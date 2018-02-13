using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverLevelScr : MonoBehaviour {

	public Objects Object ;

	public int defaultLevel ;
	bool textAltered = false;
	Text textbox;

	void Awake()
	{
		textbox = GetComponent<Text> ();
	}
	void Update(){
		if (Object.getLevel () == 0 && !textAltered) {
			textbox.text += " Lvl: Max ";
			textAltered = true;
		} else if (Object.getLevel () != 0 && !textAltered){
			textbox.text += " Lvl: " + (defaultLevel - Object.getLevel ());
			textAltered = true;
		}

	}

}
