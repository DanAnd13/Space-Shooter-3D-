using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        _enemyCountForWave = 6;
        _spawnHeight = gameObject.transform.localScale.y;
        _spawnWidth = gameObject.transform.localScale.x;
        _enemyTypeCounter = ObjectPools.transform.childCount;
        _enemyCount = 0;
    }

    private void Start()
    {
        StartCoroutine(SpawnManager());
    }

    private void Update()
    {
        _spawnHeight = gameObject.transform.localScale.y;
        _spawnWidth = gameObject.transform.localScale.x;
    }

    private void GetObjectPoolObjects()
    {
        _enemyPool = ObjectPools.GetComponentsInChildren<ObjectPool>();
    }

    private IEnumerator SpawnManager()
    {
        while (true)
        {
            Coroutine cor1 = StartCoroutine(SpawnerWithRandomEnemy(_enemyPool, _delay));
            yield return new WaitForSeconds(_delay);
            StopCoroutine(cor1);
            _enemyCount++;
            if (_enemyCount >= _enemyCountForWave)
            {
                _enemyCount = 0;
                yield return new WaitForSeconds(_delay*3);
            }
        }
    }

    private IEnumerator SpawnerWithRandomEnemy(ObjectPool[] EnemyPool, float Delay)
    {
        while (true)
        {
            _enemyRandom = UnityEngine.Random.Range(0, _enemyTypeCounter);
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
            Renderer planeRenderer = GetComponent<Renderer>();
            Vector3 planeSize = planeRenderer.bounds.size;
            float spawnX = UnityEngine.Random.Range(-planeSize.x / 2, planeSize.x / 2);
            float spawnY = UnityEngine.Random.Range(-planeSize.y / 2, planeSize.y / 2);
            _spawnRandom = new Vector3(spawnX, spawnY, gameObject.transform.position.z);
            EnemyStructure.transform.position = _spawnRandom + planeRenderer.bounds.center;
            EnemyStructure.SetActive(true);
        }
    }

    private void SpawnAllEnemiesInStructure(GameObject EnemyStructure)
    { 
        GameObject[] Enemy = new GameObject[EnemyStructure.transform.childCount];
        for (int i = 0; i < Enemy.Length; i++)
        {
            Enemy[i] = EnemyStructure.transform.GetChild(i).gameObject;
            Enemy[i].SetActive(true);
        }
    }
}
