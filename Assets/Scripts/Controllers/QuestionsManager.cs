using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestionsManager : MonoBehaviour
{
	private int currentQuestionIndex = 0;

	private Question[] questions = new Question[] {
		new Question("2 + 2 = ?", new string[] { "1", "4" }, 1),
		new Question("3^(-1) = ?", new string[] { ".33", "Não é a quarta opção", "3", "Não é a segunda opção" }, 0),
		new Question("sen(x)/cos(x) = ?", new string[] { "Nenhuma das opções", "Secante", "Cotangente", "Tangente" }, 3)
	};

	private static QuestionsManager instance;

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}

		SceneManager.sceneLoaded += SelectNextQuestion;
	}

	void Start()
	{
		ListenToAnswer();
	}

	public static int GetQuestionAnswerLength()
	{
		return instance.questions[instance.currentQuestionIndex].Answers.Length;
	}

	public static Question GetCurrentQuestion()
	{
		return instance.questions[instance.currentQuestionIndex];
	}

	public static bool WasLastQuestion()
	{
		return instance.currentQuestionIndex == instance.questions.Length - 1;
	}

	private void ListenToAnswer()
	{
		if(SceneManager.GetActiveScene().buildIndex == 0)
			QuestionAnswerEventManager.StartListening(AnswerQuestion);
	}

	private void AnswerQuestion(int answer)
	{
		if(questions[currentQuestionIndex].IsCorrectAnswer(answer))
		{
			EventManager.TriggerEvent(EventManager.onAnswerCorrectly);
		}
		else
		{
			EventManager.TriggerEvent(EventManager.onAnswerWrong);
		}
	}

	void SelectNextQuestion(Scene scene, LoadSceneMode mode)
	{
		ListenToAnswer();
		currentQuestionIndex++;
	}
}
