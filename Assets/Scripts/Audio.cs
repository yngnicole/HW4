using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _flapClip;
    [SerializeField] private AudioClip _scoreClip;
    [SerializeField] private AudioClip _hitClip;

    private void OnEnable()
    {
        if (GameController.Instance != null)
        {
            GameController.Instance.OnScoreChanged += HandleScoreChanged;
            GameController.Instance.OnGameOver += HandleGameOver;
            GameController.Instance.OnPlayerFlapped += HandleFlap;
        }
    }

    private void OnDisable()
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
        if (_flapClip != null)
            _audioSource.PlayOneShot(_flapClip);
    }

    private void HandleScoreChanged(int newScore)
    {
        if (_scoreClip != null)
            _audioSource.PlayOneShot(_scoreClip);
    }

    private void HandleGameOver()
    {
        if (_hitClip != null)
            _audioSource.PlayOneShot(_hitClip);
    }

}
