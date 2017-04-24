using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayerController : MonoBehaviour {
    public int HP;

    public AnimatorOverrideController maleAnim;
    public AnimatorOverrideController femaleAnim;

    private Animator anim;

    void Start(){
        ApplicationManager am = GameObject.FindWithTag("applicationManager").GetComponent<ApplicationManager>();
        anim = transform.GetComponent<Animator>();
        if(am.sexe == 'm')  anim.runtimeAnimatorController = maleAnim;
        else                anim.runtimeAnimatorController = femaleAnim;

    }

    public void hit(){
        HP -= 1;
    }
    public bool isDead(){
        return HP <= 0;
    }
}
