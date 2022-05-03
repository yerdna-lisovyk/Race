using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    private bool _isMoving = false;
    private Vector3 _targetPosition;
    private float _speed = 0.5f;
    private Camera _camera;

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
        _targetPosition.z = transform.position.z;
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
