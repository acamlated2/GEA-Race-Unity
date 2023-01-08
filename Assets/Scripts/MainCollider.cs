using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCollider : MonoBehaviour
{
    // public
    public bool collided;
    
    // private
    private GameObject _player;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Collider playerCollider = _player.GetComponent<Collider>();

        if (other == playerCollider)
        {
            collided = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Collider playerCollider = _player.GetComponent<Collider>();

        if (other == playerCollider)
        {
            collided = false;
        }
    }
}
