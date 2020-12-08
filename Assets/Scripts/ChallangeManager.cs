using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallangeManager : MonoBehaviour
{
	private Transform challengeParent;

	private Stack<int> stack = new Stack<int>();

	private void Awake()
	{
		FindChallengeParent();
		DisableAll();
	}

	private void Start()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
		FillStack();
		EnableChallange();
	}

	private void FindChallengeParent()
	{
		challengeParent = GameObject.Find("/Scene/Challenges").transform;
	}

	private void DisableAll()
	{
		foreach(Transform child in challengeParent)
		{
			child.gameObject.SetActive(false);
		}
	}

	private void FillStack()
	{
		for(int i = 0; i < challengeParent.childCount; i++)
		{
			stack.Push(i);
		}

		stack.Shuffle();
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if(scene.buildIndex == 0)
		{
			FindChallengeParent();
			DisableAll();
			EnableChallange();
		}
	}

	void EnableChallange()
	{
		if(stack.Count == 0)
		{
			FillStack();
		}

		int index = stack.Pop();
		challengeParent.GetChild(index).gameObject.SetActive(true);
	}
}
