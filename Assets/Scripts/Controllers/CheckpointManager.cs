using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
	private int currentCheckpoint = 0;

	private Transform checkpointsParent;

	private Transform playerTrans;
	private Rigidbody playerRb;

	private void Awake()
	{
		checkpointsParent = transform.Find("CheckPoints");

		EventManager.StartListening(EventManager.onQuestionAnswered, SelectNextCheckpoint);
		EventManager.StartListening(EventManager.onQuestionTimeOut, SelectNextCheckpoint);

		EventManager.StartListening(EventManager.onPlayerOutOfBounds, PutPlayerOnCheckPoint);
	}

	private void Start()
	{
		playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
		playerRb = playerTrans.GetComponent<Rigidbody>();
	}

	private void SelectNextCheckpoint()
	{
		currentCheckpoint++;
	}

	private void PutPlayerOnCheckPoint()
	{
		playerTrans.position = checkpointsParent.GetChild(currentCheckpoint).transform.position;
		playerRb.velocity = Vector3.zero;
	}
}
