using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _topPipePrefab;
    [SerializeField] private GameObject _bottomPipePrefab;
   // [SerializeField] private float _pipeGap = 3f;
   // [SerializeField] private float _spawnX = 10f; //spawn location
  //  [SerializeField] private float _spawnInterval = 2f;

    
    [SerializeField] private float _spawnX = 10f;
    [SerializeField] private float _gap = 5f;
    [SerializeField] private float _minY = -2f;
    [SerializeField] private float _maxY = 2f;
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

        float centerY = UnityEngine.Random.Range(_minY, _maxY);

        // Bottom pipe
        Instantiate(_bottomPipePrefab, new Vector3(_spawnX, centerY - _gap, 0), Quaternion.identity);

        // Top pipe
        Instantiate(_topPipePrefab, new Vector3(_spawnX, centerY + _gap, 0), Quaternion.identity);


        /*
        float cameraHalfHeight = Camera.main.orthographicSize;
        //float cameraHalfWidth = cameraHalfHeight * Camera.main.aspect;

        float pipeHeight = _bottomPipePrefab.GetComponent<SpriteRenderer>().bounds.size.y;

        // vertical offset range
        float maxOffset = cameraHalfHeight - _pipeGap / 2f - pipeHeight /2f;
        float offsetY = UnityEngine.Random.Range(-maxOffset, maxOffset);


        //instantiate bottom pipe
        float bottomY = offsetY - _pipeGap / 2f;
        //-cameraHalfHeight + pipeHeight / 2f + offsetY;
        Instantiate(
            _bottomPipePrefab, 
            new Vector3(_spawnX, bottomY, 0), 
            UnityEngine.Quaternion.identity);


        //instantiate top pipe
        float topY = offsetY + _pipeGap / 2f;
            //cameraHalfHeight - pipeHeight / 2f + offsetY;
        Instantiate(
            _topPipePrefab, 
            new Vector3(_spawnX, topY, 0), 
            UnityEngine.Quaternion.identity);
        */


    }

    


    //needs ref to player 
    // singleton. gamecontroller is locator
    // subs to ui and audio
    // The score code uses a Singleton to subscribe to any events raised.
}
