using UnityEngine;

public class SaveGameUI : MonoBehaviour
{
    public void SaveCurrentProgress()
    {
        if (SaveGameManager.Instance == null)
        {
            Debug.LogWarning("SaveGameManager instance not found.");
            return;
        }

        SaveGameManager.Instance.SaveGame();
    }

    public void LoadSavedProgress()
    {
        if (SaveGameManager.Instance == null)
        {
            Debug.LogWarning("SaveGameManager instance not found.");
            return;
        }

        SaveGameManager.Instance.LoadGame();
    }
}
