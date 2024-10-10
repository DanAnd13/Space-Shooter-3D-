using SpaceShooter3D.Parameters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter3D.CommonLogic
{

    public class VFXPlayer : MonoBehaviour
    {
        public GameObject VfxObjectPool;

        private ObjectPool _vfxParent;

        private void Awake()
        {
            _vfxParent = VfxObjectPool.GetComponent<ObjectPool>();
        }

        public void PlayAnimation(Transform ObjectTransform)
        {
            GameObject DeathAnimation = _vfxParent.GetPooledObject();
            if (DeathAnimation != null)
            {
                ParticleSystem DeathVfx = DeathAnimation.GetComponent<ParticleSystem>();
                if (DeathVfx != null)
                {
                    ActivateParticles(DeathVfx, ObjectTransform);
                }
            }
        }

        private void ActivateParticles(ParticleSystem DeathVfx, Transform ObjectTransform)
        {
            DeathVfx.gameObject.transform.position = ObjectTransform.position;
            DeathVfx.gameObject.SetActive(true);
            DeathVfx.Play();
            if (!DeathVfx.isPlaying)
            {
                DeathVfx.gameObject.SetActive(false);
            }
        }
    }
}