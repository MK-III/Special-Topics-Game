using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoom : MonoBehaviour {

    public Transform wallTile;

    private void Start()
    {
        Instantiate(wallTile, new Vector3(20, 0, 5), Quaternion.identity);
    }
}
