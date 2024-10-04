using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter3D.Mechanics
{
    public class DestroingStructure : MonoBehaviour
    {
        [HideInInspector]
        public int EnemyCountInConstruction;

        private SpaceShooter3D.Parameters.EnemyParam _parameters;
        private SpaceShooter3D.Parameters.EnemyScriptableObjects _enemyScriptableObjects;

        private void Awake()
        {
            _parameters = GetComponentInChildren<SpaceShooter3D.Parameters.EnemyParam>();
            _enemyScriptableObjects = _parameters.EnemyScriptableObjectByType;
        }

        private void OnEnable()
        {
            EnemyCountInConstruction = _enemyScriptableObjects.NumberOfEnemyInStructure;
        }

        void Update()
        {
            if (EnemyCountInConstruction < EnemyCountInConstruction - 1)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
