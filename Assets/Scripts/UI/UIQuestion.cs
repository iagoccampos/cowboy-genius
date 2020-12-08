using UnityEngine;
using UnityEngine.UI;

public class UIQuestion : MonoBehaviour
{
	[SerializeField]
	private Text questionText;

	[SerializeField]
	private GameObject twoOptions;

	[SerializeField]
	private GameObject fourOptions;

	private void Awake()
	{
		EventManager.StartListening(EventManager.onQuestionAcquired, Show);

		EventManager.StartListening(EventManager.onQuestionTimeOut, Hide);
		EventManager.StartListening(EventManager.onQuestionAnswered, Hide);

		Hide();
	}

	private void Show()
	{
		Question question = QuestionsManager.GetCurrentQuestion();

		questionText.text = question.QuestionText;

		if(question.Answers.Length == 2)
		{
			twoOptions.SetActive(true);

			int i = 0;
			foreach(Text text in twoOptions.GetComponentsInChildren<Text>())
			{
				text.text = char.ConvertFromUtf32(65 + i) + ": " + question.Answers[i];
				i++;
			}
		}
		else
		{
			fourOptions.SetActive(true);

			int i = 0;
			foreach(Text text in fourOptions.GetComponentsInChildren<Text>())
			{
				text.text = char.ConvertFromUtf32(65 + i) + ": " + question.Answers[i];
				i++;
			}
		}

		gameObject.SetActive(true);
	}

	private void Hide()
	{
		gameObject.SetActive(false);

		twoOptions.SetActive(false);
		fourOptions.SetActive(false);
	}
}
