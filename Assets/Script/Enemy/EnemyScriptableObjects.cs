using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter3D.Parameters
{
    [CreateAssetMenu(fileName = "EnemyType", menuName = "Enemy")]
    public class EnemyScriptableObjects : ScriptableObject
    {
        public float Health;
        public float MovementSpeed;
        public int NumberOfEnemyInStructure;
        public TypeOfEnemy EnemyType;
        public int BonusForDestroingTheEnemy;
        public enum TypeOfEnemy
        {
            BaseEnemy,
            FastEnemy,
            ArmoredEnemy,
            BossEnemy
        }
    }
}
