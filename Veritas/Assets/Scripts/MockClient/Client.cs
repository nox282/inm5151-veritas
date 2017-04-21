using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SocketIO;

namespace Veritas
{

    public class Client : MonoBehaviour
    {

        public string url_state = "http://localhost:5000/update_state";
        public string url_quests = "http://localhost:5000/get_quests";

        private SocketIOComponent socket;
        private PlayerController player;

        private Dictionary<string, string> toSend;


        void Start(){
            GameObject go = GameObject.Find("SocketIO");
            socket = go.GetComponent<SocketIOComponent>();
            player = transform.parent.GetComponent<PlayerController>();
            toSend = new Dictionary<string, string>();
        }

        void Update(){
            toSend["x"] = string.Format("{0:N2}", player.transform.position.x);
            toSend["y"] = string.Format("{0:N2}", player.transform.position.y);
            socket.Emit("Move", new JSONObject(toSend));
        }

        public void SendtoServer(ISendServer clientObject){
            StartCoroutine(POST(clientObject.toDictionnary()));
        }

        public void RetrieveQuestsFromServer(){
            StartCoroutine(GET_quests());
        }

        private IEnumerator GET_quests(){
            WWW www = new WWW(url_quests);
            yield return www;

            FindObjectOfType<ApplicationManager>();

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