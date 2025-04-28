using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int levelIndex; // 0 = First Period, 1 = Second, 2 = Third
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();

        // Check if this level is unlocked
        if (IsLevelUnlocked(levelIndex))
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }

        button.onClick.AddListener(() => OnLevelSelected());
    }

    bool IsLevelUnlocked(int index)
    {
        // Level 0 is always unlocked
        if (index == 0) return true;

        // PlayerPrefs key example: "level_1_unlocked"
        return PlayerPrefs.GetInt("level_" + index + "_unlocked", 0) == 1;
    }

    void OnLevelSelected()
    {
        Debug.Log($"Level {levelIndex} selected");

        // Example: unlock next level (for testing progression)
        int nextLevel = levelIndex + 1;
        if (nextLevel <= 2)
        {
            PlayerPrefs.SetInt("level_" + nextLevel + "_unlocked", 1);
            PlayerPrefs.Save();
        }
    }
}
