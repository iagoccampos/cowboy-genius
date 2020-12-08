using UnityEngine;

public class QuestionStage : MonoBehaviour
{
	private void Start()
	{
		int answerLength = QuestionsManager.GetQuestionAnswerLength();
		SetupStage(answerLength);
	}

	private void SetupStage(int answerLength)
	{
		Transform answerOptions = transform.Find("Config");

		switch(answerLength)
		{
			case 2:
				answerOptions.GetChild(0).gameObject.SetActive(true);
				break;
			case 4:
				answerOptions.GetChild(1).gameObject.SetActive(true);
				break;
			default:
				Debug.LogError("Quantidade de respostas diferente de 2 ou 4.");
				break;
		}
	}
}
