using UnityEngine;

public class AreaAtraction : MonoBehaviour
{
	[SerializeField]
	private float force = 1f;

	[SerializeField]
	private float radius = 1f;

	[SerializeField]
	private LayerMask interactableLayer;


	// Update is called once per frame
	void Update()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, radius, interactableLayer);

		if(colliders.Length > 0)
		{
			Vector3 dir = (transform.position - colliders[0].transform.position).normalized;
			Vector3 vel = dir * force;
			vel.y = colliders[0].attachedRigidbody.velocity.y;
			colliders[0].attachedRigidbody.velocity = vel;
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}
