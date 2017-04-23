using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
    public PlayerInventory inventory;
    public Dictionary<GameObject, Item> slots;

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
            Color tmp;

            if(slot.Value.itemName == "None"){
                tmp = Color.white;
            }else{
                tmp = slot.Value.color;
            }
            slot.Key.GetComponent<Image>().color = tmp;
            slot.Key.GetComponentInChildren<Text>().text = slot.Value.nbItems == 0 ? "" : slot.Value.nbItems.ToString();
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
