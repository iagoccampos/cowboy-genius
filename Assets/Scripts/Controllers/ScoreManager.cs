using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	public delegate void ScoreHandler(int score);
	public static event ScoreHandler onScoreChange;

	private static ScoreManager instance;

	private int currentScore = 0;
	private int correctAnswerScore = 0;
	public static int CurrentScore
	{
		get { return instance.currentScore + instance.correctAnswerScore; }
	}

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);

		if(instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}

		ClearSubs();
	}

	private void Start()
	{
		Listen();
	}

	void Listen()
	{
		EventManager.StartListening(EventManager.onAnswerCorrectly, AddAnswerScore);
		EventManager.StartListening(EventManager.onLevelFinish, AddCompleteLevelScore);
	}

	private void AddAnswerScore()
	{
		AddScore(200);
	}

	private void AddCompleteLevelScore()
	{
		AddScore(300);
	}

	private void ClearSubs()
	{
		onScoreChange = null;
	}

	public static void AddScore(int score)
	{
		instance.currentScore += score;
		onScoreChange?.Invoke(CurrentScore);
	}

	public static void AddCorrectAnswerScore(int score)
	{
		instance.correctAnswerScore += score;
		onScoreChange?.Invoke(CurrentScore);
	}

	private void OnLevelWasLoaded(int level)
	{
		EventManager.StartListening(EventManager.onAnswerCorrectly, AddAnswerScore);
		EventManager.StartListening(EventManager.onLevelFinish, AddCompleteLevelScore);
		ClearSubs();
	}
}
