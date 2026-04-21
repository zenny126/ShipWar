using UnityEngine;
using TMPro; // nếu bạn dùng TextMeshPro

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private TextMeshProUGUI goldOreText;

    private void Update()
    {
        

        // Lấy số lượng GoldOre
        var goldOre = inventory.GetItemByCode(ItemCode.GoldOre);
        if (goldOre != null)
            goldOreText.text = $"Gold Ore: {goldOre.itemCount}";
    }
}
