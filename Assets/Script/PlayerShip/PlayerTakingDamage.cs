using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter3D.CommonLogic
{
    public class PlayerTakingDamage : MonoBehaviour
    {
        public GameObject Manager;
        public ParticleSystem PlayerDeathAnimation;

        private AudioPlayer _audioPlayer;
        private UIManager _uiManager;
        private LevelManager _levelManager;
        private float _playerHealth = 10f;
        private float _currentPlayerHealth;

        private void Awake()
        {
            _uiManager = Manager.GetComponent<UIManager>();
            _levelManager = Manager.GetComponent<LevelManager>();
            _audioPlayer = Manager.GetComponent<AudioPlayer>();

            _currentPlayerHealth = _playerHealth;
        }

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.SetActive(false);
            LowerPlayerHealth();
        }

        private void LowerPlayerHealth()
        {
            _currentPlayerHealth--;
            _uiManager.UpdatePlayerHealthBar(_currentPlayerHealth, _playerHealth);

            PlayDamageAnimation();
            _audioPlayer.PlayPlayerTakeDamageSound();

            if (_currentPlayerHealth <= 0)
            {
                _uiManager.ShowSettingCanvas("Lose");
                _audioPlayer.PlayLoseSound();
                transform.localScale = Vector3.zero;
                _levelManager.GetPause();
            }
        }

        private void PlayDamageAnimation()
        {
            PlayerDeathAnimation.gameObject.transform.position = transform.position;
            PlayerDeathAnimation.gameObject.SetActive(true);
            PlayerDeathAnimation.Play();
        }
    }
}
