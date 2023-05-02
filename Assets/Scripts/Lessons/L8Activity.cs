using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L8Activity : MonoBehaviour
{
    public Button nextButton;
    public GameObject[] blocks;

    //Makes nextButton (assigned in inspector) uninteractable
    //Populates the blocks array using a tag assigned to each of the blocks in the inspector
    void Start()
    {
        nextButton.interactable = false;
        blocks = GameObject.FindGameObjectsWithTag("BTBlock");
    }

    // Update is called once per frame
    void Update()
    {
        if(activityCompleted()){
            nextButton.interactable = true;
        };
    }

    //Checks if each of the blocks is in its correct spot
    public bool activityCompleted(){
        foreach(GameObject x in blocks){
            MoveSystem thisScript = x.GetComponent<MoveSystem>();
            if(!thisScript.finished){
                return false;
            }
        }
        return true;
    }

    //Resets each of the blocks in the scene back to its original position and finished state
    public void resetActivity(){
        nextButton.interactable = false;
        foreach(GameObject x in blocks){
            MoveSystem thisScript = x.GetComponent<MoveSystem>();
            thisScript.resetBlock();
        }
    }
}
