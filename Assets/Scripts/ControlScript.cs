using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{

    public GameObject anNPC;
    public Transform[] spawnLocations;

    void Awake()
    {
        Instantiate(anNPC, spawnLocations[0]);
        Instantiate(anNPC, spawnLocations[1]);
        Instantiate(anNPC, spawnLocations[2]);
    }
}
