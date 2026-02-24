using System;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction movement;
    InputAction crouch;
    public float speed;
    private Vector2 inputValue;

    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = InputSystem.actions.FindAction("Move");

    

        movement.Enable();
        crouch.Enable();
    }




    // Update is called once per frame

    void Update()
    {
        inputValue = movement.ReadValue<Vector2>();
        anim.SetFloat("Speed", inputValue.magnitude);
        anim.SetFloat("MoveX", inputValue.x);
        anim.SetFloat("MoveY", inputValue.y);
        Vector3 move = new Vector3(inputValue.x, 0, inputValue.y);
        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0f;
        transform.rotation = Quaternion.LookRotation(forward);
        transform.Translate(move * speed * Time.deltaTime);
    }

}
