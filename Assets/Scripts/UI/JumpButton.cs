using UnityEngine.EventSystems;
public class JumpButton : UIButtonController, IPointerDownHandler
{
	public static bool Jump { get; private set; } = false;

	protected override void AwakeChild()
	{
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
		//transform.parent.gameObject.SetActive(false);
#endif
	}

	private void LateUpdate()
	{
		Jump = false;
	}

	public new void OnPointerDown(PointerEventData data)
	{
		base.OnPointerDown(data);
		Jump = true;
	}
}
