using UnityEngine;

public interface IItem
{
	public int Id { get; }
	public string Name { get; }
	public Sprite Sprite { get; }
}
