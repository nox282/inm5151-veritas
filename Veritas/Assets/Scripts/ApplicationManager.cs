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
        
    }
}