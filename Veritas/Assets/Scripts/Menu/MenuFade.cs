using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFade : MonoBehaviour {

    public bool fadeOut = false;
    public bool fadeIn = false;
    public float speed;
    public Image fadeImage;
    float alpha;
    Texture2D texture;
    Color tmp;
	// Use this for initialization
	void Start () {
        if (fadeOut) alpha = 0;
        if (fadeIn) alpha = 1;
        tmp = fadeImage.color;
	}
	
	// Update is called once per frame
	void Update () {
        fade(fadeIn, fadeOut);
        fadeImage.color = tmp;
    }

    void fade(bool fadeIn, bool fadeOut){
        if(fadeOut) alpha = Mathf.Clamp01(alpha + Time.deltaTime / speed);
        if(fadeIn) alpha = Mathf.Clamp01(alpha - Time.deltaTime / speed);
        tmp.a = alpha;
    }
}
