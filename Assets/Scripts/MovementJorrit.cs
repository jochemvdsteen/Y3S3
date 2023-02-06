using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJorrit : MonoBehaviour
{
    //cam movement
    [SerializeField] private Transform _eyes;
    [SerializeField] private float _mouseSensitivity;
    [Range(-90f, 0f)]
    [SerializeField] private float _camLimitMin;
    [Range(0f, 90f)]
    [SerializeField] private float _camLimitMax;

    //movement
    [SerializeField] private float _speed;
    private Rigidbody _rb;

    //jump
    [SerializeField] private float _jumpForce;
    [SerializeField] private KeyCode _jumpKey;

    private float _camAngle = 0.0f;

    Vector3 velocity;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        RotateEyes();
        RotateBody();
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TryJump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void RotateEyes()
    {
        float yMouse = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;
        _camAngle -= yMouse;
        _camAngle = Mathf.Clamp(_camAngle, _camLimitMin, _camLimitMax);
        _eyes.localRotation = Quaternion.Euler(_camAngle, 0, 0);
    }

    private void RotateBody()
    {
        float xMouse = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        //transform.Rotate(Vector3.up * xMouse);
    }

    private void Move()
    {
        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");

        Vector3 dir = transform.right * xDir + transform.forward * zDir;
        _rb.velocity = new Vector3(0, _rb.velocity.y, 0) + dir.normalized * _speed;
    }

    private void TryJump()
    {
        if(IsGrounded())
        {
            Jump(_jumpForce);
        }
    }

    private void Jump()
    {
        _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        return Physics.SphereCast(transform.position, 1, -transform.up ,out hit, )
    }
}
