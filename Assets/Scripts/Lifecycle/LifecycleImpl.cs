namespace Lifecycle
{
    public class LifecycleImpl : ILifecycle
    {
        private event ILifecycle.EventUpdate eventUpdate;

        public void SendEvent(ILifecycle.Event newEvent)
        {
            eventUpdate?.Invoke(newEvent);
        }

        public void RegisterEventListener(ILifecycle.EventUpdate listener)
        {
            eventUpdate += listener;
        }

        public void UnregisterEventListener(ILifecycle.EventUpdate listener)
        {
            eventUpdate -= listener;
        }

        public void Clear()
        {
            eventUpdate = null;
        }
    }
}