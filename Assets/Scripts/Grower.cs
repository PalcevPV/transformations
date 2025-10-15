using UnityEngine;

public class Grower : MonoBehaviour
{
    [SerializeField] private float _scaleSpeed = 1f;
    [SerializeField] private float _scaleAmount = 1f;

    private Vector3 _baseScale;
    private Vector3 _targetScale;
    private bool _isGrow = true;
    private float _scaleThresholdSqr = 0.0001f;

    private void Start()
    {
        _baseScale = transform.localScale;
        _targetScale = _baseScale + Vector3.one * _scaleAmount;
    }

    private void Update()
    {
        if (_isGrow)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, _targetScale, _scaleSpeed * Time.deltaTime);

            if (IsAtTargetScale(_targetScale))
            {
                _isGrow = false;
            }
        }
        else
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, _baseScale, _scaleSpeed * Time.deltaTime);

            if (IsAtTargetScale(_baseScale))
            {
                _isGrow = true;
            }
        }
    }

    private bool IsAtTargetScale(Vector3 target)
    {
        return (transform.position - target).sqrMagnitude < _scaleThresholdSqr;
    }
}