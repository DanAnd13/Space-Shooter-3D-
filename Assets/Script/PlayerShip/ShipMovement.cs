using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float TiltSpeed = 100f;

    private float _verticalInput;
    private float _horizontalInput;
    private float _zRotation;

    void Update()
    {
        GetInput();
        MoveSpaceship();
        RotateSpaceship();
    }

    private void GetInput()
    {
        InputXY();
        InputRotation();
    }

    private void InputXY()
    {
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalInput = Input.GetAxis("Horizontal");
    }

    private void InputRotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            _zRotation += TiltSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            _zRotation -= TiltSpeed * Time.deltaTime;
        }
    }

    private void MoveSpaceship()
    {
        Vector3 moveDirection = new Vector3(_horizontalInput, _verticalInput, 0).normalized;
        transform.Translate(moveDirection * MoveSpeed * Time.deltaTime);
    }

    private void RotateSpaceship()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, _zRotation);
    }
}
