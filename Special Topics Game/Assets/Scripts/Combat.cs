using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour {

    public string enemyName;
    private EnterCombat combat;
    private Player player;

	// Use this for initialization
	void Start () {
        combat = GetComponent<EnterCombat>();
        player = GetComponent<Player>();

	}
	
	// Update is called once per frame
	void Update () {
        enemyName = combat.getName();
        
        Debug.Log(enemyName);
	}

    private void Awake()
    {
      GlobalVariables.inCombat = true;  
    }
}
