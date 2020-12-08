using UnityEngine;

public class OscilationAnimation : MonoBehaviour
{
	[SerializeField]
	private float amplitude = 0.01f;

	private float startPositionY = 0f;

	private void Start()
	{
		startPositionY = transform.position.y;
	}

	void Update()
	{
		Vector3 pos = transform.position;
		pos.y = startPositionY + Mathf.Sin(Time.time * 2 * Time.deltaTime) * amplitude;
		transform.position = pos;
	}
}
