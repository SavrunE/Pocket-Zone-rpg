using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI countTMP;
	[SerializeField] private Image iconField;
	private Inventory inventory;
	private int itemId;

	public void Render(Sprite sprite, int count)
	{
		iconField.sprite = sprite;
		if (count <= 1)
			countTMP.text = "";
		else
			countTMP.text = count.ToString();
	}

	public void Initialize(Inventory inventory, int itemId)
	{
		this.inventory = inventory;
		this.itemId = itemId;
	}

	public void DeleteThis()
	{
		inventory.DeleteItem(itemId);
	}
}
