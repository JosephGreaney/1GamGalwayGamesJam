using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class personScript : MonoBehaviour {
    Character character;

    private void Awake()
    {
        character = new Character();
        print(this.name + "-" + character.GetName() + "," + character.GetWeakness());
    }

    void Update () {
	}
}
