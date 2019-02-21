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

class Node : IComparable
{
    public char Character { get; set; }
    public int Frequency { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(char character, int frequency, Node left, Node right)
    {
        Character = character;
        Frequency = frequency;
        Left = left;
        Right = right;
    }

    public int CompareTo(Object obj)
    {
        if (obj is Node)
        {
            Node aux = obj as Node;
            if (Frequency > aux.Frequency)
                return 1;
            else if (Frequency < aux.Frequency)
                return -1;
            else
                return 0;
        }
        else
            return 0;
    }
}