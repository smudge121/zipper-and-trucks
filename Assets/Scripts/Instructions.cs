using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnGUI()
	{
		GUI.Label(new Rect(0,0, 100, 100), "AttachDetach 'b' Switch 'n' SuckShoot 'm'");
	}
}
