using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterCombat : MonoBehaviour {

    private EnemyTriggered activate;
    private Player player;
    private string enemyName;
    public GameObject enemy;

	// Use this for initialization
	void Start () {
        activate = GetComponent<EnemyTriggered>();
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        enemyName = activate.getName();

        if (activate.contact && !GlobalVariables.inCombat)
        {
            //Destroy(enemy);
            SceneManager.LoadSceneAsync("Scenes/combat", LoadSceneMode.Additive);
        }
    }

    public string getName()
    {
        return enemyName;
    }
}
