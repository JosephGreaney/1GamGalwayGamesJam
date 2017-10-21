using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrechSpeechBubbleImage : MonoBehaviour {

    public RectTransform speechBubbleText;
    public float padding;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 textSize = speechBubbleText.sizeDelta;
        textSize.x += padding;
        textSize.y += padding;
        GetComponent<RectTransform>().sizeDelta = textSize;
	}
}
