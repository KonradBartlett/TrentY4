using System;

public class Node<T>
{
    private T item;
    private Node<T> next;

    public Node(T item, Node<T> next) //A Node contains a generic item (the Term), and a reference to another Node containing another generic item (another Term).
    {
        this.item = item;
        this.next = next;
    }

    //Read and write properties for each data member
    public T Item
    {
        get { return item; }
        set { item = value; }
    }

    public Node<T> Next
    {
        get { return next; }
        set { next = value; }
    }
}