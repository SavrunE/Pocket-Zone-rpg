using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> startItems = new List<Item>();
    [SerializeField] private InventoryCell inventoryCellTemplate;
    [SerializeField] private Transform container;
    private List<Item> inventoryItems = new List<Item>();
    public IReadOnlyList<Item> InventoryItems => inventoryItems.AsReadOnly();

    private void Awake()
    {
        for (int i = 0; i < startItems.Count; i++)
        {
            AddItem(startItems[i]);
        }
    }

	private void OnEnable()
	{
        Render(inventoryItems);
    }

    public void Render(List<Item> Items)
	{
        foreach (Transform con in container)
            Destroy(con.gameObject);

        Items.ForEach(item =>
        {
            InventoryCell cell = Instantiate(inventoryCellTemplate, container);
            cell.Render(item);
        });
	}

	private void AddItem(Item item)
    {
        inventoryItems.Add(item);
    }
}
