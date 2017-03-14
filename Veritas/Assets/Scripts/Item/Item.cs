using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Veritas;

public class Item : MonoBehaviour, IItem {
	public string itemName;
	public void use(){
		Debug.Log("Item used");
	}
}