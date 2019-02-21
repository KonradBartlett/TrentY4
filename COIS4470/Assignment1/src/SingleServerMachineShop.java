import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

/**
 * This program simulates a single-server machine shop using exponentially
 * distributed failure times, uniformly distributed service times and an FIFO
 * service queue
 * Sample Output:
 *  For a pool of 60 machines, and 10000 simulated failures,
 *  the average interarrival time: 1.73,
 *  the average waiting time: 5.21,
 *  the average delay time: 3.71,
 *  the average service time: 1.5,
 *  the average # in the node: 3.0,
 *  the average # in the queue: 2.14
 *  and the utilization rate: 86.0%.
 *  BUILD SUCCESSFUL (total time: 0 seconds)
 */

public class SingleServerMachineShop
{

    private static int TIME=1000;       // Time for simulation to run
    private static int LAST=10000;    /*Total number of machine failures*/
    private static double START=0.0;  /*Starting time                  */
    private static int M=100000;          /*Number of Machines             */
    public static void main(String[] args)
    {
        List list = new ArrayList();
        int spec = 0;
        int t = 0;
        double intarrive = 0;
        long index=0;                  /*Job (machine failure index)*/
        double arrival=START;          /*Time of arrival (failure) */
        double delay;                 /*Delay in repair queue      */
        double service;               /*Service (repair) time      */
        double wait;                  /*waiting time: delay +service*/
        double departure=START;       /*Time of service completion  */
        myInt m=new myInt();          /*Object containing the machine index*/
        double[] failure=new double[M]; /*List of next failure times*/
        class Sum
        {
            double wait=0.0;              /*total waiting time */
            double delay=0.0;             /*Total delay time   */
            double service=0.0;           /*Total service time   */
            double interarrival;          /*total interarrival time*/
        }
        Sum sum=new Sum();
        for(int i=0; i<M; i++)
            failure[i]=START + getFailure();

        while(index<LAST)
        {
            index++;

            if(intarrive < 0.1){
                t++;
            }

            if (995 < spec && spec < 1005)

            if (4995 < spec && spec < 5005)

            arrival  =nextFailure(failure, m);
            if(arrival<departure)
                delay=  departure -arrival;
            else
                delay = 0.0;
            service =getService();
            wait = delay +service;
            departure = arrival + wait;
            failure[m.getInt()]=departure +getFailure();
            sum.wait   +=wait;
            sum.delay  +=delay;
            sum.service +=service;

            spec+=service;
        }
        sum.interarrival= arrival - START;
        System.out.println("\n For a pool of "+M+" machines, and "+ index+
                " simulated failures"
                +",\n the average interarrival time: "+quotient(sum.interarrival, index)
                +",\n the average waiting time: "+quotient(sum.wait, index)
                +",\n the average delay time: " +quotient(sum.delay, index)
                +",\n the average service time: "+quotient(sum.service, index)
                +",\n the average # in the node: "+quotient(sum.wait, departure)
                +",\n the average # in the queue: "+quotient(sum.delay, departure)
                +"\n and the utilization rate: "+quotient(sum.service, departure)*100+"%.");

    }

    /**A simple class to carry an int value
     */
    static class myInt
    {
        int n;
        public void setInt(int n){this.n=n;}
        public int getInt(){return this.n;}
    }
    /**Find the quotient of two numbers with two decimal places
     * @param dividend the dividend of the quotient 
     * @param divisor the divisor of the quotient
     * @return the quotient with two decimal places for dividend/divisor
     */
    public static double quotient(double dividend, double divisor)
    {
        return  (int)(100*dividend/divisor)/100.0;
    }
    /**Generate a random exponential variate
     * @param m a multiplier >0
     * @return an exponential random variate
     */
    public static double exponential(double m)
    {
        return (-m*Math.log(1.0-Math.random()));
    }

    /** Generate a uniform random variate between a and b
     * @param a the start of the interval
     * @param b the end of the interval
     * @return a uniform random variate between a and b
     */
    public static double uniform(double a, double b)
    {
        return a+ (b-a)*Math.random();
    }

    /**Generate the operational time until nextfailure
     * @return the operational time until the next failure
     */
    public static double getFailure()
    {
        return exponential(100.0);
    }
    /**
     * Find the next failure time and index in the array
     * @param failure the array carrying the failure times
     * @param m an Integer object that carries the index of the failure time
     * @return the failure time
     */
    public static double nextFailure(double[] failure, myInt m)
    {
        double t= failure[0];
        int f = 0;
        m.setInt(0);
        for(int i=1; i<M; i++)
            if(failure [i]<t)
            {
                f++;
                t=failure[i];
                m.setInt(i);
            }
        System.out.println("Machine failures: "+f);
        return t;
    }
    /**Generates the next service time
     * @return the next service time
     */
    public static double getService()
    {
        return uniform(1.0, 2.0);
    }
}