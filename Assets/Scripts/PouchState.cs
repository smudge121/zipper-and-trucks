﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouchState : MonoBehaviour
{

	public bool full = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }
}
