using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

    public string Spook = "boo!";
    public Rigidbody2D rigidbody2D;

    // Use this for initialization
    void Start () {
        Debug.Log("WOWOW");
        rigidbody2D.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(new Vector2(1,0));
    }
	
	// Update is called once per frame
	void Update () {
        rigidbody2D.velocity = new Vector2(1,0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("NOOOO");
        if (other.gameObject.tag == "Person")
            Debug.Log("Its a person");
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Person")
        {
            if (Input.GetKeyDown("space"))
                Debug.Log(Spook);
        }

        if (col.gameObject.tag == "Object")
        {
            if (Input.GetKeyDown("space"))
                Debug.Log(col.name);
        }
    }
}
