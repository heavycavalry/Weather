using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Threading;

namespace Weather {
    class Program {
        public static void Main(string[] args) {
            new Application().Run();
        }
    }

    public class Application {
        public Dictionary<string, User> _users = new Dictionary<string, User>();
        public WeatherBroadcast _broadcast = new WeatherBroadcast();

        public void Run() {
            while (true) {
                try {
                    Console.Write(">");
                    string command = Console.ReadLine();
                    HandleUserInput(command);
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                }
            }
        }
        
        public void HandleUserInput(string input) {
            var inputParts = input.Split(" "); //Split nie mutuje, trzeba przypisać
            
            if (inputParts[0] == "addUser" || inputParts[0] == "au") {
                User user = new UserBuilder()
                    .SetWeatherBroadcast(_broadcast)
                    .SetLogin(inputParts[1])
                    .Build();
                _users.Add(user.Login, user);
                return;
            }


            if (inputParts[0] == "removeUser" || inputParts[0] == "ru") {
                string userLogin = inputParts[1];
                if (_users.ContainsKey(userLogin)) {
                    var user = _users[userLogin];
                    _broadcast.UnsubscribeAll(user);
                    _users.Remove(userLogin);
                }

                return;
            }

            if (inputParts[0] == "subscribe" || inputParts[0] == "sub") {
                string userLogin = inputParts[1];
                string city = inputParts[2];
                User user = _users[userLogin];
                user.Subscribe(city);
                return;
            }

            if (inputParts[0] == "unsubscribe" || inputParts[0] == "unsub") {
                string userLogin = inputParts[1];
                string city = inputParts[2];
                User user = _users[userLogin];
                user.Unsubscribe(city);
                return;
            }

            if (inputParts[0] == "setStrategy" || inputParts[0] == "ss") {
                string userLogin = inputParts[1];
                User user = _users[userLogin];
                user.SetStrategy(StrategyParser.ParseStrategy(inputParts[2]));
                return;
            }

            Console.WriteLine("Wrong command. Please try again.");
        }
    }
}