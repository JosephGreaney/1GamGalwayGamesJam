using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public Animation openDoorAnimation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.openDoorAnimation.Play();
    }
}
