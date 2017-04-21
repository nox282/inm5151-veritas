using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Veritas;

public class CombatManager : MonoBehaviour {

    ApplicationManager app;

    public GameObject playerO;
    public GameObject monsterO;

    //private CombatPlayerController player;
    //private CombatMonsterController monster;

    public bool outcome = false;

	void Start () {
		app = FindObjectOfType<ApplicationManager>();
      //  player = playerO.GetComponent<CombatPlayerController>();
      //  monster = monsterO.GetComponent<CombatMonsterController>();
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