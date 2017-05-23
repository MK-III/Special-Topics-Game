using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeamTriggered : MonoBehaviour {

    public bool beamEntered = false;
    public bool once = true;
    public GameObject beam;
    Collider2D col;

    void Update()
    {
        if (beamEntered)
        {
           UnityEngine.Debug.Log("triggered");
            StartCoroutine(
                    Wait(5,
                    () =>
                    {
                        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SmoothCamera2>().enabled = false;
                        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().gravityScale = 0;
                        GameObject.FindGameObjectWithTag("Player").transform.Translate(new Vector3(0.0f, 0.01f, 0.0f));
                    },
                () =>
                {
                    if (once)
                    {
                        SceneManager.LoadScene("Scenes/Scene1", LoadSceneMode.Additive);
                        SceneManager.UnloadSceneAsync("Scenes/Opening");
                        once = false;
                    }
                }));
            
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        this.col = col;
        beamEntered = true;
    }
    IEnumerator Wait(float sec, Action before, Action after)
    {
        before();
        yield return new WaitForSeconds(sec);
        after();
    }
}
