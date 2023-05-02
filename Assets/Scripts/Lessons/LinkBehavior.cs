using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkBehavior : MonoBehaviour
{

    public GameObject mDestinationObject;

    private LineRenderer mLineRenderer;

    Material mLineRendererMaterial;

    // Start is called before the first frame update
    void Start()
    {
        // Random line stuffs
        mLineRenderer = gameObject.AddComponent<LineRenderer>();
        mLineRenderer.startColor = new Color(0.0f, 0.0f, 0.0f);
        mLineRenderer.endColor = new Color(0.0f, 0.0f, 0.0f);
        mLineRendererMaterial = new Material(Shader.Find("Unlit/Texture"));
        mLineRenderer.material = mLineRendererMaterial;
        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(0.25f, 0.25f);
        mLineRenderer.widthCurve = curve;
        mLineRenderer.widthMultiplier = 1.0f;

        // The stuff that matters
        mLineRenderer.SetPosition(0, this.transform.position);
        mLineRenderer.SetPosition(1, mDestinationObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
