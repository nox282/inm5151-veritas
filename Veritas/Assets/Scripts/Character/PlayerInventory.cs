using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Veritas;

public class PlayerInventory : MonoBehaviour, IInventory<Item> {

	void Awake(){
		inventory = new List<Item>(12);
        for (int i = 0; i < 12; i++){
            inventory.Add(new Item("None"));
        }
	}

//IIventory Impementation
	private List<Item> oldInventory;

	private List<Item> inventory;
	public List<Item> Inventory{ get { return inventory; } set{inventory = value;}}

	// Returns true if Inventory have this item
	public bool isThere(Item item){
		return inventory.Contains(item);
	}

	public bool isThereTypeOf(Item item) {
		return true; 			//TODO: Implement
	}

	// Adds item to the Inventory
	public void receive(Item item){
        for (int i = 0; i < 12; i++)
        {
            if (inventory[i].itemName == "None"){
                inventory[i] = item;
                return;
            }
        }
        Debug.Log("L'inventaire est plein! Impossible de ramasser l'objet!"); // To FIX
	}

	public void receive(List<Item> items){
		foreach(Item i in items){
			receive(i);
		}
	}

	// Removes everything from the Inventory
	public void drop(){
		inventory.Clear();
	}

	public void drop(Item item){
		inventory.Remove(item);
	}

	// Removes everything of the type of this item
	public void dropAllOf(Item item){
		//inventory.RemoveAll(a => typeof(a) == typeof(item));
		return;				//TODO: Implement
	}
	
	public void sortByType() {
		oldInventory = inventory;
		inventory.Sort((a,b) => a.GetType().FullName.CompareTo(b.GetType().FullName));
	}

	public void revertSorting(){
		inventory = oldInventory;
	}

	// Returns the reference to an item
	public Item take(Item item){
		Item ret = inventory.Find(x => x == item);
		return ret;
	}

	public void use(Item item){
		Item i = inventory.Find(x => x == item);
		if(i != null)
			i.use();
	}
}
