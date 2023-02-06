using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private Transform eyes;
    [SerializeField] private float mouseSensitivity;
    [Range(-90f, 0f)]
    [SerializeField] private float camLimitMin;
    [Range(0f, 90f)]
    [SerializeField] private float camLimitMax;

    private float _camAngle = 0.0f;

    Vector3 velocity;

    private void Update()
    {
        RotateEyes();
        RotateBody();
    }

    private void RotateEyes()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _camAngle -= mouseY;
        _camAngle = Mathf.Clamp(_camAngle, camLimitMin, camLimitMax);

        eyes.localRotation = Quaternion.Euler(_camAngle, 0, 0);
    }

    private void RotateBody()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }
}
