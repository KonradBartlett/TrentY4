/**
 * This program simulates a single server FIFO service node using exponentially 
 * distributed interarrival times and uniformly distributed service time.
 * Sample Output:
 * For 10000 jobs, 
 * the average interarrival time: 1.97
 * the average waiting time: 4.0
 * the average delay time: 2.5
 * the average service time: 1.49
 * the average # in the node: 2.03
 * the average # in the queue: 1.27
 * The percentage of time utilization: 75.0%
 * BUILD SUCCESSFUL (total time: 0 seconds)
 */
import java.util.Random;

public class SingleServerQueue
{
    private static double START=0.0;
    private static long LAST=100000;

    public static void main(String[] args){

        double t = 0, y = 0;    //Compile time specified time
        double time = 0;
        double curr = 0;

        long index=0;          /*Job index*/
        double arrival=START;  /*Time to arrive*/
        double delay;          /*Delay time in queue*/
        double service;        /*Service time of this job*/
        double wait;           /*Delay + service time*/
        double departure=START; /*Time to departure*/
        class Sum
        {
            double delay=0.0;
            double wait=0.0;
            double service=0.0;
            double interarrival; /*Interarrival time*/
        }
        Sum sum=new Sum(); //create an object of Sum
        while (index <LAST)
        {
            index++;

            if (295 < time && time < 305)
                t = index;
            if (4995 < time && time < 5005)
                y = index;

            arrival=getArrival(arrival);
            if(arrival<departure) {
                delay = departure - arrival;           /*Delay in queue*/
                if (curr < delay) {                 // If delay is larger than largest delay
                    curr = Math.round(delay);       // Set largest delay to delay
                }
            }
            else
                delay=0.0;                         /*No delay*/
            service=getService();
            wait=delay+service;
            departure=arrival + wait;              /*Time to departure*/
            sum.delay +=delay;                     /*Total delay*/
            sum.wait+=wait;                        /*Total waiting time*/
            sum.service+=service;                  /*Total service time*/

            time += service;
        }
        sum.interarrival=arrival -START;
        System.out.println("For "+index+" jobs, ");
        System.out.println("  the average interarrival time: "
                +quotient(sum.interarrival, index));
        System.out.println("  the average waiting time: "
                +quotient(sum.wait, index));
        System.out.println("  the average delay time: "
                +quotient(sum.delay, index));
        System.out.println("  the average service time: "
                +quotient(sum.service, index));
        System.out.println("  the average # in the node: "
                +quotient(sum.wait, departure));
        System.out.println("  the average # in the queue: "
                +quotient(sum.delay, departure));
        System.out.println("  the percentage of time utilization: "
                +quotient(sum.service, departure)*100+"%");

        // Question 2a
        System.out.println("  the maximum delay time:  "+curr);
        System.out.println("  the proportion of jobs delayed:  "
                + (Math.round((quotient(quotient(sum.interarrival, index), quotient(sum.service, index))) * 100.0) / 100.0));
        System.out.println("  the number of jobs at t=300:  "+Math.round(t));
        System.out.println("  the number of jobs at t=5000:  "+Math.round(y));

    }
    /**Find the quotient of two numbers
     * @param dividend the dividend of the quotient
     * @param divisor the divisor of the quotient
     * @return the quotient with two decimal places
     */
    public static double quotient(double dividend, double divisor)
    {
        return (int)((dividend/divisor)*100)/100.0;
    }
    /**Generate an exponential variate for m>0
     *@return a random number following the exponential distribution
     */
    public static double exponential(double m)
    {
        Random r=new Random();
        return (-m*Math.log(1.0-r.nextDouble()));
    }
    /**Generate a uniform variate between a and b for a<b
     *@param a the start point of the uniform variate
     *@param b the end point of the uniform variate
     *@return a random number between a and b following the uniform distribution
     */
    public static double uniform(double a, double b)
    {
        Random r=new Random();
        return a+(b-a)*r.nextDouble();
    }
    /**Generate the next arrival time using the exponential distribution
     * @param preArrival the arrival time of the previous job
     * @return the next arrival time 
     */
    public static double getArrival(double preArrival)
    {
        return preArrival+exponential(2.0);
    }
    /**Generate the next service time between 1 and 2 following the uniform distribution
     * @return a number between 1 and 2 following the uniform distribution
     */
    public static double getService()
    {
        return uniform(1.0, 2.0);
    }
}