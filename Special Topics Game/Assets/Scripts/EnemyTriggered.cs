using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTriggered : MonoBehaviour {

    public bool contact;
    private string enemyName;
    public GameObject enemy;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Enemy"))
        {
            contact = true;
            SceneManager.LoadSceneAsync("Scenes/combat", LoadSceneMode.Additive);
            Destroy(enemy);
        }
        enemyName = col.name;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag.Equals("Enemy")) 
            contact = true;
        enemyName = col.name;
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag.Equals("Enemy"))
            contact = false;
    }

    public string getName()
    {
        return enemyName;
    }
}
