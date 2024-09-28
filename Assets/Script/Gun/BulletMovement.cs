using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public  Transform GunPosition;

    private float _bulletSpeed = 60f;

    void FixedUpdate()
    {
        Vector3 velocity = Vector3.forward * _bulletSpeed * Time.deltaTime;
        transform.position = transform.position + velocity;
    }
}
