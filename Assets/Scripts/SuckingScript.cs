using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckingScript : MonoBehaviour {

	int layer_mask;
	public Transform playerTrans;
	// Use this for initialization
	void Start () {
		layer_mask = LayerMask.GetMask("InteractableObject");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.M))
		{
			RaycastHit2D hit;
			if(Input.GetAxis("Horizontal") == 1)
			{
				hit = Physics2D.Raycast(playerTrans.position, new Vector2(1, 0), 1000f, layer_mask);
				Debug.Log("cast");
				if (hit.collider != null)
				{
					Destroy(hit.collider.gameObject);
				}
			}
		}
	}
}