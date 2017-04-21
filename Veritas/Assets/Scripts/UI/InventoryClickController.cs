using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryClickController : MonoBehaviour {

    bool onInventory;
    public bool OnInventory { get { return onInventory; } }

	// Use this for initialization
	void Start () {
        onInventory = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(onInventory);
	}

    private void OnMouseEnter(){
        onInventory = true;
    }
    private void OnMouseExit(){
        onInventory = false;
    }
}
