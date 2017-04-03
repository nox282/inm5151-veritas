using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    PlayerInventory inventory;
    Dictionary<GameObject, Item> slots;

	// Use this for initialization
	void Start () {
        slots = new Dictionary<GameObject, Item>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().bag;
        InitSlots();
    }
	
	// Update is called once per frame
	void Update () {
        // Eventuellement, on update le pannel seulement a la demade d'affichage
        UpdateUI();
    }

    private void InitSlots(){
        int inventoryIndex = 0;
        foreach (Transform slot in transform){
            slots.Add(slot.gameObject, inventory.Inventory[inventoryIndex]);
            inventoryIndex++;
        }
    }

    private void UpdateUI(){
        UpdateSlots();
        foreach (KeyValuePair<GameObject, Item> slot in slots){
            //Debug.Log(slot.Value.itemName);
            if (slot.Value.itemName != "None"){
                slot.Key.GetComponent<Image>().color = new Color(170, 0, 0, 255);
            }
        }
    }

    private void UpdateSlots(){
        int inventoryIndex = 0;
        slots.Clear();
        foreach (Transform slot in transform){
            slots.Add(slot.gameObject, inventory.Inventory[inventoryIndex]);
            inventoryIndex++;
        }
    }
}
