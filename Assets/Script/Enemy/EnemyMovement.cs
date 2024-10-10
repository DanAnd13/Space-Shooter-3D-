using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace SpaceShooter3D.Mechanics
{
    public class EnemyMovement : MonoBehaviour
    {
        public Transform PlayerShipPosition;

        private Parameters.EnemyParam _parameters;
        private Parameters.EnemyScriptableObjects _enemyScriptableObjects;
        private CommonLogic.BossSpawner? _bossSpawner;

        private void Awake()
        {
            _bossSpawner = GetComponent<SpaceShooter3D.CommonLogic.BossSpawner>();

            _parameters = GetComponentInChildren<Parameters.EnemyParam>();
            _enemyScriptableObjects = _parameters.EnemyScriptableObjectByType;
        }

        private void OnEnable()
        {
            gameObject.transform.rotation = PlayerShipPosition.rotation;
        }

        private void Update()
        {
            MovingByTheTypeOfEnemy();
        }

        private void MovingByTheTypeOfEnemy()
        {
            if (_enemyScriptableObjects.EnemyType == Parameters.EnemyScriptableObjects.TypeOfEnemy.BossEnemy)
            {
                MoveByPosition();
            }
            else
            {
                Movement();
                EnableAfterPlayerPisition();
            }
        }

        private void Movement()
        {
            Vector3 direction = Vector3.back * _enemyScriptableObjects.MovementSpeed * Time.deltaTime;
            transform.position += direction;
        }

        private void EnableAfterPlayerPisition()
        {
            if (transform.position.z < PlayerShipPosition.position.z - 20)
            {
                gameObject.SetActive(false);
            }
        }

        private void MoveByPosition()
        {
            if (transform.position.z > _bossSpawner.StopPosition)
            {
                Movement();
            }
        }
    }
}
