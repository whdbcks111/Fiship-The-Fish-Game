using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Vector3 _offset = Vector3.zero;
    public Transform target
    {
        get { return _target; }
        set { 
            _target = value;
            if(value is not null) _offset = transform.position - value.position;
        }
    }

    private void Start()
    {
        if(target is not null)
            _offset = transform.position - target.position;
    }

    private void Update()
    {
        if (target is not null)
            transform.position = target.position + _offset;
    }
}
