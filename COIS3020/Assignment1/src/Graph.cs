using System;
using UnDirectedGraphAdjacencyList;

namespace _3020
{
    class Graph
    {
        public class SubwayMap
        {
            /// <summary>
            /// Creates a graph for use of a very basic test case showing that it takes the fastest path
            /// </summary>
            /// <returns>
            /// Builds Graph:
            /// 
            ///     Longest
            /// V1---V2---V3---V4
            ///   \           /
            ///     ---------
            ///     Shortest
            /// 
            /// </returns>
            public unDirectedGraph<String> fast()
            {
                // Instantiate Graph
                unDirectedGraph<String> H = new unDirectedGraph<String>();

                // Vertices
                H.InsertStation("Node1");     // V1
                H.InsertStation("Node2");     // V2
                H.InsertStation("Node3");   // V3
                H.InsertStation("Node4");    // V4

                // Long Path
                H.InsertLink("Node1", "Node2", "White");   // E1
                H.InsertLink("Node2 ", "Node3", "White"); // E2
                H.InsertLink("Node3", "Node4", "White");// E3

                // Short Path
                H.InsertLink("Node1", "Node4", "Black");  // E4
                
                return H;
            }

            /// <summary>
            /// Creates a graph for use of testing the critical points function
            /// </summary>
            /// <returns>
            /// Builds graph:
            /// 
            ///  A-----B
            ///   \   /
            ///     C   -Articulation point
            ///     |
            ///     D   -Articulation point
            ///     |
            ///     Z   -Articulatoin point
            ///   /   \
            ///  X-----Y
            /// 
            /// </returns>
            public unDirectedGraph<String> critical()
            {
                // Instantiate Graph
                unDirectedGraph<String> H = new unDirectedGraph<String>();

                // Triangle 1
                H.InsertStation("A");  // V1
                H.InsertStation("B");  // V2
                H.InsertStation("C");   // V3

                // Critical Point
                H.InsertStation("D");   // V3
                
                // Triangle 2
                H.InsertStation("X");  // V1
                H.InsertStation("Y");  // V2
                H.InsertStation("Z");   // V3
                
                // Edges
                H.InsertLink("A", "B", "White");   // E1
                H.InsertLink("A", "C", "White");   // E1
                H.InsertLink("B", "C", "White");   // E1
                H.InsertLink("C", "D", "Red");   // E1
                
                H.InsertLink("X", "Y", "Black");   // E1
                H.InsertLink("X", "Z", "Black");   // E1
                H.InsertLink("Y", "Z", "Black");   // E1
                H.InsertLink("Z", "D", "Red");   // E1
                
                return H;
            }
        }
    }
}
