using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Threading;

namespace Weather
{
    class Program
    {
        public static void Main(string[] args)
        {
            Thread thread1 = new Thread(ThreadWork.DoWork);
            thread1.Start();
            for (int i = 0; i<3; i++) {
                Console.WriteLine("In main.");
                Thread.Sleep(100);
            }
        }
    }

}

public class ThreadWork
{
    public static void DoWork()
    {
        while (true)
        {
        }
    }
}