using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // public
    
    // private
    private GameObject _player;
    private GameObject _target;

    private Vector3 _offset;
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _target = GameObject.FindGameObjectWithTag("Camera Target");

        _offset = new Vector3(0, 4, -15);
    }


    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        Vector3 desiredAngle = _player.transform.eulerAngles;
        Quaternion rotation = Quaternion.Euler(desiredAngle);
        transform.position = _player.transform.position + (rotation * _offset);
        
        transform.LookAt(_target.transform);
    }
}
