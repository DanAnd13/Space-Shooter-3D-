using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroingStructure : MonoBehaviour
{
    [HideInInspector]
    public int EnemyCountInConstruction;

    private EnemyParam _parameters;
    private EnemyScriptableObjects _enemyScriptableObjects;

    private void Awake()
    {
        _parameters = GetComponentInChildren<EnemyParam>();
        _enemyScriptableObjects = _parameters.EnemyScriptableObjectByType;
    }
    private void OnEnable()
    {
        EnemyCountInConstruction = 0;
    }
    void Update()
    {
        if(EnemyCountInConstruction < _enemyScriptableObjects.NumberOfEnemyInStructure)
        {
            gameObject.SetActive(false);
        }
    }
}
