using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizGrader : MonoBehaviour
{
    public int numberQuestions = 10;

    public static int numberCorrect = 0;

    //These are assigned in the inspector after the script has been attached to a GameObject
    public TMP_Text label_numberCorrect;
    public TMP_Text label_percentage;
    public TMP_Text label_letterGrade;

    public void Start(){
        //Checked when scene is loaded, checking for last part of quiz (Ex. Q10P13)
        if(SceneManager.GetActiveScene().name.CompareTo("Q1P3") == 0){
            generateReport();
        }
    }
    
    //correctToggle is passed through the inspector
    public void checkAnswer(Toggle correctToggle){
        if(correctToggle.isOn){
            numberCorrect++;
        }
    }

    //Calculates the final grade of the quiz
    public float finalGrade(){
        return numberCorrect / numberQuestions;
    }

    //Assigns new text to the variables passed through the inspector
    public void generateReport(){
        label_numberCorrect.text = "Number Correct: " + numberCorrect + "/" + numberQuestions;
        label_percentage.text = "Percentage: " + (int)(((double)numberCorrect / (double)numberQuestions) * 100) + "%";
        
        switch(numberCorrect){
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                label_letterGrade.text = "Letter Grade: F";
                break;
            case 6:
                label_letterGrade.text = "Letter Grade: D";
                break;
            case 7:
                label_letterGrade.text = "Letter Grade: C";
                break;
            case 8:
                label_letterGrade.text = "Letter Grade: B";
                break;
            case 9:
            case 10:
                label_letterGrade.text = "Letter Grade: A";
                break;
        }
    }
}
