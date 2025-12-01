using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
	public List<InventoryItemData> inventoryItems;
}

public class DataManager : MonoBehaviour, IInventoryObserver
{
	[SerializeField] private Inventory inventory;
	private string filePath;

	void Start()
	{
		inventory.RegisterObserver(this);
		filePath = Path.Combine(Application.persistentDataPath, "playerData.json");
		LoadData();
	}

	public void OnInventoryChange()
	{
		PlayerData data = new PlayerData();
		List<InventoryItemData> iidata = new List<InventoryItemData>();
		var dicData = inventory.GetInventoryItems();
		if (dicData.Count != 0)
		{
			foreach (var item in dicData)
			{
				iidata.Add(item.Value);
			}
		}
		data.inventoryItems = iidata;
		SaveData(data);
	}

	public void SaveData(PlayerData data)
	{
		string json = JsonUtility.ToJson(data);
		File.WriteAllText(filePath, json);
	}

	public PlayerData LoadData()
	{
		if (File.Exists(filePath))
		{
			string json = File.ReadAllText(filePath);
			PlayerData data = JsonUtility.FromJson<PlayerData>(json);

			// Обновляем инвентарь из загруженных данных
			foreach (var item in data.inventoryItems)
			{
				inventory.AddItem(item);
			}

			return data;
		}
		return null; // Или вернуть новые данные по умолчанию
	}
}