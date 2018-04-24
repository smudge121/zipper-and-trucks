using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacters : MonoBehaviour
{
	public static SwitchCharacters instance;

	PlatformController elephantController;
	PlatformController pouchController;

	public bool elephantSelected = true;

	private ElephantState elephantState;

	private bool elephantHasPouchAux = true;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start ()
	{

		elephantController = Characters.instance.elephant.GetComponent<PlatformController>();
		pouchController = Characters.instance.pouch.GetComponent<PlatformController>();

		elephantState = Characters.instance.elephant.GetComponent<ElephantState>();
		
		SwitchElephantPouch(elephantSelected);
	}
	
	// Update is called once per frame
	void Update ()
	{

		//cannot switch characters when they are together
		if (Input.GetButtonDown("Switch") && !elephantState.hasPouch)
		{
			SwitchElephantPouch(!elephantSelected);
		}

		
	}

	public void SwitchElephantPouch(bool elephant)
	{
		elephantSelected = elephant;
		elephantController.enabled = elephantSelected;
		pouchController.enabled = !elephantSelected;
	}
}
