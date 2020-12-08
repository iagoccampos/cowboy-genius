using UnityEngine;

public class CameraRotation : MonoBehaviour
{
	[SerializeField]
	private float degPerSec = 60f;

	// Local Vars
	private float headingRotationY;
	private float headingRotationX;

	private void Update()
	{
		RotateCamera();
	}

	// Rotação da camera com o mouse
	private void RotateCamera()
	{
		headingRotationY += InputManager.horizontalLook * Time.deltaTime * degPerSec;
		headingRotationX += InputManager.verticalLook * Time.deltaTime * degPerSec;
		headingRotationX = Mathf.Clamp(headingRotationX, -15, 15);

		transform.rotation = Quaternion.Euler(headingRotationX, headingRotationY, 0);
	}
}
