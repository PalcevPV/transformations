using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 5f;

    void Update()
    {
        transform.Rotate(Vector3.up *  _rotationSpeed * Time.deltaTime);
    }
}
