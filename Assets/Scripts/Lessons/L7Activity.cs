using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L7Activity : MonoBehaviour
{
    //Assigned in inspector
    public Button nextButton;

    //Holds interacted with states for each of the buttons
    bool[] boolArray = {false, false, false, false, false};

    //Canvas sprite (assigned in inspector)
    public SpriteRenderer sprite;

    //Makes nextButton uninteractable
    void Start()
    {
      nextButton.interactable = false;      
    }

    //Checks if activity is complete, if true, make nextButton interactable
    void Update()
    {
      if(actvityComplete(boolArray)){
        nextButton.interactable = true;
      }
    }

    //Checks if each button has been interacted with
    bool actvityComplete(bool[] array){
      foreach(bool n in array){
        if(!n){
          return false;
        }
      }
      return true;
    }
    
    
    /*
    These functions change the bool value in the bool array corresponding to each button.
    Meant to be attached to button and used with the built in OnClick() found in inspector.
    Could most likely be rewritten as one function.
    */
    
    public void floatButtonClicked(bool res){
      boolArray[0] = res;
      sprite.color = Color.red;
    }

    public void integerButtonClicked(bool res){
      boolArray[1] = res;
      sprite.color = Color.blue;
    }

    public void doubleButtonClicked(bool res){
      boolArray[2] = res;
      sprite.color = Color.magenta;
    }

    public void booleanButtonClicked(bool res){
      boolArray[3] = res;
      sprite.color = Color.yellow;
    }

    public void stringButtonClicked(bool res){
      boolArray[4] = res;
      sprite.color = Color.green;
    }
}
