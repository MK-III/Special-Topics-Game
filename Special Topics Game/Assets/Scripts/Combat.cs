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
    public Text enemyName;

	// Use this for initialization
	void Start () {
        combat = GetComponent<EnterCombat>();
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //enemyName = combat.getName();
        health.text = "Health: " + GlobalVariables.health.ToString();
        ability1.text = GlobalVariables.eqp[0].getNameAbility1().ToString();
        ability2.text = GlobalVariables.eqp[0].getNameAbility2().ToString();
        enemyName.text = GlobalVariables.enemyName;
        if(GlobalVariables.health==0)
        {
            SceneManager.LoadScene(SceneManager.GetSceneByName("scene1").buildIndex);
        }
	}

    private void Awake()
    {
      GlobalVariables.inCombat = true;  
    }
}
