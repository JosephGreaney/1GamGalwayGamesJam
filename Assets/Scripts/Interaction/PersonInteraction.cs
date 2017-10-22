using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonInteraction : MonoBehaviour, Interaction
{
    public bool highlighted;
    public SpeechBubble speechBubble;

    // Use this for initialization
    void Start()
    {
        highlighted = false;
        
    }

    // Update is called once per frame
    void Update()
    {

    }  

    public bool GetHighlighted()
    {
        return highlighted;
    }

    public void SetHighlighted(bool highlighted)
    {
        this.highlighted = highlighted;
    }

    public void DoActionNow(GameObject caller)
    {
        speechBubble.DisplaySpeechBubble();
    }
}
