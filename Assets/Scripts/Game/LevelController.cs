using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelsList _levelsList;
    private SaveLoadSystem _saveLoadSystem;
    private int _currentLevel;
    private void Awake()
    {
        _saveLoadSystem = GetComponent<SaveLoadSystem>();
        _currentLevel = _saveLoadSystem.GetLevelIndex();
        Debug.Log(_currentLevel);
        _currentLevel %= _levelsList.levels.Length;
        Debug.Log(_currentLevel);
        Instantiate(_levelsList.levels[_currentLevel]);
    }
    public void LoadNextLevel()
    {
        _currentLevel++;
        _saveLoadSystem.SetLevelIndex(_currentLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
