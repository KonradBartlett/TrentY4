using System;
using System.Collections.Generic;
using Assignment_1;

public class Assignment_Main
{
    public static void Main()
    {
        Polynomials P = new Polynomials();
        string userInput = null;
        char userOutput;

        do
        {
            Console.WriteLine("Please select an action. You may: \n 'C'reate a polynomial and insert it into the list. \n 'A'dd two polynomials and insert the sum into the list. " +
                "\n 'M'ultiply two polynomials and insert the product into the list. \n 'D'elete a polynomial. \n 'E'valuate a polynomial. \n 'Q'uit the program.");

            Console.WriteLine("\n Current Polynomials: ");
            P.Print();
            Console.WriteLine();
            Console.Write("Enter action. >> ");

            userInput = Console.ReadLine();
            while(!char.TryParse(userInput, out userOutput))
            {
                Console.Write("Please enter a single character. >> ");
                userInput = Console.ReadLine();
            }
            
            switch (Char.ToUpper(userOutput))
            {
                case 'C':
                    {
                        P = CreatePolynomial(P);
                        P.Print();
                        Console.WriteLine();
                        break;
                    }
                case 'A':
                    {
                        AddPolynomials(P);
                        Console.WriteLine();
                        break;
                    }
                case 'M':
                    {
                        MultiplyPolynomials(P);
                        Console.WriteLine();
                        break;
                    }
                case 'D':
                    {
                        DeletePolynomial(P);
                        Console.WriteLine();
                        break;
                    }
                case 'E':
                    {
                        EvaluatePolynomial(P);
                        Console.WriteLine();
                        break;
                    }
                case 'Q':
                    {
                        Console.WriteLine("Exiting Program.");
                        Console.ReadLine();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Error. Please input a valid command.");
                        Console.WriteLine();
                        break;
                    }
            }
        } while (char.ToUpper(userOutput) != 'Q');
    }

    public static Polynomials CreatePolynomial(Polynomials P)
    {                                                                                    
        string coefficientInput, exponentInput = null;
        string userInput = null;
        char userOutput = 'F';
        double newCoefficient;
        byte newExponent;

        Polynomial newPoly = new Polynomial();

        do
        {
            Console.WriteLine("'A'dd a term to the polynomial. \n 'F'inish the polynomial.");
            Console.Write("Please enter an action. >> ");
            userInput = Console.ReadLine();

            while(!char.TryParse(userInput, out userOutput))
            {
                Console.Write("Invalid input. Please enter a single character. >> ");
                userInput = Console.ReadLine();
            }

            switch (char.ToUpper(userOutput))
            {
                case 'A':
                    {
                        Console.Write("Enter a value for the coefficient. >> ");
                        coefficientInput = Console.ReadLine();

                        while (!double.TryParse(coefficientInput, out newCoefficient))
                        {
                            Console.Write("Input invalid. Please enter a double. >> ");
                            coefficientInput = Console.ReadLine();
                        }

                        Console.Write("Enter a value for the exponent. >> ");
                        exponentInput = Console.ReadLine();

                        while (!byte.TryParse(exponentInput, out newExponent))
                        {
                            Console.Write("Input invalid. Please enter a number between 0 and 255. >> ");
                            exponentInput = Console.ReadLine();
                        }

                        Term newTerm = new Term(newCoefficient, newExponent);
                        newPoly.AddTerm(newTerm);
                        break;
                    }
                case 'F':
                    {
                        P.Insert(newPoly);
                        return P;
                    }
                default:
                    {
                        Console.WriteLine("Error, please input a valid command.");
                        Console.WriteLine();
                        break;
                    }
            }
        } while (char.ToUpper(userOutput) != 'F');
        return P;
}

    public static void AddPolynomials(Polynomials P)
    {
        string aInput, bInput = null;
        int aOutput, bOutput = 0;

        if (P.Polycount == 0)
            Console.WriteLine("No polynomials!");
            else
            {
                Polynomial newPoly = new Polynomial();

                do
                {
                    Console.Write("Please input the first polynomial's index. >> ");
                    aInput = Console.ReadLine();

                    while (!Int32.TryParse(aInput, out aOutput))
                    {
                        Console.Write("Invalid input, please enter an appropriate index. >> ");
                        aInput = Console.ReadLine();
                    }
                } while (aOutput <= 0 || aOutput > P.Polycount);

                do
                {
                    Console.Write("Please input the second polynomial's index. >> ");
                    bInput = Console.ReadLine();
                    while (!Int32.TryParse(bInput, out bOutput))
                    {
                        Console.Write("Invalid input, please enter an int greater than 0. >> ");
                        bInput = Console.ReadLine();
                    }
                } while (bOutput <= 0 || bOutput > P.Polycount);

                newPoly = P.Retrieve(aOutput) + P.Retrieve(bOutput);
                P.Insert(newPoly);
            }
    }

    public static void MultiplyPolynomials(Polynomials P)
    {
        string aInput, bInput = null;
        int aOutput, bOutput;
        Polynomial newPoly = new Polynomial();

        if (P.Polycount == 0)
            Console.WriteLine("No polynomials!");
        else
        {
            do
            {
                Console.Write("Please input the first polynomial's index. >> ");
                aInput = Console.ReadLine();
                while (!Int32.TryParse(aInput, out aOutput))
                {
                    Console.Write("Input invalid. Please enter an integer greater than 0. >> ");
                    aInput = Console.ReadLine();
                }
            } while (aOutput <= 0 || aOutput > P.Polycount);

            do
            {
                Console.Write("Please input the second polynomial's index. >> ");
                bInput = Console.ReadLine();
                while (!Int32.TryParse(bInput, out bOutput))
                {
                    Console.Write("Input invalid. Please enter an integer greater than 0. >> ");
                    bInput = Console.ReadLine();
                }
            } while (bOutput <= 0 || bOutput > P.Polycount);

            newPoly = P.Retrieve(aOutput) * P.Retrieve(bOutput);
            P.Insert(newPoly);
        }
    }

    public static void DeletePolynomial(Polynomials P)
    {
        string aInput = null;
        int aOutput = 0;

        if (P.Polycount == 0)
            Console.WriteLine("No polynomials!");
        else
        {
            do
            {
                Console.Write("Please input the index of the polynomial which you would like to delete. >> ");
                aInput = Console.ReadLine();
                while (!Int32.TryParse(aInput, out aOutput))
                {
                    Console.Write("Invalid input. Please enter an integer greater than 0. >> ");
                    aInput = Console.ReadLine();
                }
            } while (aOutput <= 0 || aOutput > P.Polycount);

            P.Delete(aOutput);
        }
    }

    public static void EvaluatePolynomial(Polynomials P)
    {
        string aInput, bInput = null;
        int aOutput;
        double bOutput;

        if (P.Polycount == 0)
            Console.WriteLine("No polynomials!");
        else
        {
            do
            {
                Console.Write("Please input the polynomial's index. >> ");
                aInput = Console.ReadLine();
                while (!Int32.TryParse(aInput, out aOutput))
                {
                    Console.Write("Input invalid. Please enter an integer greater than 0. >> ");
                    aInput = Console.ReadLine();
                }
            } while (aOutput <= 0 || aOutput > P.Polycount);

            Console.Write("Please input the value for x. >> ");
            bInput = Console.ReadLine();
            while (!double.TryParse(bInput, out bOutput))
            {
                Console.Write("Input invalid. Please enter a double. >> ");
                bInput = Console.ReadLine();
            }

            Console.WriteLine("The polynomial evaluates to: {0}", P.Retrieve(aOutput).Evaluate(bOutput));
        }
        
    }
}