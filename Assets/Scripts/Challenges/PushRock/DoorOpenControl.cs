using UnityEngine;

public class DoorOpenControl : MonoBehaviour
{
	[SerializeField]
	private Transform ballPosCheck;

	[SerializeField]
	private float checkRadius = 1f;

	[SerializeField]
	private LayerMask interactableLayer;

	[SerializeField]
	private Animator gateAnimator;

	void Update()
	{
		if(Physics.CheckSphere(ballPosCheck.position, checkRadius, interactableLayer))
		{
			OpenDoor();
			enabled = false;
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(ballPosCheck.position, checkRadius);
	}

	void OpenDoor()
	{
		gateAnimator.SetTrigger("Open");
	}
}
