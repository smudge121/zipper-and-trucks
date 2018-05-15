using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    ElephantState elephant;
    SuckShoot suckshoot;
    public Image keyToken;
    public Image rockToken;
	// Use this for initialization
	void Start () {
        GameObject theelephant = GameObject.Find("Elephant");
        elephant = theelephant.GetComponent< ElephantState>();
        suckshoot = theelephant.GetComponent<SuckShoot>();
        rockToken.enabled = false;
        keyToken.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (elephant.suckedInObject)
        {
            if (suckshoot.suckedItem.name == "mossyrock")
                rockToken.enabled = true;
            else if (suckshoot.suckedItem.name == "key")
                keyToken.enabled = true;
        }
        else
        {
            rockToken.enabled = false;
            keyToken.enabled = false;
        }
	}
}
