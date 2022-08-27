using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _platformToCameraOffset;
    [SerializeField] private float _speed;

    private void Update()
    {
        if (_player.CurrentPlatform == null) return;
        Vector3 targetPosition = _player.CurrentPlatform.transform.position - _platformToCameraOffset;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }
}
