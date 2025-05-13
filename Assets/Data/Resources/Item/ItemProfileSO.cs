using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfile", menuName = "ScriptableObjects/ItemProfileSO")]
public class ItemProfileSO : ScriptableObject
    {
        public ItemCode itemCode = ItemCode.NoItem;
    public ItemType itemType = ItemType.NoType;
    public string itemName = "No name";
    public int defaultMaxStack = 7;
}
