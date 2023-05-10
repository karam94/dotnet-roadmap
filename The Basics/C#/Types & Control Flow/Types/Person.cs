using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Types
{
    public class Person
    {
        public List<string> Interests = new();
        public LinkedList<string> LinkedList = new();
        public Dictionary<string, string> ContactInfo = new();
        public ConcurrentDictionary<int, string> ConcurrentDictionary = new();
        public SortedDictionary<int, string> SortedDictionary = new();
        public SortedList<int, string> SortedList = new();
        public Queue<string> Queue = new();
        public ConcurrentQueue<string> ConcurrentQueue = new();
        public Stack<string> Stack = new();
        public HashSet<string> HashSet = new();
        public Hashtable Hashtable = new();
        public ObservableCollection<string> ObservableCollection = new();

        public void ControlFlowExample(int num)
        {
            if (num < 0)
            {
                Console.WriteLine("Number is negative");
            }
            else if (num == 0)
            {
                Console.WriteLine("Number is zero");
            }
            else
            {
                Console.WriteLine("Number is positive");
            }

            var ternaryOperator = num < 0 ? "Number is negative" : num == 0 ? "Number is zero" : "Number is positive";

            switch (num)
            {
                case 0:
                    Console.WriteLine("Number is zero");
                    break;
                case 1:
                case 2:
                    Console.WriteLine("Number is one or two");
                    break;
                default:
                    Console.WriteLine("Number is greater than two");
                    break;
            }
        }

        public void ForLoopExample()
        {
            Console.WriteLine("For loop example:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"i = {i}");
            }
        }

        public void WhileLoopExample()
        {
            Console.WriteLine("While loop example:");
            int i = 0;
            while (i < 5)
            {
                Console.WriteLine($"i = {i}");
                i++;
            }
        }

        public void DoWhileLoopExample()
        {
            Console.WriteLine("Do-while loop example:");
            int i = 0;
            do
            {
                Console.WriteLine($"i = {i}");
                i++;
            } while (i < 5);
        }

        public void ForeachLoopExample()
        {
            Console.WriteLine("Foreach loop example:");
            foreach (var interest in Interests)
            {
                Console.WriteLine($"- {interest}");
            }
        }
    }
}