namespace DataAccess.Services.MsgService
{
    public interface IListener
    {
    }

    public interface IListener<T> : IListener
    {
        Task Handle(T obj);
    }
}
