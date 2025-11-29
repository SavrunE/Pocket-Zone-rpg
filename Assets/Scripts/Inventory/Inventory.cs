using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField] private List<Item> startItems = new List<Item>();
	[SerializeField] private Item Empty;

	private Dictionary<int, InventoryItemData> inventoryItems = new Dictionary<int, InventoryItemData>();
	private List<IInventoryObserver> observers = new List<IInventoryObserver>();

	private void Awake()
	{
		for (int i = 0; i < startItems.Count; i++)
		{
			AddItem(new InventoryItemData(startItems[i].Id, startItems[i].Name, startItems[i].Sprite, 1));
		}
	}

	private void AddItem(InventoryItemData iidata)
	{
		if (iidata.Count < 1)
		{
			throw new System.ArgumentException("Value cannot be negative or 0");
		}
		if (inventoryItems.ContainsKey(iidata.Id))
		{
			iidata.Count = iidata.Count + inventoryItems.Count;
			inventoryItems[iidata.Id] = iidata;
		}
		else
			inventoryItems.Add(iidata.Id, iidata);
	}

	public void DeleteItem(int itemId)
	{
		if (inventoryItems.ContainsKey(itemId))
		{
			inventoryItems.Remove(itemId);
		}
		NotifyObservers();
	}

	public void OpenInventory()
	{
		NotifyObservers();
	}

	public Dictionary<int, InventoryItemData> GetInventoryItems()
	{
		return inventoryItems;
	}

	public void RegisterObserver(IInventoryObserver observer)
	{
		observers.Add(observer);
	}

	public void UnregisterObserver(IInventoryObserver observer)
	{
		observers.Remove(observer);
	}

	private void NotifyObservers()
	{
		foreach (var observer in observers)
		{
			observer.OnInventoryOpen();
		}
	}
}
