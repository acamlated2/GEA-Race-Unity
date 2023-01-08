using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Public
    
    // Private
    private float _dt;

    private Vector3 _dir;
    
    private float _speed = 30;
    private float _rotationSpeed = 45;

    void Start()
    {
        
    }

    
    void Update()
    {
        _dt = Time.deltaTime;
        
        ManageInputs();
    }

    private void FixedUpdate()
    {
        ManageMovements();
    }

    void ManageInputs()
    {
        // forward
        if (Input.GetAxis("Forward") > 0)
        {
            _dir.x = 1;
        }
        else if (Input.GetAxis("Forward") < 0)
        {
            _dir.x = -1;
        }
        else
        {
            _dir.x = 0;
        }

        // rotation
        if (Input.GetAxis("Rotate") > 0)
        {
            _dir.z = 1;
        }
        else if (Input.GetAxis("Rotate") < 0)
        {
            _dir.z = -1;
        }
        else
        {
            _dir.z = 0;
        }
        
        // vertical
        if (Input.GetAxis("Vertical") > 0)
        {
            _dir.y = 1;
            
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            _dir.y = -1;
            
        }
        else
        {
            _dir.y = 0;
        }
    }

    void ManageMovements()
    {
        // forward & backward
        if (_dir.x > 0)
        {
            transform.Translate(Vector3.forward * _speed * _dt);
        }
        else if (_dir.x < 0)
        {
            transform.Translate(Vector3.back * _speed * _dt);
        }
        
        // rotation
        if (_dir.z > 0)
        {
            transform.Rotate(0, 1 * _rotationSpeed * _dt, 0);
        }
        else if (_dir.z < 0)
        {
            transform.Rotate(0, -1 * _rotationSpeed * _dt, 0);
        }
        
        // vertical
        if (_dir.y > 0)
        {
            transform.Rotate(-1 * _rotationSpeed * _dt, 0, 0);
        }
        else if (_dir.y < 0)
        {
            transform.Rotate(1 * _rotationSpeed * 5 * _dt, 0, 0);
        }
    }
}
