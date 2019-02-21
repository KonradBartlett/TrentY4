/*
 * This program simulates a simple (s, S) inventory system using demand read from
 * a text file. Backlogging is permitted and there is no delivery lag. The output 
 * statics are the average demand and order per time interval (they should be equal), 
 * the relative frequency of setup and  the time averaged held (+) and short (-)
 * inventory levels.
 * Note: Use 0<=MINIMUM < MAXIMUM, i.e., 0<+s<S.
 * Sample output:
 * For 100 time intervals with an average demand of 2929.0 and policy parameters (20, 80), 
 * the average order: 29.29,
 * the setup frequency: 0.39,
 * the average holding level: 42.4 and 
 * the average shortage level: 0.24
 */

import java.io.File;
import java.util.Scanner;

public class sis1
{
    public static void main(String[] args) 
    {
        /*Data file name: fis1.dat*/
       final long MIMIMUM=0;   /*'s' inventory policy*/    //minimum # cars
       final long MAXIMUM = 80; /* 'S' inventory policy*/   // maximum # cars
       long inventory=MAXIMUM;  /*Current inventory level */
       long demand;             /*Amount of demand        */
       long order;              /*Amount of order         */
       long index =0;           /*time interval index     */
       class Sum
       {
           double setup;         /*setup instances    */
           double holding;       /*inventory held (+) */
           double shortage;     /* inventory short (=) */
           double order;        /* orders             */
           double demand;      /* demands            */
       }
       class Cost
       {
           double setup;
           double holding;
           long shortage;
           long order;
           long demand;
       }
       Cost c = new Cost();
       Sum sum=new Sum();
       try
       {
        Scanner input=new Scanner(new File("src/sis1.dat")); /* Open file */
        while(input.hasNextInt())                        /*while not end of file*/
        {
            index++;
            if(inventory < MIMIMUM)                    /*Place an order */
            {
                order = MAXIMUM - inventory;
                sum.setup++;
                //sum.order += order;


/// Q1A    Q1D
                if(order <= 70)
                    c.setup += 1000;                    // Every time an order to placed, charge setup
                else
                    c.setup += 1200;
            }
            else                                       /* No order */
                order =0;
            inventory  += order;                   /*there is no delivery lag */
/// Q1F
            c.shortage = c.order;
            demand = input.nextInt() + c.shortage;              /*Read a demand  from file */
            sum.demand += demand;
            if(inventory > demand )
                sum.holding += inventory - 0.5*demand; 
            else
            {
                sum.holding +=sqr(inventory)/(2.0*demand);

/// Q1E
                c.demand += demand - inventory;
/// Q1F
                c.order = demand - inventory;
            }
            inventory  -= demand;

/// Q1A
            c.holding += inventory * 25;            // Holding cost is the number of cars * $25
        }


        if(inventory < MAXIMUM )          /*force the final inventory */
        {                                 /* to match the initial inventory*/
            order = MAXIMUM - inventory;
            sum.setup ++;
            sum.order +=order;
            inventory +=order;
        }
       }catch(Exception e)
       {
           System.out.println(e.getMessage());
       }

       System.out.println(" For "+index +" time intervals with an average demand of "
                            +sum.demand+" and policy parameters ("+MIMIMUM+", "
                            +MAXIMUM+"), "
                            +"\n the average order: "+quotient(sum.order, index)
                            +"\n the setup frequency: "+quotient(sum.setup, index)
                            +"\n the average holding level: "+quotient(sum.holding, index)
                            +"\n the average shortage level: "+quotient(sum.shortage, index)
                            +"\n the average holding cost: $"+quotient(c.holding, index)
                            +"\n the average shortage cost: $" +quotient(Math.round(sum.shortage * 700), index)  /// Q1A number of cars short * 700
                            +"\n the average setup cost: $"+quotient(c.setup, index)
                            +"\n the average unit cost: $"+quotient(Math.round(sum.order * 8000), index)
                            +"\n the number of unsatisfied customers: "+ c.demand); /// Q1A number of cars ordered * 8000
    }
    public static double sqr(double x)
    {
        return x*x;
    }
    
    public static double quotient(double a, double b)
    {
       return ((int) (a/b*100))/100.0;
    }
}