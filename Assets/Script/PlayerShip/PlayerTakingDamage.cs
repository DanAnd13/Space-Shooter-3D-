using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakingDamage : MonoBehaviour
{
    public GameObject Manager;

    private UIManager _uiManager;
    private LevelManager _levelManager;
    private float _playerHealth = 10f;
    private float _currentPlayerHealth;

    private void Awake()
    {
        _uiManager = Manager.GetComponent<UIManager>();
        _levelManager = Manager.GetComponent<LevelManager>();

        _currentPlayerHealth = _playerHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        LowerPlayerHealth();
    }

    private void LowerPlayerHealth()
    {
        _currentPlayerHealth--;
        _uiManager.UpdatePlayerHealthBar(_currentPlayerHealth, _playerHealth);
        if (_currentPlayerHealth <= 0)
        {
            _uiManager.ShowSettingCanvas("Lose");
            _levelManager.GetPause();
        }
    }
}
