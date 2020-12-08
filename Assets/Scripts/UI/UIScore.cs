using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
	[SerializeField]
	private Text scoreText;

	private void Start()
	{
		ScoreManager.onScoreChange += SetScore;
		SetScore(ScoreManager.CurrentScore);
	}

	private void SetScore(int score)
	{
		if(scoreText != null)
		{
			scoreText.text = "Pontos: " + score.ToString();
		}
		else
		{
			Debug.Log(scoreText);
		}
	}
}
