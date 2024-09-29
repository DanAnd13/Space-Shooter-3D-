using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsSpawner : MonoBehaviour
{
    public GameObject BonusElement;

    public void SpawnPowerUps(KillCounter KillCounter, Transform SpawnPoint)
    {
        if (KillCounter.GetKillCount() % 10 == 0)
        {
            if (BonusElement != null)
            {
                BonusElement.transform.position = SpawnPoint.position;
                BonusElement.SetActive(true);
            }
        }
    }
}
