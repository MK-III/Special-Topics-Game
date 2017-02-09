using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMain : MonoBehaviour {

	public void OnClick()
    {
        Debug.Log("On Click");
        GlobalVariables.inCombat = false;
        SceneManager.UnloadSceneAsync("Scenes/combat");
        //SceneManager.LoadSceneAsync("Scenes/gui", LoadSceneMode.Additive);

    }

   

}
