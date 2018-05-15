using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantPouchAnimator : MonoBehaviour
{
    public SpriteAnimator spriteAnimator;
    public PlatformController platformController;
    public Rigidbody2D rigidbody2D;

    // Use this for initialization
    void Start()
    {
        spriteAnimator = GetComponent<SpriteAnimator>();
        platformController = transform.root.GetComponent<PlatformController>();
        rigidbody2D = transform.root.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if she's not grounded and moving up, play jump
        if (!platformController.grounded && rigidbody2D.velocity.y > 0)
        {
            spriteAnimator.Play("Jump");
        }
        //if she's not grounded and moving down, play fall
        else if (!platformController.grounded && rigidbody2D.velocity.y < 0)
        {
            spriteAnimator.Play("Fall");
        }
        //if she's grounded and moving left or right, play Walk
        else if (platformController.grounded && (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0f))
        {
            spriteAnimator.Play("Walk");
        }
        //if none of these are the case, play idle
        else
        {
            spriteAnimator.Play("Idle");
        }
    }
}
