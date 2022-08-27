using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Controls _controls;
    [SerializeField] private GameObject _deathMenu;
    [SerializeField] private GameObject _wonMenu;
    private void Start()
    {
        _controls = FindObjectOfType<Controls>();
    }
    public enum State
    {
        Playing,
        Won,
        Loss
    }
    public State CurrentState { get; private set; }
    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        _controls.enabled = false;
        _deathMenu.SetActive(true);
    }
    public void OnPlayerFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        _controls.enabled = false;
        _wonMenu.SetActive(true);
    }
}
