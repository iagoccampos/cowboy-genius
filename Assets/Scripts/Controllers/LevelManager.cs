using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	private void Start()
	{
		EventManager.StartListening(EventManager.onLevelFinish, LoadNextScene);
	}

	private void LoadNextScene()
	{
		if(!QuestionsManager.WasLastQuestion())
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		else
		{
			SceneManager.LoadScene(1);
		}
	}
}
