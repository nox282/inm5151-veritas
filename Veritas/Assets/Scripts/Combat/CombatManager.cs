using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Veritas;

public class CombatManager : MonoBehaviour {

    public GameObject playerO;
    public GameObject monsterO;

    private ApplicationManager app;
    private CombatPlayerController player;
    private CombatMonsterController monster;

    private Goal g;

    public bool outcome = false;

	void Start () {
		app = GameObject.FindWithTag("applicationManager").GetComponent<ApplicationManager>();
        player = playerO.GetComponent<CombatPlayerController>();
        monster = monsterO.GetComponent<CombatMonsterController>();
        g = app.currentMonster.goal;

        Debug.Log(g.Question);
	}

    public void TryAnswer(string a){
        bool t = (a != "") && g.tryAnswer(a);
        if(t){
            win();
        } else {
            player.hit();
            if(player.isDead())
                loose();
        }
    }

    public string GetQuestion(){
        return g.Question;
    }

    public void win(){
        outcome = true;
        returnToGame();
    }

    public void loose(){
        outcome = false;
        returnToGame();
    }

    private void returnToGame(){
        app.wasInCombat = true;
        app.win = outcome;
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}