using UnityEngine;
using CM.HealthSystem;

public class Enemy : MonoBehaviour, IGetHealthSystem
{
    [SerializeField] private int maxHealth = 100;
    private HealthSystem healthSystem;

	private void Awake()
	{
        healthSystem = new HealthSystem(maxHealth);

        healthSystem.OnDead += Dead;
    }

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile")) // Проверяем, что это снаряд
        {
            Destroy(gameObject); // Уничтожаем врага
            Destroy(collision.gameObject); // Уничтожаем снаряд
        }
    }

    public void TakeDamage(int damage)
	{
        healthSystem.Damage(damage);
	}

    public void Dead(object sender, System.EventArgs e)
	{
        Destroy(this.gameObject);
    }

	public HealthSystem GetHealthSystem()
	{
        return healthSystem;
	}
}