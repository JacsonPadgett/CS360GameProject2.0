using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : MonoBehaviour
{
    //Correct position of the movable object, assigned in inspector
    public GameObject correctForm;
    
    private bool moving;
    
    //Is the object in the correct place
    public bool finished;

    //Starting position of the object
    private float startPosX;
    private float startPosY;

    //Objects original position at start of scene
    Vector3 resetPosition;

    // Start is called before the first frame update
    void Start()
    {
       resetPosition = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //Allow movement while object is not finished (on top of the correctForm game object)
        if(!finished){        
            if(moving){
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
            }
        }

    }

    //When mouse is pressed, object follows mouse cursor
    private void OnMouseDown(){
        if(Input.GetMouseButtonDown(0)){
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }

    }

    //If the object (when mouse is released) is on top of the correctForm object, then lock object in place. Else, reset object back to it's original position

    /*IMPORTANT:
    if(Math.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 1 && Math.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= 1)
    
    The number being compared to (in this case 1) is the degree of accuracy of the game object being on top of the correctForm game object. Ex. .5 requires more accuracy while 2 requires less accuracy.
    */
    private void OnMouseUp(){
        moving = false;

        if(Math.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 1 && Math.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= 1){
                this.transform.position = new Vector3(correctForm.transform.position.x, correctForm.transform.position.y,correctForm.transform.position.z);
                finished = true;
        }
        else{
            this.transform.localPosition = new Vector3(resetPosition.x,resetPosition.y,resetPosition.z);
        }
    }

    
    //Sets the block to unfinished and resets it back to its original location
    public void resetBlock(){
        finished = false;
        this.transform.localPosition = new Vector3(resetPosition.x,resetPosition.y,resetPosition.z);
    }
}
