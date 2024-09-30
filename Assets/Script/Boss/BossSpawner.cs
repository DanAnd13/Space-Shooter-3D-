using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public float StopPosition = 100f;

    private float _spawnPosition = 150f;

    public bool IsBossKilled()
    {
        if (gameObject.activeSelf)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void AwakeBoss()
    {
        gameObject.transform.position = new Vector3 (0, 0, _spawnPosition);
        gameObject.SetActive(true);
    }
}
