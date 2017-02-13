using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Combat : MonoBehaviour {

    //public string enemyName;
    private EnterCombat combat;
    private Player player;
    public Text health;
    public Text ability1;
    public Text ability2;
    public Text medicalAbility;
    public Text assistAbility;
    public Text enemyName;
    public Text TurnCount;

	// Use this for initialization
	void Start () {
        combat = GetComponent<EnterCombat>();
        player = GetComponent<Player>();
        GlobalVariables.turn = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //enemyName = combat.getName();
        health.text = "Health: " + GlobalVariables.health.ToString();
        TurnCount.text = "Turn: " + GlobalVariables.turn.ToString();
        ability1.text = GlobalVariables.eqp[0].getNameAbility1().ToString();
        ability2.text = GlobalVariables.eqp[0].getNameAbility2().ToString();
        assistAbility.text = GlobalVariables.eqp[1].getNameAbility1().ToString();
        medicalAbility.text = GlobalVariables.eqp[2].getNameAbility1().ToString();
        enemyName.text = GlobalVariables.enemyName;
        if(GlobalVariables.health > 100) { GlobalVariables.health = 100; }
        if (GlobalVariables.health==0)
        {
            SceneManager.LoadScene(SceneManager.GetSceneByName("scene1").buildIndex);
        }
	}

    private void Awake()
    {
      GlobalVariables.inCombat = true;  
    }

    public void NextTurn()
    {
        GlobalVariables.turn += 1;
    }

    public void MedicalAbility()
    {
        GlobalVariables.eqp[2].ability1();
    }

    public void AssistAbility()
    {
        GlobalVariables.eqp[1].ability1();
    }

    public void Ability1()
    {
        GlobalVariables.eqp[0].ability1();
    }

    public void Ability2()
    {
        GlobalVariables.eqp[0].ability2();
    }
}
