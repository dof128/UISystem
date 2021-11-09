namespace WFang.EventSystem
{
    public interface IEventReceiver
    {
        void OnEvent(EventMessage eventMessage);
    }
}