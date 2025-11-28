using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private Inventory targetInventory;
    [SerializeField] private RectTransform itemsPanel;

    private void Start()
    {
        Redraw();
    }

    private void Redraw()
    {
        for (int i = 0; i < targetInventory.InventoryItems.Count; i++)
        {
            var item = targetInventory.InventoryItems[i];

            GameObject buttonObject = new GameObject("ItemButton");
            Button button = buttonObject.AddComponent<Button>();
            button.targetGraphic = buttonObject.AddComponent<UnityEngine.UI.Image>();
            button.targetGraphic.color = Color.white;
        }
    }
}
