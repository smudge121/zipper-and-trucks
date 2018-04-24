using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class AttachDetach : MonoBehaviour
{

	public Collider2D pouchCollider;
	public Collider2D collider;
	
	public ElephantState elephantState;

	public float pouchThrowForce = 1;
	
	// Use this for initialization
	void Start ()
	{
		pouchCollider = Characters.instance.pouch.GetComponent<Collider2D>();
		elephantState = GetComponent<ElephantState>();

		collider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		

		if (Input.GetButtonDown("AttachDetach") )
		{
			switch (elephantState.hasPouch)
			{
				case true:
					
					//detach pouch from elephant
					pouchCollider.gameObject.transform.parent = null;
					pouchCollider.gameObject.SetActive(true);

					//set elephant sprite to elephant with pouch sprite
					elephantState.hasPouch = false;
		
					pouchCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x, 0) * pouchThrowForce);
				
					//switch to the pouch controls
					SwitchCharacters.instance.SwitchElephantPouch(false);
					
					break;
					
				case false:
					
					//if they are intersecting, attach
					if (collider.bounds.Intersects(pouchCollider.bounds)) {
			
						//now attach pouch to elephant
						pouchCollider.gameObject.transform.parent = transform;
						pouchCollider.gameObject.SetActive(false);

						//set elephant sprite to elephant with pouch sprite
						elephantState.hasPouch = true;
	
						
						//if we were controlling the pouch, now we are controlling the elephant
						SwitchCharacters.instance.SwitchElephantPouch(true);
					}

					
					break;
					
			}
			
			
		}
	}
}
