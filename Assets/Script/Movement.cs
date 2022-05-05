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

        _targetPosition.z = position.z;
        Debug.Log(_targetPosition);
        if (_arrowNow != null)
        {
            Destroy(_arrowNow);
        }
        _arrowNow =  Instantiate(_arrow, position, Quaternion.identity);
        _arrowNow.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(_targetPosition.y - transform.position.y, _targetPosition.x - transform.position.x) * Mathf.Rad2Deg - 90);
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
