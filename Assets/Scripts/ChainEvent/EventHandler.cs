using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChainEvent
{
	public abstract class EventHandler : MonoBehaviour, IEventHandle
	{
		IEventHandle next;

		public void SetNext(IEventHandle next)
		{
			this.next = next;
		}

		// Se a classe não implementou, continua...
		public virtual void Handle()
		{
			TriggerNext();
		}

		public void TriggerNext()
		{
			if(next != null)
			{
				next.Handle();
			}
		}
	}
}