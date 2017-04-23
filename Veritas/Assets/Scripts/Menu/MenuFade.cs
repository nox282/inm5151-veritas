using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFade : MonoBehaviour {

    public bool fadeOut = false;
    public bool fadeIn = false;
    public bool transparent;
    public float speed;
    public Image fadeImage;
    float alpha = 1;
    Texture2D texture;
    Color tmp;
	// Use this for initialization
	void Start () {
        if (transparent) alpha = 0;
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
        if (this.alpha < 0.01) this.fadeIn = false;
        if (this.alpha > 0.99) this.fadeOut = false;
        tmp.a = alpha;
    }
}
