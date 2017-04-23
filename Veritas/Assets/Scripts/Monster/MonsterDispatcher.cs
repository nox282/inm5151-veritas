using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Veritas;

public class MonsterDispatcher : MonoBehaviour {
    public SpawningArea[] spAreas;
    public int minDensity;
    public int maxDensity;
    public List<GameObject> monsters;

    public GameObject[] monstersPF;

	void Start () {
        spAreas = gameObject.GetComponentsInChildren<SpawningArea>();
		monsters = new List<GameObject>();
	}

    public void DispatchMonsters(List<Quest> quests){
        foreach(Quest q in quests){
            foreach(Goal g in q.Objectives){
                foreach(SpawningArea sp in spAreas){
                    int d = Random.Range(minDensity, maxDensity);
                    for(int i = 0; i < d; i++){
                        SpawnMonster(g, sp);
                    }
                }
            }
        }
    }

    private void SpawnMonster(Goal g, SpawningArea sp){
        Debug.Log("new monsters");
    }
}
