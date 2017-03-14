using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Veritas;

// PlayerController script must be added to the player GameObject
public class PlayerController : MonoBehaviour, ICharacter {
    public Vector2 tooltipOffset;
    public Vector2 tooltipSize;
    public float speed = 1.5f;
    public float heightOffset;


    //Flags
    private bool bringUpToolTip;    //true: display tooltip on player
    private bool canPickup;          //true: player can pick up an Item 

    private Rigidbody2D body;
    private Vector2 positionTo;

	void Start () {
        body = GetComponent<Rigidbody2D>();
        positionTo = transform.position;

        body.gravityScale = 0;
        Spawn();

        bag = GetComponentInChildren<PlayerInventory>();
	}
	
    // Listen for clicks to move the player around
	void Update () {
        if (Input.GetMouseButton(0)) {
            UpdateDestination(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            pickup();
        }
        UpdatePosition();
    }

    void UpdateDestination(Vector2 clicked){
        positionTo = new Vector2(clicked.x, clicked.y + heightOffset);
    }

    void UpdatePosition(){
        transform.position = Vector2.MoveTowards(body.position, positionTo, speed * Time.deltaTime);
        //TODO : Change this OR change boxcollider2d to polygon which will be a circle
        transform.rotation = Quaternion.Euler(new Vector2(0, 0));
    }

    // Method that Spawn the player somewhere on the map
    void Spawn() {

    }


    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("walls"))
            positionTo = transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision){
        bringUpToolTip = true;
        if(collision.gameObject.CompareTag("pickUps")){
            canPickup = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        bringUpToolTip = false;
        if(collision.gameObject.CompareTag("pickUps")){
            canPickup = false;
        }
    }

    void OnGUI(){
        if(bringUpToolTip){
            Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);
            pos += tooltipOffset;

            GUI.Box(new Rect(pos.x, pos.y, tooltipSize.x, tooltipSize.y), "Appuies sur espace pour ramasser!");
        }
    }

//ICharacter Implementation

    private String playerName;
    public PlayerInventory bag;
    public PlayerInventory equipement;
    public PlayerInventory questLog;

    public String Name {
        get{return playerName;}
        set{playerName = value;}
    }

    // Returns the type of cell the character is standing on;
    public GameObject scan(){
        Collider2D col = GetComponent<Collider2D>();
        Vector2 target = col.transform.position;
        target.y -= col.bounds.extents.y + 0.1f;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit.collider != null)
            return hit.collider.gameObject;
        return null;
    }

    public GameObject[] scanAround(){
        GameObject [] ret = {scan()};
        return ret;         //TODO: Implement
    }
    
    private void pickup(){
        if(!canPickup) return;

        GameObject item = scan();
        if(item == null) return;

        pickUp(item.GetComponent<Item>());
        Debug.Log(item.GetComponent<Item>().itemName);
        if(item != gameObject)
            Destroy(item);

        bringUpToolTip = false; // TODO: fix that
        canPickup = false;      // TODO: fix that
    }

    // Character picks up something he is standing on
    public void pickUp(Item i){
        bag.receive(i);
    }

    // Assign Quest to Character's QuestLog
    public void pickUp(Quest q) {return;}  //TODO: Implement
    public void drop(Item i) {bag.drop(i);}    //TODO: Implement
    public void drop(Quest q) {return;}    //TODO: Implement
    public void equip(Item i) {return;}    //TODO: Implement
    public void unequip(Item i) {return;} //TODO: Implement
}