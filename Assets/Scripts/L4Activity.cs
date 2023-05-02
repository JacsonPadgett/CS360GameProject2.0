using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// By: Giavonni Papenbrock
// The driver for the lesson 4 activity
public class L4Activity : MonoBehaviour
{

	// Next button from inspector.
	public Button mNextButton;

	// Line renderer for drawing the white line.
	private LineRenderer mLineRenderer;

	// Objects on the scene that we use to draw the line.
	public GameObject mLeftEnd;
	public GameObject[] mBoxes;
	public GameObject mRightEnd;

	// An array to figure out the order that the user has the boxes in.
    private int[] mOrderPreserved = new int[5];

	// The material of the line.
    Material mLineRendererMaterial;

	// Start is called before the first frame update
	void Start()
	{
		mNextButton.interactable = false;

		// Create the line renderer, attach to mLineRenderer
		mLineRenderer = gameObject.AddComponent<LineRenderer>();
		mLineRenderer.startColor = new Color(0.0f, 0.0f, 0.0f);
		mLineRenderer.endColor = new Color(0.0f, 0.0f, 0.0f);

		// Create the line renderer material, attach to line renderer
		mLineRendererMaterial = new Material(Shader.Find("Unlit/Texture"));
		mLineRenderer.material = mLineRendererMaterial;

		// Change line width
		AnimationCurve curve = new AnimationCurve();
		curve.AddKey(0.25f, 0.25f);
		mLineRenderer.widthCurve = curve;
		mLineRenderer.widthMultiplier = 1.0f;

		// Set up the box order array
        for (int i = 0; i < mOrderPreserved.Length; i++)
        {
            mOrderPreserved[i] = i + 1;
        }
    }

	// Update is called once per frame
	void Update()
	{
		// The amount of positions the line will go between
		int PositionCount = 2; // Add one for left end and right end

		// An array for if a box, at the same index, is close enough to rope (ones that aren't
		// close enough aren't going to be connected)
		bool[] IsCloseToRope = new bool[mBoxes.Length];

		// Sort the box array by x position (return value is whether or not the boxes are in the
		// correct order)
		bool IsCorrectOrder = SortArray();

		// Check if all of the boxes are on the line.
		bool IsAllOnLine = true;
		for (int i = 0; i < mBoxes.Length; i++)
		{
			if (mBoxes[i].transform.position.y < 1.0f)
			{
				IsCloseToRope[i] = true;
				PositionCount++;
			}
			else
			{
				IsAllOnLine = false;

            }
		}

		// If all of the boxes are on the line and in the correct order, all the user to proceed.
		if (IsCorrectOrder && IsAllOnLine)
		{
			mNextButton.interactable = true;
        }

		// Set the position count.
		mLineRenderer.positionCount = PositionCount;

		// Set the left end to the first position, which is where the line starts.
		mLineRenderer.SetPosition(0, mLeftEnd.transform.position);

		// If a box is close enough to the line, add that box's position to the line's positions.
		for (int boxIndex = 0, positionIndex = 1; boxIndex < mBoxes.Length; boxIndex++)
		{
			if (IsCloseToRope[boxIndex])
			{
				mLineRenderer.SetPosition(positionIndex, mBoxes[boxIndex].transform.position);
				positionIndex++;
			}
		}

		// Add the right end as the end of the line.
		mLineRenderer.SetPosition(PositionCount - 1, mRightEnd.transform.position);
	}

	// A selection or insertion (can't remember) sort for ordering the boxes by x position.
	public bool SortArray()
	{
		var arrayLength = mBoxes.Length;
		for (int i = 0; i < arrayLength - 1; i++)
		{
			var smallestVal = i;
			for (int j = i + 1; j < arrayLength; j++)
			{
				if (mBoxes[j].transform.position.x < mBoxes[smallestVal].transform.position.x)
				{
					smallestVal = j;
				}
			}
			var tempVar = mBoxes[smallestVal];
			var tempVar2 = mOrderPreserved[smallestVal];
			mBoxes[smallestVal] = mBoxes[i];
            mOrderPreserved[smallestVal] = mOrderPreserved[i];
			mBoxes[i] = tempVar;
            mOrderPreserved[i] = tempVar2;
		}

		// A hard-coded check for if the boxes are in the correct position.
		if (mOrderPreserved[0] == 2 && mOrderPreserved[1] == 5 && mOrderPreserved[2] == 3 && mOrderPreserved[3] == 1 && mOrderPreserved[4] == 4)
		{
			return true;
		}

		return false;
	}
}
