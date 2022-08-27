using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    private const string LevelConstKey = "LevelIndex";

    public void SetLevelIndex(int index)
    {
        PlayerPrefs.SetInt(LevelConstKey, index);
    }
    public int GetLevelIndex()
    {
        return PlayerPrefs.GetInt(LevelConstKey, 0);
    }
}
