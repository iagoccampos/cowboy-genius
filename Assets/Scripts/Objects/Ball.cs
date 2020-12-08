using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
	public Vector3 dir;

	[SerializeField]
	private float speed = 5f;

	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		rb.velocity = rb.velocity + dir * speed * Time.deltaTime;
	}

	private void OnEnable()
	{
		rb.velocity = Vector3.zero;
		StartCoroutine(Disable());
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.collider.CompareTag("Player"))
		{
			Vector3 pushDir = collision.contacts[0].point - transform.position;
			pushDir.y = 0;
			pushDir.Normalize();

			collision.collider.GetComponent<IPlayerPushable>().PushPlayer(pushDir);
		}
	}

	private IEnumerator Disable()
	{
		yield return new WaitForSeconds(20);
		gameObject.SetActive(false);
	}
}
