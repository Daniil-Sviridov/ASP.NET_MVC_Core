using System.Collections.Concurrent;

namespace MVC_study.DomainEvents
{
    public interface IDomainEvent
    {
    }

    public static class DomainEventsManager
    {
        private static readonly ConcurrentDictionary<Type, List<Delegate>> _handlers = new();

        public static void Register<T>(Action<T> eventHandler) where T : IDomainEvent
        {
            /*_handlers.AddOrUpdate(typeof(T),
                addValueFactory: _ => new List<Delegate>() { eventHandler },
                updateValueFactory: (_, delegates) =>
                {
                    delegates.Add(eventHandler);
                    return delegates;
                });*/

            if (_handlers.ContainsKey(typeof(T)))
            {
                _handlers[typeof(T)].Add(eventHandler);
            }
            else
            {
                _handlers[typeof(T)] = new List<Delegate>() { eventHandler };
            };
        }

        public static void Raise<T>(T domainEvent) where T : IDomainEvent
        {
            foreach (Delegate handler in _handlers[domainEvent.GetType()])
            {
                var action = (Action<T>)handler;
                action(domainEvent);
            }
        }
    }
}
