﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float walkSpeed = 10f;
    public float runSpeed = 15f;
    public float maxSpeed = 5f;
    public bool inCombat = GlobalVariables.inCombat;


    private Rigidbody2D player;
    private GroundCheck grndChk;


	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
        grndChk = GetComponent<GroundCheck>();
        GlobalVariables.eqp[1] = new Fists(0, Item.type.Weapon);
        GlobalVariables.eqp[0] = new Revolver(1, Item.type.Weapon);
        //SceneManager.LoadSceneAsync("Scenes/gui", LoadSceneMode.Additive);
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        player.AddForce(Vector2.right * h * ((Input.GetKey(KeyCode.LeftShift)) ? runSpeed : walkSpeed));

        //Slow down player
        if (player.velocity.x > maxSpeed)
            player.velocity = new Vector2(maxSpeed, player.velocity.y);
        else if (player.velocity.x < -maxSpeed)
            player.velocity = new Vector2(-maxSpeed, player.velocity.y);

        player.velocity = dampSpeed(h);

        //Add if statement to check if dead

        Mathf.Clamp(GlobalVariables.health, 0, 100);
    }

    private Vector2 dampSpeed(float h)
    {
        Vector2 dampSpeed;

        if(h == 0 && Input.GetAxis("Vertical") == 0 && grndChk)
        {
            dampSpeed.x = player.velocity.x / 2;
            dampSpeed.y = player.velocity.y;
        }
        else
        {
            dampSpeed.x = player.velocity.x;
            dampSpeed.y = player.velocity.y;
        }

        return dampSpeed;
    }


}
