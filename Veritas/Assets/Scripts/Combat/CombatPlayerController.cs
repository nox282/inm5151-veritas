using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayerController : MonoBehaviour {

    public int HP;

    public void hit(){
        HP -= 1;
    }
    public bool isDead(){
        return HP <= 0;
    }
}
