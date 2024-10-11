using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter3D.CommonLogic
{
    public class AudioPlayer : MonoBehaviour
    {
        public AudioSource ShootingSound;
        public AudioSource PlayerTakeDamageSound;
        public AudioSource EnemyKillSound;
        public AudioSource NextWaveSound;
        public AudioSource LoseSound;

        public void PlayShootingSound()
        {
            ShootingSound.Play();
        }

        public void PlayPlayerTakeDamageSound()
        {
            PlayerTakeDamageSound.Play();
        }

        public void PlayEnemyKillSound()
        {
            EnemyKillSound.Play();
        }

        public void PlayNextWaveSound()
        {
            NextWaveSound.Play();
        }

        public void PlayLoseSound()
        {
            LoseSound.Play();
        }
    }
}
