using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Veritas;

public class InputManager : MonoBehaviour {

    public GameObject inventory;
    public GameObject server;
    public GameObject player;
    Client cl;
    PlayerController pl;
    bool showInventory = false;

	// Use this for initialization
	void Start () {
        inventory.SetActive(showInventory);
        cl = server.GetComponent<Client>();
        pl = player.GetComponent<PlayerController>();
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            cl.RetrieveQuestsFromServer();
        }
    }
}
