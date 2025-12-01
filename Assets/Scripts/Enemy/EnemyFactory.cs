using System;
using UnityEngine;

public abstract class EnemyFactory : GameObjectFactory
{
	[Serializable]
	public class EnemyConfig
	{
		[SerializeField] private Enemy prefab;
		[SerializeField, FloatRangeSlider(0.5f, 3f)]
		private FloatRange speed = new FloatRange(1f, 2f);
		[SerializeField] private int health = 100;

		public Enemy Prefab => prefab;
		public FloatRange Speed => speed;
		public int Health => health;
	}

	public Enemy Get(EnemyType type)
	{
		var config = GetConfig(type);
		Enemy instance = CreateGameObjectInstance(config.Prefab);
		instance.Init(config.Health, this);
		return instance;
	}

	protected abstract EnemyConfig GetConfig(EnemyType type);
}