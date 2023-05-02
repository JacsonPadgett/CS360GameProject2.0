using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class L5Activity : MonoBehaviour
{

	string[] array = new string[5];		//Array representing the stack
	int arraySize = 0;					//Since the array is always length 5, this represents the amount of items in the array
	public TMP_InputField iField;		//Input text field (Assigned in inspector)
	public TextMeshProUGUI text0;		//Text for first item in stack (Assigned in inspector)
	public TextMeshProUGUI text1;		//Text for second item in stack (Assigned in inspector)
	public TextMeshProUGUI text2;		//Text for third item in stack (Assigned in inspector)
	public TextMeshProUGUI text3;		//Text for fourth item in stack (Assigned in inspector)
	public TextMeshProUGUI text4;		//Text for fifth item in stack (Assigned in inspector)
	public TextMeshProUGUI textPop;		//Text that displays which item was popped last (Assigned in inspector)
	
	//Linked to the button in inspector, pushes the text in the input field to the stack
    public void PushButton(){
		
		//Only push if the array is not full
		if(arraySize < 5){
			
			//Set next index in the array to the inputted text
			array[arraySize] = iField.text;
			
			arraySize += 1;
			UpdateLabels();
		}
	}
	
	//Linked to the button in inspector, pops the top value from the stack
	public void PopButton(){
		
		//Only pop if the queue has anything to pop
		if(arraySize > 0){
			
			//Set the output text to the data that will be removed
			textPop.text = array[arraySize-1];
			
			//Remove text from the index in the array
			array[arraySize-1] = "";
			
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
