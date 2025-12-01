using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemFactory/RandomItemFactory")]
public class RandomItemFactory : ItemFactory
{
	[SerializeField] private int spawnCount;

	protected override InventoryItemData GetData(List<Item> items)
	{
		return GetRandomItem(Items);
	}

	public InventoryItemData GetRandomItem(List<Item> items)
	{
		if (items.Count == 0)
		{
			Debug.LogWarning("Список itemPrefs пуст!");
			return null;
		}

		int index = UnityEngine.Random.Range(0, items.Count);
		InventoryItemData iiData = new InventoryItemData(items[index], spawnCount);
		return iiData;
	}
}