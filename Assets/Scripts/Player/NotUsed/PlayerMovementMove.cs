using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementMove : MonoBehaviour
{
	[SerializeField]
	private float movementSpeed = 1;

	[SerializeField]
	private float jumpForce = 1;

	[SerializeField]
	private float degPerSec = 60f;

	[SerializeField]
	private float groundCheckRadius = 1f;

	[SerializeField]
	private Transform groundCheck;

	[SerializeField]
	private LayerMask groundLayer;

	private Transform cameraPivot;

	private Rigidbody rb;

	private float headingRotationY;
	private float headingRotationX;

	private Vector3 nextPos;

	private void Awake()
	{
		this.rb = GetComponent<Rigidbody>();
		cameraPivot = Camera.main.transform.parent;
	}

	void Update()
	{
		// Rotação da camera com o mouse
		headingRotationY += Input.GetAxis("Mouse X") * Time.deltaTime * degPerSec;
		headingRotationX += Input.GetAxis("Mouse Y") * Time.deltaTime * degPerSec;
		headingRotationX = Mathf.Clamp(headingRotationX, -15, 15);

		cameraPivot.rotation = Quaternion.Euler(headingRotationX, headingRotationY, 0);

#if UNITY_EDITOR || UNITY_STANDALONE_WIN
		//Movimentação do player relativo a camera
		Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

		Vector3 camForward = Camera.main.transform.forward;
		Vector3 camRight = Camera.main.transform.right;

		camForward.y = camRight.y = 0;

		camForward.Normalize();
		camRight.Normalize();

		nextPos = (camForward * input.y + camRight * input.x) * movementSpeed;

#endif

		//Pulo
		bool grounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
		bool jumpButton = Input.GetButtonDown("Jump");

		if(grounded && jumpButton)
		{
			rb.AddForce(Vector3.up * jumpForce * 100);
		}

		//Rotação do player conforme movimento
		Vector3 velocityDir = rb.velocity;
		velocityDir.y = 0;
		velocityDir.Normalize();

		if(velocityDir.magnitude != 0)
		{
			Quaternion fromRotation = transform.rotation;
			Quaternion toRotation = Quaternion.LookRotation(velocityDir);
			transform.rotation = Quaternion.RotateTowards(fromRotation, toRotation, 2);
		}
	}

	private void FixedUpdate()
	{
		rb.MovePosition(transform.position + nextPos * Time.fixedDeltaTime);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
	}
}
