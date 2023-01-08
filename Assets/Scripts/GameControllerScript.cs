using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    // public
    
    // private
    private GameObject[] _checkpoints;

    private int _targetIndex;
    private int _nextIndex;

    private Color _green = new Color(0, 1, 0, 0.25f);
    private Color _yellow = new Color(1, 1, 0, 0.25f);
    private Color _red = new Color(1, 0, 0, 0.25f);

    private Camera _camera;
    private GameObject _checkpointTracker;

    void Start()
    {
        _checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");

        _nextIndex = _targetIndex + 1;

        _camera = Camera.main;
        _checkpointTracker = GameObject.FindGameObjectWithTag("Checkpoint Tracker").gameObject;
    }

    void Update()
    {
        ManageCheckpoints();
        ManageTracker();
    }

    void ManageCheckpoints()
    {
        // check index
        if (_checkpoints[_targetIndex].GetComponent<CheckpointScript>().hit)
        {
            _checkpoints[_targetIndex].GetComponent<CheckpointScript>().SetHitFalse();
            _targetIndex += 1;
            _nextIndex += 1;

            if (_targetIndex > _checkpoints.Length - 1)
            {
                _targetIndex = 0;
            }

            if (_nextIndex > _checkpoints.Length - 1)
            {
                _nextIndex = 0;
            }
        }
        
        // set color
        for (int i = 0; i < _checkpoints.Length; i++)
        {
            if (i == _targetIndex)
            {
                _checkpoints[i].transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", _green);
            }

            if (i == _nextIndex)
            {
                _checkpoints[i].transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", _yellow);
            }

            if ((i > _targetIndex + 1) ||
                ((i < _targetIndex) && (i != _nextIndex)))
            {
                _checkpoints[i].transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", _red);
            }
        }
    }

    void ManageTracker()
    {
        _checkpointTracker.transform.position =
            _camera.WorldToScreenPoint(_checkpoints[_targetIndex].transform.position);

        if (_checkpointTracker.transform.position.x < 0)
        {
            _checkpointTracker.transform.position = new Vector3(0,
                _checkpointTracker.transform.position.y);
        }

        if (_checkpointTracker.transform.position.x > Screen.width)
        {
            _checkpointTracker.transform.position = new Vector3(Screen.width,
                _checkpointTracker.transform.position.y);
        }
        
        if (_checkpointTracker.transform.position.y < 0)
        {
            _checkpointTracker.transform.position = new Vector3(_checkpointTracker.transform.position.x,
                0);
        }

        if (_checkpointTracker.transform.position.y > Screen.height)
        {
            _checkpointTracker.transform.position = new Vector3(_checkpointTracker.transform.position.x,
                Screen.height);
        }
    }
}
