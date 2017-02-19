using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiaion : MonoBehaviour {

    public GameObject gameObject;
    public static Player player = new Player();

    // Use this for initialization
    void Awake () {
        DontDestroyOnLoad(gameObject);
        player.EquipItem(new Fists(Item.type.Weapon));
	}
}
