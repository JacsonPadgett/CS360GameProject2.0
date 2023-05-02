using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class L6Activity : MonoBehaviour
{

	string[] array = new string[5];		//Array representing the queue
	int arraySize = 0;					//Since the array is always length 5, this represents the amount of items in the array
	public TMP_InputField iField;		//Input text field (Assigned in inspector)
	public TextMeshProUGUI text0;		//Text for first item in queue (Assigned in inspector)
	public TextMeshProUGUI text1;		//Text for second item in queue (Assigned in inspector)
	public TextMeshProUGUI text2;		//Text for third item in queue (Assigned in inspector)
	public TextMeshProUGUI text3;		//Text for fourth item in queue (Assigned in inspector)
	public TextMeshProUGUI text4;		//Text for fifth item in queue (Assigned in inspector)
	public TextMeshProUGUI textPop;		//Text that displays which item was popped last (Assigned in inspector)
	
	//Linked to the button in inspector, pushes the text in the input field to the queue
    public void PushButton(){
		
		//Only push if the array is not full
		if(arraySize < 5){
			
			//Set next index in the array to the inputted text
			array[arraySize] = iField.text;
			
			arraySize += 1;
			UpdateLabels();
		}
	}

	//Linked to the button in inspector, pops the bottom value from the queue
	public void PopButton(){
		
		//Only pop if the queue has anything to pop
		if(arraySize > 0){
			
			//Set the output text to the data that will be removed
			textPop.text = array[0];
			
			//Move each item down by one
			array[0] = array[1];
			array[1] = array[2];
			array[2] = array[3];
			array[3] = array[4];
			array[4] = "";
			
			arraySize -= 1;
			UpdateLabels();
		}
	}
	
	//Set text outputs to array data
	public void UpdateLabels(){
		text0.text = array[0];
		text1.text = array[1];
		text2.text = array[2];
		text3.text = array[3];
		text4.text = array[4];
	}
}
