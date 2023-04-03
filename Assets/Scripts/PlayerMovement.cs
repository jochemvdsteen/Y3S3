using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    // movement
    [SerializeField] private float currentSpeed;
    private float baseSpeed = 5f;
    public float gravity = -9.81f;
    public float jump = 1f;
    private int jumpAmount;

    // groundcheck
    public Transform groundCheck;
    public float groundDistance = 0.01f;
    public float fallDistance = 1f;
    public LayerMask groundMask;

    // falling
    Vector3 velocity;
    bool isGrounded;
    public bool isFalling;
    bool fall = false;

    // ability
    public WeaponController weaponController;

    [SerializeField] private KeyCode _abilitySwingKey;
    [SerializeField] private KeyCode _abilityMagicKey;
    [SerializeField] private Ability _abilitySwing;
    [SerializeField] private Ability _abilityMagic;

    // key
    public static bool hasKey = false;
    public bool canGrab = true;

    // audio
    public AudioSource Footsteps;
    public AudioSource JumpLand;
    public AudioSource Key;

    public AudioClip Jump;
    public AudioClip Land;
    public AudioClip KeyGrab;

    // example for future reference
    /*private Rigidbody2D _rb;

    public Rigidbody2D Rb
    {
        get => _rb;
        private set => _rb = value;
    }*/

    private void Start()
    {
        currentSpeed = baseSpeed;
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

        if(Input.GetKey(KeyCode.Mouse1))
        {
            currentSpeed = baseSpeed / 2;
        }
        else
        {
            currentSpeed = baseSpeed;
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

        controller.Move(move * currentSpeed * Time.deltaTime);

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

        if(Input.GetKeyDown(_abilitySwingKey))
        {
            if(weaponController.canUse)
            {
                _abilitySwing.Use(this);
            }
        }

        if (Input.GetKeyDown(_abilityMagicKey))
        {
            if (weaponController.canUse)
            {
                _abilityMagic.Use(this);
            }
        }

        // _ability = (you can use this to change your ability)
    }
}