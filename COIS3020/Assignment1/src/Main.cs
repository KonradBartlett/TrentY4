using System;
using UnDirectedGraphAdjacencyList;
using static _3020.Graph;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            SubwayMap graph = new SubwayMap();
            unDirectedGraph<String> Task1 = new unDirectedGraph<String>();
            unDirectedGraph<String> Task2 = new unDirectedGraph<String>();
            
            Task1 = graph.fast();
            Task2 = graph.critical();

            Console.WriteLine("Task 1: Fastest Route\nVertexA\tVertexB\tColour\n=======================================\n");
            Task1.Print();
            Console.ReadKey();
            Console.WriteLine("Task 2: Articulation Points\nVertexA\tVertexB\tColour\n=======================================\n");
            Task2.Print();
            Console.ReadKey();
            
            Console.WriteLine("Fastest Route");
            Console.WriteLine("Graph: fast");
            Task1.Fastest("Node1", "Node4");
            Console.ReadKey();
            Console.WriteLine("\nGraph: critical");
            Task2.Fastest("A", "Z");
            Console.ReadKey();
            Console.WriteLine("\nArticulation Points\nGraph: fast");
            Task1.CriticalStation();
            Console.ReadKey();
            Console.WriteLine("\nGraph: critical");
            Task2.CriticalStation();

            Console.ReadKey();

        }
    }
}