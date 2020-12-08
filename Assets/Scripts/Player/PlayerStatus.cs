using UnityEngine;

public abstract class PlayerStatus : PlayerConfig
{
	[ReadOnly]
	[SerializeField]
	private bool grounded;
	protected bool Grounded { get { return grounded; } }

	[ReadOnly]
	[SerializeField]
	private float slopeAngle;
	protected float SlopeAngle { get { return slopeAngle; } }

	[ReadOnly]
	[SerializeField]
	private bool sliding;
	protected bool Sliding { get { return sliding; } }

	[ReadOnly]
	[SerializeField]
	private Vector3 slopeDir;
	protected Vector3 SlopeDir { get { return slopeDir; } }

	protected void Update()
	{
		SetGrounded();
		SetSlopeAngle();
		SetSliding();
	}

	private void SetGrounded()
	{
		grounded = Physics.CheckSphere(transform.position + Vector3.up * 0.45f, 0.49f, groundLayer);
	}

	private void SetSliding()
	{
		sliding = slopeAngle > maxClimbSlopeAngle && grounded;
	}

	private void SetSlopeAngle()
	{
		RaycastHit[] hits = Physics.RaycastAll(transform.position + Vector3.up * 0.1f, Vector3.down, 1f, groundLayer);

		if(hits.Length > 0)
		{
			Vector3 normal = hits[0].normal;

			Vector3 aux = normal;
			aux.y *= -1;
			aux.Normalize();

			Vector3 right = Vector3.Cross(normal, aux).normalized;
			Vector3 cross = Vector3.Cross(normal, right);

			if(cross.y < 0)
			{
				cross *= -1;
			}

			Debug.DrawRay(transform.position, normal, Color.green);
			Debug.DrawRay(transform.position, aux, Color.magenta);
			Debug.DrawRay(transform.position, right, Color.red);
			Debug.DrawRay(transform.position, cross, Color.blue);

			//Pra medir o ângulo
			Vector3 yPlane = new Vector3(cross.x, 0, cross.z).normalized;

			slopeDir = cross;
			slopeAngle = Vector3.Angle(yPlane, cross);
		}
		else
		{
			slopeAngle = 0;
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position + Vector3.up * 0.1f, transform.position + Vector3.up * 0.1f + Vector3.down * 0.3f);
		Gizmos.DrawWireSphere(transform.position + Vector3.up * 0.45f, 0.49f);
	}
}
