using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerController script must be added to the player GameObject
public class PlayerController : MonoBehaviour {

    private Rigidbody2D body;

    private Vector2 positionTo;

	void Start () {
        body = GetComponent<Rigidbody2D>();
        positionTo = body.position;
        Spawn();
	}
	
    // Listen for clicks to move the player around
	void Update () {
        if (Input.GetMouseButton(0)) {
            Vector3 clicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            positionTo = new Vector2(clicked.x, clicked.y);
        }
        body.position = Vector2.MoveTowards(body.position, positionTo, Time.deltaTime*3f);
	}

    // Method that Spawn the player somewhere on the map
    void Spawn() {

    }
}
