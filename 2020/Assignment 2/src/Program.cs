/*
 * COIS 2020 Assignment 2
 * Priority Queues, and Huffman trees
 * Konrad Bartlett 0580964
 * Benjamin Keith 0623484
 * 2018 - 11 - 06
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)                                                // Run program continuously
            {
                Console.Write("Hello please enter a message: ");        // Welcome message
                String S = Console.ReadLine();                          // Take string input
                
                if(S == " ")
                {
                    break;
                }

                Huffman h = new Huffman(S);                             // Create Huffman tree

                String e = h.Encode(S);                                 // Encoded message
                Console.WriteLine("Encoded message: " + e);             // Write encoded message

                String d = h.Decode(e);                                 // Decoded message
                Console.WriteLine("Decoded message: " + d + "\n");      // Write decoded message
            }
        }
    }



    class Huffman
    {
        private Node HT;                                                        // Huffman tree to create codes and decode text
        private Dictionary<char, string> D = new Dictionary<char, string>();    // Dictionary to encode text

        public Huffman(string S)            // Huffman Constructor
        {
            int[] F = AnalyzeText(S);       // Count character frequencies
            Build(F);                       // Create Huffman Tree
            CreateCodes(HT, "");            // Generate code dictionary based on tree
        }

        // 15 marks
        // Return the frequency of each character in the given text (invoked by Huffman)
        private int[] AnalyzeText(string S)
        {
            int[] result = new int[255];    // INT array to hold all ASCII characters            

            foreach (char item in S)        // FOR every character in string
            {
                ++result[(int)item];        // Increment value at corresponding ASCII location in array
            }

            return result;                   // Return array
        }

        // 20 marks
        // Build a Huffman tree based on the character frequencies greater than 0 (invoked by Huffman)
        private void Build(int[] F)
        {
            PriorityQueue<Node> PQ = new PriorityQueue<Node>(255);      // Initialize priority queue to max size
            Node left, right;                                           // Placeholder nodes to generate priority nodes 
            
            for (int i = 0; i < F.Length; i++)                          // FOR length of array
            {   
                if (F[i] > 0)                                           // IF there is more than one occurence of character
                {
                    Node node = new Node((char)i, F[i], null, null);    // Create a new node for that character with frequency
                    PQ.Add(node);                                       // Add new node to priority queue
                }
            }

            if(PQ.Size() == 1)                                          // IF there is only 1 character
            {
                HT = PQ.Front();                                        // Huffman Tree is that character
                D.Add(HT.Character, "0");                               // Add character to dictionary with default code
            }

            while(PQ.Size() > 1)                                        // WHILE there are items in the priority queue (not root node)
            {       
                left = PQ.Front();                                      // Left node is the front of priority queue
                PQ.Remove();                                            // Remove front
                right = PQ.Front();                                     // Right is the next front
                PQ.Remove();                                            // Remove front

                PQ.Add(new Node('-', left.Frequency + right.Frequency, left, right));   // Add a new node that is the priority of both nodes
            }

            HT = PQ.Front();                                            // The tree root is the highest priority
        }

        // 20 marks
        // Create the code of 0s and 1s for each character by traversing the Huffman tree (invoked by Huffman)
        private void CreateCodes(Node p, string s)
        {
            if(HT == null)
            {
                return;
            }

            if(HT.Left == null)                     // IF only one character
            {
                return;                             // Code already in dictionary
            }

            if (p.Left == null)                     // IF leaf node
            {
                D.Add(p.Character, s);              // Add string value of path to character value in dictionary
            } else
            {
                CreateCodes(p.Left, s + '0');       // IF left add a 0
                CreateCodes(p.Right, s + '1');      // IF right add a 1
            }
            return;
        }

        // 10 marks
        // Encode the given text and return a string of 0s and 1s
        public string Encode(string S)
        {
            String result = "";                             // Create an empty string

            for (int i = 0; i < S.Length; i++)              // For characters in string
            {
                string value;                               // Create empty string to store path value
                D.TryGetValue((char)S[i], out value);       // TryGetValue return path where dictionary has character

                result = result + value;                    // Concat current sequence + path from TryGetValue
            }

            return result;
        }

        // 10 marks
        // Decode the given string of 0s and 1s and return the original text
        public string Decode(string S)
        {
            if(HT == null)
            {
                return null;
            }

            String result = "";                         // Create empty string
            Node placeholder = HT;                      // Reference to root node

            for(int i = 0; i < S.Length ; i++)          // For characters in string
            {
                if(HT.Left == null && HT.Right == null) // IF leaf node
                {
                    result = result + HT.Character;     // Add node character to result string
                    HT = placeholder;                   // Visit root node
                }

                if (S[i].Equals('0')) {                 // Traverse left subtree
                    HT = HT.Left;                       // Set current node to left node
                } else { 
                    HT = HT.Right;                      // Set current node to right node
                }
            }

            if (S.Length != 1)                          // IF message is longer than 1
            {
                result = result + HT.Character;         // Add last character outside of for loop (array index issue)
            }

            return result;                          
        }
    }
}
