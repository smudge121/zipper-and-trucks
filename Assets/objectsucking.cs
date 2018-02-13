using UnityEngine;

public class objectsucking : MonoBehaviour
{
    private bool canShoot;

    private RaycastHit2D hitInfo;
    private bool lookDirection;

    [Range(1, 10)] public float projectileSpeed;

    private GameObject storage; //object being stored

    // Use this for initialization
    private void Start()
    {
        lookDirection = GetComponent<playerMovement>().lookDirection;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            LayerMask lm = 1 << LayerMask.NameToLayer("sucking");
            if (lookDirection)
                hitInfo = Physics2D.Raycast((Vector2) transform.position - new Vector2(0, .5f), Vector3.right, 5f, lm);
            else if (!lookDirection)
                hitInfo = Physics2D.Raycast((Vector2) transform.position - new Vector2(0, .5f), Vector3.left, 5f, lm);
            if (hitInfo.collider != null)
            {
                storage = hitInfo.transform.gameObject;
                storage.SetActive(false);
                canShoot = true;
            }
        }

        if (Input.GetKey(KeyCode.RightShift) && canShoot)
        {
            canShoot = false;
            storage.SetActive(true);
            storage.transform.position = transform.position;
            storage.GetComponent<Rigidbody2D>().AddForce(new Vector2(200 * projectileSpeed, 0));
        }
    }
}