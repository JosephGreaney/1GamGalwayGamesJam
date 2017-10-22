using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLocation : MonoBehaviour, Interaction  {

    private GameObject item;
    public bool highlighted;
    private bool containsLure;
    private String currentLure;

    // Use this for initialization
    void Start()
    {
        highlighted = false;
        containsLure = false;
        currentLure = "None";
    }

    public void DoActionNow(GameObject caller)
    {
        item = caller.GetComponent<PlayerInteraction>().PickedUp;
        if (item)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            currentLure = item.GetComponent<SpriteRenderer>().sprite.name;
            containsLure = true;
            item = null;
            caller.GetComponent<PlayerInteraction>().UI.GetComponentInChildren<UnityEngine.UI.Image>().sprite = null;
        }
    }

    public bool GetHighlighted()
    {
        return highlighted;
    }

    public void SetHighlighted(bool set)
    {
        highlighted = set;
    }
}
