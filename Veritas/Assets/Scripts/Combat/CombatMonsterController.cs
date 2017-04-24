using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMonsterController : MonoBehaviour {
    public AnimatorOverrideController blueAnim;
    public AnimatorOverrideController greenAnim;
    public AnimatorOverrideController pinkAnim;    

    private Animator anim;

	void Start () {
		ApplicationManager am = GameObject.FindWithTag("applicationManager").GetComponent<ApplicationManager>();
        anim = transform.GetComponent<Animator>();
        
        string subject = am.currentMonster.goal.Subject;

        if(         subject == "math"){
            anim.runtimeAnimatorController = blueAnim;
        } else if(  subject == "francais"){
            anim.runtimeAnimatorController = greenAnim;
        } else if(  subject == "anglais")
            anim.runtimeAnimatorController = pinkAnim;
	}
}