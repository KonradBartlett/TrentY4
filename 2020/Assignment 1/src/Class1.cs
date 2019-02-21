using Assignment_1;
using System;

interface IDegree
{
    bool Order(Object obj);
}

public class Polynomial : IDegree
{
    // A reference to the first node of a singly-linked list
    private Node<Term> front;

    //Creates the polynomial 0
    public Polynomial()
    {
        Term item = new Term(0, 0);
        Node<Term> front = new Node<Term>(item, null);
    }

    //Inserts the given term t into the current polynomial in its proper order
    public Polynomial AddTerm(Term t)
    {
        Node<Term> currentNode = front;     //currentNode is a reference to Nodes that moves through the linkedlist.
        int comparison; //holds value from Term.CompareTo
        Node<Term> previousNode = null;
        do
        {
            comparison = t.CompareTo(currentNode.Item);
            if (comparison == -1)
            {
                previousNode = currentNode;             //Grabs current node to update it's Next property to new node t (maybe).
                currentNode = currentNode.Next;         //Moves pointer to next node in linked list if Term t is less than current Term.
            }

        } while (comparison == -1);         //Loops while Term t is less than the term being pointed at.

        if (comparison == 1)
        {
            Node<Term> node = new Node<Term>(t, currentNode);       //When Term t is greater than current Term, create a new node with node.Next = currentNode 
            if (previousNode == null)                               //If there is no prior node, make Term t's node the front of the linked list
                front = node;
            else
                previousNode.Next = node;                           // If there IS a prior node, set it's Next property equal to the newly created node.
        }

        else if (comparison == 0)
        {
            currentNode.Item.Coefficient += t.Coefficient;
        }
        
        return this;
    }

    // Adds the given polynomials p and q to yield a new polynomial
    public static Polynomial operator +(Polynomial p, Polynomial q)
    {
        Polynomial z = new Polynomial();        //Creates new Polynomial z
        Node<Term> currentNode = p.front;       //sets a pointer to the front of p's linked list

        while (currentNode != null)          //DO WHILE currentNode EXISTS
        {
            z.AddTerm(currentNode.Item);    //Add terms from p to z
            currentNode = currentNode.Next;
        }

        currentNode = q.front;
        while (currentNode != null)          //DO WHILE currentNode EXISTS
        {
            z.AddTerm(currentNode.Item);    //Add terms from q to z
            currentNode = currentNode.Next;
        }

        return z;
    }

    // Multiplies the given polynomials p and q to yield a new polynomial
    public static Polynomial operator *(Polynomial p, Polynomial q)
    {
        Polynomial z = new Polynomial();
        Node<Term> currentPNode = p.front; //needs two pointers to multiply the two polynomials together
        Node<Term> currentQNode = q.front;

        while (currentPNode != null)
        {
            while (currentQNode != null)
            {
                double newCoefficient = currentPNode.Item.Coefficient * currentQNode.Item.Coefficient;      //Multiplying every combination of coefficients of p & q together.
                byte newExponent = (byte)(currentPNode.Item.Exponent + currentQNode.Item.Exponent);         //Adding every combination of exponents of p & q together. Adding bytes together becomes an int, therefore you must explicitly cast to a byte.
                Term newTerm = new Term(newCoefficient, newExponent);                                       // Creates new Term with previous values
                z.AddTerm(newTerm);                     // Adds newTerm to Polynomial z
                currentQNode = currentQNode.Next;       // Iterates over to next Node in Polynomial q
            }
            currentPNode = currentPNode.Next;       // Iterates over to next Node in Polynomial p
        }
        return z;
    }

    // Evaluates the current polynomial for a given x
    public double Evaluate(double x)
    {
        double evaluatePolynomial = 0;
        Node<Term> currentNode = this.front;

        while (currentNode != null)         // Iterates through nodes.
        {
            evaluatePolynomial += currentNode.Item.Evaluate(x);     //Sums up terms in Polynomial for a given x
            currentNode = currentNode.Next;
        }
        return evaluatePolynomial;          //Returns sum.
    }

    //Prints the current polynomial
    public void Print()
    {
        Node<Term> currentNode = this.front;

        while (currentNode != null)             //Iterates through nodes
        {
            if (currentNode.Item.Coefficient != 0)  //If term == 0, skip it
            {
                if (currentNode.Item.Exponent != 0) //If exponent == 0, write 1
                    Console.Write("(({0})x^{1})", currentNode.Item.Coefficient, currentNode.Item.Exponent);
                else
                    Console.Write("1");

                if (currentNode.Next != null) // Write " + " if there is another term.
                {
                    Console.Write(" + ");
                }
            }
            currentNode = currentNode.Next;
        }
    }

    public bool Order(Object obj)
    {
        if (obj == null)
            return true;
        Polynomial comparedPolynomial = obj as Polynomial;    //obj must become an instance of type Polynomial to compare
        if (comparedPolynomial == null)           //Check to see if obj successfully changed to Polynomial, if not - throw exception
            throw new ArgumentException("obj is not a Polynomial! Pass a Polynomial Object to Order method");

        if (this.front.Item.Exponent >= comparedPolynomial.front.Item.Exponent)     // If this polynomial has a degree that is larger than or equal to the compared polynomial return true.
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
