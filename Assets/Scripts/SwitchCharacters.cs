using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacters : MonoBehaviour
{

	public ElephantController elephantController;
	public PouchController pouchController;

	public bool elephantSelected = true;
	
	// Use this for initialization
	void Start () {
		
		elephantController.enabled = elephantSelected;
		pouchController.enabled = !elephantSelected;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetButtonDown("Switch"))
		{
			elephantSelected = !elephantSelected;
			elephantController.enabled = elephantSelected;
			pouchController.enabled = !elephantSelected;
		}


	}
}
