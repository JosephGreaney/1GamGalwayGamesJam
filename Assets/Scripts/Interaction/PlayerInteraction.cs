using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    
    public Rigidbody2D rigidbody2D;
    public GameObject pickedUp;
    public List<GameObject> currentTouching;
    public int highlighedObject;
    public Canvas UI;

    // Use this for initialization
    void Start () {
        Debug.Log("WOWOW");
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
        if (temp.tag == "Person")
            temp.GetComponent<PersonInteraction>().SetHighlighted(set);
        else if (temp.tag == "Item")
            temp.GetComponent<Item>().SetHighlighted(set);
        else if (temp.tag == "Object")
            temp.GetComponent<ItemAction>().SetHighlighted(set);
    }

    public void PickUp(GameObject item)
    {
        pickedUp = item.gameObject;
        UI.GetComponentInChildren<UnityEngine.UI.Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
    }

    public void DropItem() {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        currentTouching.Add(col.gameObject);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetButtonDown("Jump")){
            if (col.gameObject.tag == "Person" || col.gameObject.tag == "Object" || col.gameObject.tag == "Item")
            {
                col.GetComponent<Interaction>().DoActionNow(this.gameObject);
            } else if (pickedUp != null) {
                pickedUp.transform.position = transform.position;
                pickedUp.SetActive(true);
                pickedUp = null;
                UI.GetComponentInChildren<UnityEngine.UI.Image>().sprite = null;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        currentTouching.Remove(col.gameObject);
    }
}
