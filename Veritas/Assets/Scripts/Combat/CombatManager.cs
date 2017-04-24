using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

	}

    public void TryAnswer(string a){
        bool t = g.tryAnswer(a);
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

    public void Update(){
        //if(player.HP == 0) loose();
        //if(monster.HP == 0) win();
    }

    void OnGui(){
        //gui here;
    }

    public void win(){
        outcome = true;
        //load with parameters
    }

    public void loose(){
        outcome = false;
        //load with parameters
    }
}