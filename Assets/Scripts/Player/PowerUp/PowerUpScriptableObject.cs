using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PowerUpScriptableObject", order = 1)]
public class PowerUpScriptableObject : ScriptableObject
{
	public float speedBoost = 1;
	public float jumpBoost = 1;
}
