using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class YellowBird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRigidbody
    [SerializeField] private float _jump;
    void Update()
    {
        // The player can flap with SPACE, which: makes the player pop upwards, but gravity pulls them down.plays a sound.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerRigidbody.AddForce(Vector2.up * _jump, ForceMode2D.Impulse);
        }


    }





    // points
    // collider 
    // collides with pipes and trigger event (points) 
    // subscribe to events: UI and Audio maybe not bc not locater
    // collision
    // The player loses if they collide with a pipe, which: plays a sound. stops the game.
    // The player gains a point if they pass a pipe without colliding with it, and: the number of points is displayed in the UI.earning a point plays a sound.
}
