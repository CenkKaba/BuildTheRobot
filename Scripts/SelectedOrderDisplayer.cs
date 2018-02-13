using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedOrderDisplayer : MonoBehaviour {
	public Text babyText;
	public Text woodText;
	public Text eggText;
	public Text fishText;
	public Text boxText;
	public Text gunText;

	private int defaultCounter = 6;
	private int currentCounter = 6;

	public void babyOrderHandler(){
		currentCounter = this.gameObject.GetComponent<GM> ().counter;
		babyText.text = defaultCounter - currentCounter + " "; 
	}

	public void woodOrderHandler(){
		currentCounter = this.gameObject.GetComponent<GM> ().counter;
		woodText.text = defaultCounter - currentCounter + " "; 
	}

	public void eggOrderHandler(){
		currentCounter = this.gameObject.GetComponent<GM> ().counter;
		eggText.text = defaultCounter - currentCounter + " "; 
	}

	public void fishOrderHandler(){
		currentCounter = this.gameObject.GetComponent<GM> ().counter;
		fishText.text = defaultCounter - currentCounter + " "; 
	}

	public void boxOrderHandler(){
		currentCounter = this.gameObject.GetComponent<GM> ().counter;
		boxText.text = defaultCounter - currentCounter + " "; 
	}

	public void gunOrderHandler(){
		currentCounter = this.gameObject.GetComponent<GM> ().counter;
		gunText.text = defaultCounter - currentCounter + " "; 
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
