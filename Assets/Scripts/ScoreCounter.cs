using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
	private int totalScore;

	private Text scoreText;

	[SerializeField]
	private float speed;

	void Awake()
	{
		totalScore = ScoreManager.CurrentScore;
		scoreText = GetComponent<Text>();

		scoreText.text = "0";
	}

	void Start()
	{
		StartCoroutine(ScoreAnimation());
	}

	IEnumerator ScoreAnimation()
	{
		int currentScoreCount = 0;
		yield return new WaitForSeconds(1);

		while(currentScoreCount < totalScore)
		{
			currentScoreCount += (int)(Time.deltaTime * speed);

			if(currentScoreCount > totalScore)
			{
				currentScoreCount = totalScore;
			}

			scoreText.text = currentScoreCount.ToString();
			yield return null;
		}

		scoreText.text = currentScoreCount.ToString() + "!";
	}
}
