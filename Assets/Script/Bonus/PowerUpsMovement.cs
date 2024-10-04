using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter3D.Mechanics
{
    public class PowerUpsMovement : MonoBehaviour
    {
        public Transform PlayerShipPosition;

        private float _movementSpeed = 50f;

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            Vector3 direction = Vector3.back * _movementSpeed * Time.deltaTime;
            transform.position += direction;

            EnableAfterPalyerShip();
        }

        private void EnableAfterPalyerShip()
        {
            if (transform.position.z < PlayerShipPosition.position.z)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
