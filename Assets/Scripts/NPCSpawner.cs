using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour {

    public GameObject npc;
    public Transform[] transforms;

    private GameObject[] instantiatedNPCs;


	// Use this for initialization
	void Awake () {
        instantiatedNPCs = new GameObject[3];
        instantiatedNPCs[0] = Instantiate(npc, transforms[0]);
        instantiatedNPCs[0].GetComponent<Utils>().weakness = "BeerItem";
        instantiatedNPCs[1] = Instantiate(npc, transforms[1]);
        instantiatedNPCs[1].GetComponent<Utils>().weakness = "Food";
        instantiatedNPCs[2] = Instantiate(npc, transforms[2]);
        instantiatedNPCs[2].GetComponent<Utils>().weakness = "Anime";
    }

    public GameObject GetBeerGuy()
    {
        return instantiatedNPCs[0];
    }

    public GameObject GetFoodGuy()
    {
        return instantiatedNPCs[1];
    }

    public GameObject GetAnimeGuy()
    {
        return instantiatedNPCs[2];
    }
}
