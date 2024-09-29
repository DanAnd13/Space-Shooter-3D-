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

    private DestroingStructure _enemyStructure;
    private EnemyParam _parameters;
    private EnemyScriptableObjects _enemyScriptableObjects;

    private void Awake()
    {
        _pointsFromDestroingEnemy = Manager.GetComponent<PointsFromDestroingEnemy>();
        _killCounter = Manager.GetComponent<KillCounter>();
        _powerUpsSpawner = Manager.GetComponent<PowerUpsSpawner>();
        _enemyStructure = GetComponentInParent<DestroingStructure>();
        _parameters = GetComponent<EnemyParam>();
        _enemyScriptableObjects = _parameters.EnemyScriptableObjectByType;
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
            _enemyHealth--;
            other.gameObject.SetActive(false);
        }
        if (_enemyHealth <= 0)
        {
            _killCounter.IncreaseKillCount();
            _powerUpsSpawner.SpawnPowerUps(_killCounter,gameObject.transform);

            _pointsFromDestroingEnemy.IncreasePoints(_enemyScriptableObjects.BonusForDestroingTheEnemy);
            gameObject.SetActive(false);
            //play death animation
            _enemyStructure.EnemyCountInConstruction--;
        }
    }
}
