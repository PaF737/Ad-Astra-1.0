using UnityEngine;

public class LevelNameData
{


    private const string Key = "SceneName";
    private const string KeyLevelIndex = "LEvelIndex";

    public void SetName(string name)
    {
        PlayerPrefs.SetString(Key, name);
        PlayerPrefs.Save();
    }

    public string GetName()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            return PlayerPrefs.GetString(Key);
        }
        return null;
    }

    public void SetLevelIndex(int levelIndex)
    {
        PlayerPrefs.SetInt(KeyLevelIndex, levelIndex);
        PlayerPrefs.Save();
    }

    public int GetLevelIndex()
    {
        if (PlayerPrefs.HasKey(KeyLevelIndex))
        {
            return PlayerPrefs.GetInt(KeyLevelIndex);
        }
        return 0;
    }
}
