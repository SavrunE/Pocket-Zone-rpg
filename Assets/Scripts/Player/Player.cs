using CM.HealthSystem;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IGetHealthSystem
{
	[SerializeField] private Inventory inventory;
	private HealthSystem healthSystem;

	private void SetHealthSystem(int health)
	{
		healthSystem = new HealthSystem(health);

		healthSystem.OnDead += Dead;
	}

	private void Awake()
	{
		SetHealthSystem(100);
	}

	public void TakeItem(InventoryItemData iidata)
	{
		inventory.AddItem(iidata);
	}

	public void TakeDamage(int dmg)
	{
		if (dmg < 1)
		{
			Debug.Log("create functional to heal if u need this");
		}
		else
		{
			healthSystem.Damage(dmg);
		}
	}

	public void Dead(object sender, System.EventArgs e)
	{
		Debug.Log("die");
	}

	public HealthSystem GetHealthSystem()
	{
		return healthSystem;
	}
}
