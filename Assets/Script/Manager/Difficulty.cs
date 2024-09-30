using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public Type DifficultyType;
    public enum Type
    {
        Easy,
        Medium,
        Hard
    }
    public int EnemyCount = 6;

    private float _enemyHealth;
    private float _enemySpeed;
    private int _enemiesPerWave;
    private EnemyScriptableObjects[] _enemyScriptableObjects;

    public void GetValueFromDifficulty()
    {
        for (int i = 0; i < _enemyScriptableObjects.Length; i++)
        {
            ValuesFromDifficultyType(_enemyScriptableObjects[i], EnemyCount);
        }
    }

    public void GetScriptableObjectsFromResources()
    {
        _enemyScriptableObjects = Resources.LoadAll<EnemyScriptableObjects>("ScriptableObjects");
        for (int i = 0; i < _enemyScriptableObjects.Length; i++)
        {
            GetEnemyScriptableObjectsValues(_enemyScriptableObjects[i], EnemyCount);
            ValuesFromDifficultyType(_enemyScriptableObjects[i], EnemyCount);
        }
    }

    private void GetEnemyScriptableObjectsValues(EnemyScriptableObjects EnemyScriptableObjects, int EnemyCountPerWave)
    {
        _enemyHealth = EnemyScriptableObjects.Health;
        _enemySpeed = EnemyScriptableObjects.MovementSpeed;
        _enemiesPerWave = EnemyCountPerWave;
    }

    private void ValuesFromDifficultyType(EnemyScriptableObjects EnemyScriptableObjects, int EnemyCountPerWave)
    {
        switch (DifficultyType)
        {
            case Type.Easy:

                EnemyScriptableObjects.Health = _enemyHealth;
                EnemyScriptableObjects.MovementSpeed = _enemySpeed;
                EnemyCountPerWave = _enemiesPerWave;
                break;

            case Type.Medium:

                EnemyScriptableObjects.Health *= 1.5f;
                EnemyScriptableObjects.MovementSpeed *= 1.5f;
                EnemyCountPerWave *= 2;
                break;
            
            case Type.Hard:

                EnemyScriptableObjects.Health *= 2f;
                EnemyScriptableObjects.MovementSpeed *= 2f;
                EnemyCountPerWave *= 3;
                break;
        }
    }
}
