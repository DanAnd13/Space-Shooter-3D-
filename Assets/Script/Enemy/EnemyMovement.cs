using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyParam _parameters;
    private EnemyScriptableObjects _enemyScriptableObjects;

    private void Awake()
    {
        _parameters = GetComponentInChildren<EnemyParam>();
        _enemyScriptableObjects = _parameters.EnemyScriptableObjectByType;
    }

    private void FixedUpdate()
    {
        Vector3 direction = Vector3.back * _enemyScriptableObjects.MovementSpeed * Time.deltaTime;
        transform.position += direction;
    }
}
