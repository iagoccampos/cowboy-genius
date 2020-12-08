namespace ChainEvent
{
	public interface IEventHandle
	{
		void SetNext(IEventHandle next);
		void TriggerNext();
		void Handle();
	}
}
