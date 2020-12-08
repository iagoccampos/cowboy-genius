using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GateControl : MonoBehaviour
{
	private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();

		EventManager.StartListening(EventManager.onQuestionAnswered, Open);
		EventManager.StartListening(EventManager.onQuestionTimeOut, Open);
	}

	private void Open()
	{
		animator.SetTrigger("Open");
	}
}
