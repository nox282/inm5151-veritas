using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Veritas;

public class ServerScript : MonoBehaviour {
    Client server;
    ISendServer clientObject;

    public void Start(){
        clientObject = GetComponent<PlayerController>();
        server = GameObject.FindGameObjectWithTag("server").GetComponent<Client>();
    }

    public void Update(){
        //server.SendtoServer(clientObject);
    }
}
