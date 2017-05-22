using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera2 : MonoBehaviour
{

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target; //player
    private Camera camMain;
    private float distance;

    // Use this for initialization
    void Start()
    {
        camMain = GetComponent<Camera>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (target)
        {
            //transform.LookAt(target, transform.up);
            Vector3 point =  camMain.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - camMain.ViewportToWorldPoint(new Vector3(0.12f, 0.24f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

        }
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - distance);
    }
}
