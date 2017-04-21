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

        private Vector3 lastPosition;
        
        void Start(){
            GameObject go = GameObject.Find("SocketIO");
            socket = go.GetComponent<SocketIOComponent>();
            player = transform.parent.GetComponent<PlayerController>();
            lastPosition = player.transform.position;

            //SOCKET ENVENT CONFIG #####################
            socket.On("Dispatch", ReceiveWithSocket);
            //##########################################   
        }

        void Update(){
            if(player.transform.position != lastPosition)
                SendWithSocket();
            lastPosition = player.transform.position;
        }

        public void SendWithSocket(){
            socket.Emit("Move", new JSONObject(player.toDictionnary()));
        }

        public void ReceiveWithSocket(SocketIOEvent e){
            //Send to ApplicationManager
            Debug.Log(string.Format("name: {0}, data: {1}]", e.name, e.data));
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