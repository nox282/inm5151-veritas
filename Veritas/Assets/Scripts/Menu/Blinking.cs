using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinking : MonoBehaviour {
    public int speed = 1;
    public string text1;
    public string text2;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Math.Ceiling(Time.fixedTime) % 2 == 0){
            this.GetComponent<Text>().text = text2;
        }else{
            this.GetComponent<Text>().text = text1;
        }
	}
}
