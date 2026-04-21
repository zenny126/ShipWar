using UnityEngine;
using TMPro; // nếu bạn dùng TextMeshPro

public class IronScore : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private TextMeshProUGUI ironOreText;

    private void Update()
    {

        // Lấy số lượng IronOre
        var ironOre = inventory.GetItemByCode(ItemCode.IronOre);
        if (ironOre != null)
            ironOreText.text = $"Iron Ore: {ironOre.itemCount}";
    }
}