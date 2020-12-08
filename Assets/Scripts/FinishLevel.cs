using UnityEngine;

public class FinishLevel : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			EventManager.TriggerEvent(EventManager.onLevelFinish);
		}
	}
}
