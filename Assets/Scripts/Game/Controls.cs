using UnityEngine;

public class Controls : MonoBehaviour
{
    [SerializeField] float _sensetivity;
    private Transform _levelTransform;
    private Vector3 _previousMousePosition;
    private void Start()
    {
        _levelTransform = gameObject.GetComponent<Transform>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            _levelTransform.Rotate(0, -delta.x * _sensetivity, 0);
        }
        _previousMousePosition = Input.mousePosition;
    }

}
