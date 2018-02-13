using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public bool lookDirection = true; //right is true, left is false
    Rigidbody2D rb;
    public float speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        if (x < 0)
            lookDirection = false;
        else if (x > 0)
            lookDirection = true;
        rb.velocity = new Vector2(x, 0).normalized * speed;
    }
    
}
