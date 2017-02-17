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
    private bool attackChanged;
    private bool defenseChanged;
    private bool[] playerAbilityUsed = new bool[4];
    Enemy enemy;
    private bool deflect;
    int turnCountA;
    int turnCountB;

    // Use this for initialization
    void Start () {
        combat = GetComponent<EnterCombat>();
        player = GetComponent<Player>();
        GlobalVariables.turn = 0;
        playerAbilityUsed = new[] { false, false, false, false, };
        switch (GlobalVariables.enemyName)
        {
            case "Alien":
                enemy = new Alien();
                turnChanged = false;
                break;
            case "Zombie":
                enemy = null;
                break;
            default:
                enemy = null;
                break;
        }
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
        if (GlobalVariables.health==0){
            SceneManager.LoadScene(SceneManager.GetSceneByName("scene1").buildIndex);
        }


        if (playerAbilityUsed[0]){
            enemy.doDamage(DamageCalc(GlobalVariables.eqp[0].ability1(), enemy.defense, false));
        }

        if (playerAbilityUsed[1])
        {
            if (GlobalVariables.eqp[0].Equals(typeof(LazerSaber))){
                if (Random.Range(0, 100) <= 35)
                    deflect = true;
            }
            enemy.doDamage(DamageCalc(GlobalVariables.eqp[0].ability2(), enemy.defense, false));
        }

        if (enemy.health == 0)
            enemy.killEnemy();

        if (turnChanged){
            switch (enemy.getUsedAbility()){
                case 1:
                    if (deflect)
                        enemy.health -= 2 * DamageCalc(enemy.ability1(), enemy.defense, true);
                    else
                        GlobalVariables.health -= DamageCalc(enemy.ability1(), GlobalVariables.PDefense, false);
                    break;
                case 2:
                    if (deflect)
                        enemy.health -= 2 * DamageCalc(enemy.ability2(), enemy.defense, true);
                    else
                        GlobalVariables.health -= DamageCalc(enemy.ability2(), GlobalVariables.PDefense, false);
                    break;
            }
        }
        
        if(!defenseChanged)
            GlobalVariables.PDefense = GlobalVariables.PDEFENSE;

        playerAbilityUsed = new[] { false, false, false, false, };
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
        playerAbilityUsed[2] = true;
    }

    public void AssistAbility()
    {
        GlobalVariables.eqp[1].ability1();
        playerAbilityUsed[1] = true;
    }

    public void Ability1()
    {
        GlobalVariables.eqp[0].ability1();
        playerAbilityUsed[0] = true;
    }

    public void Ability2()
    {
        GlobalVariables.eqp[0].ability2();
        playerAbilityUsed[1] = true;
    }

    public int TurnChanged
    {
        get { return GlobalVariables.turn; }
        set
        {
            GlobalVariables.turn = value;
            if (GlobalVariables.turn == 1)
            {
                Debug.Log("WHY THE FUCK DONT YOU WORK YOU NIGGER-FAGGOT");
                if (attackChanged)
                    turnCountA++;
                if (turnCountA == 1)
                    turnCountA++;
                if(turnCountA == 2)
                    GlobalVariables.PAttack = GlobalVariables.PATTACK;

                if (attackChanged)
                    turnCountB++;
                if (turnCountB == 1)
                    turnCountB++;
                if (turnCountB == 2)
                    GlobalVariables.PDefense = GlobalVariables.PDEFENSE;
                turnChanged = true;
            }
        }
    }

    public int AttckChanged
    {
        get { return GlobalVariables.PAttack; }
        set
        {
            GlobalVariables.PAttack = value;
            if (GlobalVariables.PAttack == 1)
            {
                attackChanged = true;
            }
        }
    }

    public int DefenseChanged
    {
        get { return GlobalVariables.PDefense; }
        set
        {
            GlobalVariables.PDefense = value;
            if (GlobalVariables.PDefense == 1)
            {
                defenseChanged = true;
            }
        }
    }

    public int DamageCalc(int[] combatVals, int targetDef, bool guarenteed)
    {
        combatVals = new int[3];
        if (Random.Range(0, 100) >= targetDef - (combatVals[0] + GlobalVariables.PAttack) || guarenteed)
            return combatVals[1];
        else
            return 0;
    }
    

}
