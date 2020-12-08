using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : UIButtonController, IPointerUpHandler, IDragHandler
{
	private float maxRange;

	[SerializeField]
	private float dead = 0.01f;

	[SerializeField]
	private float alive = 0.99f;

	private RectTransform rectTrans;

	public static float HorizontalAxis { get; private set; }
	public static float VerticalAxis { get; private set; }

	protected override void AwakeChild()
	{
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
		//transform.parent.gameObject.SetActive(false);
#endif
		rectTrans = GetComponent<RectTransform>();
		rectTrans.anchorMax = rectTrans.anchorMin = rectTrans.pivot = new Vector2(0.5f, 0.5f);
		maxRange = rectTrans.sizeDelta.x / 2;
	}


	void Update()
	{
		UpdateVirtualAxes(rectTrans.anchoredPosition);
	}

	public void OnDrag(PointerEventData data)
	{
		Vector2 delta = data.position - data.pressPosition;
		rectTrans.anchoredPosition = Vector2.ClampMagnitude(delta, maxRange);
	}

	void UpdateVirtualAxes(Vector2 axis)
	{
		HorizontalAxis = Mathf.Clamp(axis.x / maxRange, -1, 1);
		VerticalAxis = Mathf.Clamp(axis.y / maxRange, -1, 1);

		HorizontalAxis = Mathf.Abs(HorizontalAxis) < dead ? 0 : HorizontalAxis;
		VerticalAxis = Mathf.Abs(VerticalAxis) < dead ? 0 : VerticalAxis;

		HorizontalAxis = Mathf.Abs(HorizontalAxis) > alive ? 1 * Mathf.Sign(HorizontalAxis) : HorizontalAxis;
		VerticalAxis = Mathf.Abs(VerticalAxis) > alive ? 1 * Mathf.Sign(VerticalAxis) : VerticalAxis;
	}

	public new void OnPointerUp(PointerEventData data)
	{
		base.OnPointerUp(data);
		rectTrans.anchoredPosition = Vector2.zero;
	}
}