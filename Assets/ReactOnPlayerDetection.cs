using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactOnPlayerDetection : MonoBehaviour
{
    [SerializeField]private float _threshold=5 ;

    // Start is called before the first frame update
    void Start()
    {
        GameEventManager.OnPlayerDetection += OnPlayerDetection;
    }

    private void OnPlayerDetection(Vector3 _position)
    {
        Debug.Log(name + " - ReactOnPlayerDetection");
        var vector = transform.position - _position;
        if(vector.sqrMagnitude < _threshold*_threshold) {

            Debug.Log(name + " - Starts pursuit");
        }
        
    }

    private void OnDisable()
    {
        GameEventManager.OnPlayerDetection -= OnPlayerDetection;
    }
}
