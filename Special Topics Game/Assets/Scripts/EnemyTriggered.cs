using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTriggered : MonoBehaviour {

    public bool contact;
    private string enemyName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Contains("Enemy"))
        {
            contact = true;
            //SceneManager.UnloadSceneAsync("Scenes/gui");
            SceneManager.LoadSceneAsync("Scenes/combat", LoadSceneMode.Additive);

            if (col.tag.Contains("Zombie")) { GlobalVariables.enemyName = "Zombie"; }
            if (col.tag.Contains("Alien")) { GlobalVariables.enemyName = "Alien"; }

            Destroy(col.gameObject);
        }
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
