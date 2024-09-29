using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsMovement : MonoBehaviour
{
    public Transform PlayerShipPosition;

    private float _movementSpeed = 50f;

    private void Update()
    {
        Vector3 direction = Vector3.back * _movementSpeed * Time.deltaTime;
        transform.position += direction;
        if(transform.position.z < PlayerShipPosition.position.z)
        {
            gameObject.SetActive(false);
        }
    }
}
