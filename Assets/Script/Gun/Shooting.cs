using SpaceShooter3D.CommonLogic;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace SpaceShooter3D.Mechanics
{
    public class Shooting : MonoBehaviour
    {
        public AudioPlayer AudioPlayer;
        public float ShootInterval = 0.5f;
        public float ShootDuration = 2f;
        public Transform Gun;
        public Parameters.ObjectPool Bullets;

        private float _reloadTime;

        private void Update()
        {
            ShootWithInterval();
        }

        private void ShootWithInterval()
        {
            if (_reloadTime <= 0f)
            {
                Shoot();
                AudioPlayer.PlayShootingSound();
                _reloadTime = ShootInterval;
            }
            else
            {
                _reloadTime -= Time.deltaTime;
            }
        }

        private void Shoot()
        {
            GameObject shootingBullet = Bullets.GetPooledObject();
            if (shootingBullet != null)
            {
                GetPositionAndStartMovement(shootingBullet);
            }
        }

        private void GetPositionAndStartMovement(GameObject shootingBullet)
        {
            shootingBullet.transform.position = Gun.position;
            shootingBullet.SetActive(true);
            StartCoroutine(BulletLiveTime(shootingBullet));
        }

        IEnumerator BulletLiveTime(GameObject bullet)
        {
            yield return new WaitForSeconds(ShootDuration);
            bullet.SetActive(false);
        }
    }
}
