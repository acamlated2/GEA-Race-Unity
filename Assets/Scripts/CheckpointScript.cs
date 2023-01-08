using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
   // public
   public bool hit;

   // private
   private GameObject _mainCollider;

   void Start()
    {
        _mainCollider = transform.GetChild(0).gameObject;
    }

    
    void Update()
    {
        CheckCollider();
    }

    void CheckCollider()
    {
        if (_mainCollider.GetComponent<MainCollider>().collided)
        {
            hit = true;
        }
    }

    public void SetHitFalse()
    {
        hit = false;
    }
}
