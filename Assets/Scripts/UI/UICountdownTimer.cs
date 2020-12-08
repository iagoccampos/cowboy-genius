using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//Simple UI Countdown
public class UICountdownTimer : MonoBehaviour
{
	[SerializeField]
	private Text timeText;
	private int sec;
	public bool IsRunning { get; private set; } = false;

	private void Awake()
	{
		EventManager.StartListening(EventManager.onQuestionAcquired, StartCountdown);
		EventManager.StartListening(EventManager.onQuestionAnswered, StopCountdown);
		EventManager.StartListening(EventManager.onQuestionTimeOut, StopCountdown);

		gameObject.SetActive(false);
		timeText.text = "00:00";
	}

	private void StartCountdown()
	{
		gameObject.SetActive(true);

		this.sec = 60;
		if(!IsRunning)
			StartCoroutine(Timer());
	}

	private void StopCountdown()
	{
		gameObject.SetActive(false);
		StopAllCoroutines();
		timeText.text = "00:00";
		IsRunning = false;
	}

	private IEnumerator Timer()
	{
		IsRunning = true;

		while(sec >= 0)
		{
			int seconds = sec % 60;
			int minutes = sec / 60;

			string secondsText = seconds.ToString().PadLeft(2, '0');
			string minutesText = minutes.ToString().PadLeft(2, '0');

			timeText.text = minutesText + ":" + secondsText;

			sec--;
			yield return new WaitForSeconds(1);
		}

		IsRunning = false;

		EventManager.TriggerEvent(EventManager.onQuestionTimeOut);
	}
}
