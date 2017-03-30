using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Veritas;

public class Item : IItem {
	public string itemName;

    public Item(string itemName){
        this.itemName = itemName;
    }

	public void use(){
		Debug.Log("Item used");
	}
}