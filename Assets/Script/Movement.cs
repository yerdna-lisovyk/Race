using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private bool _isMoving = false;
    private Vector3 _targetPosition;
    private float _speed = 0.5f;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }

        if (_isMoving)
        {
            Move();
        }
    }

    private void SetTargetPosition()
    {
        if (_camera is { }) _targetPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _targetPosition.z = transform.position.z;
        _isMoving = true;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        if (transform.position == _targetPosition)
        {
            _isMoving = false;
        }
    }
}
