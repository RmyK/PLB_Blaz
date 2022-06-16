namespace DataAccess.Services.MsgService
{
    public class MessageService
    {
        private static HashSet<IListener> subscribers = new HashSet<IListener>();

        private void Publish(object[] objects, Type type)
        {
            foreach (var subscriver in GetSubscriberOf(type))
            {
                var methode = subscriver.GetType().GetMethod("Handle", new Type[] { type });
                if (methode != null)
                {
                    try
                    {
                        methode.Invoke(subscriver, new object[] { objects[0] });
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
        }

        private IEnumerable<IListener> GetSubscriberOf(Type tpe)
        {
            foreach (var subscriber in subscribers.ToList())
            {
                var interfaceTypes = subscriber.GetType().GetInterfaces().ToArray();
                foreach (var it in interfaceTypes)
                {
                    if (!it.IsGenericType || !typeof(IListener).IsAssignableFrom(it)) continue;

                    var gentypedef = it.GetGenericArguments()[0];
                    if (gentypedef == tpe)
                        yield return subscriber;
                }
            }
        }

        public void Publish<T>(T signal) => Publish(new object[] { signal }, typeof(T));

        public void Subscribe(IListener model) => subscribers.Add(model);
        public void Unsubscribe(IListener model) => subscribers.Remove(model);
    }
}
