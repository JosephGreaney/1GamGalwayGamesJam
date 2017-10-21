using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAction : MonoBehaviour, Interaction{
    private bool highlighted;

    // Use this for initialization
    void Start () {
        highlighted = false;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void DoActionNow(GameObject caller)
    {
        if(highlighted)
            Debug.Log("Let me do my thing!!!");
    }

    public bool GetHighlighted()
    {
        return highlighted;
    }

    public void SetHighlighted(bool highlighted)
    {
        this.highlighted = highlighted;
    }
}
