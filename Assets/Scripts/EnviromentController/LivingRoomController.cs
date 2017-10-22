using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomController : MonoBehaviour {
	// Update is called once per frame
    public int timestepsBetweenLightChanges;
    public int iterationsCompleted = 0;
    public int currentFilter = 0;
    public GameObject[] filters;
    public bool HasPower { get; set; }

    private void Start()
    {
        HasPower = false;
    }

    void FixedUpdate()
    {
        if (HasPower)
        {
            if (iterationsCompleted > timestepsBetweenLightChanges)
            {
                iterationsCompleted = 0;
                filters[currentFilter % 3].SetActive(false);
                filters[currentFilter++ % 3].SetActive(true);
            }
            iterationsCompleted++;
        }
        else
        {
            filters[currentFilter % 3].SetActive(false);
        }
    }
}
