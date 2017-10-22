using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLureFollow : MonoBehaviour {

    public float lureNoticeDistance;
    public Utils npcUtils;
    public NPCMoveScript npcMoveScript;

    private List<GameObject> noticedItems;

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

        for (int i = 0; i < overlappingCol.Length; i++) {
            if (overlappingCol[i].tag == "Item") {
                Debug.Log("Weakness = " + npcUtils.GetWeakness());
                if (!noticedItems.Contains(overlappingCol[i].gameObject) 
                    && overlappingCol[i].GetComponent<SpriteRenderer>().sprite.name == npcUtils.GetWeakness()) {

                    noticedItems.Add(overlappingCol[i].gameObject);
                    npcMoveScript.AddNodeToTheStartOfThePath(overlappingCol[i].gameObject.transform);
                }
            }
        }

        return isAround;
    }
}
