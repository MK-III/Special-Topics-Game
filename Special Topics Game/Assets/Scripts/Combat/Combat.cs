using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Linq;
using System;

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
    public Text enemyHealth;
	public Text damageEnemy;
	public Text damagePlayer;
    public Text healPlayer;
    public Text healEnemy;
    private Entity enemyTarget = Instantiaion.player;
    private Entity playerTarget;
    private Camera camMain;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    Enemy enemy;

    private Stopwatch stopwatch = Stopwatch.StartNew();
    private bool healAbilityUsed = false;

    // Use this for initialization
    void Start () {
        button1.interactable = true;
        button2.interactable = true;
        button3.interactable = true;
        button4.interactable = true;
        combat = GetComponent<EnterCombat>();
        GlobalVariables.turn = 0;
        switch (GlobalVariables.enemyName)
        {
		case "Alien":
			enemy = new Alien();
                break;
            case "Zombie":
                enemy = null;
                break;
            default:
                enemy = null;
                break;
        }
        playerTarget = enemy;
    }

    IEnumerator Wait(int sec, Action before, Action after)
    {
        UnityEngine.Debug.Log("Before Waiting "+sec+" seconds");
        button1.interactable = false;
        button2.interactable = false;
        button3.interactable = false;
        button4.interactable = false;
        before();
        yield return new WaitForSeconds(sec);
        after();
        button1.interactable = true;
        button2.interactable = true;
        button3.interactable = true;
        button4.interactable = true;
        UnityEngine.Debug.Log("After Waiting "+sec+" Seconds");
    }
    private void updatePlayer()
    {
        UnityEngine.Debug.Log("Updating Player");
        health.text = "Health: " + Instantiaion.player.getHealth().ToString();
        damagePlayer.text = "- " + GlobalVariables.pDamageDone;
        GlobalVariables.pDamageDone = 0;
        healPlayer.text = "+ " + GlobalVariables.pHealed;
        GlobalVariables.pHealed = 0;
    }
    private void updateEnemy()
    {
        UnityEngine.Debug.Log("Updating Enemy");
        enemyHealth.text = "Enemy Health: " + enemy.getHealth().ToString();
        damageEnemy.text = "- " + GlobalVariables.eDamageDone;
        GlobalVariables.eDamageDone = 0;
        healEnemy.text = "+ " + GlobalVariables.eHealed;
        GlobalVariables.eHealed = 0;
    }
    private void enemyAttack()
    {
        switch (enemy.getUsedAbility())
        {
            case 1:
                enemy.ability1(enemyTarget);
                break;
            case 2:
                enemy.ability2(enemyTarget);
                break;
            case 3:
                enemy.ability3(enemyTarget);
                break;
            case 4:
                enemy.ability4(enemyTarget);
                break;
        }
    }
    // Update is called once per frame
    void FixedUpdate () {
        //Initial Conditions
        if (GlobalVariables.turn == 0)
        {
            updatePlayer();
            updateEnemy();
        }
            TurnCount.text = "Turn: " + GlobalVariables.turn.ToString();
            ability1.text = Instantiaion.player.GetNameWeaponAbility1();
            ability2.text = Instantiaion.player.GetNameWeaponAbility2();
            assistAbility.text = Instantiaion.player.GetNameAssistAbility();
            medicalAbility.text = Instantiaion.player.GetNameMedicalAbility();
            enemyName.text = GlobalVariables.enemyName;
            Vector3 delta = GameObject.FindGameObjectWithTag("HealthBar").transform.position - camMain.ViewportToWorldPoint(new Vector3(((Instantiaion.player.getHealth()) * 2.64f), 0.0f, 0.0f));
        
        //Bound Health
            if (Instantiaion.player.getHealth() > 100) { Instantiaion.player.setHealth(100); }
        //Kill Player
            if (Instantiaion.player.getHealth() <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetSceneByName("scene1").buildIndex);
                Instantiaion.player.setHealth(100);
            }
        //Kill Enemy
            if (this.enemy.getHealth() <= 0)
                this.enemy.killEnemy();
        //Change to Next Turn
            if (turnChanged)
            {
            if (healAbilityUsed)
            {
                UnityEngine.Debug.Log("First Aid kit used");
                StartCoroutine(
                    Wait(1,
                    () =>
                    {
                        updatePlayer();
                    },
                () =>
                {
                    enemyAttack();
                    updatePlayer();
                }));
            }
            else {
                StartCoroutine(
                    Wait(1,
                    () =>
                {
                    updateEnemy();
                },
                () =>
                {
                    enemyAttack();
                    updatePlayer();
                })); }
            healAbilityUsed = false;
            }
            turnChanged = false;

        
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
    
    public void ActivateWeaponAbility1(){
        Instantiaion.player.WeaponAbility1(playerTarget);
    }

    public void ActivateWeaponAbility2(){
        Instantiaion.player.WeaponAbility2(playerTarget);
    }

    public void ActivateAssistAbility(){
        Instantiaion.player.AssistAbility(playerTarget);
    }

    public void ActivateMedicalAbility(){
        Instantiaion.player.MedicalAbility(playerTarget);
        if (Instantiaion.player.eqp[2].getNameAbility1()=="First Aid Kit" || 
            Instantiaion.player.eqp[2].getNameAbility1() == "NanoBots" ||
            Instantiaion.player.eqp[2].getNameAbility1() == "Adv. First Aid Kit")
        {
            healAbilityUsed = true;
        }
    }

}
