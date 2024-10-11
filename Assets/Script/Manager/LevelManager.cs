using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter3D.CommonLogic
{
    public class LevelManager : MonoBehaviour
    {
        public static bool gamePause = false;

        private void Start()
        {
            gamePause = false;
        }

        private void Update()
        {
            PauseByClick();
        }

        public void ReloadScene()
        {
            GetPause();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void GetPause()
        {
            if (gamePause)
            {
                gamePause = false;
            }
            else
            {
                gamePause = true;
            }
            Pause();
        }

        private void Pause()
        {
            if (gamePause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        private void PauseByClick()
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                gamePause = true;
                Pause();
            }
        }
    }
}
