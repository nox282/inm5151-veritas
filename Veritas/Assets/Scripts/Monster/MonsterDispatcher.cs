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
                        SpawnMonster(q, g, sp);
                    }
                }
            }
        }
    }

    private void SpawnMonster(Quest q, Goal g, SpawningArea sp){
        GameObject prefab = subjectToMonster(q.Subject);
        float angle = Random.Range(0, 360);
        float radius = Random.Range(0, sp.radius);
        Vector2 position = angleToPosition(sp.position, angle, radius);

        GameObject monster = Instantiate(prefab, position, Quaternion.identity, sp.transform);
        monster.GetComponent<MonsterController>().goal = g;
        monsters.Add(monster);
    }

    private GameObject subjectToMonster(string subject){
        if(         subject == "math"){
            return monstersPF[0];
        } else if(  subject == "francais"){
            return monstersPF[1];
        } else if(  subject == "anglais")
            return monstersPF[2];
        return monstersPF[0];
    }

    private Vector2 angleToPosition(Vector2 pos, float angle, float radius){
        return new Vector2(
            pos.x + radius * Mathf.Sin(Mathf.Deg2Rad * angle),
            pos.y + radius * Mathf.Cos(Mathf.Deg2Rad * angle)
        );
    }
}
