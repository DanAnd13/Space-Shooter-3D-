using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    public Transform PlayerShipPosition;

    private EnemyParam _parameters;
    private EnemyScriptableObjects _enemyScriptableObjects;

    private void Awake()
    {
        _parameters = GetComponentInChildren<EnemyParam>();
        _enemyScriptableObjects = _parameters.EnemyScriptableObjectByType;
    }

    private void OnEnable()
    {
        gameObject.transform.rotation = PlayerShipPosition.rotation;
    }

    private void FixedUpdate()
    {
        Vector3 direction = Vector3.back * _enemyScriptableObjects.MovementSpeed * Time.deltaTime;
        transform.position += direction;
        if (transform.position.z < PlayerShipPosition.position.z - 20)
        {
            gameObject.SetActive(false);
        }
    }
}
