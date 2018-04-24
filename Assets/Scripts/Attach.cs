using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach : MonoBehaviour {

    public GameObject eleObj, pouchObj;
    public ElephantState eleState;
    Collider2D eleCol, pouchCol;
	// Use this for initialization
	void Start () {
        if (eleObj != null)  {
            eleCol = eleObj.GetComponent<Collider2D>();
        }
        if (pouchObj != null)  {
            pouchCol = pouchObj.GetComponent<Collider2D>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (eleCol.bounds.Intersects(pouchCol.bounds)) {
            eleState.canAttach = true;
        }
        else {
            eleState.canAttach = false;
        }
	}
}
