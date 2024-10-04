using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter3D.Parameters
{
    public class TypeOfBonus : MonoBehaviour
    {
        public Types BonusTypes;
        public enum Types
        {
            Damage,
            ShootSpeed,
            Sheald,
            Speed
        }
    }
}
