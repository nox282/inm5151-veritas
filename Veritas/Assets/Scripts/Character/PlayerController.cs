using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Veritas;

// PlayerController script must be added to the player GameObject
public class PlayerController : MonoBehaviour, ICharacter, ISendServer {

    public Vector3 tooltipOffset;
    public Vector2 tooltipSize;
    public float speed = 1.5f;
    public float heightOffset;

    //Flags
    private bool bringUpToolTip;     //true: display tooltip on player
    private bool canPickup;          //true: player can pick up an Item 
    private bool canMove;

    public bool CanMove { get { return canMove; } set { canMove = value; } }

    private Rigidbody2D body;
    private Vector2 positionTo;
    private Animator anim;
 
    public bool north;
    public bool south;
    public bool east;
    public bool west;

    public bool p_north;
    public bool p_south;
    public bool p_east;
    public bool p_west;

    public bool isMoving;

    private void Awake(){
        bag = GetComponentInChildren<PlayerInventory>();
    }

    void Start () {
        ApplicationManager am = GameObject.FindWithTag("applicationManager").GetComponent<ApplicationManager>();
        body = GetComponent<Rigidbody2D>();
        tooltipOffset = new Vector3(0.3f, 1f, 0);
        canMove = true;
        body.gravityScale = 0;
        anim = transform.GetComponent<Animator>();
        Spawn();

        transform.position = am.playerPosition;
        positionTo = transform.position;
	}
	
    // Listen for clicks to move the player around
	void Update () {
        if (canMove){
            if (Input.GetMouseButton(0)){
                UpdateDestination(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            if (Input.GetKeyDown(KeyCode.Space)){
                pickup();
            }
        }
        UpdatePosition();

        UpdateHeading();
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("north", north);
        anim.SetBool("south", south);
        anim.SetBool("east", east);
        anim.SetBool("west", west);

        if(DirectionIsDifferent())
            anim.SetTrigger("changeDirection");
    }

    void UpdateDestination(Vector2 clicked){
        positionTo = new Vector2(clicked.x, clicked.y + heightOffset);
    }

    void UpdatePosition(){
        isMoving = !(((Vector2) transform.position) == positionTo);

        transform.position = Vector2.MoveTowards(body.position, positionTo, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector2(0, 0));
    }

    // Method that Spawn the player somewhere on the map
    void Spawn() {

    }

    private void UpdateHeading(){
        float angle = heading();
        saveDirectionState();
        resetDirections();

        if(angle > 0.0f && angle < 90.0f){
            north = true;
        } else if(angle >= 90.0f && angle <= 180.0f){
            east = true;
        } else if(angle >= 0.0f || angle > -90.0f){
            west = true;
        } else{
            south = true;
        }
    }

    private void resetDirections(){
        north = false;
        south = false;
        east = false;
        west = false;
    }

    private void saveDirectionState(){
        p_north = north; 
        p_south = south;
        p_east = east;
        p_west = west;
    }

    private bool DirectionIsDifferent(){
        return  !(north == p_north &&
                  south == p_south &&
                  east  == p_east  &&
                  west  == p_west);
    }

    private float heading(){
        Vector2 reference = new Vector2(0, 1);
        Vector2 direction = new Vector2(
            positionTo.x - transform.position.x,
            positionTo.y - transform.position.y
        );

        float sign = (direction.x < reference.x)? -1.0f: 1.0f;
        return Vector2.Angle(reference, direction) * sign;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("monster")){
            ApplicationManager am = GameObject.FindWithTag("applicationManager").GetComponent<ApplicationManager>();
            am.currentMonster = collision.gameObject.GetComponent<MonsterController>();
            am.playerPosition = transform.position;
            SceneManager.LoadScene("Combat", LoadSceneMode.Single);
        }
    }

    private void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject.CompareTag("walls") || collision.gameObject.CompareTag("pickUps"))
        {
            positionTo = transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D collision){
        if (collision.gameObject.CompareTag("pickUps")){
            canPickup = true;
            bringUpToolTip = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("pickUps")){
            canPickup = false;
            bringUpToolTip = false;
        }
    }

    void OnGUI(){
        if(bringUpToolTip){
            Vector2 pos = Camera.main.WorldToScreenPoint(transform.position + tooltipOffset);
            GUI.Box(new Rect(pos.x, Screen.height - pos.y, tooltipSize.x, tooltipSize.y), "Appuies sur espace pour ramasser!");
        }
    }

//ICharacter Implementation

    private string playerName;
    public PlayerInventory bag;
    public PlayerInventory equipement;
    public PlayerInventory questLog;

    public string Name {
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

        pickUp(new Item(item.GetComponent<ItemCollision>().itemName, item.GetComponent<SpriteRenderer>().color));
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
        dict.Add("PlayerName", this.playerName);
        dict.Add("PosX", (transform.position.x).ToString());
        dict.Add("PosY", (transform.position.y).ToString());
        return dict;
    }
}