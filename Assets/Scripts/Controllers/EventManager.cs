using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
	public static readonly string onQuestionAcquired = "onQuestionAcquired";
	public static readonly string onQuestionAnswered = "onQuestionAnswered";
	public static readonly string onQuestionTimeOut = "onQuestionTimeOut";
	public static readonly string onAnswerCorrectly = "onAnswerCorrectly";
	public static readonly string onAnswerWrong = "onAnswerWrong";
	public static readonly string onPlayerOutOfBounds = "onPlayerOutOfBounds";
	public static readonly string onLevelFinish = "onLevelFinish";

	private Dictionary<string, UnityEvent> eventDictionary;

	private static EventManager eventManager;

	private static EventManager Instance
	{
		get
		{
			if(!eventManager)
			{
				eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

				if(!eventManager)
				{
					Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
				}
				else
				{
					eventManager.Init();
				}
			}

			return eventManager;
		}
	}

	void Init()
	{
		if(eventDictionary == null)
		{
			eventDictionary = new Dictionary<string, UnityEvent>();
		}
	}

	public static void StartListening(string eventName, UnityAction listener)
	{
		UnityEvent thisEvent = null;
		if(Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
		{
			thisEvent.AddListener(listener);
		}
		else
		{
			thisEvent = new UnityEvent();
			thisEvent.AddListener(listener);
			Instance.eventDictionary.Add(eventName, thisEvent);
		}
	}

	public static void StopListening(string eventName, UnityAction listener)
	{
		if(eventManager == null)
		{
			return;
		}

		UnityEvent thisEvent = null;
		if(Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
		{
			thisEvent.RemoveListener(listener);
		}
	}

	public static void TriggerEvent(string eventName)
	{
		UnityEvent thisEvent = null;
		if(Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
		{
			thisEvent.Invoke();
		}
	}
}