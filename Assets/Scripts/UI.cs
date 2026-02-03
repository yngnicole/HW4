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
            
            GameController.Instance.OnScoreChanged += HandleScoreChanged;
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
        
        if (_scoreText != null)
        {
            _scoreText.text = newScore.ToString();
        }
        
    }
}
