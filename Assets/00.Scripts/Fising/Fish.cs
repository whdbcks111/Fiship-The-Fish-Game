using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    private int _moveAxis = 0;
    private float _minX, _maxX, _speed;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _moveAxis = Random.value < 0.5 ? -1 : 1;
        _minX = ScreenRect.leftTop.x;
        _maxX = ScreenRect.rightBottom.x;
        _speed = Random.Range(0.5f, 1.5f);
    }

    private void Update()
    {
        transform.position += Vector3.right * _moveAxis * Time.deltaTime * _speed;
        if (transform.position.x < _minX)
        {
            var pos = transform.position;
            pos.x = _minX;
            transform.position = pos;
            _moveAxis *= -1;
        }
        else if (transform.position.x > _maxX)
        {
            var pos = transform.position;
            pos.x = _maxX;
            transform.position = pos;
            _moveAxis *= -1;
        }

        _spriteRenderer.flipX = _moveAxis > 0;
    }
}
