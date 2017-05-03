using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

    public bool doorEntered = false;
    public GameObject extDoor;
    Collider2D col;
	
	// Update is called once per frame
	void Update () {
        if (doorEntered)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                var movePosition = extDoor.transform.position - col.transform.position;
                col.transform.position = extDoor.transform.position;
                Camera.main.transform.position += movePosition;
            }
        }
	}
    
    void OnTriggerEnter2D(Collider2D col)
    {
        this.col = col;
        doorEntered = true;
    }
}
