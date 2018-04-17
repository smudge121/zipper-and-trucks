using UnityEngine;

public class ElephantController : MonoBehaviour
{
    
    private Rigidbody2D rb;
    
    [Header("Movement")]
    
    public float runSpeed = 8;
    private float xMove;
    public float maxSpeed = 5f;
    
    [HideInInspector] public bool facingRight;
    
    [Space(10)]
    
    [Header("Jumping")]
    
    [HideInInspector] public bool jump;
    public float fallMultiplier = 2.5f;
    public float jumpForce = 1000f;
    public float lowJumpMultiplier = 2f;

    [Space(10)]
    
    [Header("Grounding")]
    
    public Transform topLeft;
    public Transform bottomRight;
    private bool grounded;
    public LayerMask groundLayers;  


    // Use this for initialization
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded) jump = true;


        if (Input.GetAxisRaw("Horizontal") == -1 && !facingRight)
            Flip();
        else if (Input.GetAxisRaw("Horizontal") == 1 && facingRight)
            Flip();

        //mario jump
        if (rb.velocity.y < 0)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        //check if grounded
        grounded = Physics2D.OverlapArea(topLeft.position, bottomRight.position, groundLayers);

        float h;

        //store Right Hor input
        h = Input.GetAxis("Horizontal");

        //store wish move Right Hor
        float xMove = h * runSpeed;

        //move Right Horly
        rb.velocity += new Vector2(xMove - rb.velocity.x, 0);

        //jump
        if (jump)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }

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