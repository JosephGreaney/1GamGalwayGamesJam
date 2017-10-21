using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, Interaction{
    private bool highlighted;

    // Use this for initialization
    void Start () {
        highlighted = false;
    }
	
	// Update is called once per frame
	void Update () {
		
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
        {
            caller.GetComponent<PlayerInteraction>().PickUp(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
