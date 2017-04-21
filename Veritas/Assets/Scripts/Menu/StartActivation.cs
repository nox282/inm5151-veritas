using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartActivation : MonoBehaviour {

    Text inputFieldtxt;

	// Use this for initialization
	void Start () {
        inputFieldtxt = GameObject.FindGameObjectWithTag("charName").GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        onActivation(inputFieldtxt.text);
	}

    void onActivation(string text){
        if(text != ""){
            GetComponent<Button>().interactable = true;
        }else{
            GetComponent<Button>().interactable = false;
        }
    }
}
