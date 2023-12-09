using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float rayDistance = 0.3f;
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private float speed = 10f;

    [SerializeField] private GameObject Feet;

    private Rigidbody rb;
    private Vector3 prevVelocity;
    private bool isGrounded = true;

    [Space]
    public bool horizontalRotation = true;
    public bool verticalRotation = true;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }


    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleJumping();
    }

    private void HandleMovement()
    {
        // Get the horizontal and vertical axis values from the input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Store the current velocity
        prevVelocity = rb.velocity;

        // Calculate the new velocity based on the input and speed
        Vector3 velocity = (transform.forward * vertical + transform.right * horizontal) * speed;

        // If no input is given, set velocity to zero
        if (!(horizontal != 0 || vertical != 0)) velocity = Vector3.zero;

        // Keep the current y velocity for smooth movement
        velocity.y = prevVelocity.y;
        rb.velocity = velocity;

    }




    private void HandleRotation()
    {
        // Get the horizontal and vertical mouse axis values from the input
        Vector2 mousePos = new Vector2(Input.GetAxis("Mouse X") * sensitivity, -Input.GetAxis("Mouse Y") * sensitivity);

        // If horizontal rotation is enabled
        if (horizontalRotation)
        {
            // Rotate the player based on the horizontal mouse axis
            transform.Rotate(new Vector3(0, mousePos.x, 0));
        }

        // If vertical rotation is enabled
        if (verticalRotation)
        {
            // Rotate the main camera based on the vertical mouse axis
            Camera.main.transform.Rotate(mousePos.y, 0, 0);
        }

    }
    private void HandleJumping()
    {
        // Creating a ray going downwards from the player's position
        Ray ray = new Ray(Feet.gameObject.transform.position, Vector3.down);
        RaycastHit groundRay;

        // Raycasting downwards to detect if the player is on the ground and setting isGrounded accordingly
        isGrounded = Physics.Raycast(ray, out groundRay, rayDistance) && groundRay.collider.gameObject.GetComponent<MultiTag>().HasTag("Ground") ? true : false;

        // Checking if the jump button is pressed and the player is on the ground
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Adding an upward velocity to the player's rigidbody
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            // Setting isGrounded to false when the player jumps
            isGrounded = false;
        }
    }
}
