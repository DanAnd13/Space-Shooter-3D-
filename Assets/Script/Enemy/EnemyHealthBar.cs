using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    private Image _healthBar;
    private EnemyParam _parameters;
    private EnemyScriptableObjects _enemyScriptableObjects;

    private void Awake()
    {
        _healthBar = GetComponentInChildren<Canvas>().GetComponentInChildren<Image>();
        _parameters = GetComponent<EnemyParam>();
        _enemyScriptableObjects = _parameters.EnemyScriptableObjectByType;
    }

    private void OnEnable()
    {
        _healthBar.fillAmount = 1;
    }

    public void UpdateHealthBar(float currentHealth)
    {
        _healthBar.fillAmount = currentHealth / _enemyScriptableObjects.Health;
    }
}
