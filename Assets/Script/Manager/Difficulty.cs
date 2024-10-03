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

    private float[] _enemyHealth;
    private float[] _enemySpeed;
    private int[] _enemiesPerWave;
    private EnemyScriptableObjects[] _enemyScriptableObjects;

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
        GetValueFromDifficulty();
    }

    public void GetScriptableObjectsFromResources()
    {
        _enemyScriptableObjects = Resources.LoadAll<EnemyScriptableObjects>("ScriptableObjects");
        _enemiesPerWave = new int[_enemyScriptableObjects.Length];
        _enemyHealth = new float[_enemyScriptableObjects.Length];
        _enemySpeed = new float[_enemyScriptableObjects.Length];

        for (int i = 0; i < _enemyScriptableObjects.Length; i++)
        {
            SaveBaseScriptableObjectsValues(_enemyScriptableObjects[i], EnemyCount, i);
        }
    }

    private void GetValueFromDifficulty()
    {
        for (int i = 0; i < _enemyScriptableObjects.Length; i++)
        {
            GetEnemyScriptableObjectsValues(_enemyScriptableObjects[i], EnemyCount, i);
        }
    }

    private void SaveBaseScriptableObjectsValues(EnemyScriptableObjects EnemyScriptableObjects, int EnemyCountPerWave, int Index)
    {
        _enemyHealth[Index] = EnemyScriptableObjects.Health;
        _enemySpeed[Index] = EnemyScriptableObjects.MovementSpeed;
        _enemiesPerWave[Index] = EnemyCountPerWave;
    }

    private void GetEnemyScriptableObjectsValues(EnemyScriptableObjects EnemyScriptableObjects, int EnemyCountPerWave, int Index)
    {
        switch (DifficultyType)
        {
            case Type.Easy:

                EnemyScriptableObjects.Health = _enemyHealth[Index];
                EnemyScriptableObjects.MovementSpeed = _enemySpeed[Index];
                EnemyCountPerWave = _enemiesPerWave[Index];
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
