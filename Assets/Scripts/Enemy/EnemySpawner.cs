using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private EnemyFactory factory;
	[SerializeField] private GameObject enemyParrent;
	[SerializeField] private Player player;
	[SerializeField] private int totalEnemy = 3;
	private int currentEnemyCount = 0;
	[SerializeField] private float spawnDelay = 1f;
	[SerializeField] private float minDistance = 20f;
	[SerializeField] private float maxDistance = 20f;

	private void Start()
	{
		StartCoroutine(Spawner());
	}

	private IEnumerator Spawner()
	{
		while (currentEnemyCount < totalEnemy)
		{
			currentEnemyCount++;
			SpawnEnemy();
			yield return new WaitForSeconds(spawnDelay);
		}
	}

	private void SpawnEnemy()
	{
		Enemy enemy = factory.Get(GetRandomEnemyType());
		enemy.transform.parent = enemyParrent.transform;
		enemy.SpawnOn(TakeEnemyPos());
		enemy.SetTarget(player);
	}

	private EnemyType GetRandomEnemyType()
	{
		// Получаем все значения перечисления EnemyType
		EnemyType[] enemyTypes = (EnemyType[])System.Enum.GetValues(typeof(EnemyType));
		// Выбираем случайный индекс
		int randomIndex = Random.Range(0, enemyTypes.Length);
		// Возвращаем случайный тип врага
		return enemyTypes[randomIndex];
	}

	private Vector3 TakeEnemyPos()
	{
		// Вычисляем случайный угол
		float randomAngle = Random.Range(0f, 360f);
		// Вычисляем случайное расстояние от игрока
		float randomDistance = Random.Range(minDistance, maxDistance);

		// Вычисляем координаты спавна относительно игрока
		Vector3 spawnPosition = player.transform.position + new Vector3(
			Mathf.Cos(randomAngle * Mathf.Deg2Rad) * randomDistance,
			Mathf.Sin(randomAngle * Mathf.Deg2Rad) * randomDistance,
			0);
		return spawnPosition;
	}
}
