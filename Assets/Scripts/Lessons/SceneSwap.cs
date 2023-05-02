using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{

/*This script takes a String name of the scene you wish to load.
For use with buttons, attach script to button and select the SceneSwap script in the inspector. 
Next, select the LoadScene function. This will allow you to enter the name of the scene
you wish to load once the button is clicked.*/

public void LoadScene(string sceneName){
    SceneManager.LoadScene(sceneName);
}

}
