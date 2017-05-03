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
    public Text eAbility;
    public Text pAbility;
    private Entity enemyTarget = Instantiaion.player;
    private Entity playerTarget;
    private Camera camMain;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    Enemy enemy;
    private Stopwatch stopwatch = Stopwatch.StartNew();
    public Boolean stopFirstUpdate = false;
    public Animator Anim;
    public bool attack;

    // Use this for initialization
    void Start () {
        pAbility.text = "";
        eAbility.text = "";
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
    }
    private void updatePlayer()
    {
        if (Instantiaion.player.getHealth() > Instantiaion.player.HEALTH) { Instantiaion.player.setHealth(Instantiaion.player.HEALTH); }
        health.text = "Health: " + Instantiaion.player.getHealth().ToString();
        damagePlayer.text = "- " + GlobalVariables.pDamageDone;
        //GameObject.FindGameObjectWithTag("Player Health Bar").transform.localScale += new Vector3(-(GlobalVariables.pHealed - GlobalVariables.pDamageDone)/2.64f, 0.0f, 0.0f);
        GameObject.FindGameObjectWithTag("Player Health Bar").transform.Translate(new Vector3((GlobalVariables.pHealed - GlobalVariables.pDamageDone)*(264f / Instantiaion.player.HEALTH), 0.0f, 0.0f));
        GlobalVariables.pDamageDone = 0;
        healPlayer.text = "+ " + GlobalVariables.pHealed;
        GlobalVariables.pHealed = 0;
    }
    private void updateEnemy()
    {
        if (this.enemy.getHealth() > this.enemy.HEALTH) { this.enemy.setHealth(this.enemy.HEALTH); }
        enemyHealth.text = "Enemy Health: " + enemy.getHealth().ToString();
        damageEnemy.text = "- " + GlobalVariables.eDamageDone;
        GlobalVariables.eDamageDone = 0;
        healEnemy.text = "+ " + GlobalVariables.eHealed;
        GlobalVariables.eHealed = 0;
    }
    private void enemyAttack()
    {
        switch (enemy.getUsedAbility(this.enemy.getHealth()))
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
        eAbility.text = enemy.getUsedAbilityName();
        pAbility.text = "";
    }
    // Update is called once per frame
    void FixedUpdate () {
        //Initial Conditions
        if(GlobalVariables.turn == 0 && !stopFirstUpdate)
        {
            updatePlayer();
            updateEnemy();
            stopFirstUpdate = true;
        }

        TurnCount.text = "Turn: " + GlobalVariables.turn.ToString();
            ability1.text = Instantiaion.player.GetNameWeaponAbility1();
            ability2.text = Instantiaion.player.GetNameWeaponAbility2();
            assistAbility.text = Instantiaion.player.GetNameAssistAbility();
            medicalAbility.text = Instantiaion.player.GetNameMedicalAbility();
            enemyName.text = GlobalVariables.enemyName;
        //Kill Player
        if (Instantiaion.player.getHealth() <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetSceneByName("scene1").buildIndex);
                Instantiaion.player.setHealth(100);
            }
        //Kill Enemy
        if (this.enemy.getHealth() <= 0)
        {
            this.enemy.onDeath();
            this.enemy.killEnemy();
        }
        //Change to Next Turn
            if (turnChanged)
            {
            pAbility.text = Instantiaion.player.getUsedAbilityName();
            eAbility.text = "";
                StartCoroutine(
                    Wait(1,
                    () =>
                {
                    updatePlayer();
                    attack = true;
                    Anim.SetBool("attack", attack);
                    updateEnemy();
                },
                () =>
                {
                    enemyAttack();
                    updatePlayer();
                    updateEnemy();
                    attack = false;
                    Anim.SetBool("attack", attack);
                }));
            }
        turnChanged = false;
    }
    
    public void changeScale(int val)
    {
        // Vector3 scale = transform.localScale;
        //scale.x = val;
        
        //GameObject.FindGameObjectWithTag("Player Health Bar").transform.localScale = scale;
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
        Instantiaion.player.setUsedAbility(1);
    }

    public void ActivateWeaponAbility2(){
        Instantiaion.player.WeaponAbility2(playerTarget);
        Instantiaion.player.setUsedAbility(2);
    }

    public void ActivateAssistAbility(){
        Instantiaion.player.AssistAbility(playerTarget);
        Instantiaion.player.setUsedAbility(3);
    }

    public void ActivateMedicalAbility(){
        Instantiaion.player.MedicalAbility(playerTarget);
        Instantiaion.player.setUsedAbility(4);
    }

}
