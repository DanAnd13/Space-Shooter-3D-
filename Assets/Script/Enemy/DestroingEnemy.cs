using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroingEnemy : MonoBehaviour
{
    private float _enemyHealth;
    private DestroingStructure _enemyStructure;
    private EnemyParam _parameters;
    private EnemyScriptableObjects _enemyScriptableObjects;

    private void Awake()
    {
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
        _enemyHealth--;
        other.gameObject.SetActive(false);
        if (_enemyHealth < 0)
        {
            gameObject.SetActive(false);
            //play death animation
            _enemyStructure.EnemyCountInConstruction--;
        }
    }
}
