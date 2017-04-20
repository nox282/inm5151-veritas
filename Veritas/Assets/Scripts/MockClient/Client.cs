using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Veritas
{

    public class Client : MonoBehaviour
    {

        public string url_state = "http://localhost:5000/update_state";
        public string url_quests = "http://localhost:5000/get_quests";

        public void SendtoServer(ISendServer clientObject){
            StartCoroutine(POST(clientObject.toDictionnary()));
        }

        public void RetrieveQuestsFromServer(){
            StartCoroutine(GET_quests());
        }

        private IEnumerator GET_quests(){
            WWW www = new WWW(url_quests);
            yield return www;
            //Debug.Log(www.text);
        }

        private IEnumerator POST(Dictionary<string, string> dict){
            WWWForm toSend = new WWWForm();

            foreach (KeyValuePair<string, string> kv in dict)
            {
                toSend.AddField(kv.Key, kv.Value);
            }

            WWW www = new WWW(url_state, toSend);

            yield return www;

        }
    }
}