using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public bool lookDirection = true; //right is true, left is false
    private Rigidbody2D rb;
    public float speed;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if (x < 0)
            lookDirection = false;
        else if (x > 0)
            lookDirection = true;
        rb.velocity = new Vector2(x, 0).normalized * speed;
    }
}