using CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Commands
{
    public interface ICommand
    {

    }

    public interface IHandleCommand : ICommand
    {

    }

    public interface IHandleCommand<TCommand> : IHandleCommand
        where TCommand : ICommand
    {
        void Handle(TCommand command);
    }

    public interface ICommandBus
    {
        void SendCommand<T>(T command) where T : ICommand;
    }

    public class CommandBus : ICommandBus
    {
        private readonly Func<Type, IHandleCommand> handlersFactory;

        public CommandBus(Func<Type, IHandleCommand> handlersFactory)
        {
            this.handlersFactory = handlersFactory;
        }


        public void SendCommand<T>(T command) where T : ICommand
        {
            var handler = (IHandleCommand<T>)handlersFactory(typeof(T));
            handler.Handle(command);
        }
    }

    public class CreateTermin : ICommand
    {
        public DateTime Date { get; set; }
    }

    public class CreateTerminHandler : IHandleCommand<CreateTermin>

    {
        public void Handle(CreateTermin command)
        {
            throw new NotImplementedException();
        }
    }
}