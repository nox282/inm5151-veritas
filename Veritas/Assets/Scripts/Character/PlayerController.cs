using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Veritas;

// PlayerController script must be added to the player GameObject
public class PlayerController : MonoBehaviour, ICharacter, ISendServer {
    public Vector3 tooltipOffset;
    public Vector2 tooltipSize;
    public float speed = 1.5f;
    public float heightOffset;


    //Flags
    private bool bringUpToolTip;    //true: display tooltip on player
    private bool canPickup;          //true: player can pick up an Item 
    private Vector2 pickupLocation;

    private Rigidbody2D body;
    private Vector2 positionTo;

    private void Awake(){
        bag = GetComponentInChildren<PlayerInventory>();
    }

    void Start () {
        body = GetComponent<Rigidbody2D>();
        positionTo = transform.position;
        pickupLocation = transform.position;
        tooltipOffset = new Vector3(0.3f, 1f, 0);

        body.gravityScale = 0;
        Spawn();
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

    private void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject.CompareTag("walls")){
            positionTo = transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("pickUps")){
            canPickup = true;
            bringUpToolTip = true;
            pickupLocation = collision.gameObject.GetComponent<PolygonCollider2D>().points[1];
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("pickUps")){
            canPickup = false;
            bringUpToolTip = false;
            pickupLocation = transform.position;
        }
    }

    void OnGUI(){
        if(bringUpToolTip){
            Vector2 pos = Camera.main.WorldToScreenPoint(transform.position + tooltipOffset);
            GUI.Box(new Rect(pos.x, Screen.height - pos.y, tooltipSize.x, tooltipSize.y), "Appuies sur espace pour ramasser!");
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
        if (hit.collider != null && hit.collider.gameObject.CompareTag("pickUps"))
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

        pickUp(new Item(item.GetComponent<ItemCollision>().itemName)); 
        Debug.Log("Picked up : " + item.GetComponent<ItemCollision>().itemName);
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

// ISendServer Interface
    public Dictionary<string, string> toDictionnary(){
        Dictionary<string, string> dict = new Dictionary<string, string>();
        dict.Add("PosX", (transform.position.x).ToString());
        dict.Add("PosY", (transform.position.y).ToString());
        return dict;
    }
}