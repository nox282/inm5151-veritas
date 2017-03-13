using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerController script must be added to the player GameObject
public class PlayerController : MonoBehaviour {
    public Vector2 tooltipOffset;
    public Vector2 tooltipSize;
    public float speed = 1.5f;

    //true to display tooltip on player
    private bool bringUpToolTip;

    private Rigidbody2D body;
    private Vector2 positionTo;

	void Start () {
        body = GetComponent<Rigidbody2D>();
        positionTo = transform.position;

        body.gravityScale = 0;
        Spawn();
	}
	
    // Listen for clicks to move the player around
	void Update () {
        if (Input.GetMouseButton(0)) {
            UpdateDestination(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        UpdatePosition();
    }

    void UpdateDestination(Vector2 clicked){
        positionTo = new Vector2(clicked.x, clicked.y);
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
    }

    void OnTriggerExit2D(Collider2D collision){
        bringUpToolTip = false;
    }

    void OnGUI(){
        if(bringUpToolTip){
            Vector2 pos = Camera.main.WorldToScreenPoint(transform.position);
            pos += tooltipOffset;
            
            GUI.Box(new Rect(pos.x, pos.y, tooltipSize.x, tooltipSize.y), "Appuies sur espace pour ramasser!");
        }
    }
}