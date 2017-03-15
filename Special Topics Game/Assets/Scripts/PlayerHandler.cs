using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHandler : MonoBehaviour {

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
        //SceneManager.LoadSceneAsync("Scenes/gui", LoadSceneMode.Additive);
    }

    private void FixedUpdate(){
        float h = Input.GetAxisRaw("Horizontal");

        player.AddForce(Vector2.right * h * ((Input.GetKey(KeyCode.LeftShift)) ? runSpeed : walkSpeed));

        //Slow down player
        if (player.velocity.x > maxSpeed)
            player.velocity = new Vector2(maxSpeed, player.velocity.y);
        else if (player.velocity.x < -maxSpeed)
            player.velocity = new Vector2(-maxSpeed, player.velocity.y);

        player.velocity = dampSpeed(h);
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (GlobalVariables.inInventory == false)
            {
                SceneManager.LoadSceneAsync("Scenes/Equip Items", LoadSceneMode.Additive);
                GlobalVariables.inInventory = true;
            }
            else
            {
                SceneManager.UnloadSceneAsync("Scenes/Equip Items");
                GlobalVariables.inInventory = false;
            }
        }
    }

    private Vector2 dampSpeed(float h){
        Vector2 dampSpeed;

        if(h == 0 && Input.GetAxis("Vertical") == 0 && grndChk){
            dampSpeed.x = player.velocity.x / 2;
            dampSpeed.y = player.velocity.y;
        }
        else{
            dampSpeed.x = player.velocity.x;
            dampSpeed.y = player.velocity.y;
        }

        return dampSpeed;
    }


}
