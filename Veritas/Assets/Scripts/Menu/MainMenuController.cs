using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    public GameObject amgo;
    public Text playerName;
    public Button start;
    public Toggle male;
    public Toggle female;

    MenuFade fade;

	void Start () {
        fade = Camera.main.GetComponent<MenuFade>();
		start.onClick.AddListener(delegate{
            loadStart();
        });
	}



    IEnumerator fadeStart(){
        fade.fadeOut = true;
        while (fade.fadeOut){
            yield return null;
        }
        ApplicationManager am = amgo.GetComponent<ApplicationManager>();
        am.playerName = playerName.text;
        if(male.isOn)   am.sexe = 'm';
        else            am.sexe = 'f';
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    void loadStart(){
        StartCoroutine(fadeStart());
    }
}
