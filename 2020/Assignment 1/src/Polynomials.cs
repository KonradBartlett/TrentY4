using System;
using System.Collections.Generic;
using Assignment_1;


public class Polynomials
{
    private List<Polynomial> P;

    private int polycount;
    public int Polycount
    {
        get { return P.Count; }
        set { polycount = value; }
    }
    //creates an empty list of polynomials
    public Polynomials()
    {
        this.P = new List<Polynomial>();
        Polycount++;
    }

    //Retrieves the polynomial stored at position i-1 in the list
    public Polynomial Retrieve (int i)
    {
        if (i <= 0)
            throw new ArgumentException("i less than or equal to 0 in Retrieve method");
        int index = i - 1;
        return P[index];
    }

    //Inserts polynomial p into the list of polynomials ordered by degree
    public void Insert (Polynomial p)
    {
        bool evaluation = false;
        for (int i = 0; i < (P.Count); i++)
        {
            evaluation = p.Order(P[i]);
            if (evaluation == true)
            {
                P.Insert(i, p);
                return;
            }
        }
        if (evaluation == false)
        {
            P.Insert(P.Count, p);
        }
    }

    //Deletes the polynomial at index i-1
    public void Delete (int i)
    {
        if (i <= 0)
            throw new ArgumentException("i less than or equal to 0 in Delete method.");
        int index = i - 1;
        P.RemoveAt(index);
    }

    //Prints out the list of polynomials (beginning with polynomial 1)
    public void Print()
    {
        for (int i = 0; i < P.Count; i++)
        {
            Console.Write("{0}: ", (i+1));
            P[i].Print();
            Console.WriteLine();
        }
    }
}