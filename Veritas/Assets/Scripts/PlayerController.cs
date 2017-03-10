using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerController script must be added to the player GameObject
public class PlayerController : MonoBehaviour {

    //private Rigidbody body;
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
            Vector2 clicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            positionTo = new Vector2(clicked.x, clicked.y);
        }
        body.position = Vector2.MoveTowards(body.position, getDirections(body.position, positionTo, 0.2f), Time.deltaTime*2f);
        //getDirections(body.position, positionTo);


    }

    Vector2 getDirections(Vector2 bPos, Vector2 tPos, float precision)
    {
        Vector2 relPos = tPos - bPos;
        Vector2 toReturn = bPos;
        float coef = 0.5f;
        float x = relPos.x;
        float y = relPos.y;

        if ((Math.Abs(x) + Math.Abs(y)) < precision) return bPos;

        if (x <= 0 && Math.Abs(x * coef) >= Math.Abs(y)) {
            //Debug.Log("2");
            toReturn.x -= 10;
        }else if (x > 0 && Math.Abs(x * coef) >= Math.Abs(y)) {
            //Debug.Log("4");
            toReturn.x += 10;
        }
        else if (y >= 0 && Math.Abs(x * coef) < Math.Abs(y)) {
            //Debug.Log("1");
            toReturn.y += 10;
        }
        else {
            //Debug.Log("3");
            toReturn.y -= 10;
        }
        return toReturn;
    }

    // Method that Spawn the player somewhere on the map
    void Spawn() {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision!!  ");
    }
}
