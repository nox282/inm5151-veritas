using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Veritas
{

    public class Client : MonoBehaviour
    {

        public string url = "http://localhost:5000/index";


        //private Bonhomme ReadJsonFile(string jsonfile) {
        //    Bonhomme myBonhomme = new Bonhomme(); 
        //    string jsondata = File.ReadAllText(jsonfile);
        //    myBonhomme = JsonUtility.FromJson<Bonhomme>(jsondata); 
        //    return myBonhomme; 
        //}

        public void SendtoServer(ISendServer clientObject){

            StartCoroutine(POST(clientObject.toDictionnary()));
        }

        private IEnumerator POST(Dictionary<string, string> dict){
            WWWForm toSend = new WWWForm();

            foreach (KeyValuePair<string, string> kv in dict)
            {
                toSend.AddField(kv.Key, kv.Value);
            }

            WWW www = new WWW(url, toSend);

            yield return www;
        }
    }
}