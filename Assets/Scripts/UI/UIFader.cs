using UnityEngine;

public class UIFader : MonoBehaviour
{
	[SerializeField]
	private float speed = 1;

	private CanvasRenderer canvasRenderer;

	private float startTime;

	private void Awake()
	{
		canvasRenderer = GetComponent<CanvasRenderer>();
	}

	private void OnEnable()
	{
		startTime = Time.time;
		canvasRenderer.SetAlpha(1);
	}

	void Update()
	{
		if(Time.time > startTime + 3)
		{
			canvasRenderer.SetAlpha(canvasRenderer.GetAlpha() - Time.deltaTime * speed);
		}

		if(canvasRenderer.GetAlpha() <= 0)
		{
			gameObject.SetActive(false);
		}
	}
}
