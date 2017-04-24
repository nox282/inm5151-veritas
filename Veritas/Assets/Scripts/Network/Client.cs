using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
//using SocketIO;

namespace Veritas
{

    public class Client : MonoBehaviour {
        public string url_state = "http://localhost:5000/update_state";
        public string url_quests = "http://localhost:5000/get_quests";

        //private SocketIOComponent socket;
        private PlayerController player;

        private ApplicationManager am;

        private Vector3 lastPosition;
        
        void Start(){
            am = GameObject.FindWithTag("applicationManager").GetComponent<ApplicationManager>();

            //GameObject go = GameObject.Find("SocketIO");
            //socket = go.GetComponent<SocketIOComponent>();
            player = transform.parent.GetComponent<PlayerController>();
            player.Name = am.playerName;
            lastPosition = player.transform.position;
            
            if(!am.wasInCombat)
                RetrieveQuestsFromServer();

            //SOCKET EVENT CONFIG #####################
            //socket.On("Dispatch", ReceivePosWithSocket);
            //##########################################
        }

        void Update(){
            // Sockets are not a supported by the unity webgl player
            //if(player.transform.position != lastPosition)
            //    SendWithSocket();
            //lastPosition = player.transform.position;
        }

        /*private void SendWithSocket(){
            socket.Emit("Move", new JSONObject(player.toDictionnary()));
        }

        private void ReceivePosWithSocket(SocketIOEvent e){
            am.setPositions(e);
        }*/

        public void RetrieveQuestsFromServer(){
            StartCoroutine(GET_quests());
        }

        private IEnumerator GET_quests(){
            WWW www = new WWW(url_quests);
            yield return www;

            am.setQuests(www.text);
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