using System;
using System.Collections;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
	[SerializeField] private ItemFactory factory;
	[SerializeField] private Transform parent;

    private static ItemsSpawner instance;

    public static ItemsSpawner Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ItemsSpawner>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
            throw new NotImplementedException();
        instance = this;
    }

    public void SpawnItem(Vector3 pos)
	{
		WorldItem item = factory.Get();
		item.transform.parent = parent.transform;
		item.transform.position = pos;
	}
}
