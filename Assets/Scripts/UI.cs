using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Start()
    {
        if (GameController.Instance != null)
        {
            Debug.Log("UI: subscribing to OnScoreChanged");
            GameController.Instance.OnScoreChanged += HandleScoreChanged;
        }
        else
        {
            Debug.LogWarning("UI: GameController.Instance is null in OnEnable");
        }
    }

    private void OnDestory()
    {
        if (GameController.Instance != null)
        {
            GameController.Instance.OnScoreChanged -= HandleScoreChanged;
        }
    }

    private void HandleScoreChanged(int newScore)
    {
        Debug.Log("UI: received score " + newScore);
        if (_scoreText != null)
        {
            _scoreText.text = newScore.ToString();
        }
        else
        {
            Debug.LogWarning("UI: _scoreText is NULL!");
        }
    }
}
