using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopCamera : MonoBehaviour {

    public bool triggered = false;
    Collider2D col;

    void Update()
    {
        if (triggered)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SmoothCamera2>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        this.col = col;
        triggered = true;
    }
    
}
