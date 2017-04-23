using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkName : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ApplicationManager app = GameObject.FindGameObjectWithTag("applicationManager").GetComponent<ApplicationManager>();
        GetComponentInChildren<Text>().text = app.playerName;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
