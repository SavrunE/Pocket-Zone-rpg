using System.Collections.Generic;
using UnityEngine;

public abstract class ItemFactory : GameObjectFactory
{
	[SerializeField] protected List<Item> Items;
	[SerializeField] private WorldItem prefab;

	public WorldItem Prefab => prefab;


	public WorldItem Get()
	{
		var config = GetData(Items);
		WorldItem instance = CreateGameObjectInstance(prefab);
		instance.Init(config);
		return instance;
	}

	protected abstract InventoryItemData GetData(List<Item> items);
}