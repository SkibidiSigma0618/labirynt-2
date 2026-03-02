using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction movement;
    InputAction jump;
    public float speed;
    public float rotationSpeed = 15f;
    public float jumpHeight = 2f;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    private bool isGrounded;
    
    private Vector2 inputValue;

    public Animator anim;
    private Rigidbody rb;
    private Transform camTransform;

    public Transform respawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = InputSystem.actions.FindAction("Move");
        jump = InputSystem.actions.FindAction("Jump");
        rb = GetComponent<Rigidbody>();
        camTransform = Camera.main.transform;

        movement.Enable();
        rb.interpolation = RigidbodyInterpolation.Interpolate; 
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }




    // Update is called once per frame

    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);
        inputValue = movement.ReadValue<Vector2>();
        anim.SetFloat("Speed", inputValue.magnitude);
        anim.SetFloat("MoveX", inputValue.x);
        anim.SetFloat("MoveY", inputValue.y);

        if (jump.WasPressedThisFrame() && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        Vector3 forward = camTransform.forward;
        forward.y = 0f;

        if (forward.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        Vector3 moveDir = transform.right * inputValue.x + transform.forward * inputValue.y;
        Vector3 targetVelocity = moveDir * speed;
        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);
    }
    
    void Jump()
    {
        float jumpVelocity = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
        rb.AddForce(Vector3.up * jumpVelocity, ForceMode.VelocityChange);
        anim.SetTrigger("jump");
    }

    public void Teleport(Transform teleportPoint)
    {
        transform.position = teleportPoint.position;
    }
}
