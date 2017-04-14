using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Veritas;

public class Item : IItem {
	public string itemName;
    public int nbItems = 1;

    public Item(string itemName){
        this.itemName = itemName;
    }

    public Item(string itemName, int nbItems){
        this.itemName = itemName;
        this.nbItems = nbItems;
    }

	public void use(){
		Debug.Log("Item used");
	}
}