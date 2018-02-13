using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomGameOverText : MonoBehaviour {

	public Text t;
	int index;

	string [] names = {"Ooops..", "Oh well..", "Next time.. Perhaps","Again..","Keep going","Almost there ","You can do it!"};

	public void GenerateChangeText(){
		t.text = names [index];
	}

	// Use this for initialization
	void Awake () {
		index = Random.Range (0, 7);
	}
}
