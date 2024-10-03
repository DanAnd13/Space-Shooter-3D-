using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSettings : MonoBehaviour
{
    public Scrollbar DifficultyScrollBar;
    public Slider Volume;

    private Difficulty _difficulty;

    private void Awake()
    {
        _difficulty = GetComponent<Difficulty>();
        DifficultyScrollBar.value = PlayerPrefs.GetFloat("Difficulty");
        Volume.value = PlayerPrefs.GetFloat("Volume");
    }

    public void SaveValues()
    {
        _difficulty.ChangeDifficultyByValues(DifficultyScrollBar.value);

        PlayerPrefs.SetFloat("Difficulty", DifficultyScrollBar.value);
        PlayerPrefs.SetFloat("Volume", Volume.value);
        PlayerPrefs.Save();
        
    }
}
