using System;

namespace Weather {
    public interface ICommandHandler {
        void SetNext(ICommandHandler handler);
        void Handle(string command);
    }

    public class UnrecognizedCommandHandler : ICommandHandler {
        
        public void SetNext(ICommandHandler handler) {
            //do nothing
        }

        public void Handle(string command) {
            Console.WriteLine($"Unknown command {command}");
        }
    }
}