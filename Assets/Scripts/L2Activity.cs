using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// By: Giavonni Papenbrock
// The driver for the lesson 2 activity
public class L2Activity : MonoBehaviour
{
    // Data related to the activity.
    private int mCorrectAnswers;
    private int mRequiredAnswers;
    private int mCurrentIndexValue;
    private int mCurrentSizeValue;

    // Dynamic text on the scene, from the inspector.
    public TMP_Text mQuestionPromptText;
    public TMP_Text mResponseText;
    public TMP_Text mCorrectAnswersText;
    public TMP_Text mRequiredAnswersText;

    // A response text field for telling the user if they were right or wrong.
    private float mResponseTextTimer;

    // Next button from inspector. User can't continue until answering enough questions.
    public Button mNextButton;

    // Color presets.
    private Color mCorrectColor = new Color(0.0f, 1.0f, 0.0f);
    private Color mWrongColor = new Color(1.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        mCorrectAnswers = 0;
        mNextButton.interactable = false;
        mResponseText.text = "";
        mCorrectAnswersText.text = "0";
        InitializeActivity();
        GenerateNewPrompt();
    }

    // Generate amount of required answers before progressing.
    private void InitializeActivity()
    {
        // Required answers, between 3 - 7
        mRequiredAnswers = (int)Mathf.Round(Random.value * 4.0f + 3.0f);
        mRequiredAnswersText.text = mRequiredAnswers.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Is previous animation finished?
        if (mResponseTextTimer < 0.0f)
        {
            mResponseTextTimer = 0.0f;
            mResponseText.text = "";
        }

        // Is an animation currently playing?
        if (mResponseTextTimer > 0.0f)
        {
            // Decrease time value.
            mResponseTextTimer -= Time.deltaTime;
        }
    }

    // The player submits an answer.
    public void SubmitAnswer(string argAnswer)
    {
        int ParsedAnswer = 0;
        bool IsValid = int.TryParse(argAnswer, out ParsedAnswer);

        if (!IsValid)
        {
            // Tell user they suck.
            mResponseText.color = mWrongColor;
            mResponseText.text = "Invalid entry! Please put a number?";
            mResponseTextTimer = 3.0f;
            return;
        }

        if (ParsedAnswer == mCurrentIndexValue * mCurrentSizeValue)
        {
            mCorrectAnswers++;
            mCorrectAnswersText.text = mCorrectAnswers.ToString();
            // Tell user they got it right.
            mResponseText.color = mCorrectColor;
            mResponseText.text = "Correct! Keep it going!";
            mResponseTextTimer = 3.0f;
        }
        else
        {
            // Tell user they were wrong.
            mResponseText.color = mWrongColor;
            mResponseText.text = "Incorrect! Here's a different question, try again!";
            mResponseTextTimer = 3.0f;
        }

        // if correct answers = required answers, allow user to use right arrow
        if (mCorrectAnswers == mRequiredAnswers)
        {
            mNextButton.interactable = true;
        }

        GenerateNewPrompt();
    }

    private void GenerateNewPrompt()
    {
        // Obtain new number random from 0 - 10. This is the index.
        mCurrentIndexValue = (int)Mathf.Round(Random.value * 10.0f);

        // Obtain a number from 1 - 16. Powers of 4. This is the size.
        mCurrentSizeValue = (int)Mathf.Pow(2, Mathf.Round(Random.value * 4.0f));

        // Update the text.
        mQuestionPromptText.text = "You are accessing the element at index " + mCurrentIndexValue 
            + ". Each element has a size of " + mCurrentSizeValue + ". How many bytes is the element from the array's location?";
    }
}
