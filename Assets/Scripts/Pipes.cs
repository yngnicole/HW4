using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] private float _destoryPipe = -12f;
    [SerializeField] private float _moveSpeed;

    private bool _isDestroyed;

    void Update()
    {
        if (_isDestroyed)
            return;

        //pipe moving left 
        transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);

        // if pipe off screen, gets destroyed
        if (transform.position.x < _destoryPipe)
        {
            Destory(gameObject);
            return;
        }
    }


    // collider
    // infinte 
    // locate gamecontroller and sub 
    // child top pipe
    // child bottom pipe.
    // invisible point wall. ontrigger enter if want at right of pipe 
    
    // Pipes have variation as to where the gap between the top and bottom pipes are placed.
}
