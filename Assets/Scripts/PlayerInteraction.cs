using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    public string Spook = "boo!";
    public Rigidbody2D rigidbody2D;
    public GameObject pickedUp;
    public Canvas UI;

    // Use this for initialization
    void Start () {
        Debug.Log("WOWOW");
        rigidbody2D.GetComponent<Rigidbody2D>();
        //rigidbody2D.AddForce(new Vector2(1,0));
    }
	
	// Update is called once per frame
	void Update () {
        //rigidbody2D.velocity = new Vector2(1,0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Person")
            Debug.Log("Its a person");
        else if (col.gameObject.tag == "Object")
            Debug.Log("Its an object");
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetButtonDown("Jump")){
            if (col.gameObject.tag == "Person")
            {
                Debug.Log(Spook);
            }
            else if (col.gameObject.tag == "Object")
            {
                col.GetComponent<ItemAction>().DoAaction();
            }
            else if (col.gameObject.tag == "Item")
            {
                pickedUp = col.gameObject;
                col.GetComponent<Item>().PickUp();
                UI.GetComponentInChildren<UnityEngine.UI.Image>().sprite = col.GetComponent<SpriteRenderer>().sprite;
            }
        }
    }
}
