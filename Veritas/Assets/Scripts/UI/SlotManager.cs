using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour {

    InventoryManager invManager;
    bool showInformation = false;

	// Use this for initialization
	void Start () {
        invManager = GetComponentInParent<InventoryManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseOver(){
        showInformation = true;
    }

    private void OnMouseExit(){
        showInformation = false;
    }

    void OnGUI()
    {
        if (showInformation)
        {
            Debug.Log("Show text : " + this.name);
            Vector2 pos = Camera.main.WorldToScreenPoint(transform.position + new Vector3(-1f,1f,0));
            GUI.Box(new Rect(pos.x, Screen.height - pos.y, 100f, 20f), invManager.slots[gameObject].itemName);
        }
    }
}
