using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public GameObject inventory;
    bool showInventory = true;

	// Use this for initialization
	void Start () {
        inventory.SetActive(showInventory);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I)){
            showInventory = !showInventory;
            inventory.SetActive(showInventory);
        }
	}
}
