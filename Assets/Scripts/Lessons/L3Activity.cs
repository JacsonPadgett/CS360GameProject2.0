using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class L3Activity : MonoBehaviour
{

	int currentNumber = 0;				//Current number chosen by the user
	public TextMeshProUGUI outputLabel;	//Text for the output of the function (Assigned in inspector)
	
	//Linked to the button in inspector, increments the selected value up by one
    public void PlusButton(){
		
		//Prevent the user from going above 15 since it gets slow at a certain point
		if(currentNumber < 15){
			currentNumber += 1;
			outputLabel.text = "fibonacci(" + currentNumber.ToString() + ") = " + fibonacci(currentNumber).ToString();
		}
	}
	
	//Linked to the button in inspector, increments the selected value down by one
	public void MinusButton(){
		
		//There should not be negative inputs
		if(currentNumber > 0){
			currentNumber -= 1;
			outputLabel.text = "fibonacci(" + currentNumber.ToString() + ") = " + fibonacci(currentNumber).ToString();
		}
	}
	
	//Returns the number of the fibonacci sequence at the given index n
	public int fibonacci(int n){
		
		//Base case: 0 index of fibonacci is 0
		if (n==0)
			return 0;
		
		//Base case: 1 index of fibonacci is 1
		if (n == 1)
			return 1;
		
		//Recursive case: any index of the fibonacci sequence is the previous two added together
		else
			return fibonacci(n - 1) + fibonacci(n - 2);
	}
}
