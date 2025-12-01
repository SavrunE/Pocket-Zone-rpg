using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; // Префаб снаряда
    [SerializeField] private Transform firePoint; // Точка, откуда будет происходить выстрел
    [SerializeField] private int playerDamage = 50; // Точка, откуда будет происходить выстрел
    [SerializeField] private float projectileSpeed = 10f; // Скорость снаряда
    [SerializeField] private float detectionRadius = 5f; // Радиус обнаружения врагов

    private Enemy closestEnemy;

    public void ShootAtClosestEnemy()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        float closestDistance = Mathf.Infinity;

        foreach (Collider2D enemy in enemiesInRange)
        {
            if (enemy.CompareTag("Enemy")) // Проверяем, что это враг
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy.GetComponent<Enemy>();
                }
            }
        }

        if (closestEnemy != null)
        {
            // Вычисляем направление на врага
            Vector2 direction = (closestEnemy.transform.position - transform.position).normalized;
            Shoot(direction, closestEnemy.transform.position);
        }
        else
        {
            // Обработка случая, когда врагов нет в радиусе
            Debug.Log("Нет врагов в радиусе обнаружения."); // Выводим сообщение в консоль
        }
    }

    private void Shoot(Vector2 direction, Vector2 targetPosition)
    {
        // Создаем снаряд
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Запускаем корутину для движения и уничтожения снаряда
        StartCoroutine(MoveProjectile(projectile, targetPosition));
    }

    private IEnumerator MoveProjectile(GameObject projectile, Vector2 targetPosition)
    {
        float journeyLength = Vector2.Distance(projectile.transform.position, targetPosition);
        float startTime = Time.time;
        float journeyDuration = journeyLength / projectileSpeed; // Время для полного пути

        while (true)
        {
            float distanceCovered = (Time.time - startTime) * projectileSpeed;

            // Рассчитываем процент пути к цели
            float percentageComplete = distanceCovered / journeyLength;

            // Если снаряд прошел 95% пути, уничтожаем его
            if (percentageComplete >= 0.7f)
            {
                Destroy(projectile);
				if (closestEnemy!= null)
				{
                    closestEnemy.TakeDamage(playerDamage);
                }
                yield break; // Выход из корутины
            }

            // Перемещаем снаряд с помощью Lerp
            projectile.transform.position = Vector2.Lerp(projectile.transform.position, targetPosition, percentageComplete);
            yield return null; // Ждем следующего кадра
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius); // Отображение радиуса обнаружения
    }
}
