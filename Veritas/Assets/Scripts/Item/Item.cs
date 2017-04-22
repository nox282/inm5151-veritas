using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Veritas;

public class Item : IItem {
	public string itemName;
    public int nbItems = 1;
    public Color color;

    public Item(string itemName, Color color){
        this.itemName = itemName;
        this.color = color;
    }

    public Item(string itemName, int nbItems, Color color){
        this.itemName = itemName;
        this.nbItems = nbItems;
        this.color = color;
    }

	public void use(){
		Debug.Log("Item used");
	}
}