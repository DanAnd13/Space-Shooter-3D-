using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter3D.CommonLogic
{
    public class Spawner : MonoBehaviour
    {
        public GameObject ObjectPools;
        public BossSpawner BossSpawner;
        public SpaceShooter3D.Parameters.Difficulty Difficulty;
        public UIManager UIManager;
        public Scrollbar DifficultyScrollBar;

        private static float _delay;
        private SpaceShooter3D.Parameters.ObjectPool[] _enemyPool;
        private float _spawnWidth;
        private float _spawnHeight;
        private int _enemyRandom;
        private Vector3 _spawnRandom;
        private int _enemyTypeCounter;
        private int _enemyCount;
        private int _enemyCountPerWave;
        private int _waveCounter;

        private void Awake()
        {
            GetObjectPoolObjects();
            _enemyTypeCounter = ObjectPools.transform.childCount;

            _enemyCountPerWave = Difficulty.EnemyCount;
            Difficulty.GetScriptableObjectsFromResources();
            Difficulty.ChangeDifficultyByValues(PlayerPrefs.GetFloat("Difficulty"));

            _spawnHeight = gameObject.transform.localScale.y;
            _spawnWidth = gameObject.transform.localScale.x;
            _enemyCount = 0;
            _waveCounter = 1;
            _delay = 3;
        }

        private void Start()
        {
            StartCoroutine(SpawnManager());
        }

        private void Update()
        {
            UpdateSpawnScale();
        }

        private void UpdateSpawnScale()
        {
            _spawnHeight = gameObject.transform.localScale.y;
            _spawnWidth = gameObject.transform.localScale.x;
        }

        private void GetObjectPoolObjects()
        {
            _enemyPool = ObjectPools.GetComponentsInChildren<SpaceShooter3D.Parameters.ObjectPool>();
        }

        private IEnumerator SpawnManager()
        {
            UIManager.UpdateWaveCount(_waveCounter);
            while (true)
            {
                Coroutine cor1 = StartCoroutine(SpawnerWithRandomEnemy(_enemyPool, _delay));
                yield return new WaitForSeconds(_delay);
                StopCoroutine(cor1);
                _enemyCount++;
                if (_enemyCount >= _enemyCountPerWave)
                {
                    _waveCounter++;
                    _enemyCount = 0;
                    _enemyCountPerWave += _enemyCountPerWave;
                    if (Difficulty.DifficultyType == SpaceShooter3D.Parameters.Difficulty.Type.Hard)
                    {
                        BossSpawner.AwakeBoss();
                        yield return new WaitUntil(BossSpawner.IsBossKilled);
                    }
                    UIManager.UpdateWaveCount(_waveCounter);
                    yield return new WaitForSeconds(2f);
                }
            }
        }

        private IEnumerator SpawnerWithRandomEnemy(SpaceShooter3D.Parameters.ObjectPool[] EnemyPool, float Delay)
        {
            while (true)
            {
                _enemyRandom = UnityEngine.Random.Range(0, _enemyTypeCounter);
                yield return new WaitForSeconds(Delay);
                RandomSpawnLocation(EnemyPool[_enemyRandom]);
            }
        }

        private void RandomSpawnLocation(SpaceShooter3D.Parameters.ObjectPool EnemyPool)
        {
            GameObject EnemyStructure = EnemyPool.GetPooledObject();
            ActivateAllEnemiesInStructure(EnemyStructure);

            if (EnemyStructure != null)
            {
                Renderer planeRenderer = GetComponent<Renderer>();
                GetRandomSpawnPoint(planeRenderer);
                SpawnEnemy(planeRenderer, EnemyStructure);
            }
        }

        private void GetRandomSpawnPoint(Renderer planeRenderer)
        {
            Vector3 planeSize = planeRenderer.bounds.size;
            float spawnX = UnityEngine.Random.Range(-planeSize.x / 2, planeSize.x / 2);
            float spawnY = UnityEngine.Random.Range(-planeSize.y / 2, planeSize.y / 2);
            _spawnRandom = new Vector3(spawnX, spawnY, gameObject.transform.position.z);
        }

        private void SpawnEnemy(Renderer planeRenderer, GameObject EnemyStructure)
        {
            EnemyStructure.transform.position = _spawnRandom + planeRenderer.bounds.center;
            EnemyStructure.SetActive(true);
        }

        private void ActivateAllEnemiesInStructure(GameObject EnemyStructure)
        {
            GameObject[] Enemy = new GameObject[EnemyStructure.transform.childCount];
            for (int i = 0; i < Enemy.Length; i++)
            {
                Enemy[i] = EnemyStructure.transform.GetChild(i).gameObject;
                Enemy[i].SetActive(true);
            }
        }
    }
}
