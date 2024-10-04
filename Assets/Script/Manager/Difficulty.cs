using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter3D.Parameters
{
    public class Difficulty : MonoBehaviour
    {
        public Type DifficultyType;
        public enum Type
        {
            Easy,
            Medium,
            Hard
        }

        public int EnemyCount = 0;

        private float[] _baseEnemyHealth;
        private float[] _baseEnemySpeed;
        private float[] _currentEnemyHealth;
        private float[] _currentEnemySpeed;
        private int _currentEnemiesPerWave = 6;
        private EnemyScriptableObjects[] _enemyScriptableObjects;
        private EnemyScriptableObjects[] _baseScriptableObjects;

        public void GetScriptableObjectsFromResources()
        {
            _baseScriptableObjects = Resources.LoadAll<EnemyScriptableObjects>("ScriptableObjects/Base");

            _enemyScriptableObjects = Resources.LoadAll<EnemyScriptableObjects>("ScriptableObjects/Current");

            _currentEnemyHealth = new float[_enemyScriptableObjects.Length];
            _currentEnemySpeed = new float[_enemyScriptableObjects.Length];
        }

        public void ChangeDifficultyByValues(float ScrollBarValues)
        {
            if (ScrollBarValues < 0.5f)
            {
                DifficultyType = Type.Easy;
            }
            else if (ScrollBarValues > 0.5f)
            {
                DifficultyType = Type.Hard;
            }
            else
            {
                DifficultyType = Type.Medium;
            }
            ApplyDifficulty();
        }

        private void ApplyDifficulty()
        {
            for (int i = 0; i < _enemyScriptableObjects.Length; i++)
            {
                ApplyEnemyScriptableObjectsValues(_enemyScriptableObjects[i], _baseScriptableObjects[i], i);
            }
        }

        private void ApplyEnemyScriptableObjectsValues(EnemyScriptableObjects enemyScriptableObjects, EnemyScriptableObjects BaseScriptableObjects, int index)
        {
            switch (DifficultyType)
            {
                case Type.Easy:
                    _currentEnemyHealth[index] = BaseScriptableObjects.Health;
                    _currentEnemySpeed[index] = BaseScriptableObjects.MovementSpeed;
                    EnemyCount = _currentEnemiesPerWave;
                    break;

                case Type.Medium:
                    _currentEnemyHealth[index] = BaseScriptableObjects.Health * 1.5f;
                    _currentEnemySpeed[index] = BaseScriptableObjects.MovementSpeed * 1.5f;
                    EnemyCount = _currentEnemiesPerWave * 2;
                    break;

                case Type.Hard:
                    _currentEnemyHealth[index] = BaseScriptableObjects.Health * 2f;
                    _currentEnemySpeed[index] = BaseScriptableObjects.MovementSpeed * 2f;
                    EnemyCount = _currentEnemiesPerWave * 3;
                    break;
            }
            enemyScriptableObjects.Health = _currentEnemyHealth[index];
            enemyScriptableObjects.MovementSpeed = _currentEnemySpeed[index];
        }
    }
}
