using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntUnityEvent : UnityEvent<int>
{

}

public class QuestionAnswerEventManager : MonoBehaviour
{
	private IntUnityEvent unityEvent = new IntUnityEvent();

	private static QuestionAnswerEventManager instance;
	private static QuestionAnswerEventManager Instance
	{
		get
		{
			if(!instance)
			{
				instance = FindObjectOfType(typeof(QuestionAnswerEventManager)) as QuestionAnswerEventManager;

				if(!instance)
				{
					Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
				}
			}

			return instance;
		}
	}

	public static void StopListening(UnityAction<int> listener)
	{
		Instance.unityEvent.RemoveListener(listener);
	}

	public static void StartListening(UnityAction<int> listener)
	{
		Instance.unityEvent.AddListener(listener);
	}

	public static void TriggerEvent(int answer)
	{
		Instance.unityEvent.Invoke(answer);
	}

	private void OnDestroy()
	{
		Instance.unityEvent.RemoveAllListeners();
	}
}
