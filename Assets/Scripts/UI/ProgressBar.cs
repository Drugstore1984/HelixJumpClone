using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _progressBar;
    [SerializeField] private Transform _finishPlatform;
    private float _startY;
    private float _finishY;
    private float _minimumReachedY;
    [SerializeField] private float _offsetFinishPlatform = 1f;
    [SerializeField] private float _offsetStartPlatform = 1f;
    private void Awake()
    {


    }
    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _finishPlatform = FindObjectOfType<FinishPlatform>().transform;

        _startY = _player.transform.position.y - _offsetStartPlatform;
        _finishY = _finishPlatform.transform.position.y + _offsetFinishPlatform;
    }
    private void Update()
    {
         _minimumReachedY = Mathf.Min(_minimumReachedY, _player.transform.position.y);
        float t = Mathf.InverseLerp(_startY, _finishY, _minimumReachedY);
        _progressBar.value = t;
    }
}
