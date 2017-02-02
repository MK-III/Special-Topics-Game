using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    private Rigidbody2D player;
    private GroundCheck grndChk;

    public float jumpHeight = 400f;

	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
        grndChk = GetComponent<GroundCheck>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (grndChk.grounded)
        {
            if (Input.GetButtonDown("Jump"))
                player.AddForce(Vector2.up * jumpHeight);
        }
	}
}
