using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    
    public Rigidbody2D rigidbody2D;
    public GameObject PickedUp { get; set;}
    public List<GameObject> currentTouching;
    public int highlighedObject;
    public Canvas UI;
    public float dropCooldown;

    public bool droppable;

    // Use this for initialization
    void Start () {
        droppable = false;
        rigidbody2D.GetComponent<Rigidbody2D>();
        currentTouching = new List<GameObject>();
        highlighedObject = 0;
        //rigidbody2D.AddForce(new Vector2(1,0));
    }
	
	// Update is called once per frame
	void Update () {
        //Hightlight one of the objects the player is touching.
        if (highlighedObject > currentTouching.Count - 1)
        {
            highlighedObject = 0;
        }
        UpdateHighlights();

        if (Input.GetButtonDown("Fire1"))
        {
            highlighedObject++;
            UpdateHighlights();
        }

        if (Input.GetButtonDown("Jump")) {
            DropItem();
        }
    }

    void UpdateHighlights()
    {
        foreach (GameObject temp in currentTouching)
        {
            if (currentTouching.IndexOf(temp) == highlighedObject)
            {
                SetHighlights(temp, true);
            }
            else
            {
                SetHighlights(temp, false);
            }
        }
    }

    void SetHighlights(GameObject temp, bool set)
    {
        if (temp.GetComponent<Interaction>() != null)
        {
            temp.GetComponent<Interaction>().SetHighlighted(set);
        }
    }

    public void PickUp(GameObject item)
    {
        PickedUp = item.gameObject;
        UI.GetComponentInChildren<UnityEngine.UI.Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
        droppable = false;
        Invoke("allowDrop", dropCooldown);
    }

    public void DropItem() {
        if (currentTouching.Count == 0 && PickedUp != null && droppable) {
            Debug.Log("Dropping Item" + "currentTouching.Count = " + currentTouching.Count);
            PickedUp.transform.position = transform.position;
            PickedUp.SetActive(true);
            PickedUp = null;
            UI.GetComponentInChildren<UnityEngine.UI.Image>().sprite = null;
        }
    }

    private void allowDrop() {
        droppable = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        currentTouching.Add(col.gameObject);
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Person" || col.gameObject.tag == "Object" || col.gameObject.tag == "Item") {
            if (!currentTouching.Contains(col.gameObject)) {
                currentTouching.Add(col.gameObject);
            }
        }

        if (Input.GetButtonDown("Jump")){
            if (col.gameObject.tag == "Person" || col.gameObject.tag == "Object" || col.gameObject.tag == "Item" )
            {
                col.GetComponent<Interaction>().DoActionNow(this.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        currentTouching.Remove(col.gameObject);
    }
}
