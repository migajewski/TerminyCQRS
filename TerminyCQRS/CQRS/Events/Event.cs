using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Events
{
    public interface IEvent
    {

    }

    public interface IHandleEvent : IEvent
    {

    }

    public interface IHandleEVent<TEvent> : IHandleEvent
        where TEvent : IEvent
    {
        void Handle(TEvent ev);
    }

    public interface IEventBus
    {
        void PublishEvent<T>(T ev) where T : IEvent;
    }

    public class EventBus : IEventBus
    {
        private readonly Func<Type, IEnumerable<IHandleEvent>> handlersFactory;

        public void PublishEvent<T>(T ev) where T : IEvent
        {
            var handlers = handlersFactory(typeof(T))
                .Cast<IHandleEVent<T>>();

            foreach (var handler in handlers)
            {
                handler.Handle(ev);
            }
        }

        public EventBus(Func<Type, IEnumerable<IHandleEvent>> handlersFactory)
        {
            this.handlersFactory = handlersFactory;
        }
    }

    public class TerminCreated : IEvent
    {
        public int DateTime { get; set; }
    }

    public class WhenTerminCreatedNotifyPatient : IHandleEVent<TerminCreated>
    {
        public void Handle(TerminCreated ev)
        {
        }
    }

    public class WhenTerminCreatedBlockOtherTerms : IHandleEVent<TerminCreated>
    {
        public void Handle(TerminCreated ev)
        {

        }
    }
}
