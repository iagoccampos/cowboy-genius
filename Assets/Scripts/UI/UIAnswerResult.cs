using UnityEngine;

public class UIAnswerResult : MonoBehaviour
{
	[SerializeField]
	private GameObject correctText;

	[SerializeField]
	private GameObject wrongText;

	[SerializeField]
	private GameObject timeOutText;

	private void Awake()
	{
		correctText.SetActive(false);
		wrongText.SetActive(false);
		timeOutText.SetActive(false);
	}

	void Start()
	{
		EventManager.StartListening(EventManager.onAnswerCorrectly, ShowCorrect);
		EventManager.StartListening(EventManager.onAnswerWrong, ShowWrong);
		EventManager.StartListening(EventManager.onQuestionTimeOut, ShowTimeOut);
	}

	private void ShowCorrect()
	{
		correctText.SetActive(true);
	}

	private void ShowWrong()
	{
		wrongText.SetActive(true);
	}

	private void ShowTimeOut()
	{
		timeOutText.SetActive(true);
	}
}
