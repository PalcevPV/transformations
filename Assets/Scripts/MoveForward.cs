using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float _moveDistance = 5f;
    [SerializeField] private float _moveSpeed = 5f;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private bool _isMoving = true;

    private void Start()
    {
        _startPosition = transform.position;
        _targetPosition = _startPosition + Vector3.forward * _moveDistance;
    }

    private void Update()
    {
        if (_isMoving)
        {
            transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _targetPosition) < 0.05f)
            {
                _isMoving = false;
            }
        }
        else
        {
            transform.Translate(Vector3.back * _moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _startPosition) < 0.05f)
            {
                _isMoving = true;
            }
        }
    }
}