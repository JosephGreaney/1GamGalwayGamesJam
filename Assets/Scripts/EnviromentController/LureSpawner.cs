using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LureSpawner : MonoBehaviour {

    public GameObject item;
    public float respawnTime;

    private bool respawning;

	// Use this for initialization
	void Start () {
        GameObject lureInstance = Instantiate(item);
        lureInstance.transform.parent = transform;
        respawning = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!respawning) {
            bool respawn = true;

            for (int i = 0; i < transform.childCount; i++) {
                Transform child = transform.GetChild(i);

                if (child.name.Contains(item.name)) {
                    respawn = false;
                }
            }

            if (respawn) {
                respawning = true;
                StartCoroutine(SpawnAfterTime(respawnTime));
            }
        }
	}

    IEnumerator SpawnAfterTime(float time) {
        yield return new WaitForSeconds(time);

        respawning = false;
        GameObject lureInstance = Instantiate(item);
        lureInstance.transform.parent = transform;
    }
}
