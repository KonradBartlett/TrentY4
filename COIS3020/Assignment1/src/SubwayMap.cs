using System;
using System.Collections.Generic;

namespace UnDirectedGraphAdjacencyList
{
    public class Edge<T>
    {
        public Vertex<T> AdjVertex { get; set; }
        public string Color { get; set; }

        public Edge(Vertex<T> vertex, string colour)
        {
            AdjVertex = vertex;
            Color = colour;
        }
    }

    //---------------------------------------------------------------------------------------------

    public class Vertex<T>
    {
        public T Name { get; set; }              // Vertex name
        public bool Visited { get; set; }
        public List<Edge<T>> E { get; set; }     // List of adjacency vertices

        public Vertex(T name)
        {
            Name = name;
            Visited = false;
            E = new List<Edge<T>>();
        }

        // FindEdge
        // Returns the index of the given adjacent vertex in E; otherwise returns -1
        // Time complexity: O(n) where n is the number of vertices

        public int FindEdge(T name)
        {
            int i;
            for (i = 0; i < E.Count; i++)
            {
                if (E[i].AdjVertex.Name.Equals(name))
                    return i;
            }
            return -1;
        }
    }

    //---------------------------------------------------------------------------------------------

    public interface IunDirectedGraph<T>
    {
        void InsertStation(T name);
        void RemoveVertex(T name);
        void InsertLink(T name1, T name2, string color);
        void DeleteLink(T name1, T name2);
    }

    //---------------------------------------------------------------------------------------------

    public class unDirectedGraph<T> : IunDirectedGraph<T>
    {
        private List<Vertex<T>> V;
        private int time = 0;

        public unDirectedGraph()
        {
            V = new List<Vertex<T>>();
        }

        // FindVertex
        // Returns the index of the given vertex (if found); otherwise returns -1
        // Time complexity: O(n)

        private int FindVertex(T name)
        {
            int i;

            for (i = 0; i < V.Count; i++)
            {
                if (V[i].Name.Equals(name))
                    return i;
            }
            return -1;
        }

        // AddVertex
        // Adds the given vertex to the graph
        // Note: Duplicate vertices are not added
        // Time complexity: O(n) due to FindVertex

        public void InsertStation(T name)
        {
            if (FindVertex(name) == -1)
            {
                Vertex<T> v = new Vertex<T>(name);
                V.Add(v);
            }
        }

        // RemoveVertex
        // Removes the given vertex and all incident edges from the graph
        // Note:  Nothing is done if the vertex does not exist
        // Time complexity: O(max(n,m)) where m is the number of edges

        public void RemoveVertex(T name)
        {
            int i, j, k;
            if ((i = FindVertex(name)) > -1)
            {
                for (j = 0; j < V.Count; j++)
                {
                    for (k = 0; k < V[j].E.Count; k++)
                        if (V[j].E[k].AdjVertex.Name.Equals(name))   // Incident edge
                        {
                            V[j].E.RemoveAt(k);
                            break;  // Since there are no duplicate edges
                        }
                }
                V.RemoveAt(i);
            }
        }

        // AddEdge
        // Adds the given edge (name1, name2) to the graph
        // Notes: Duplicate edges are not added
        //        By default, the cost of the edge is 0
        // Time complexity: O(n)

        public void InsertLink(T from, T to, string color = "White")
        {
            int i, j;
            Edge<T> e;
            Edge<T> d;

            // Do the vertices exist?
            if ((i = FindVertex(from)) > -1 && (j = FindVertex(to)) > -1)
            {
                // Does the edge not already exist?
                if (V[i].FindEdge(to) == -1)
                {
                    e = new Edge<T>(V[j], color);
                    d = new Edge<T>(V[i], color);
                    V[i].E.Add(e);
                    V[j].E.Add(d);
                }
            }
        }

        // RemoveEdge
        // Removes the given edge (name1, name2) from the graph
        // Note: Nothing is done if the edge does not exist
        // Time complexity: O(n)

        public void DeleteLink(T from, T to)
        {
            int i, j;
            if ((i = FindVertex(from)) > -1 && (j = V[i].FindEdge(to)) > -1)
                V[i].E.RemoveAt(j);
        }

        // Referenced from https://www.geeksforgeeks.org/articulation-points-or-cut-vertices-in-a-graph/
        private void CriticalStation(Vertex<T> u, bool[] visited, int[] disc, int[] low, Vertex<T>[] parent, bool[] ap)
        {

            // Count of children in DFS Tree 
            int children = 0;

            // Mark the current node as visited 
            visited[FindVertex(u.Name)] = true;

            // Initialize discovery time and low value 
            disc[FindVertex(u.Name)] = low[FindVertex(u.Name)] = ++time;

            // Go through all vertices aadjacent to this 
            for(int i = 0; i < u.E.Count; i++)
            {
                Vertex<T> v = u.E[i].AdjVertex;  // v is current adjacent of u 

                // If v is not visited yet, then make it a child of u 
                // in DFS tree and recur for it 
                if (!visited[FindVertex(v.Name)])
                {
                    children++;
                    parent[FindVertex(v.Name)] = u;
                    CriticalStation(v, visited, disc, low, parent, ap);

                    // Check if the subtree rooted with v has a connection to 
                    // one of the ancestors of u 
                    low[FindVertex(u.Name)] = Math.Min(low[FindVertex(u.Name)], low[FindVertex(v.Name)]);

                    // u is an articulation point in following cases 

                    // (1) u is root of DFS tree and has two or more chilren. 
                    if (parent[FindVertex(u.Name)] == null && children > 1)
                        ap[FindVertex(u.Name)] = true;

                    // (2) If u is not root and low value of one of its child 
                    // is more than discovery value of u. 
                    if (parent[FindVertex(u.Name)] != null && low[FindVertex(v.Name)] >= disc[FindVertex(u.Name)])
                        ap[FindVertex(u.Name)] = true;
                }

                // Update low value of u for parent function calls. 
                else if (v != parent[FindVertex(u.Name)])
                    low[FindVertex(u.Name)] = Math.Min(low[FindVertex(u.Name)], disc[FindVertex(v.Name)]);
            }
        }

        // Reference https://www.geeksforgeeks.org/articulation-points-or-cut-vertices-in-a-graph/
        // The function to do DFS traversal. It uses recursive function CriticalStation() 
        public void CriticalStation()
        {
            // Mark all the vertices as not visited 
            bool[] visited = new bool[V.Count];
            int[] disc = new int[V.Count];
            int[] low = new int[V.Count];
            Vertex<T>[] parent = new Vertex<T>[V.Count];
            bool[] ap = new bool[V.Count]; // To store articulation points 

            // Initialize parent and visited, and ap(articulation point) 
            // arrays 
            for (int i = 0; i < V.Count; i++)
            {
                parent[i] = null;
                visited[i] = false;
                ap[i] = false;
            }

            // Call the recursive helper function to find articulation 
            // points in DFS tree rooted with vertex 'i' 
            for (int i = 0; i < V.Count; i++)
                if (visited[i] == false)
                    CriticalStation(V[i], visited, disc, low, parent, ap);

            // Now ap[] contains articulation points, print them 
            for (int i = 0; i < V.Count; i++)
                if (ap[i] == true)
                    Console.WriteLine(V[i].Name + " ");
        }
        
        public void Fastest(string v, string u)
        {
            Vertex<T> from = null, to = null;
            for(int i = 0; i < V.Count; i++)
            {
                if (V[i].Name.Equals(v))
                {
                    from = V[i];
                }
                if (V[i].Name.Equals(u))
                {
                    to = V[i];
                }
                if (from != null && to != null)
                {
                    //Console.WriteLine(from.Name.ToString() + to.Name);
                    Fastest(from, to);
                }
            }
        }
        
        public void Fastest(Vertex<T> from, Vertex<T> to)
        {
            Vertex<T>[] vertices = new Vertex<T>[V.Count];
            Queue<Vertex<T>> queue = new Queue<Vertex<T>>();
            Stack<Vertex<T>> stack = new Stack<Vertex<T>>();


            for (int i = 0; i < V.Count; i++)
            {
                vertices[i] = null;
            }

            int start = FindVertex(from.Name);
            vertices[start] = from;

            queue.Enqueue(from);

            Vertex<T> current, neighbour;

            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                for (int i = 0; i < current.E.Count; i++)
                {
                    neighbour = current.E[i].AdjVertex;
                    if (vertices[FindVertex(neighbour.Name)] == null)
                    {
                        vertices[FindVertex(neighbour.Name)] = current;    // store the current station as the previously visited station for all of its neighbours
                        queue.Enqueue(neighbour);



                    }
                }
            }
            
            GetPath(stack, vertices, to);

            for (int i = stack.Count; i > 1; i--)
            {
                current = stack.Pop();

                Edge<T> next = current.E[current.FindEdge(stack.Peek().Name)];

                Console.WriteLine(current.Name + " -> " + next.Color);
            }

            current = stack.Pop();

            Console.WriteLine(current.Name);
        }

        // GetPath
        // Recursively pushes stations in the specified path onto a stack
        public Vertex<T> GetPath(Stack<Vertex<T>> stack, Vertex<T>[] visited, Vertex<T> current)
        {
            // if the previous station is the same as current, we have reached the beginning of the path
            if (visited[FindVertex(current.Name)] == current)
            {
                stack.Push(current);
                return current;
            }
            stack.Push(current);
            return GetPath(stack, visited, visited[FindVertex(current.Name)]);
        }
        
        // Print
        // Prints out the graph
        // Time complexity: O(m)

        public void Print()
        {
            int i, j, p = 0;
            String result = "";
            for (i = 0; i < V.Count; i++)
            {
                for (j = 0; j < V[i].E.Count; j++)
                {
                    Console.WriteLine(V[i].Name + "\t" + V[i].E[j].AdjVertex.Name + "\t" + V[i].E[j].Color);
                }
            }
            Console.Write("\n\n");
            //return result;
        }
    }
}