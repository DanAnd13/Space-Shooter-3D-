using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter3D.Mechanics
{
    public class DestroingEnemy : MonoBehaviour
    {
        public GameObject Manager;

        private float _enemyHealth;
        private SpaceShooter3D.CommonLogic.PointsFromDestroingEnemy _pointsFromDestroingEnemy;
        private SpaceShooter3D.CommonLogic.KillCounter _killCounter;
        private SpaceShooter3D.CommonLogic.PowerUpsSpawner _powerUpsSpawner;
        private SpaceShooter3D.CommonLogic.EnemyHealthBar _enemyHealthBar;

        private DestroingStructure _enemyStructure;
        private SpaceShooter3D.Parameters.EnemyParam _parameters;
        private SpaceShooter3D.Parameters.EnemyScriptableObjects _enemyScriptableObjects;

        private void Awake()
        {
            _enemyHealthBar = GetComponent<SpaceShooter3D.CommonLogic.EnemyHealthBar>();
            _parameters = GetComponent<SpaceShooter3D.Parameters.EnemyParam>();
            _enemyScriptableObjects = _parameters.EnemyScriptableObjectByType;
            _enemyStructure = GetComponentInParent<DestroingStructure>();

            _pointsFromDestroingEnemy = Manager.GetComponent<SpaceShooter3D.CommonLogic.PointsFromDestroingEnemy>();
            _killCounter = Manager.GetComponent<SpaceShooter3D.CommonLogic.KillCounter>();
            _powerUpsSpawner = Manager.GetComponent<SpaceShooter3D.CommonLogic.PowerUpsSpawner>();
        }
        private void OnEnable()
        {
            _enemyHealth = _enemyScriptableObjects.Health;
        }

        private void OnTriggerEnter(Collider other)
        {
           SpaceShooter3D.Mechanics.BulletMovement collisionObj = other.GetComponent<SpaceShooter3D.Mechanics.BulletMovement>();
            if (collisionObj != null)
            {
                other.gameObject.SetActive(false);
                LowerEnemyHeath();
            }
        }

        private void LowerEnemyHeath()
        {
            _enemyHealth--;
            _enemyHealthBar.UpdateHealthBar(_enemyHealth);
            if (_enemyHealth <= 0)
            {
                DestroingEnemyAndIncreaseValues();
            }
        }

        private void DestroingEnemyAndIncreaseValues()
        {
            IncreaseKillsPointsAndSpawnBonus();
            gameObject.SetActive(false);
            if (_enemyScriptableObjects.EnemyType != SpaceShooter3D.Parameters.EnemyScriptableObjects.TypeOfEnemy.BossEnemy)
            {
                _enemyStructure.EnemyCountInConstruction--;
            }
        }
        private void IncreaseKillsPointsAndSpawnBonus()
        {
            _killCounter.IncreaseKillCount();
            _powerUpsSpawner.SpawnPowerUps(_killCounter, gameObject.transform);
            _pointsFromDestroingEnemy.IncreasePoints(_enemyScriptableObjects.BonusForDestroingTheEnemy);

        }
    }
}
