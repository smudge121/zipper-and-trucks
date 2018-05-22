using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class SuckShoot : MonoBehaviour {

	public float suckRange = 1;
	public float shootForce = 4;

	public GameObject suckedItem;
	
	int layerMask;
    int layerMask2;

	private CapsuleCollider2D capsuleCollider;
	private ElephantState elephantState;
	
	// Use this for initialization
	void Start ()
	{
		// set up suckposition
		capsuleCollider = GetComponent<CapsuleCollider2D>();
		
		layerMask = LayerMask.GetMask("Item", "Key");

		elephantState = GetComponent<ElephantState>();
	}
	
	// Update is called once per frame
	void Update () {

		if (!elephantState.hasPouch)
		{
			return;
		}
		
		Vector2 suckPosition = (Vector2) transform.position + new Vector2(0, (capsuleCollider.size.y * 0.5f) - 0.2f);
		
		Vector2 suckDirection = new Vector2( transform.localScale.x, 0);
		
		if(Input.GetButtonDown("SuckShoot"))
		{
			RaycastHit2D hit = Physics2D.Raycast(suckPosition, suckDirection, suckRange, layerMask);

            Debug.DrawRay(suckPosition, suckDirection);

			if (hit.collider != null && !suckedItem)
			{
				//suck in the item
				suckedItem = hit.transform.gameObject;

				//put item in pouch
				suckedItem.transform.parent = Characters.instance.pouch.transform;
				suckedItem.SetActive(false);

				elephantState.suckedInObject = true;
			}
			else
			{

				// shoot
				
				if (suckedItem)
				{
				
					suckedItem.transform.parent = null;
					suckedItem.SetActive(true);

					if (suckedItem.GetComponent<Rigidbody2D>())
					{
						suckedItem.GetComponent<Rigidbody2D>().AddForce(suckDirection * shootForce, ForceMode2D.Impulse);
					}

					suckedItem = null;	
				}
				
				elephantState.suckedInObject = false;
				
			}
		
		}
	}
}