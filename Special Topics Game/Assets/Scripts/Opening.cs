using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Linq;
using System;
using UnityStandardAssets._2D;

public class Opening : MonoBehaviour{
    public Animator title;
    public Text enter;
    public bool started;
    private bool once = true;
    public GameObject player;

    // Use this for initialization
    void Start () {
        //player.GetComponent<PlatformerCharacter2D>().enabled = false;
        player.GetComponent<Platformer2DUserControl>().enabled = false;
        title.SetBool("pressed", false);
        started = false;
	}

    void FixedUpdate()
    {
        GlobalVariables.gameStart = started;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());//idk why this works but it does
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            started = true;
            title.SetBool("pressed", true);
            //player.GetComponent<PlatformerCharacter2D>().enabled = true;
            player.GetComponent<Platformer2DUserControl>().enabled = true;
            enter.text = "";
        }
    }
}
