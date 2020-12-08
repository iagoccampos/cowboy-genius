using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraAutoSetup : MonoBehaviour
{
	private Transform player;

    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;

		PositionConstraint posConstraint = GetComponent<PositionConstraint>();
		posConstraint.ClearSources();
		posConstraint.AddTransform(player);

		LookAtConstraint lookConstraint = Camera.main.GetComponent<LookAtConstraint>();
		lookConstraint.ClearSources();
		lookConstraint.AddTransform(player.Find("LookAtTarget"));
    }
}
