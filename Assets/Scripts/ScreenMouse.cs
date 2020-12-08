using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenMouse : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	public static Vector2 Axis { get; private set; }

	private Vector2 lastPressPos;

	public void OnDrag(PointerEventData eventData)
	{
		float magnitude = (eventData.position - lastPressPos).magnitude;
		Vector2 dir = (eventData.position - lastPressPos).normalized;

		if(magnitude <= 2)
		{
			Axis = Vector2.zero;
		}
		else
		{
			Axis = dir * magnitude / 20;
		}

		lastPressPos = eventData.position;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		lastPressPos = eventData.position;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		Axis = Vector2.zero;
	}
}
