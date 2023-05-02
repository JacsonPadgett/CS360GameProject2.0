using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// By: Giavonni Papenbrock
// A driver for the lesson 1 activity
public class L1Activity : MonoBehaviour
{

    // The amount of the time, in seconds, it takes for the big O sprite to change color.
    private static float BIGOANIMATIONTIME = 0.25f;

    // The different names of the data structures
    enum DataStructureButtonName
    {
        Array,
        LinkedList,
        Stack,
        BinaryTree,
        HashMap
    }

    // The different names of the operations
    enum OperationButtonName
    {
        Access,
        Insert,
        Remove,
        Search
    }

    // The next button, supplied by the inspector, for disabling at the start of the lesson and
    // enabling at the end of the lesson.
    public Button mNextButton;

    // Array of the buttons. The Boolean is true if the button is selected, false if the button is
    // not selected.
    private bool[] mDataStructureButtons;
    private bool[] mOperationButtons;

    // The Big O sprite and text, supplied by the inspector.
    public SpriteRenderer mBigOSprite;
    public TMP_Text mBigOText;

    // The text displaying the currently selected data structure and operation, supplied by the
    // inspector from the scene.
    public TMP_Text mCurrentDSText;
    public TMP_Text mCurrentOperationText;

    // A Boolean for if an animation is queued. An animation is usually queued when the data
    // structure or operation has changed.
    private bool mAnimationQueued;
    private float mBigOAnimationTimer;

    // Information for the Big O sprite animation. The previous color is the last color and the
    // target color is the final color, both corresponding to their Big O speed. Functions will
    // interpolate between these two colors depending on how long the animation has left and
    // display the result.
    private Color mPreviousColor;
    private Color mTargetColor;

    // If all buttons have been pressed. This is the continue condition.
    private bool[] AllButtonsPressed;

    // The different names of the big O statuses.
    enum BigOStatus
    {
        Horrible,
        Bad,
        Fair,
        Good,
        Excellent,
        NA
    }

    // All of the colors available for the different big O statuses.
    private Color mHorribleColor = new Color(0.99607f, 0.5372549f, 0.5333333f); //FE8988
    private Color mBadColor = new Color(1.0f, 0.7725490f, 0.2666666f); //FFC544
    private Color mFairColor = new Color(1.0f, 1.0f, 0.0f); //FFFF00
    private Color mGoodColor = new Color(0.7803921f, 0.9176470f, 0.0078431f); //C8EA03
    private Color mExcellentColor = new Color(0.3333333f, 0.8117647f, 0.0f); //55CF00
    private Color mNAColor = new Color(0.8901960f, 0.8901960f, 0.8901960f); //E3E3E3


    // Start is called before the first frame update
    void Start()
    {
        // Initialize all arrays to proper sizes.
        mDataStructureButtons = new bool[5];
        mOperationButtons = new bool[4];
        AllButtonsPressed = new bool[20];

        // Disable next button. User required to interact with lesson.
        mNextButton.interactable = false;

        // Set Big O animation timer to 0.
        mBigOAnimationTimer = 0.0f;

        // No animation queued.
        mAnimationQueued = false;

        // Set Big O sprite to initial grey color.
        mBigOSprite.color = mNAColor;

        // The color of big O text is always inversion of big O sprite color.
        mBigOText.color = InvertBigOColor();

        // Default text.
        mBigOText.text = "N/A";
        mCurrentDSText.text = "N/A";
        mCurrentOperationText.text = "N/A";
    }

    // Update is called once per frame
    void Update()
    {
        // Is previous animation finished?
        if (mBigOAnimationTimer < 0.0f)
        {
            mBigOAnimationTimer = 0.0f;
            Debug.Log("Animation finished.");
        }

        // Is an animation currently playing?
        if (mBigOAnimationTimer > 0.0f)
        {
            // Decrease color value.
            mBigOAnimationTimer -= Time.deltaTime;

            // Update the big o sprite
            UpdateBigOSprite();

            mBigOText.color = InvertBigOColor();
        }

        // Is an animation queued to play?
        if (mAnimationQueued)
        {
            Debug.Log("Animation detected.");

            // We are now processing this animation, set to false
            mAnimationQueued = false;

            // Determine the big o value (check if color actually changes. if not, end early)
            Color BigOColor = DetermineBigOColor();

            // Set the target color to corresponding big o color
            mTargetColor = BigOColor;

            // Get the current color from the Big O sprite
            Color CurrentColor = mBigOSprite.color;

            // Set the previous color, which is the starting color
            mPreviousColor = CurrentColor;

            // Set the animation timer to 2 seconds
            mBigOAnimationTimer = BIGOANIMATIONTIME;
        }
    }

    // "Invert" the color of the Big O sprite. Used for the text to keep it visible.
    private Color InvertBigOColor()
    {
        return new Color(1.0f - mBigOSprite.color.r, 1.0f - mBigOSprite.color.g, 1.0f - mBigOSprite.color.b);
    }

    // Change the Big O color and text based on combination of data structure and operation
    // selected. I'm not commenting each one -- should be self-explanatory.
    private Color DetermineBigOColor()
    {
        if (mDataStructureButtons[(int)DataStructureButtonName.Array])
        {
            if (mOperationButtons[(int)OperationButtonName.Access])
            {
                mBigOText.text = "O(1) - Constant";
                return mExcellentColor;
            }
            if (mOperationButtons[(int)OperationButtonName.Insert])
            {
                mBigOText.text = "O(n) - Linear";
                return mFairColor;
            }
            if (mOperationButtons[(int)OperationButtonName.Remove])
            {
                mBigOText.text = "O(n) - Linear";
                return mFairColor;
            }
            if (mOperationButtons[(int)OperationButtonName.Search])
            {
                mBigOText.text = "O(n) - Linear";
                return mFairColor;
            }
        }
        else if (mDataStructureButtons[(int)DataStructureButtonName.LinkedList])
        {
            if (mOperationButtons[(int)OperationButtonName.Access])
            {
                mBigOText.text = "O(n) - Linear";
                return mFairColor;
            }
            if (mOperationButtons[(int)OperationButtonName.Insert])
            {
                mBigOText.text = "O(1) - Constant";
                return mExcellentColor;
            }
            if (mOperationButtons[(int)OperationButtonName.Remove])
            {
                mBigOText.text = "O(1) - Constant";
                return mExcellentColor;
            }
            if (mOperationButtons[(int)OperationButtonName.Search])
            {
                mBigOText.text = "O(n) - Linear";
                return mFairColor;
            }
        }
        else if (mDataStructureButtons[(int)DataStructureButtonName.Stack])
        {
            if (mOperationButtons[(int)OperationButtonName.Access])
            {
                mBigOText.text = "O(n) - Linear";
                return mFairColor;
            }
            if (mOperationButtons[(int)OperationButtonName.Insert])
            {
                mBigOText.text = "O(1) - Constant";
                return mExcellentColor;
            }
            if (mOperationButtons[(int)OperationButtonName.Remove])
            {
                mBigOText.text = "O(1) - Constant";
                return mExcellentColor;
            }
            if (mOperationButtons[(int)OperationButtonName.Search])
            {
                mBigOText.text = "O(n) - Linear";
                return mFairColor;
            }
        }
        else if (mDataStructureButtons[(int)DataStructureButtonName.BinaryTree])
        {
            if (mOperationButtons[(int)OperationButtonName.Access])
            {
                mBigOText.text = "O(log n) - Logarithmic";
                return mGoodColor;
            }
            if (mOperationButtons[(int)OperationButtonName.Insert])
            {
                mBigOText.text = "O(log n) - Logarithmic";
                return mGoodColor;
            }
            if (mOperationButtons[(int)OperationButtonName.Remove])
            {
                mBigOText.text = "O(log n) - Logarithmic";
                return mGoodColor;
            }
            if (mOperationButtons[(int)OperationButtonName.Search])
            {
                mBigOText.text = "O(log n) - Logarithmic";
                return mGoodColor;
            }
        }
        else if (mDataStructureButtons[(int)DataStructureButtonName.HashMap])
        {
            if (mOperationButtons[(int)OperationButtonName.Access])
            {
                mBigOText.text = "N/A";
                return mNAColor;
            }
            if (mOperationButtons[(int)OperationButtonName.Insert])
            {
                mBigOText.text = "O(1) - Constant";
                return mExcellentColor;
            }
            if (mOperationButtons[(int)OperationButtonName.Remove])
            {
                mBigOText.text = "O(1) - Constant";
                return mExcellentColor;
            }
            if (mOperationButtons[(int)OperationButtonName.Search])
            {
                mBigOText.text = "O(1) - Constant";
                return mExcellentColor;
            }
        }
        mBigOText.text = "N/A";
        return mNAColor;
    }

    // Functions for interpolating the color for the Big O sprite.
    private void UpdateBigOSprite()
    {
        // Get the amount of steps to use for interpolation
        double TimerRemainder = mBigOAnimationTimer / BIGOANIMATIONTIME;

        double NewInterpolationValue = InterpolateSCurve(TimerRemainder);

        // Use new interpolation value to interpolate color.
        mBigOSprite.color = Color.Lerp(mPreviousColor, mTargetColor, (float)NewInterpolationValue);
    }
    private double InterpolateSCurve(double argInterpolationValue)
    {
        // 2x^3 - 3x^2 + 1
        // Easier to read
        double x = argInterpolationValue;

        // Get new interpolation value from s-curve
        return 2.0 * x * x * x - 3.0 * x * x + 1.0;
    }

    // Click button handlers.
    public void ClickDataStructureButton(int argIndex)
    {
        if (mDataStructureButtons[argIndex])
        {
            return;
        }

        SwapDataStructure(argIndex);
        mAnimationQueued = true;
        UpdateAllButtonsPressed();
    }
    private void SwapDataStructure(int argIndex)
    {
        // change Boolean status of ds array
        for (int i = 0; i < mDataStructureButtons.Length; i++)
        {
            mDataStructureButtons[i] = false;
        }

        mDataStructureButtons[argIndex] = true;

        if (mDataStructureButtons[(int)DataStructureButtonName.Array]) mCurrentDSText.text = "Array";
        else if (mDataStructureButtons[(int)DataStructureButtonName.LinkedList]) mCurrentDSText.text = "Linked List";
        else if (mDataStructureButtons[(int)DataStructureButtonName.Stack]) mCurrentDSText.text = "Stack";
        else if (mDataStructureButtons[(int)DataStructureButtonName.BinaryTree]) mCurrentDSText.text = "Binary Tree";
        else if (mDataStructureButtons[(int)DataStructureButtonName.HashMap]) mCurrentDSText.text = "Hash Map";
    }
    public void ClickOperationButton(int argIndex)
    {
        if (mOperationButtons[argIndex])
        {
            return;
        }

        SwapOperation(argIndex);
        mAnimationQueued = true;
        UpdateAllButtonsPressed();
    }
    private void SwapOperation(int argIndex)
    {
        // change Boolean status of ds array
        for (int i = 0; i < mOperationButtons.Length; i++)
        {
            mOperationButtons[i] = false;
        }

        mOperationButtons[argIndex] = true;

        if (mOperationButtons[(int)OperationButtonName.Access]) mCurrentOperationText.text = "Access";
        else if (mOperationButtons[(int)OperationButtonName.Insert]) mCurrentOperationText.text = "Insert";
        else if (mOperationButtons[(int)OperationButtonName.Remove]) mCurrentOperationText.text = "Remove";
        else if (mOperationButtons[(int)OperationButtonName.Search]) mCurrentOperationText.text = "Search";
    }

    // Updating the clear condition.
    private void UpdateAllButtonsPressed()
    {
        int DSIndex;
        for (DSIndex = 0; DSIndex < mDataStructureButtons.Length; DSIndex++)
        {
            if (mDataStructureButtons[DSIndex]) break;
        }
        int OpIndex;
        for (OpIndex = 0; OpIndex < mOperationButtons.Length; OpIndex++)
        {
            if (mOperationButtons[OpIndex]) break;
        }
        AllButtonsPressed[DSIndex * 4 + OpIndex] = true;
        Debug.Log("Button Combo " + (DSIndex * 4 + OpIndex) + " Pressed");

        CheckAllButtons();
    }
    private void CheckAllButtons()
    {
        for(int i = 0; i < AllButtonsPressed.Length; i++)
        {
            if (!AllButtonsPressed[i]) return;
        }
        mNextButton.interactable = true;
    }
}
