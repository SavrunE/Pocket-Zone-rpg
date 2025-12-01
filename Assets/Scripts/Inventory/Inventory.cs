using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	private Dictionary<int, InventoryItemData> inventoryItems = new Dictionary<int, InventoryItemData>();
	private List<IInventoryObserver> observers = new List<IInventoryObserver>();

	public void AddItem(InventoryItemData iidata)
	{
		if (iidata.Count < 1)
		{
			throw new System.ArgumentException("Value cannot be negative or 0");
		}
		if (inventoryItems.ContainsKey(iidata.Id))
		{
			iidata.Count = iidata.Count + inventoryItems[iidata.Id].Count;
			inventoryItems[iidata.Id] = iidata;
		}
		else
			inventoryItems.Add(iidata.Id, iidata);
		NotifyObservers();
	}

	public void DeleteItem(int itemId)
	{
		if (inventoryItems.ContainsKey(itemId))
		{
			Debug.Log(inventoryItems[itemId] + "is deleted");
			inventoryItems.Remove(itemId);
		}
		else
		{
			Debug.LogWarning($"Item with ID {itemId} not found in inventory.");
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
			observer.OnInventoryChange();
		}
	}
}
