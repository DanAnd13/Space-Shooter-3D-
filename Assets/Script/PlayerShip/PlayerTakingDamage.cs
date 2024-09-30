using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakingDamage : MonoBehaviour
{
    private float _playerHealth = 0;

    private void Awake()
    {
        _playerHealth = 10f;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        LowerPlayerHealth();
    }

    private void LowerPlayerHealth()
    {
        _playerHealth--;
        
        if (_playerHealth <= 0)
        {
            //loos icon
            gameObject.SetActive(false);
        }
    }
}
