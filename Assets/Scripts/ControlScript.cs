using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{

    public GameObject anNPC;
    public Transform spawnLocation;

    void Awake()
    {
        Instantiate(anNPC, spawnLocation);
    }
}
