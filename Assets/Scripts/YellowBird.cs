using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class YellowBird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField] private float _jump;
    [SerializeField] private float _gravity = 15f;
    private bool _flap;

    public delegate void PlayerEventHandler();
    public event PlayerEventHandler OnScored;
    public event PlayerEventHandler OnDied;
    public event PlayerEventHandler OnFlapped;

    void Update()
    {
        // The player can flap with SPACE, which: makes the player pop upwards, but gravity pulls them down. Plays a sound.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _flap = true;
        }

    }

    private void FixedUpdate()
    {
        if (_flap)
        {
            // preventing bird from flying super fast up
            _playerRigidbody.velocity = new Vector2
            (
                _playerRigidbody.velocity.x,
                0f
            );

            // bird jumps
            _playerRigidbody.AddForce
            (
                Vector2.up * _jump,
                ForceMode2D.Impulse
            );

            OnFlapped?.Invoke();

            _flap = false;
        }

            // gravity pulls bird down 
        if (_playerRigidbody.velocity.y < 0)
        {
            _playerRigidbody.AddForce(Vector2.down * _gravity);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //The player gains a point if they pass a pipe without colliding with it, and: the number of points is displayed in the UI.earning a point plays a sound.
        if (collision.CompareTag("PointsWall"))
        {
            Debug.Log("POINT SCORED (YellowBird)!");
            OnScored?.Invoke();
            Destroy(collision.gameObject);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with: " + collision.collider.gameObject.tag);
        Debug.Log("Trigger with: " + collision.gameObject.tag);
        // The player loses if they collide with a pipe, which: plays a sound. stops the game.
        if (collision.collider.CompareTag("Pipes"))
        {
            Debug.Log("HIT PIPE!");
            OnDied?.Invoke();
        }
    }
   
}
