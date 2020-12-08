using UnityEngine;

public class InputManager : MonoBehaviour
{
	public static bool jump { get; private set; }

	public static float horizontalAxis { get; private set; }
	public static float verticalAxis { get; private set; }

	public static float horizontalLook { get; private set; }
	public static float verticalLook { get; private set; }

	private void Update()
	{
#if UNITY_ANDROID

		jump = JumpButton.Jump;
		horizontalAxis = Joystick.HorizontalAxis;
		verticalAxis = Joystick.VerticalAxis;

#endif

#if UNITY_EDITOR || UNITY_STANDALONE_WIN
		jump = Input.GetButtonDown("Jump");
		horizontalAxis = Input.GetAxis("Horizontal");
		verticalAxis = Input.GetAxis("Vertical");

		horizontalLook = Input.GetAxis("Mouse X");
		verticalLook = Input.GetAxis("Mouse Y");
#else
		jump = JumpButton.Jump;
		horizontalAxis = Joystick.HorizontalAxis;
		verticalAxis = Joystick.VerticalAxis;

		horizontalLook = ScreenMouse.Axis.x;
		verticalLook = ScreenMouse.Axis.y;
#endif
	}
}
