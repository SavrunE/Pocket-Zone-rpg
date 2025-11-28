using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item")]
public class Item : ScriptableObject, IItem
{
	string IItem.Name => name;
	Sprite IItem.Icon => icon;

	[SerializeField] private string name = "Item";
	[SerializeField] private Sprite icon;
}
