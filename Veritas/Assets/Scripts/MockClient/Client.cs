using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Client : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown() {
        //Debug.Log("clic!");
        string jsonstr = ReadJsonFile(Application.dataPath + "/Scripts/MockClient/" + "TestData.json");
        //POST(jsonstr); 
        
    }

    private string ReadJsonFile(string jsonfile) {
        Bonhomme myBonhomme = new Bonhomme(); 

        string jsondata = File.ReadAllText(jsonfile);

        myBonhomme = JsonUtility.FromJson<Bonhomme>(jsondata); 

        Debug.Log(jsondata);
        Debug.Log(myBonhomme.name+", "+myBonhomme.funlevel+", "+myBonhomme.color);

        return jsondata; 
    }

    /*public WWW POST(string jsonstr) {
        WWW www;
        Hashtable postHeader = new Hashtable();
        postHeader.Add("Content-Type", "application/json");

        // convert json string to byte
        var formData = System.Text.Encoding.UTF8.GetBytes(jsonstr);

        www = new WWW(POSTAddUserURL, formData, postHeader);
        StartCoroutine(WaitForRequest(www));
        return www;
    }*/
}