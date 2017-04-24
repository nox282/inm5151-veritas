using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUIController : MonoBehaviour {

    public CombatManager cm;
    public Text question;
    public InputField reponse;
    public Button valider;
    public Button effacer;

	void Start () {
		question.text = cm.GetQuestion();
        valider.onClick.AddListener(delegate{
            validate();
        });
        effacer.onClick.AddListener(delegate{
            erase();
        });
	}
	
    void validate(){
        cm.TryAnswer(reponse.text);
    }

    void erase(){
        reponse.text = "";
    }
}