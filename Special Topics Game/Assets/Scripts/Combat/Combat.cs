using System.Collections;
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
    public Text enemyHealth;
	public Text damageEnemy;
	public Text damagePlayer;
    private Entity enemyTarget = Instantiaion.player;
    private Entity playerTarget;
    Enemy enemy;

    // Use this for initialization
    void Start () {
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
	
	// Update is called once per frame
	void FixedUpdate () {
        health.text = "Health: " + Instantiaion.player.getHealth().ToString();
        TurnCount.text = "Turn: " + GlobalVariables.turn.ToString();
        ability1.text = Instantiaion.player.GetNameWeaponAbility1();
        ability2.text = Instantiaion.player.GetNameWeaponAbility2();
        assistAbility.text = Instantiaion.player.GetNameAssistAbility();
        medicalAbility.text = Instantiaion.player.GetNameMedicalAbility();
        enemyName.text = GlobalVariables.enemyName;
		enemyHealth.text = "Enemy Health: " + enemy.getHealth().ToString();
        //damageEnemy.text = "- " + GlobalVariables.eDamageDone;
        //damagePlayer.text = "- " + GlobalVariables.pDamageDone;

        if (Instantiaion.player.getHealth() > 100) { Instantiaion.player.setHealth(100); } //Bound Health

        if (Instantiaion.player.getHealth() <= 0){
            SceneManager.LoadScene(SceneManager.GetSceneByName("scene1").buildIndex);
            Instantiaion.player.setHealth(100);
        }
        
		if (this.enemy.getHealth() <= 0)
            this.enemy.killEnemy();

        if (turnChanged){
            switch (enemy.getUsedAbility()){
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
    }

}
