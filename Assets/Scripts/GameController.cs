using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _topPipePrefab;
    [SerializeField] private GameObject _bottomPipePrefab;
    [SerializeField] private float _minY = -2f;
    [SerializeField] private float _maxY = 2f;
    [SerializeField] private float _pipeGap = 3f;
    [SerializeField] private float _spawnX = 10f;


    // creates pipes. destory. spawn location. random. range. and diff height. moves left. infinite 
    // same interval but different hieghts 
    public void SpawnPipes()
    {
        //instantiate pipes with equal interval horizontally but with different heights infinitely 
        
        //random center for pipe gap 
        float centerY = Random.Range(_minY, _maxY);

        //instantiate bottom pipe
        Instantiate(
            _bottomPipePrefab, 
            new Vector3(_spawnX, centerY - _pipeGap / 2f, 0),
            UnityEngine.Quaternion.identity);

        //instantiate top pipe
        Instantiate(
            _topPipePrefab, 
            new Vector3(_spawnX, centerY + _pipeGap / 2f, 0),
            UnityEngine.Quaternion.identity);
    }




    //needs ref to player 
    // singleton. gamecontroller is locator
    // subs to ui and audio
    // The score code uses a Singleton to subscribe to any events raised.
}
