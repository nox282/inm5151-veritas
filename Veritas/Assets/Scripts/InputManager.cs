using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Veritas;

public class InputManager : MonoBehaviour {

    public GameObject inventory;
    public GameObject server;
    public GameObject player;
    public GameObject mainMenu;
    public float transitionTime = 1f;
    Camera mainCamera;
    Client cl;
    PlayerController pl;
    bool showInventory = false;
    bool gameIsOn = false;
    bool transition = false;
    
    float readyToPlay = 0f;
    State currentState = State.MainMenu;

    public bool GameIsOn { get { return gameIsOn; } set { gameIsOn = value; } }

    public enum State
    {
        MainMenu,
        Play,
        Pause
    }

	// Use this for initialization
	void Start () {
        inventory.SetActive(showInventory);
        cl = server.GetComponent<Client>();
        pl = player.GetComponent<PlayerController>();
        mainCamera = Camera.main;
	}

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.MainMenu:
                MainMenuState();
                break;
            case State.Play:
                PlayState();
                break;
            case State.Pause:
                PauseState();
                break;
            default:
                break;
        }
    }

    void changeState(State to){
        switch (currentState) {
            case State.MainMenu:
                if(to == State.Play){
                    mainMenu.SetActive(false);
                    currentState = to;
                }
                break;
            case State.Play:
                if(to == State.Pause){
                    currentState = to;
                }
                break;
            case State.Pause:
                if (to == State.Play || to == State.MainMenu){
                    currentState = to;
                }
                break;
            default:
                Debug.Log("Bad state transition.");
                break;
        }
    }

    void MainMenuState()
    {
        mainMenu.SetActive(true);
        pl.CanMove = false;
        mainCamera.GetComponent<CameraController>().toFollow = mainMenu.transform;
        if (gameIsOn && !mainCamera.GetComponent<MenuFade>().fadeOut){
            changeState(State.Play);
            readyToPlay = Time.fixedTime + transitionTime;
            transition = true;
        }
    }

    void PlayState()
    {
        if (transition)
        {
            mainCamera.GetComponent<CameraController>().toFollow = player.transform;
            if (Time.fixedTime > readyToPlay){
                mainCamera.GetComponent<MenuFade>().fadeIn = true;
                transition = false;
            }
        }
        if (mainCamera.GetComponent<MenuFade>().fadeIn) return;
        pl.CanMove = true;
        showInventory = false;
        inventory.SetActive(showInventory);
        
        if (Input.GetKeyDown(KeyCode.I)){
            changeState(State.Pause);
        }
        if (Input.GetKeyDown(KeyCode.Q)){
            cl.RetrieveQuestsFromServer();
        }
    }

    void PauseState()
    {
        pl.CanMove = false;
        showInventory = true;
        inventory.SetActive(showInventory);
        if (Input.GetKeyDown(KeyCode.I)){
            changeState(State.Play);
        }
    }
}
