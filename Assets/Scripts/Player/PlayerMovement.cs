using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : PlayerStatus, IPlayerPushable
{
	[ReadOnly]
	[SerializeField]
	private Vector3 velocity;

	[ReadOnly]
	[SerializeField]
	private bool movementEnable = true;

	[SerializeField]
	private PhysicMaterial material;

	private void Update()
	{
		base.Update();
		Move();
		RotatePlayer();
	}

	private void FixedUpdate()
	{
		if(!movementEnable)
		{
			return;
		}

		rb.velocity = velocity;
	}

	//Movimentação do player relativo a camera
	private void Move()
	{
		if(!movementEnable)
		{
			return;
		}

		Vector2 input = new Vector2(InputManager.horizontalAxis, InputManager.verticalAxis).normalized;

		Vector3 camForward = Camera.main.transform.forward;
		Vector3 camRight = Camera.main.transform.right;

		camForward.y = camRight.y = 0;

		camForward.Normalize();
		camRight.Normalize();

		velocity = (camForward * input.y + camRight * input.x) * MovementSpeed;
		velocity.y = rb.velocity.y;

		//Se parou de se mover e está no chão, se mantém no chão
		if(Grounded && input == Vector2.zero)
		{
			velocity.y = 0;
		}

		if(Sliding)
		{
			velocity = -SlopeDir * MovementSpeed;
		}

		//Pulo
		if(Grounded && InputManager.jump && !Sliding)
		{
			rb.AddForce(Vector3.up * JumpForce * 100);
		}
	}

	//Rotação do player conforme direção movimento
	private void RotatePlayer()
	{
		Vector3 velocityDir = velocity;
		velocityDir.y = 0;
		velocityDir.Normalize();

		if(velocityDir.magnitude != 0)
		{
			Quaternion fromRotation = transform.rotation;
			Quaternion toRotation = Quaternion.LookRotation(velocityDir);
			transform.rotation = Quaternion.RotateTowards(fromRotation, toRotation, 300 * Time.deltaTime);
		}
	}

	public void PushPlayer(Vector3 pushDir)
	{
		movementEnable = false;
		rb.AddForce(pushDir * 300);
		material.staticFriction = material.dynamicFriction = 0.9f;


		StopCoroutine(EnableMovement());
		StartCoroutine(EnableMovement());
	}

	private IEnumerator EnableMovement()
	{
		yield return new WaitForSeconds(1.5f);
		movementEnable = true;
		material.staticFriction = material.dynamicFriction = 0;
	}
}
