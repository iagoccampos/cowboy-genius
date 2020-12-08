using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UIButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private Image image;
	private CanvasRenderer render;

	private void Awake()
	{
		render = GetComponent<CanvasRenderer>();
		render.SetAlpha(0.5f);

		AwakeChild();
	}

	protected virtual void AwakeChild() { }

	public void OnPointerDown(PointerEventData eventData)
	{
		render.SetAlpha(1f);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		render.SetAlpha(0.5f);
	}
}
