using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    private Rigidbody rb;
    MeshRenderer meshRenderer;
    public float moveSpeed = 10f;
    public float jumpForce = 10f;
    private bool canJump = true;
    private bool isShift = false;

    OpenDoor openDoor;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        openDoor = FindObjectOfType<OpenDoor>();
        meshRenderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.1f))
        {
            canJump = true;
        }

        Move();
        Jump();
        ShapeShifting();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0, 0);
        rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, 0);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        canJump = true;
        if (collision.gameObject.CompareTag("Lava"))
        {
            isShift = true;
        }
        if (collision.gameObject.tag == "Door" && isShift)
        {

            Destroy(gameObject);

            Debug.Log("door");
            openDoor.OpeningDoor();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        canJump = true;
    }


    void ShapeShifting()
    {
        if (Input.GetKeyDown(KeyCode.F) && gameObject.CompareTag("Clone") && isShift)
        {
            meshRenderer.material = gameManager.lava;
            Debug.Log("Shape Shift");

        }
    }

   
}