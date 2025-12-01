using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
	private Player player; // Ссылка на игрока
	public float detectionRange = 20f; // Радиус обнаружения
	public float attackRange = 1.5f; // Радиус атаки
	public float moveSpeed = 4f; // Скорость движения монстра
	public float attackCooldown = 1f; // Время между атаками
	public int damage = 25;
	private float lastAttackTime;

	private void Update()
	{
		if (player != null)
		{
			float distanceToTarget = Vector3.Distance(transform.position, player.transform.position);

			if (distanceToTarget <= detectionRange)
			{
				// Если игрок в пределах радиуса обнаружения, приближаемся к нему
				MoveTowardsPlayer(distanceToTarget);
			}
		}
	}

	public void SetTarget(Player player)
	{
		this.player = player;
	}

	private void MoveTowardsPlayer(float distanceToPlayer)
	{
		if (distanceToPlayer > attackRange)
		{
			// Двигаемся к игроку
			Vector3 direction = (player.transform.position - transform.position).normalized;
			transform.position += direction * moveSpeed * Time.deltaTime;
		}
		else if (distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown)
		{
			// Атакуем игрока
			AttackPlayer();
		}
	}

	private void AttackPlayer()
	{
		player.TakeDamage(damage);
		lastAttackTime = Time.time;
	}
}