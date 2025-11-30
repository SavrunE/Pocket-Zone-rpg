using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;

    private Transform thisT;

	private void Awake()
	{
        thisT = gameObject.transform;

    }
	public void Update()
    {
        float vx = variableJoystick.Horizontal;
        float vy = variableJoystick.Vertical;

        transform.position += new Vector3(vx, vy, 0f) * speed * Time.deltaTime;
    }
}