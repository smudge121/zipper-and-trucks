using UnityEngine;

public class PouchController : MonoBehaviour
{
    
    private Rigidbody2D rb;
    
    [Header("Movement")]
    
    public float runSpeed = 8;
    private float xMove;
    public float maxSpeed = 5f;
    
    [HideInInspector] public bool facingRight;

    [Space(10)]
    
    [Header("Grounding")]
    
    public Transform topLeft;
    public Transform bottomRight;
    public LayerMask groundLayers;  


    // Use this for initialization
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {


        if (Input.GetAxisRaw("Horizontal") == -1 && !facingRight)
            Flip();
        else if (Input.GetAxisRaw("Horizontal") == 1 && facingRight)
            Flip();

    }

    private void FixedUpdate()
    {

        float h;

        //store Right Hor input
        h = Input.GetAxis("Horizontal");

        //store wish move Right Hor
        float xMove = h * runSpeed;

        //move Right Horly
        rb.velocity += new Vector2(xMove - rb.velocity.x, 0);


        //limit speed by maxSpeed
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
    }


    private void Flip()
    {
        facingRight = !facingRight;
        var theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}