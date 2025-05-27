using UnityEngine;

public static class LevelSaveData
{
    private const string Key = "SceneName";
    private const string KeyLevelIndex = "LEvelIndex";

    public static void SetName(string name)
    {
        PlayerPrefs.SetString(Key, name);
        PlayerPrefs.Save();
    }

    public static string GetName()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            return PlayerPrefs.GetString(Key);
        }
        return null;
    }

    public static void SetLevelIndex(int levelIndex)
    {
        PlayerPrefs.SetInt(KeyLevelIndex, levelIndex);
        PlayerPrefs.Save();
    }

    public static int GetLevelIndex()
    {
        if (PlayerPrefs.HasKey(KeyLevelIndex))
        {
            return PlayerPrefs.GetInt(KeyLevelIndex);
        }
        return 0;
    }
}
