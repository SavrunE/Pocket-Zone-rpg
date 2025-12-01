using UnityEngine;

[System.Serializable]
public class InventoryItemData
{
    public int Id;
    public string Name;
    public Sprite Sprite;
    public int Count;

    public InventoryItemData(int id, string name, Sprite sprite, int count)
    {
        this.Id = id;
        this.Name = name;
        this.Sprite = sprite;
        this.Count = count;
    }

    public InventoryItemData(Item item, int count)
	{
        this.Id = item.Id;
        this.Name = item.Name;
        this.Sprite = item.Sprite;
        this.Count = count;
    }
}