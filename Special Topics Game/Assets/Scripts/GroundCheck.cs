using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    public bool grounded;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Ground"))
            grounded = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag.Equals("Ground"))
            grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag.Equals("Ground"))
            grounded = false;
    }


 
}
