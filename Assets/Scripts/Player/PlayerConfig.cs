using UnityEngine;

public abstract class PlayerConfig : PlayerController
{
	[SerializeField]
	private float movementSpeed = 1;
	protected float MovementSpeed
	{
		get
		{
			return movementSpeed * (powerUp == null ? 1 : powerUp.speedBoost);
		}
	}

	[SerializeField]
	private float jumpForce = 1;
	protected float JumpForce
	{
		get
		{
			return jumpForce * (powerUp == null ? 1 : powerUp.jumpBoost);
		}
	}

	[SerializeField]
	protected float maxClimbSlopeAngle = 30f;

	[SerializeField]
	protected LayerMask groundLayer;

	private PowerUpScriptableObject powerUp;

	public void AddPowerUp(PowerUpScriptableObject power)
	{
		powerUp = power;
	}
}
