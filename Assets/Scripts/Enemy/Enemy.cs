using UnityEngine;
using CM.HealthSystem;

[RequireComponent(typeof(EnemyAttacker))]
public class Enemy : MonoBehaviour, IGetHealthSystem
{
    private EnemyAttacker enemyAttacker;
    private EnemyFactory originFactory;
    private HealthSystem healthSystem;

    private void SetHealthSystem(int health)
	{
        healthSystem = new HealthSystem(health);

        healthSystem.OnDead += Dead;
    }

    public void SetTarget(Player target)
	{
        enemyAttacker = gameObject.GetComponent<EnemyAttacker>();
        enemyAttacker.SetTarget(target);
    }

    public void Init(int health, EnemyFactory fact)
    {
        SetHealthSystem(health);
        originFactory = fact;
    }

    public void TakeDamage(int damage)
	{
        healthSystem.Damage(damage);
	}

    public void Dead(object sender, System.EventArgs e)
    {
        ItemsSpawner.Instance.SpawnItem(this.transform.position);
		Destroy(this.gameObject);
	}

    public void SpawnOn(Vector3 pos)
    {
        transform.localPosition = pos;
    }

    public HealthSystem GetHealthSystem()
	{
        return healthSystem;
	}
}