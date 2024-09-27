using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ObjectPools;
    
    private static float _delay;
    private ObjectPool[] _enemyPool;
    private float _spawnWidth;
    private float _spawnHeight;
    private int _enemyRandom;
    private Vector3 _spawnRandom;
    private int _enemyCountForWave;
    private int _enemyTypeCounter;
    private int _enemyCount;

    private void Awake()
    {
        GetObjectPoolObjects();
        _delay = 3;
        _enemyCountForWave = 5;
        _spawnHeight = gameObject.transform.localScale.y;
        _spawnWidth = gameObject.transform.localScale.x;
        _enemyTypeCounter = ObjectPools.transform.childCount;
        _enemyCount = 0;
    }

    void Start()
    {
        StartCoroutine(SpawnManager());
    }
    private void GetObjectPoolObjects()
    {
        _enemyPool = new ObjectPool[_enemyTypeCounter];
        for (int i = 0; i < _enemyPool.Length; i++) {
            _enemyPool[i] = ObjectPools.GetComponentInChildren<ObjectPool>();
        }
    }
    private IEnumerator SpawnManager()
    {
        while (true)
        {
            Coroutine cor1 = StartCoroutine(SpawnerWithRandomEnemy(_enemyPool, _delay));
            _enemyCount++;
            if (_enemyCount > _enemyTypeCounter)
            {
                _enemyCount = _enemyTypeCounter - 1;
            }
            if (_enemyCount > _enemyCountForWave)
            {
                yield return new WaitForSeconds(_delay * 2);
            }
        }
    }
    private IEnumerator SpawnerWithRandomEnemy(ObjectPool[] EnemyPool, float Delay)
    {
        while (true)
        {
            _enemyRandom = UnityEngine.Random.Range(0,_enemyTypeCounter);
            yield return new WaitForSeconds(Delay);
            RandomSpawnLocation(EnemyPool[_enemyRandom]);
        }
    }
    private void RandomSpawnLocation(ObjectPool EnemyPool)
    {
        GameObject EnemyStructure = EnemyPool.GetPooledObject();
        SpawnAllEnemiesInStructure(EnemyStructure);
        if (EnemyStructure != null)
        {
            _spawnRandom = new Vector3(UnityEngine.Random.Range(-(_spawnWidth / 2), _spawnWidth / 2),
                                       UnityEngine.Random.Range(-(_spawnHeight/2), _spawnHeight/2), 1);
            EnemyStructure.transform.position = _spawnRandom;
            EnemyStructure.SetActive(true);
        }
    }
    private void SpawnAllEnemiesInStructure(GameObject EnemyStructure)
    {
        GameObject[] Enemy = EnemyStructure.GetComponentsInChildren<GameObject>();
        for (int i = 0; i < Enemy.Length; i++)
        {
            Enemy[i].SetActive(true);
        }
    }
}
