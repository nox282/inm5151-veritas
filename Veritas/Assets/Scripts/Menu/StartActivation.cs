using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartActivation : MonoBehaviour {

    public GameObject eventManager;
    public GameObject pauseMenu;
    Text inputFieldtxt;
    Camera mainCam;


	// Use this for initialization
	void Start () {
        inputFieldtxt = GameObject.FindGameObjectWithTag("charName").GetComponentInChildren<Text>();
        mainCam = Camera.main;
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

    void startTransition(){
        mainCam.GetComponent<MenuFade>().fadeOut = true;
        eventManager.GetComponent<InputManager>().GameIsOn = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Name = inputFieldtxt.text;
        pauseMenu.GetComponent<Text>().text = inputFieldtxt.text;
    }
}
