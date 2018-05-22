using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public string item;
    public GameObject pouch;
    // Update is called once per frame
    private void Start()
    {
        pouch = Characters.instance.pouch;
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.name.Equals("Elephant"))
        {
            pouch.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
