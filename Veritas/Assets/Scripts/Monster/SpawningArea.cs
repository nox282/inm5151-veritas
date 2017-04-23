using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningArea : MonoBehaviour {

    public Vector2 position;
    public float radius;

	void Start () {
		position = transform.localPosition;
        radius = transform.lossyScale.x;

        transform.localScale = new Vector3(1, 1, 1);
	}
}
