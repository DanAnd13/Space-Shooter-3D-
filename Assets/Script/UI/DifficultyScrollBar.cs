using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyScrollBar : MonoBehaviour
{
    public TextMeshProUGUI ScrollBarTitle;

    private Scrollbar _difficultyScrollBar;

    private void Awake()
    {
        _difficultyScrollBar = GetComponent<Scrollbar>();
    }

    void Update()
    {
        if (_difficultyScrollBar.value < 0.5f)
        {
            ScrollBarTitle.text = "Easy";
        }
        else if(_difficultyScrollBar.value > 0.5f)
        {
            ScrollBarTitle.text = "Hard";
        }
        else
        {
            ScrollBarTitle.text = "Medium";
        }
    }
}
