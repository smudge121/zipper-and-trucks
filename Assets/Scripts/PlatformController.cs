using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private Rigidbody2D rb;

    private CapsuleCollider2D collider;
    private SpriteAnimator spriteAnimator;

    [Header("Movement")]

    public bool canJump = true;

    public ElephantState eleState;

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

    public bool grounded;
    public LayerMask groundLayers;


    private Vector3 topLeft;
    private Vector3 btmRight;
    private Vector3 topRightOffset;
    private Vector3 btmLeftOffset;


    // Use this for initialization
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();

        setUpCorners();
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
//        grounded = Physics2D.OverlapArea(topLeft.position, bottomRight.position, groundLayers);
        grounded = isGrounded();


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


    //on start and rotate character, set up top and bottom boxes for ceiling/ground detection and raycast for turning
    private void setUpCorners()
    {


        //get extents
        float top = collider.offset.y + (collider.size.y / 2f);
        float btm = collider.offset.y - (collider.size.y / 2f);
        float left = collider.offset.x - (collider.size.x / 2f);
        float right = collider.offset.x + (collider.size.x /2f);

        //get corners
        topLeft = (new Vector2( left, top));
        btmRight = (new Vector2( right, btm));

        //ceiling detect will use topLeft to topRight + offset
        topRightOffset = (new Vector2( right, top + 0.1f));

        //ground detect will use btmRight to btmLeft - offset
        btmLeftOffset = (new Vector2( left, btm - 0.1f));


    }

    //determine if grounded by current set up
    private bool isGrounded()
    {
        Debug.DrawLine(transform.position +btmRight, transform.position +btmLeftOffset);
        //return Physics2D.OverlapArea(transform.position + btmRight, transform.position + btmLeftOffset, groundLayers);
        return Physics2D.Raycast(transform.position + new Vector3(-0.4f, 0), transform.TransformDirection(Vector3.down), 0.5f)
            || Physics2D.Raycast(transform.position + new Vector3(0.4f, 0), transform.TransformDirection(Vector3.down), 0.5f);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        var theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
