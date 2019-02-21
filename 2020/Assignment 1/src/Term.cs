using System;

//Capital O object is the class
//lowercase o object is the instance or an 'object' of a type

namespace Assignment_1
{
    public class Term : IComparable
    {
        private double coefficient;
        private byte exponent;

        //Constructor
        // Creates a term with the given coefficient and exponent
        public Term(double coefficient, byte exponent)
        {
            this.coefficient = coefficient;
            this.exponent = exponent;
        }

        //Evaluates the current term for a given x
        public double Evaluate(double x)
        {
            return this.coefficient * Math.Pow(x, this.exponent);
        }

        //Return -1, 0, or 1 if the exponent of the current term
        // is less than, equal to, or greater than the exponent of obj.
        public int CompareTo(Object obj)
        {
            if (obj == null)
                return 1;
            Term comparedTerm = obj as Term;    //obj must become an instance of type Term to use CompareTo
            if (comparedTerm == null)           //Check to see if kbj successfully changed to Term, if not - throw exception
                throw new ArgumentException("obj is not a Term! Pass a Term Object to CompareTo method");
            else
                return this.exponent.CompareTo(comparedTerm.Exponent);  //Uses built in Byte.CompareTo for Exponent property of this object.
        }

        //Read and write properties for each data member
        public double Coefficient
        {
            get { return coefficient; }
            set { coefficient = value; }
        }
        
        public byte Exponent
        {
            get { return exponent; }
            set { exponent = value; }
        }
    }
}