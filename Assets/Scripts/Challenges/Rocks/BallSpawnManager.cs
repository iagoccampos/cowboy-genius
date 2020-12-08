using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnManager : MonoBehaviour
{
	[SerializeField]
	private Transform[] positions;

	[SerializeField]
	private GameObject ballPrefab;

	private ObjectPooler pooler;

	private void Awake()
	{
		pooler = new ObjectPooler(ballPrefab);
	}

	private void Start()
	{
		StartCoroutine(DisableTimer());
	}

	private IEnumerator DisableTimer()
	{
		while(true)
		{
			Stack<int> stack = new Stack<int>();
			for(int i = 0; i < positions.Length; i++)
			{
				stack.Push(i);
			}
			stack.Shuffle();

			for(int i = 0; i < positions.Length; i++)
			{
				pooler.Instantiate(positions[stack.Pop()].position, Quaternion.identity);

				yield return new WaitForSeconds(Random.Range(0.3f, 0.5f));
			}
		}
	}
}
