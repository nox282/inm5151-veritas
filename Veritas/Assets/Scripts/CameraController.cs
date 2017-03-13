using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform toFollow;
    public float stiffness;
    Vector3 from;
    Vector3 to;

	void Start () {
        
	}
	
	void Update () {
        FollowPlayer();
    }

    void FollowPlayer(){
        from = transform.position;
        to = toFollow.position;
        to.z = from.z;
        transform.position = Vector3.Lerp(from, to, stiffness * Time.deltaTime);
    }
}
