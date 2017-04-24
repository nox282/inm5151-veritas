using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Veritas;
using SocketIO;

public class ApplicationManager : MonoBehaviour {
    public string playerName;
    public Vector2 playerPosition;
    public char sexe;

    public Dictionary<string, Vector3> players;
    public List<Quest> quests = new List<Quest>();

    public bool wasInCombat;
    public bool win;

    public MonsterController currentMonster;

    private Client client;

	void Start () {
        playerPosition = new Vector2(195, -75);
        players = new Dictionary<string, Vector3>();
        DontDestroyOnLoad(gameObject);        
    }

    void Update(){
        if(wasInCombat){
            resetState();
        }
    }

    private void resetState(){
        if(win){
                Debug.Log("win");
        } else {
                Debug.Log("loose");
        }

        wasInCombat = false;
        win = false;
        
        currentMonster = null;
    }

    public void setPositions(SocketIOEvent e){
        string name = e.data["PlayerName"].str;
        float x = float.Parse(e.data["PosX"].str);
        float y = float.Parse(e.data["PosY"].str);
        
        players[name] = new Vector3(x, y, 0.0f);
    }

    public void setQuests(string data){
        quests = new List<Quest>();

        JSONObject j = new JSONObject(data); 

        foreach(JSONObject d in j.list){
            Quest q = new Quest(); 
            for(int i = 0; i < d.list.Count; i++){
                string key = (string) d.keys[i];
                q = setQuestsAttributes(q, key, d.list[i]);
            }
            quests.Add(q);
        }
        MonsterDispatcher md = GameObject.FindWithTag("monsterDispatcher").GetComponent<MonsterDispatcher>();
        md.DispatchMonsters(quests);
    }

    //public void finishCombat(bool win){
    //    if
    //}

    private Quest setQuestsAttributes(Quest q, string key, JSONObject data){
        if(       key == "titre"){
            q.Title = data.str;
        } else if(key == "subject"){
            q.Subject = data.str;
        } else if(key == "level"){
            q.Level = data.str;
        } else if(key == "questions"){
            q.setObjectives(data);
        }
        return q;
    }
}