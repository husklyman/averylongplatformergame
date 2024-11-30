using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons; // Array of level buttons
    [SerializeField] private Sprite lockedSprite;  // Sprite for locked levels

    private void Start()
    {
        if (!LevelUnlockManager.IsLevelUnlocked(1)) LevelUnlockManager.UnlockLevel(1);
        UpdateLevelButtons();
    }

    private void UpdateLevelButtons()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1; // Assuming levels are 1-indexed
            bool isUnlocked = LevelUnlockManager.IsLevelUnlocked(levelIndex);

            // Enable or disable button based on unlock status
            levelButtons[i].interactable = isUnlocked;

            // Update the button's sprite based on unlock status
            if (!isUnlocked)
            {
                levelButtons[i].GetComponent<Image>().sprite = lockedSprite;
            }
        }
    }
}
