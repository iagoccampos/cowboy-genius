using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementCharacter : MonoBehaviour
{
	[SerializeField]
	private float speed = 1;

	[SerializeField]
	private float jumpHeight = 1;

	[SerializeField]
	private float degPerSec = 180f;

	[SerializeField]
	private float groundCheckRadius = 1f;

	[SerializeField]
	private Transform groundCheck;

	[SerializeField]
	private LayerMask groundLayer;

	private CharacterController charControl;

	private Transform cameraPivot;

	private float headingRotationY;
	private float headingRotationX;

	private float velocityY;

	void Start()
    {
		charControl = GetComponent<CharacterController>();
		cameraPivot = Camera.main.transform.parent;
	}

    // Update is called once per frame
    void Update()
    {
		// Rotação da camera com o mouse
		headingRotationY += Input.GetAxis("Mouse X") * Time.deltaTime * degPerSec;
		headingRotationX += Input.GetAxis("Mouse Y") * Time.deltaTime * degPerSec;
		headingRotationX = Mathf.Clamp(headingRotationX, -15, 15);

		cameraPivot.rotation = Quaternion.Euler(headingRotationX, headingRotationY, 0);

		// Movimentação
		Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		Vector3 camForward = Camera.main.transform.forward;
		Vector3 camRight = Camera.main.transform.right;

		camForward.y = camRight.y = 0;

		camForward.Normalize();
		camRight.Normalize();

		Vector3 velocity = (camForward * input.y + camRight * input.x) * speed;

		bool grounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
		
		if(grounded && velocityY < 0)
		{
			velocityY = 0f;
		}
			
		// Pulo
		if(Input.GetButtonDown("Jump") && grounded)
		{
			velocityY += Mathf.Sqrt(jumpHeight * -2.0f * Physics.gravity.y);
		}

		if(!grounded)
		{
			velocityY += Physics.gravity.y * Time.deltaTime;
		}
		
		charControl.Move(velocity * Time.deltaTime + velocityY * Vector3.up * Time.deltaTime);

		// Rotação do player conforme movimento
		Vector3 velocityDir = velocity;
		velocityDir.y = 0;
		velocityDir.Normalize();

		if(velocityDir.magnitude != 0)
		{
			Quaternion fromRotation = transform.rotation;
			Quaternion toRotation = Quaternion.LookRotation(velocityDir);
			transform.rotation = Quaternion.RotateTowards(fromRotation, toRotation, 2);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
	}
}
