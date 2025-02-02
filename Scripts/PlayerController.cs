using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public Transform orientation;
    private VariableJoystick joystick;

    [Header("Control")]
    public float speed = 5f;
    public float drag = 4f;
    public float jumpForce = 2f;
    public float airMult = .4f;

    [Header("Ground Check")]
    public LayerMask groundLayer;
    public float playerHeight = 1;
    public bool isGrounded;

    float horizontalInput;
    float verticalInput;
    Vector3 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        joystick = GameUIManager.instance.joystick;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.state == GameState.Play)
        {
            isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);

            GetInput();

            if (isGrounded)
                rb.drag = drag;
            else
                rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.state == GameState.Play)
        {
            MovePlayer();
        }
    }

    private void GetInput()
    {
        horizontalInput = joystick.Horizontal;
        verticalInput = joystick.Vertical;
    }

    public void Jump()
    {
        if (isGrounded)
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void MovePlayer()
    {
        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > (speed + speed * 0.25f))
        {
            moveDir = Vector3.zero;
        }

        if (isGrounded)
            rb.AddForce(moveDir * speed * 10f, ForceMode.Force);
        else
            rb.AddForce(moveDir * speed * airMult * 10f, ForceMode.Force);
    }
}
