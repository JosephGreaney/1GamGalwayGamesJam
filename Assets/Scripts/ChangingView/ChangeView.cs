using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour
{

    public GameObject currentView;
    public GameObject nextView;
    public GameObject player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Going inside");
        if (collision.gameObject.layer == this.gameObject.layer)
        {
            this.nextView.SetActive(true);
            this.currentView.SetActive(false);
        }
    }
}
