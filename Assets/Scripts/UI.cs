using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshPro _scoreText;

    private void OnEnable()
    {
        if (GameController.Instance != Null)
        {
            GameController.Instance.OnScoreChanged += HandleScoreChanged;
        }
    }

    private void OnDisable()
    {
        if (GameController.Instance != Null)
        {
            GameController.Instance.OnScoreChanged -= HandleScoreChanged;
        }
    }

    private void HandleScoreChanged(int newScore)
    {
        if (_scoreText != null)
        {
            _scoreText.text = newScore.ToString();
        }
    }


    //
    // points text 
    // event changes text
    //  The score text AND audio system is alerted of changes to the Player’s score via events.
    // sub to events
}
