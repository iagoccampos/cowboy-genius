using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChainEvent
{
	public class ChainEventManager : MonoBehaviour
	{
		[SerializeField]
		private IEventHandle[] handlers;

		private void Awake()
		{
			for(int i = 1; i < handlers.Length; i++)
			{
				handlers[i - 1].SetNext(handlers[i]);
			}

			handlers[0].Handle();
		}
	}
}
