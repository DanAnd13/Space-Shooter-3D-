using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public  Transform GunPosition;

    private float _bulletSpeed = 60f;

    void FixedUpdate()
    {
        MovingByTheTypeOfGun();
    }

    private void MovingByTheTypeOfGun()
    {
        if (GunPosition.name == EnemyScriptableObjects.TypeOfEnemy.BossEnemy.ToString())
        {
            Movement(Vector3.back);
        }
        else
        {
            Movement(Vector3.forward);
        }
    }

    private void Movement(Vector3 direction)
    {
        Vector3 velocity = direction * _bulletSpeed * Time.deltaTime;
        transform.position = transform.position + velocity;
    }
}
