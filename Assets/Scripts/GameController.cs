using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _topPipePrefab;
    [SerializeField] private GameObject _bottomPipePrefab;
    [SerializeField] private float _pipeGap = 3f;
    [SerializeField] private float _spawnX = 10f; //spawn location
    [SerializeField] private float _spawnInterval = 2f;

    private float _spawnTimer;

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
        float cameraHalfHeight = Camera.main.orthographicSize;
        float cameraHalfWidth = cameraHalfHeight * Camera.main.aspect;

        float pipeHeight = _bottomPipePrefab.GetComponent<SpriteRenderer>().bounds.size.y;

        // vertical offset range
        float maxOffset = cameraHalfHeight - pipeHeight - _pipeGap / 2f;
        float offsetY = Random.Range(-maxOffset, maxOffset);
    

        //instantiate bottom pipe
        float bottomY = -cameraHalfHeight + pipeHeight / 2f + offsetY;
        Instantiate(
            _bottomPipePrefab, 
            new Vector3(_spawnX, bottomY, 0), 
            UnityEngine.Quaternion.identity);

        //instantiate top pipe
        float topY = cameraHalfHeight - pipeHeight / 2f + offsetY;
        Instantiate(
            _topPipePrefab, 
            new Vector3(_spawnX, topY, 0), 
            UnityEngine.Quaternion.identity);
    }

    


    //needs ref to player 
    // singleton. gamecontroller is locator
    // subs to ui and audio
    // The score code uses a Singleton to subscribe to any events raised.
}
