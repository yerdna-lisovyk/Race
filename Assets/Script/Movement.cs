using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    private bool _isMoving = false;
    private Vector3 _targetPosition;
    private float _speed = 0.5f;
    private Camera _camera;
    private GameObject _arrowNow=null;
        
    [SerializeField] private GameObject _arrow = null;

    public void SetIsMoving(bool isMoving)
    {
        _isMoving = isMoving;
    }
    private void Start()
    {
        _camera = Camera.main;

    }

    public void StartMove()
    {
        StartCoroutine(Move());
    }
    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }
    }

    private void SetTargetPosition()
    {
        if (_camera is { }) _targetPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        var position = transform.position;
        if (_arrowNow != null)
        {
            Destroy(_arrowNow);
        }
        _arrowNow =  Instantiate(_arrow, position, Quaternion.identity);
        var p = Vector3.SignedAngle(_targetPosition - position, transform.forward, Vector3.up);
        Debug.Log(p);
        _arrowNow.transform.Rotate(new Vector3(0,0,p));
        _isMoving = true;
    }

    private IEnumerator Move()
    {
        while (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            yield return null;
        }
        _isMoving = false;
    }
}
