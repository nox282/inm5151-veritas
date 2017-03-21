using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform toFollow;
    public float stiffness;
    Vector3 from;
    Vector3 to;
    Vector3 velocity = Vector3.zero;

	void Start () {
        
	}
	
	void Update () {
        FollowPlayer();
    }

    void FollowPlayer(){
        from = transform.position;
        to = toFollow.position;
        to.z = from.z;
        transform.position = Vector3.SmoothDamp(from, to, ref velocity, stiffness);
    }
}
