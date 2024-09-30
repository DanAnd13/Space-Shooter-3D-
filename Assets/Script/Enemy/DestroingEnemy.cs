using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroingEnemy : MonoBehaviour
{
    public GameObject Manager;

    private float _enemyHealth;
    private PointsFromDestroingEnemy _pointsFromDestroingEnemy;
    private KillCounter _killCounter;
    private PowerUpsSpawner _powerUpsSpawner;
    private EnemyHealthBar _enemyHealthBar;

    private DestroingStructure _enemyStructure;
    private EnemyParam _parameters;
    private EnemyScriptableObjects _enemyScriptableObjects;

    private void Awake()
    {
        _enemyHealthBar = GetComponent<EnemyHealthBar>();
        _parameters = GetComponent<EnemyParam>();
        _enemyScriptableObjects = _parameters.EnemyScriptableObjectByType;
        _enemyStructure = GetComponentInParent<DestroingStructure>();

        _pointsFromDestroingEnemy = Manager.GetComponent<PointsFromDestroingEnemy>();
        _killCounter = Manager.GetComponent<KillCounter>();
        _powerUpsSpawner = Manager.GetComponent<PowerUpsSpawner>();
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
        }
    }

    private void DestroingEnemyAndIncreaseValues()
    {
        IncreaseKillsPointsAndSpawnBonus();
        gameObject.SetActive(false);
        //play death animation
        if (_enemyScriptableObjects.EnemyType != EnemyScriptableObjects.TypeOfEnemy.BossEnemy)
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
