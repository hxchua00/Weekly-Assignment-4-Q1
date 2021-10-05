using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Weekly_Assignment_4_Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Thread> ThreadCollection = new List<Thread>();
            bool cont = true;
            while (cont) 
            {
                Console.WriteLine("Choose your operation: ");
                Console.WriteLine("1) Create Thread");
                Console.WriteLine("2) Destroy Thread");
                Console.WriteLine("3) View Running Thread");
                Console.WriteLine("4) Make Synchronous Thread");
                Console.WriteLine("5) Sleep Thread");
                Console.WriteLine("6) Exit");
                Console.WriteLine();
                Console.Write("Enter choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Thread newThread = new Thread(()=> { CreateThread(); });
                        newThread.IsBackground = true;
                        ThreadCollection.Add(newThread);
                        newThread.Start();
                        break;
                    case 2:
                        DestroyThread(ThreadCollection);
                        break;
                    case 3:
                        ViewRunningThreads(ThreadCollection);
                        break;
                    case 4:
                        break;
                    case 5:
                        SleepThread(ThreadCollection);
                        break;
                    case 6:
                        cont = false;
                        Console.WriteLine("Exited the program!");
                        break;
                    default:
                        Console.WriteLine("Invalid option entered!");
                        break;
                }
            }
            
        }

        public static void CreateThread()
        {
            bool stopthread = true;
            while (stopthread)
            {
                Thread.Sleep(3000);
            }          
        }

        public static void DestroyThread(List<Thread> t)
        {
            Console.WriteLine("Enter ThreadID to destroy: ");
            int ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            foreach (Thread obj in t)
            {
                if (obj.ManagedThreadId == ID)
                {
                    if (obj.IsAlive)
                    {
                        obj.Abort();
                        Console.WriteLine("ThreadID {0} has been destroyed!", obj.ManagedThreadId);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("The ThreadID {0} you entered either did not exist or has been terminated.", ID);
                    Console.WriteLine();
                }
            }
        }

        public static void ViewRunningThreads(List<Thread> t) 
        {
            if (t.Count != 0)
            {
                foreach (Thread obj in t)
                {
                    Console.WriteLine("Thread name: {0}", obj.Name);
                    Console.WriteLine("Thread ID: {0}", obj.ManagedThreadId);
                    Console.WriteLine("Thread is alive: {0}", obj.IsAlive);
                    if (obj.IsAlive == true)
                    {
                        Console.WriteLine("Thread background: {0}", obj.IsBackground);
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no threads running currently!");
            }
            
            Console.WriteLine("Total number of threads running: " + t.Count);
            Console.WriteLine();
        }

        public static void SleepThread(List<Thread> t)
        {
            
            foreach (Thread obj in t)
            {
                Console.WriteLine("Enter ThreadID: ");
                int ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (obj.ManagedThreadId == ID)
                {
                    if (obj.IsAlive)
                    {
                        Console.WriteLine("ThreadID {0} has been found!", obj.ManagedThreadId);
                        Console.WriteLine("How long do you wish to sleep?(in seconds)");
                        int time = (Convert.ToInt32(Console.ReadLine())) * 1000;

                        lock (obj)
                        {
                            Monitor.Wait(obj,time);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("The ThreadID {0} you entered either did not exist or has been terminated.", ID);
                    Console.WriteLine();
                }

            }
        }
    }
}
