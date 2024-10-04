using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter3D.Mechanics
{
    public class ParticleBoundaryReset : MonoBehaviour
    {
        public List<GameObject> Particles;
        public Transform PlayerShip;

        private Vector3 _basePosition;
        private int _currentIndex;

        private void Start()
        {
            _basePosition = PlayerShip.position;
            _currentIndex = 0;
        }

        private void Update()
        {
            CheckPosition();
        }

        private void CheckPosition()
        {
            if (PlayerShip.position.x > _basePosition.x)
            {
                ActivateNextParticleSystem(new Vector3(500, 0, 0));
            }
            else if (PlayerShip.position.x < _basePosition.x)
            {
                ActivateNextParticleSystem(new Vector3(-500, 0, 0));
            }
            if (PlayerShip.position.y > _basePosition.y)
            {
                ActivateNextParticleSystem(new Vector3(0, 500, 0));
            }
            else if (PlayerShip.position.y < _basePosition.y)
            {
                ActivateNextParticleSystem(new Vector3(0, -500, 0));
            }
        }

        private void ActivateNextParticleSystem(Vector3 offset)
        {
            int nextIndex = (_currentIndex + 1) % Particles.Count;
            Particles[nextIndex].transform.position = Particles[_currentIndex].transform.position + offset;
            Particles[nextIndex].gameObject.SetActive(true);
            _basePosition = Particles[nextIndex].transform.position;
            _currentIndex = nextIndex;
        }
    }
}
