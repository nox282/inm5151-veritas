using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Veritas;

public class InputManager : MonoBehaviour {

    public GameObject inventory;
    public GameObject player;
    public Button questUpdate;
    
    Client cl;
    PlayerController pl;
    bool showInventory = false;

	// Use this for initialization
	void Start () {
        inventory.SetActive(showInventory);
        
        pl = player.GetComponent<PlayerController>();
        cl = player.GetComponentInChildren<Client>();


        questUpdate.onClick.AddListener(delegate{
            UpdateQuests();
        });
	}

    // Update is called once per frame
    void Update()
    {
        pl.CanMove = !showInventory;
        if (Input.GetKeyDown(KeyCode.I))
        {
            showInventory = !showInventory;
            inventory.SetActive(showInventory);
        }
    }

    void UpdateQuests(){
        cl.RetrieveQuestsFromServer();
    }
}
