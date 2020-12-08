using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMark : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			gameObject.SetActive(false);
			EventManager.TriggerEvent(EventManager.onQuestionAcquired);
		}
	}
}
