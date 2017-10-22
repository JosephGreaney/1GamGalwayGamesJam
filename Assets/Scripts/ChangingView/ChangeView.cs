using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour
{
    public GameObject currentView;
    public GameObject nextView;
    public List<GameObject> items;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.transform.position = nextView.transform.position;
            //this.nextView.SetActive(true);
            //this.currentView.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerInteraction>().SetView(nextView.transform);
            GameObject.Find("Player").GetComponent<PlayerInteraction>().currentTouching.Clear();
        }
    }
}
