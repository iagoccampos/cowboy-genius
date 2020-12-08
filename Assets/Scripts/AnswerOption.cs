using UnityEngine;

public class AnswerOption : MonoBehaviour
{
	private int answerIndex;

	private void Awake()
	{
		answerIndex = transform.GetSiblingIndex();

		// Quando personagem pegar uma pergunta, habilita a opção
		EventManager.StartListening(EventManager.onQuestionAcquired, Enable);

		// Quando o personagem responder, desabilita todas as outras opções, por segurança
		EventManager.StartListening(EventManager.onQuestionAnswered, Disable);

		EventManager.StartListening(EventManager.onQuestionTimeOut, Disable);

		Disable();
	}

	private void Enable()
	{
		this.gameObject.SetActive(true);
	}

	private void Disable()
	{
		this.gameObject.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)
	{
		QuestionAnswerEventManager.TriggerEvent(answerIndex);
		EventManager.TriggerEvent(EventManager.onQuestionAnswered);
	}
}
