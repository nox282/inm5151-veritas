using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Veritas;

public class ApplicationManager : MonoBehaviour {

    public List<string> monsterList;
    public string currentMonster;

    public GameObject connection;

    private Client client;

	void Start () {
        client = connection.GetComponent<Client>();
        client.RetrieveQuestsFromServer();
    }

    //public void newData();
}