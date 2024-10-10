using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter3D.Mechanics
{
    public class DestroingEnemy : MonoBehaviour
    {
        public GameObject Manager;

        private float _enemyHealth;
        private CommonLogic.PointsFromDestroingEnemy _pointsFromDestroingEnemy;
        private CommonLogic.KillCounter _killCounter;
        private CommonLogic.PowerUpsSpawner _powerUpsSpawner;
        private CommonLogic.EnemyHealthBar _enemyHealthBar;
        private CommonLogic.VFXPlayer _vfx;

        private DestroingStructure _enemyStructure;
        private Parameters.EnemyParam _parameters;
        private Parameters.EnemyScriptableObjects _enemyScriptableObjects;

        private void Awake()
        {
            _parameters = GetComponent<Parameters.EnemyParam>();
            _enemyScriptableObjects = _parameters.EnemyScriptableObjectByType;
            _enemyStructure = GetComponentInParent<DestroingStructure>();

            _enemyHealthBar = GetComponent<CommonLogic.EnemyHealthBar>();
            _pointsFromDestroingEnemy = Manager.GetComponent<CommonLogic.PointsFromDestroingEnemy>();
            _killCounter = Manager.GetComponent<CommonLogic.KillCounter>();
            _powerUpsSpawner = Manager.GetComponent<CommonLogic.PowerUpsSpawner>();
            _vfx = Manager.GetComponent<CommonLogic.VFXPlayer>();
        }
        private void OnEnable()
        {
            _enemyHealth = _enemyScriptableObjects.Health;
        }

        private void OnTriggerEnter(Collider other)
        {
           BulletMovement collisionObj = other.GetComponent<BulletMovement>();
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
                _vfx.PlayAnimation(transform);
            }
        }

        private void DestroingEnemyAndIncreaseValues()
        {
            IncreaseKillsPointsAndSpawnBonus();
            gameObject.SetActive(false);
            if (_enemyScriptableObjects.EnemyType != Parameters.EnemyScriptableObjects.TypeOfEnemy.BossEnemy)
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
