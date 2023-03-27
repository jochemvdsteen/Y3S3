using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    [SerializeField] private float _speed;
    public float gravity = -9.81f;
    public float jump = 1f;

    private int jumpAmount;

    public Transform groundCheck;
    public float groundDistance = 0.01f;
    public float fallDistance = 1f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    public bool isFalling;
    bool fall = false;

    public static bool hasKey = false;
    public bool canGrab = true;

    public AudioSource Footsteps;
    public AudioSource JumpLand;
    public AudioSource Key;

    public AudioClip Jump;
    public AudioClip Land;
    public AudioClip KeyGrab;

    private void Start()
    {
        _speed = 7f;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isFalling = Physics.CheckSphere(groundCheck.position, fallDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if(isGrounded && Input.GetKey(KeyCode.W) || isGrounded && Input.GetKey(KeyCode.A) || isGrounded && Input.GetKey(KeyCode.S) || isGrounded && Input.GetKey(KeyCode.D))
        {
            Footsteps.enabled = true;
        }
        else
        {
            Footsteps.enabled = false;
        }

        if(!isFalling)
        {
            fall = true;
        }

        if(Input.GetKey(KeyCode.Mouse2))
        {
            _speed = _speed / 2;
        }
        else
        {
            _speed = 5f;
        }

        if(canGrab)
        {
            if(hasKey)
            {
                Key.PlayOneShot(KeyGrab);
                canGrab = false;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * _speed * Time.deltaTime);

        if(isGrounded)
        {
            jumpAmount = 1;

            if(fall)
            {
                JumpLand.PlayOneShot(Land);
                fall = false;
            }
        }

        if (Input.GetButtonDown("Jump") && jumpAmount > 0 && isGrounded)
        {
            velocity.y = 0;
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
            JumpLand.PlayOneShot(Jump);
            jumpAmount -= 1;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}