using UnityEngine;

[RequireComponent(typeof(WorldItem))]
public class initWorldItem : MonoBehaviour
{
	[SerializeField] private Item item;
	[SerializeField] private int count;

	private void OnEnable()
	{
		GetComponent<WorldItem>().Init(new InventoryItemData(item, count));
	}
}
