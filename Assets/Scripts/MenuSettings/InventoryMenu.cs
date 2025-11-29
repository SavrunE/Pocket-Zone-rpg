using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class InventoryMenu : MonoBehaviour, IInventoryObserver
{
	[SerializeField] private InventoryCell inventoryCellTemplate;
	[SerializeField] private Transform container;

	private Inventory inventory;

	private void Start()
	{
		inventory = GetComponent<Inventory>();
		inventory.RegisterObserver(this);
	}

	public void OnInventoryOpen()
	{
		MenuManager.Instance.OpenInventoryMenu();
		Render();
	}

	public void CloceInventory()
	{
		MenuManager.Instance.CloseInventoryMeny();
	}

	public void Render()
	{
		foreach (Transform con in container)
			Destroy(con.gameObject);

		Dictionary<int, InventoryItemData> itemsData = inventory.GetInventoryItems();
		
		foreach (var item in itemsData)
		{
			int itemId = item.Key;
			InventoryItemData itemData = item.Value;
			InventoryCell cell = Instantiate(inventoryCellTemplate, container);
			cell.Render(itemData.Sprite, itemData.Count);
			cell.Initialize(inventory, itemId);
		}
	}
}
