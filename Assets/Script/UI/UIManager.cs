using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter3D.CommonLogic
{
    public class UIManager : MonoBehaviour
    {
        public Image PlayerHealthBar;
        public TextMeshProUGUI PointsText;
        public TextMeshProUGUI WaveTitle;
        public Canvas SettingMenuCanvas;
        public TextMeshProUGUI SettingsTitle;

        public void UpdatePlayerHealthBar(float PlayerHealthValue, float PlayerMaxHealth)
        {
            PlayerHealthBar.fillAmount = PlayerHealthValue / PlayerMaxHealth;
        }

        public void UpdatePointsValue(float Points)
        {
            PointsText.text = Points.ToString();
        }

        public void UpdateWaveCount(float WaveCount)
        {
            WaveTitle.text = "Wave " + WaveCount.ToString();
            StartCoroutine(ShowWaveTitle());
        }

        public void ShowSettingCanvas(string Title)
        {
            SettingsTitle.text = Title;
            SettingMenuCanvas.gameObject.SetActive(true);
        }

        public void HideSettingCanvas()
        {
            SettingMenuCanvas.gameObject.SetActive(false);
        }

        private IEnumerator ShowWaveTitle()
        {
            WaveTitle.gameObject.SetActive(true);
            yield return new WaitForSeconds(2f);
            WaveTitle.gameObject.SetActive(false);
        }
    }
}
