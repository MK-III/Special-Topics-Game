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
    public String usedAttackName;
    // Use this for initialization
    void Start () {
        pAbility.text = "";
        eAbility.text = "";
        button1.interactable = true;
        button2.interactable = true;
        button3.interactable = true;
        button4.interactable = true;
        combat = GetComponent<EnterCombat>();
        GameObject.FindGameObjectWithTag("Player Health Bar").transform.Translate(new Vector3((-Instantiaion.player.HEALTH+Instantiaion.player.getHealth()) * (264f / Instantiaion.player.HEALTH), 0.0f, 0.0f));
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

    IEnumerator Wait(float sec, Action before, Action after)
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
        if (Instantiaion.player.getHealth() < 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player Health Bar"));
        }
        else {
            if (GlobalVariables.pHealed - GlobalVariables.pDamageDone != 0)
            {
                GameObject.FindGameObjectWithTag("Player Health Bar").transform.Translate(new Vector3((GlobalVariables.pHealed - GlobalVariables.pDamageDone) * (134f / Instantiaion.player.HEALTH), 0.0f, 0.0f));
                GameObject.FindGameObjectWithTag("Player Health Bar").transform.localScale += new Vector3(10.18479f * (GlobalVariables.pHealed - GlobalVariables.pDamageDone) * (264f / Instantiaion.player.HEALTH) / 264, 0.0f, 0.0f);

            } }
        GlobalVariables.pDamageDone = 0;
        healPlayer.text = "+ " + GlobalVariables.pHealed;
        GlobalVariables.pHealed = 0;
    }
    private void updateEnemy()
    {
        if (this.enemy.getHealth() > this.enemy.HEALTH) { this.enemy.setHealth(this.enemy.HEALTH); }
        enemyHealth.text = "Enemy Health: " + enemy.getHealth().ToString();
        damageEnemy.text = "- " + GlobalVariables.eDamageDone;
        if (this.enemy.getHealth() < 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy Health Bar"));
        }
        else
        {
            if (GlobalVariables.eHealed - GlobalVariables.eDamageDone != 0)
            {
                GameObject.FindGameObjectWithTag("Enemy Health Bar").transform.Translate(new Vector3(-(GlobalVariables.eHealed - GlobalVariables.eDamageDone) * (134f / this.enemy.HEALTH), 0.0f, 0.0f));
                GameObject.FindGameObjectWithTag("Enemy Health Bar").transform.localScale += new Vector3(10.18479f * (GlobalVariables.eHealed - GlobalVariables.eDamageDone) * (264f / this.enemy.HEALTH) / 264, 0.0f, 0.0f);

            }
        }
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
        //Change to Next Turn
            if (turnChanged && Instantiaion.player.getHealth() > 0 && this.enemy.getHealth() > 0)
            {
            pAbility.text = Instantiaion.player.getUsedAbilityName();
            eAbility.text = "";
                StartCoroutine(
                    Wait(2,
                    () =>
                {
                    updatePlayer();
                    runPlayerAnim(Instantiaion.player.getUsedAbility(), true);
                    updateEnemy();
                },
                () =>
                {
                    enemyAttack();
                    updatePlayer();
                    updateEnemy();
                    runPlayerAnim(Instantiaion.player.getUsedAbility(), false);

                }));
            }
        turnChanged = false;
        //End Combat
        if (Instantiaion.player.getHealth() <= 0 || enemy.getHealth() <= 0)
        {
            StartCoroutine(
                    Wait(5,
                    () =>
                    {
                        if (Instantiaion.player.getHealth() <= 0)
                        {
                            Anim.SetBool("isDead", true);
                            Anim.SetLayerWeight(1, 0);
                            UnityEngine.Debug.Log("death animation");
                        }
                        else
                        {
                            updatePlayer();
                            runPlayerAnim(Instantiaion.player.getUsedAbility(), true);
                            updateEnemy();
                        }
                  },
                () =>
                {
                    if (Instantiaion.player.getHealth() <= 0)
                    {
                        SceneManager.LoadScene(SceneManager.GetSceneByName("scene1").buildIndex);
                        Instantiaion.player.setHealth(100);
                    }
                    else
                    {
                        this.enemy.onDeath();
                        this.enemy.killEnemy();
                    }
                }));
        }
    }

    public void runPlayerAnim(int option, bool attack)
    {

        switch (option)
        {
            case 1:
                usedAttackName= Instantiaion.player.getAbility1Name();
                break;
            case 2:
                usedAttackName = Instantiaion.player.getAbility2Name();
                break;
            case 3:
                usedAttackName = Instantiaion.player.getAbility3Name();
                break;
            case 4:
                usedAttackName = Instantiaion.player.getAbility4Name();
                break;
            default:
                UnityEngine.Debug.Log("Error with runPlayerAnim");
                break;
          }
        switch (usedAttackName)
        {
            case "Shoot":
                Anim.SetBool("Revolver1", attack);
                break;
            case "Pistol Whip":
                Anim.SetBool("Revolver2", attack);
                break;
            case "Jab":
                break;
                Anim.SetBool("Fists1", attack);
                break;
            case "UpperCut":
                Anim.SetBool("Fists2", attack);
                break;
            case "Plasma Burn":
                Anim.SetBool("Plasma1", attack);
                break;
            case "Plasma Stab":
                Anim.SetBool("Plasma2", attack);
                break;
            case "Shoot Repeater":
                Anim.SetBool("Repeating1", attack);
                break;
            case "Multi Shot":
                Anim.SetBool("Repeating2", attack);
                break;
            case "Spray":
                Anim.SetBool("Gattling1", attack);
                break;
            case "Focus":
                Anim.SetBool("Gattling2", attack);
                break;
            case "Laser Shot":
                Anim.SetBool("Laser1", attack);
                break;
            case "Head Shot":
                Anim.SetBool("Laser2", attack);
                break;
            case "Lazer Slash":
                Anim.SetBool("LazerS1", attack);
                break;
            case "Deflect":
                Anim.SetBool("LazerS2", attack);
                break;
            case "Slash":
                Anim.SetBool("Sabre1", attack);
                break;
            case "Charge":
                Anim.SetBool("Sabre2", attack);
                break;
            case "Adv. First Aid Kit":
                Anim.SetBool("Adv. First Aid Kit", attack);
                break;
            case "Alien Probe":
                Anim.SetBool("Alien Probe", attack);
                break;
            case "First Aid Kit":
                Anim.SetBool("First Aid Kit", attack);
                break;
            case "Moonshine":
                Anim.SetBool("Moonshine", attack);
                break;
            case "Morphine":
                Anim.SetBool("Morphine", attack);
                break;
            case "NanoBots":
                Anim.SetBool("NanoBots", attack);
                break;
            case "Explode":
                Anim.SetBool("Explode", attack);
                break;
            case "Flash Bang":
                Anim.SetBool("Flash Bang", attack);
                break;
            case "Sheild":
                Anim.SetBool("Sheild", attack);
                break;
            case "Smoke Bomb":
                Anim.SetBool("Smoke Bomb", attack);
                break;
            default:
                UnityEngine.Debug.Log("Error with runPlayerAnim");
                break;
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
