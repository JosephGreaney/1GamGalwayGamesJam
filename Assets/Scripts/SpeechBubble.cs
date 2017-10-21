using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour {

    public GameObject images;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplaySpeechBubble() {
        images.SetActive(true);
        Invoke("DisableSpeechBubble", 2);
    }

    private void DisableSpeechBubble() {
        images.SetActive(false);
    }
}
