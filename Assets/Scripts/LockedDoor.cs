using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public string item;
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D Other) {
        item = GameObject.Find("Elephant").GetComponent<SuckShoot>().suckedItem.name;
        if (item.Equals("Key"))
        {
            transform.parent.gameObject.SetActive(false);
            GameObject.Find("Elephant").GetComponent<SuckShoot>().suckedItem = null;
        }
	}
}
