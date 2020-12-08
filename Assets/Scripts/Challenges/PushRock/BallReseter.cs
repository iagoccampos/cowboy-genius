using UnityEngine;

public class BallReseter : MonoBehaviour
{
	[SerializeField]
	private Transform ballResetPosition;

	private void OnTriggerEnter(Collider other)
	{
		other.transform.position = ballResetPosition.position;
		other.attachedRigidbody.velocity = Vector3.zero;
	}
}
