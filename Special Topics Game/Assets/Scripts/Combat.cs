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
    private bool turnChanged;
    private bool[] abilityUsed = new bool[4];

	// Use this for initialization
	void Start () {
        combat = GetComponent<EnterCombat>();
        player = GetComponent<Player>();
        GlobalVariables.turn = 0;
        abilityUsed = new[] { false, false, false, false, };
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //enemyName = combat.getName();
        Enemy enemy;
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

        switch (GlobalVariables.enemyName)
        {
            case "Alien":
                enemy = new Alien(50);
                if (turnChanged)
                {
                    switch (enemy.getUsedAbility())
                    {
                        case 1:
                            enemy.ability1();
                            break;
                        case 2:
                            enemy.ability2();
                            break;
                    }
                }

                turnChanged = false;
                break;
            case "Zombie":
                break;
        }

        

        abilityUsed = new[] { false, false, false, false, };
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
        abilityUsed[2] = true;
    }

    public void AssistAbility()
    {
        GlobalVariables.eqp[1].ability1();
        abilityUsed[1] = true;
    }

    public void Ability1()
    {
        GlobalVariables.eqp[0].ability1();
        abilityUsed[0] = true;
    }

    public void Ability2()
    {
        GlobalVariables.eqp[0].ability2();
        abilityUsed[1] = true;
    }

    public int TurnChanged
    {
        get { return GlobalVariables.turn; }
        set
        {
            GlobalVariables.turn = value;
            if (GlobalVariables.turn == 1)
            {
                turnChanged = true;
            }
        }
    }
    

}
