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
            _offset = transform.position - value.position;
            Debug.Log(_offset);
        }
    }

    private void Start()
    {
        _offset = transform.position - _target.position;
    }

    private void Update()
    {
        transform.position = target.position + _offset;
    }
}
