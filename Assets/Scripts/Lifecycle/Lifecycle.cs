namespace Lifecycle
{
    public interface ILifecycle
    {
        public void RegisterEventListener(EventUpdate listener);

        public void UnregisterEventListener(EventUpdate listener);
        

        public delegate void EventUpdate(Event newEvent);
        

        public enum Event
        {
            Destroy,
        }
    }
}