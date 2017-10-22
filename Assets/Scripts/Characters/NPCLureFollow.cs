using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLureFollow : MonoBehaviour {

    public float lureNoticeDistance;
    public Utils npcUtils;
    public NPCMoveScript npcMoveScript;

    private List<GameObject> noticedItems;
    private Transform startingPosition;
    private GameObject transformCopy;

    // Use this for initialization
    void Start () {
        noticedItems = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        isLureAround();
	}

    private bool isLureAround() {
        bool isAround = false;
        string[] layersToRetrieve = { "Lure" };
        int layerMask = LayerMask.GetMask(layersToRetrieve);

        Collider2D[] overlappingCol = Physics2D.OverlapCircleAll(transform.position, lureNoticeDistance);

        // Go through all colliders around you
        for (int i = 0; i < overlappingCol.Length; i++) {
            // If it's an item/lure
            if (overlappingCol[i].tag == "Item") {
                Debug.Log("Weakness = " + npcUtils.GetWeakness());

                // Get an item in between you and the lure
                bool blocked = false;
                string[] blockedLayersToRetrieve = { "Wall" };
                int blockedLayerMask = LayerMask.GetMask(blockedLayersToRetrieve);
                RaycastHit2D raycastResult = Physics2D.Linecast(transform.position, overlappingCol[i].transform.position, blockedLayerMask);

                // If it hasn't been an item that the NPC moved to before, and there's nothing in between, and the name is NPC's weakness
                if (!noticedItems.Contains(overlappingCol[i].gameObject) 
                    && raycastResult.collider == null
                    && overlappingCol[i].GetComponent<SpriteRenderer>().sprite.name == npcUtils.GetWeakness()) {

                    transformCopy = new GameObject();
                    transformCopy.transform.position = transform.position;
                    startingPosition = transformCopy.transform;
                    noticedItems.Add(overlappingCol[i].gameObject);
                    npcMoveScript.AddNodeToTheStartOfThePath(overlappingCol[i].gameObject.transform);
                }
            }
        }

        return isAround;
    }

    void OnTriggerStay2D(Collider2D other) { 
        Debug.Log("In trigger event");
        // If over the lure, destroy it and return to the starting position
        if (other.tag == "Item" && other.GetComponent<SpriteRenderer>().sprite.name == npcUtils.GetWeakness()) {
            Destroy(other.gameObject);
            ReturnToStartingPos();
        }
    }

    private void ReturnToStartingPos() {
        npcMoveScript.AddNodeToTheStartOfThePath(startingPosition);
    }
}
