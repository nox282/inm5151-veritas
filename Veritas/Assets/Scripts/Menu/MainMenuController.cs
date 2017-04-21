using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    public GameObject amgo;

    public Text playerName;
    public Button start;
    public Button quit;

	void Start () {
		start.onClick.AddListener(delegate{
            loadStart();
        });
        
        quit.onClick.AddListener(delegate{
            loadQuit();
        });
	}

    void loadStart(){
        ApplicationManager am = amgo.GetComponent<ApplicationManager>();
        am.playerName = playerName.text;
        SceneManager.LoadScene ("Game", LoadSceneMode.Single);
    }

    void loadQuit(){
        Application.Quit();
    }
}
