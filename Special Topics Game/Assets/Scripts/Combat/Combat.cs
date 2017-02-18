﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Combat : MonoBehaviour {

    //public string enemyName;
    private EnterCombat combat;
    private bool turnChanged = false;
    public Text health;
    public Text ability1;
    public Text ability2;
    public Text medicalAbility;
    public Text assistAbility;
    public Text enemyName;
    public Text TurnCount;
    Enemy enemy;

    // Use this for initialization
    void Start () {
        combat = GetComponent<EnterCombat>();
        GlobalVariables.turn = 0;
        switch (GlobalVariables.enemyName)
        {
            case "Alien":
                enemy = new Alien(Instantiaion.player);
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
        health.text = "Health: " + Instantiaion.player.getHealth().ToString();
        TurnCount.text = "Turn: " + GlobalVariables.turn.ToString();
        ability1.text = Instantiaion.player.GetNameWeaponAbility1();
        ability2.text = Instantiaion.player.GetNameWeaponAbility2();
        assistAbility.text = Instantiaion.player.GetNameAssistAbility();
        medicalAbility.text = Instantiaion.player.GetNameMedicalAbility();
        enemyName.text = GlobalVariables.enemyName;
        if(Instantiaion.player.getHealth() > 100) { Instantiaion.player.setHealth(100); }
        if (Instantiaion.player.getHealth() <= 0){
            SceneManager.LoadScene(SceneManager.GetSceneByName("scene1").buildIndex);
        }

        if (turnChanged){
            switch (enemy.getUsedAbility()){
                case 1:
                    enemy.ability1(Instantiaion.player);
                    break;
                case 2:
                    enemy.ability2(Instantiaion.player);
                    break;
                case 3:
                    enemy.ability3(Instantiaion.player);
                    break;
                case 4:
                    enemy.ability4(Instantiaion.player);
                    break;
            }
        }

    }

    

    private void Awake()
    {
      GlobalVariables.inCombat = true;  
    }

    public void NextTurn()
    {
        GlobalVariables.turn += 1;
        turnChanged = true;
    }
    
    public int DamageCalc(int[] combatVals, int targetDef, bool guarenteed)
    {
        combatVals = new int[3];
        if (Random.Range(0, 100) >= targetDef - (combatVals[0] + Instantiaion.player.getAttack()) || guarenteed)
            return combatVals[1];
        else
            return 0;
    }
    

}
