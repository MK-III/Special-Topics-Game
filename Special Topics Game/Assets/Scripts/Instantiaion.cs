using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiaion : MonoBehaviour {

    public GameObject gameObject;
    public static Player player = new Player();

    // Use this for initialization
    void Awake () {
        player.inv[0] = true;
        DontDestroyOnLoad(gameObject);
        player.EquipItem(new Fists());
		player.EquipItem (new FirstAidKit ());
		player.EquipItem (new Dynamite ());
	}
}
