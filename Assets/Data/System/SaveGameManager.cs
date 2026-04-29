using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGameManager : ZennyMonoBehavior
{
    public static SaveGameManager Instance { get; private set; }

    [Header("Save Settings")]
    [SerializeField] protected string saveFileName = "savegame.json";
    [SerializeField] protected bool autoLoadOnStart = false;
    [SerializeField] protected bool autoSaveOnQuit = false;

    public string SavePath => Path.Combine(Application.persistentDataPath, saveFileName);

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Multiple SaveGameManager instances found. Destroying duplicate.", gameObject);
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    protected override void Start()
    {
        base.Start();
        if (autoLoadOnStart)
        {
            LoadGame();
        }
    }

    protected virtual void OnApplicationQuit()
    {
        if (autoSaveOnQuit)
        {
            SaveGame();
        }
    }

    public bool HasSaveFile()
    {
        return File.Exists(SavePath);
    }

    public void SaveGame()
    {
        SaveData saveData = CollectSaveData();
        try
        {
            string json = JsonUtility.ToJson(saveData, true);
            File.WriteAllText(SavePath, json);
            Debug.Log($"Game saved to: {SavePath}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to save game: {ex.Message}");
        }
    }

    public void LoadGame()
    {
        if (!HasSaveFile())
        {
            Debug.LogWarning("No save file found to load.");
            return;
        }

        try
        {
            string json = File.ReadAllText(SavePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            ApplySaveData(saveData);
            Debug.Log($"Game loaded from: {SavePath}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to load game: {ex.Message}");
        }
    }

    protected virtual SaveData CollectSaveData()
    {
        SaveData saveData = new SaveData
        {
            sceneName = SceneManager.GetActiveScene().name,
            playerPosition = GetPlayerPosition(),
            playerHP = GetPlayerCurrentHP(),
            playerMaxHP = GetPlayerMaxHP(),
            inventoryItems = GetInventoryItems()
        };

        return saveData;
    }

    protected virtual void ApplySaveData(SaveData saveData)
    {
        if (saveData == null)
        {
            Debug.LogWarning("Save data is empty.");
            return;
        }

        SetPlayerPosition(saveData.playerPosition);
        SetPlayerHealth(saveData.playerHP);
        SetInventoryItems(saveData.inventoryItems);
    }

    protected virtual Vector3 GetPlayerPosition()
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        if (playerMovement == null) return Vector3.zero;

        Transform movingTransform = playerMovement.transform.parent != null ? playerMovement.transform.parent : playerMovement.transform;
        return movingTransform.position;
    }

    protected virtual void SetPlayerPosition(Vector3 position)
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        if (playerMovement == null) return;

        Transform movingTransform = playerMovement.transform.parent != null ? playerMovement.transform.parent : playerMovement.transform;
        movingTransform.position = position;
    }

    protected virtual float GetPlayerCurrentHP()
    {
        PlayerDameReceiver playerHP = FindObjectOfType<PlayerDameReceiver>();
        return playerHP != null ? playerHP.CurrentHP : 0f;
    }

    protected virtual float GetPlayerMaxHP()
    {
        PlayerDameReceiver playerHP = FindObjectOfType<PlayerDameReceiver>();
        return playerHP != null ? playerHP.MaxHP : 0f;
    }

    protected virtual void SetPlayerHealth(float currentHP)
    {
        PlayerDameReceiver playerHP = FindObjectOfType<PlayerDameReceiver>();
        if (playerHP != null)
        {
            playerHP.SetCurrentHP(currentHP);
        }
    }

    protected virtual List<SaveItem> GetInventoryItems()
    {
        List<SaveItem> items = new List<SaveItem>();
        Inventory inventory = FindObjectOfType<Inventory>();
        if (inventory == null) return items;

        foreach (ItemInventory itemInventory in inventory.GetAllItems())
        {
            if (itemInventory == null) continue;
            if (itemInventory.itemProfile == null) continue;
            if (itemInventory.itemCount <= 0) continue;

            items.Add(new SaveItem
            {
                itemCode = itemInventory.itemProfile.itemCode,
                count = itemInventory.itemCount
            });
        }

        return items;
    }

    protected virtual void SetInventoryItems(List<SaveItem> items)
    {
        Inventory inventory = FindObjectOfType<Inventory>();
        if (inventory == null || items == null) return;

        foreach (SaveItem item in items)
        {
            ItemInventory itemInventory = inventory.GetItemByCode(item.itemCode);
            if (itemInventory != null)
            {
                itemInventory.itemCount = item.count;
            }
        }
    }
}

[Serializable]
public class SaveData
{
    public string sceneName;
    public Vector3 playerPosition;
    public float playerHP;
    public float playerMaxHP;
    public List<SaveItem> inventoryItems;
}

[Serializable]
public class SaveItem
{
    public ItemCode itemCode;
    public int count;
}
