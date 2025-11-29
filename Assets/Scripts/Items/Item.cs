using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item")]
public class Item : ScriptableObject, IItem
{
	public int Id => itemId;
	public string Name => itemName;
	public Sprite Sprite => sprite;

	[SerializeField] private int itemId;
	[SerializeField] private string itemName = "Item";
	[SerializeField] private Sprite sprite;
}