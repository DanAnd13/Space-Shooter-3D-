using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float shootInterval = 0.5f;
    public float shootDuration = 2f;
    public ObjectPool Bullets;

    private float _reloadTime;

    private void FixedUpdate()
    {
        if (_reloadTime <= 0f)
        {
            Shoot();
            _reloadTime = shootInterval;
        }
        else
        {
            _reloadTime -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject shootingBullet = Bullets.GetPooledObject();
        if (shootingBullet != null)
        {
            shootingBullet.transform.position = gameObject.transform.position;
            shootingBullet.SetActive(true);
            StartCoroutine(BulletLiveTime(shootingBullet));
        }
    }
    IEnumerator BulletLiveTime(GameObject bullet)
    {
        yield return new WaitForSeconds(shootDuration);
        bullet.SetActive(false);
    }
}
