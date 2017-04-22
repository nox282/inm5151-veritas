using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Veritas;
using SocketIO;

public class ApplicationManager : MonoBehaviour {
    public string playerName;

    public Dictionary<string, Vector3> players;
    public List<string> monsterList;
    public List<Quest> quests = new List<Quest>();
    public string currentMonster;

    private Client client;

	void Start () {
        players = new Dictionary<string, Vector3>();
        DontDestroyOnLoad(gameObject);
    }

    public void setPositions(SocketIOEvent e){
        string name = e.data["PlayerName"].str;
        float x = float.Parse(e.data["PosX"].str);
        float y = float.Parse(e.data["PosY"].str);
        
        players[name] = new Vector3(x, y, 0.0f);
    }

    public void setQuests(string data){
        JSONObject d = new JSONObject(data); 

        foreach(JSONObject j in d.list){
            Quest q = new Quest(); 
            for(int i = 0; i < j.list.Count; i++){
                string key = (string) j.keys[i];
                q = setQuestsAttributes(q, key, j.list[i]);
            }
            quests.Add(q);
        }

        Debug.Log(quests.ToString());
    }

    private Quest setQuestsAttributes(Quest q, string key, JSONObject data){
        if(       key == "titre"){
            q.Title = data.str;
        } else if(key == "subject"){
            q.Subject = data.str;
        } else if(key == "level"){
            q.Level = data.str;
        } else if(key == "questions"){
            Debug.Log(data.type);
            //q.setObjectives(data);
        }
        return q;
    }
}