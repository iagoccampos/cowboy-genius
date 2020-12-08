using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Axis { X, Y, Z}

public class RotateAnimation : MonoBehaviour
{
	[SerializeField]
	private float speed = 1;

	[SerializeField]
	private bool counterClockwise = false;

	[SerializeField]
	private Axis axis;

	private Vector3 axisVector;

	private Vector3 rotation;

	private void Start()
	{
		switch(axis)
		{
			case Axis.X:
				axisVector = Vector3.right;
				break;
			case Axis.Y:
				axisVector = Vector3.up;
				break;
			case Axis.Z:
				axisVector = Vector3.forward;
				break;
			default:
				axisVector = Vector3.zero;
				break;
		}

		axisVector *= counterClockwise ? -1 : 1;
		axisVector *= speed;
	}

	// Rotação no eixo Z
	void Update()
    {
		rotation += axisVector * speed * Time.deltaTime;
		transform.rotation = Quaternion.Euler(rotation);
	}
}
