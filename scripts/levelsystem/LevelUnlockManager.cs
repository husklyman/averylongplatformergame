using System.Collections.Generic;
using UnityEngine;

public static class LevelUnlockManager
{
    private static Dictionary<int, bool> levelUnlocked = new Dictionary<int, bool>();

    private const string PrefKey = "levelunlocked_";

    public static void UnlockLevel(int levelIndex)
    {
        if (!levelUnlocked.ContainsKey(levelIndex))
        {
            levelUnlocked.Add(levelIndex, true);
        }
        else
        {
            levelUnlocked[levelIndex] = true;
        }

        PlayerPrefs.SetInt(PrefKey + levelIndex, 1);
        PlayerPrefs.Save();
    }

    public static bool IsLevelUnlocked(int levelIndex)
    {
        if (!levelUnlocked.ContainsKey(levelIndex))
        {
            levelUnlocked[levelIndex] = PlayerPrefs.GetInt(PrefKey + levelIndex, 0) == 1;
        }

        return levelUnlocked[levelIndex];
    }
}
