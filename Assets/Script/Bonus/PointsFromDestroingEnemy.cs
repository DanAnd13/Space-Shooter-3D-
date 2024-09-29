using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsFromDestroingEnemy : MonoBehaviour
{
    [HideInInspector]
    public float Points;
    //public TextMeshProUGUI OutputField;

    private void Awake()
    {
        Points = 0f;
    }

    public void IncreasePoints(float PointsByEnemyType)
    {
        Points += PointsByEnemyType;
    }
}
