using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WorldItem : MonoBehaviour
{
	private InventoryItemData data;
	private SpriteRenderer sr;
	
	public void Init(InventoryItemData iiData)
	{
		sr = GetComponent<SpriteRenderer>();
		data = iiData;
		sr.sprite = data.Sprite;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			other.GetComponent<Player>().TakeItem(data);
			Destroy(this.gameObject);
		}
	}
}
