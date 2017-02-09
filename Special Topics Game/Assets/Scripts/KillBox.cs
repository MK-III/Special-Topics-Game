using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBox : MonoBehaviour {

    public bool contact;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Contains("Kill"))
        {
            contact = true;
            //SceneManager.UnloadSceneAsync("Scenes/gui");
            Destroy(col.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag.Equals("Kill"))
            contact = true;

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag.Equals("Kill"))
            contact = false;
    }
}
