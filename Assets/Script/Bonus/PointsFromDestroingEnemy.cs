using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsFromDestroingEnemy : MonoBehaviour
{
    [HideInInspector]
    public float Points;
    
    private UIManager _manager;

    private void Awake()
    {
        Points = 0f;
        _manager = GetComponent<UIManager>();
    }

    public void IncreasePoints(float PointsByEnemyType)
    {
        Points += PointsByEnemyType;
        _manager.UpdatePointsValue(Points);
    }
}
