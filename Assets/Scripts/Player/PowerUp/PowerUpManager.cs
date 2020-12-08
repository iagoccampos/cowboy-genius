using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
	[SerializeField]
	private PowerUpScriptableObject[] powerUps;

	private void Start()
	{
		EventManager.StartListening(EventManager.onAnswerCorrectly, SetPowerUp);
	}

	private void SetPowerUp()
	{
		if(powerUps.Length == 0)
		{
			return;
		}

		int randomIndex = Random.Range(0, powerUps.Length);

		PowerUpScriptableObject randomPowerUp = powerUps[randomIndex];
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConfig>().AddPowerUp(randomPowerUp);
	}
}
