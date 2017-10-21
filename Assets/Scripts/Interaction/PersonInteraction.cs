using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonInteraction : MonoBehaviour, Interaction
{
    public bool highlighted;
    public string word;

    // Use this for initialization
    void Start()
    {
        highlighted = false;
        word = "Hey there friend";
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
        if (highlighted)
            Debug.Log(word);
    }
}
