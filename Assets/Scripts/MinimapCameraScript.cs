using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinimapCameraScript : MonoBehaviour
{
    // private
    private GameObject _player;
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        // set position
        transform.position = _player.transform.position + new Vector3(0, 100, 0);
    }
}
