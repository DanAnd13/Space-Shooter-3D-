using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter3D.CommonLogic
{
    public class KillCounter : MonoBehaviour
    {
        [HideInInspector]
        public int Counter;

        private void Awake()
        {
            Counter = 0;
        }

        public void IncreaseKillCount()
        {
            Counter++;
        }

        public int GetKillCount()
        {
            return Counter;
        }
    }
}
