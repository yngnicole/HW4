using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _topPipePrefab;
    [SerializeField] private GameObject _bottomPipePrefab;
    [SerializeField] private GameObject _pointsWall;

    [SerializeField] private float _spawnX = 10f;
    [SerializeField] private float _gap = 5f;
    [SerializeField] private float _minY = -2f;
    [SerializeField] private float _maxY = 2f;
    [SerializeField] private float _spawnInterval = 2f;

    private float _spawnTimer;
    private int _score;
    public bool IsGameOver { get; private set; }

    public delegate void ScoreChangedHandler(int newScore);
    public event ScoreChangedHandler OnScoreChanged;

    public delegate void GameOverHandler();
    public event GameOverHandler OnGameOver;

    public delegate void FlapHandler();
    public event FlapHandler OnPlayerFlapped;


    public static GameController Instance { get; private set; }
    public YellowBird Player { get; private set; } //ref to player

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        GameObject playerObj = GameObject.FindWithTag("Player");
        Player = playerObj.GetComponent<YellowBird>();

        if (Player != null)
        {
            Player.OnScored += HandlePlayerScored;
            Player.OnDied += HandlePlayerDied;
            Player.OnFlapped += HandlePlayerFlapped;
        }
    }

    private void HandlePlayerScored()
    {
        if (IsGameOver)
            return;

        _score++;
        OnScoreChanged?.Invoke(_score);
    }

    private void HandlePlayerDied()
    {
        if (IsGameOver)
            return;

        IsGameOver = true;
        OnGameOver?.Invoke();
    }

    private void HandlePlayerFlapped()
    {
        OnPlayerFlapped?.Invoke();
    }
    private void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= _spawnInterval)
        {
            SpawnPipes();
            _spawnTimer = 0f;
        }
    }
    public void SpawnPipes()
    {

        float centerY = UnityEngine.Random.Range(_minY, _maxY);

        // Bottom pipe
        Instantiate(_bottomPipePrefab, new Vector3(_spawnX, centerY - _gap, 0), Quaternion.identity);

        // Top pipe
        Instantiate(_topPipePrefab, new Vector3(_spawnX, centerY + _gap, 0), Quaternion.identity);

        //points wall
        Instantiate(_pointsWall, new Vector3(_spawnX + 1f, centerY, 0f), Quaternion.identity);
    }

}
