using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Veritas;

public class MonsterController : MonoBehaviour {
    public float speed;
    public Vector2 MovementRange;
    public int movementFrequency;
    public Goal goal;
    
    private int frameCount;
    private Vector2 positionTo;
    private Rigidbody2D body;

	
    void Start () {
        body = GetComponent<Rigidbody2D>();
		positionTo = transform.position;
        body.gravityScale = 0;
	}
	
    void Update () {
        frameCount++;
        if(frameCount > movementFrequency){
            frameCount = 0;
            positionTo = randomTarget();   
        }
        UpdatePosition();
	}

    private Vector2 randomTarget(){
        float x = Random.Range(-MovementRange.x, MovementRange.x);
        float y = Random.Range(-MovementRange.y, MovementRange.y);

        return new Vector2(
            transform.position.x + x,
            transform.position.y + y
        );
    }

    private void UpdatePosition(){
        transform.position = Vector2.MoveTowards(transform.position, positionTo, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector2(0, 0));
    }

}