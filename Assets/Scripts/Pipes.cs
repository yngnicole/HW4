using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] private float _destroyPipe = -12f;
    [SerializeField] private float _moveSpeed;

    private bool _isDestroyed;

    private void Update()
    {
        MoveLeft();
    }
    public void MoveLeft()
    {
        if (_isDestroyed)
            return;

        //pipe moving left 
        transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);

        // if pipe off screen, gets destroyed
        if (transform.position.x < _destroyPipe)
        {
            Destroy(gameObject);
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
