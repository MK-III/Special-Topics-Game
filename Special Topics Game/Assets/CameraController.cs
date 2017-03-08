using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    public GameObject target;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 tempPos = target.transform.position;
        tempPos.x = tempPos.x + 0.0f;
        tempPos.y = tempPos.y + 0.0f;
        transform.position = tempPos;
        transform.LookAt(target.transform.position);
    }
}