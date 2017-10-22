using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLureFollow : MonoBehaviour {

    public float lureNoticeDistance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private bool isLureAround() {
        bool isAround = false;
        string[] layersToRetrieve = { "Lure" };
        int layerMask = LayerMask.GetMask(layersToRetrieve);

        Collider[] overlappingCol = Physics.OverlapSphere(transform.position, lureNoticeDistance, layerMask);

        for (int i = 0; i < overlappingCol.Length; i++) {
            //if (overlappingCol[i].name == )
        }

        return isAround;
    }
}
