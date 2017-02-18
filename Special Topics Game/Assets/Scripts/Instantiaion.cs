using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiaion : MonoBehaviour {

    public GameObject gameObject;

	// Use this for initialization
	void Awake () {
        DontDestroyOnLoad(gameObject);
	}

    public static Player player = new Player();
	
}
