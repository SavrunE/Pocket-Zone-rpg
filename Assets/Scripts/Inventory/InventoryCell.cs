using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI countTMP;
	[SerializeField] private Image iconField;

	public void Render(IItem item)
	{
		countTMP.text = item.Name;
		iconField.sprite = item.Icon;
	}
}
