using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _flapClip;
    [SerializeField] private AudioClip _scoreClip;
    [SerializeField] private AudioClip _hitClip;

    private void Start()
    {
        if (GameController.Instance != null)
        {
            
            GameController.Instance.OnScoreChanged += HandleScoreChanged;
            GameController.Instance.OnGameOver += HandleGameOver;
            GameController.Instance.OnPlayerFlapped += HandleFlap;
        }
       
    }

    private void OnDestroy()
    {
        if (GameController.Instance != null)
        {
            GameController.Instance.OnScoreChanged -= HandleScoreChanged;
            GameController.Instance.OnGameOver -= HandleGameOver;
            GameController.Instance.OnPlayerFlapped -= HandleFlap;
        }
    }

    private void HandleFlap()
    {
        if (_audioSource != null && _flapClip != null)
        {
            _audioSource.PlayOneShot(_flapClip);
        }
            
    }

    private void HandleScoreChanged(int newScore)
    {
        if (_audioSource != null && _scoreClip != null)
        {
            _audioSource.PlayOneShot(_scoreClip);
        }
            
    }

    private void HandleGameOver()
    {
        if (_audioSource != null && _hitClip != null)
        {

            _audioSource.PlayOneShot(_hitClip);
        }
            
    }

}
