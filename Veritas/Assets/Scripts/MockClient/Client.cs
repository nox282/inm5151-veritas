using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Client : MonoBehaviour {

    string URL = "http://localhost:5000/index";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown() {
        //Debug.Log("clic!");
        Bonhomme myBonhomme = ReadJsonFile(Application.dataPath + "/Scripts/MockClient/" + "TestData.json");

        StartCoroutine(POST(URL, myBonhomme.toDictionnary()));
        //POST(jsonstr); 
        
    }

    private Bonhomme ReadJsonFile(string jsonfile) {
        Bonhomme myBonhomme = new Bonhomme(); 
        string jsondata = File.ReadAllText(jsonfile);
        myBonhomme = JsonUtility.FromJson<Bonhomme>(jsondata); 
        return myBonhomme; 
    }

    IEnumerator POST(string url, Dictionary<string, string> dict){
        WWWForm toSend = new WWWForm();

        foreach (KeyValuePair<string, string> kv in dict){
            toSend.AddField(kv.Key, kv.Value);
        }

        WWW www = new WWW(url, toSend);

        yield return www;
    }
}