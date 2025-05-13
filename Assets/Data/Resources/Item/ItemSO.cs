using System.Collections;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/ItemSO")]

public class ItemSO : ScriptableObject
    {
    public ItemCode itemCode ;
    public string itemName = "Item";

}
