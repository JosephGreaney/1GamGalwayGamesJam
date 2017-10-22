using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour
{

    public GameObject currentView;
    public GameObject nextView;
    public GameObject player;
    public List<GameObject> items;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Going inside");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            this.nextView.SetActive(true);
            this.currentView.SetActive(false);
            for(int i = 0; i < items.Count; i++)
            {
                Debug.Log(items[i].activeSelf);
                items[i].SetActive(!items[i].activeSelf);
            }
        }
    }
}
