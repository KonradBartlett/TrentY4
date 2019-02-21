/**
 * Simulation of the Newspaper Seller System
 * Assignment Number 1, Question 1 for COIS 4470H/AMOD5230H
 */
import java.util.Random;
import java.util.Scanner;

public class NewspaperAssignment
{
    public static void main(String[] args) {
        while(true)
            simulate();
    }


    public static void simulate()
    {
        int NUM_DAYS=0;  //The number of days to simulate
        int NUM_BUY=0;   //The number of news papers to buy each day
        double totalProfit=0;//Total profit
        double priceBuy=0.33; //The price of each paper to buy
        double priceSell=0.50;//The price of each paper to sell
        double priceRecycle=0.05;//The price of each paper to recycle
        int dayDemand; //Number of papers demanded for the day
        int randDayType, randGoodDay, randFairDay, randPoorDay;
        Random rand=new Random();//Create an Object of the Random class
        //that will be used to generate random integers
        Scanner scan=new Scanner(System.in);//Create an object for input from keyboard
        System.out.println("Enter the number of papers to buy and press the enter key: ");
        NUM_BUY=scan.nextInt();//Read and store the integer entered
        System.out.println("Enter the number of days to simulate and press the enter key:");
        NUM_DAYS=scan.nextInt();//Read and store the integer entered
        System.out.println("This program simulates "+NUM_DAYS+
                " days with "+NUM_BUY+" papers to buy each day.");

        for(int i=0; i<NUM_DAYS; i++)//Iterate NUM_DAYs times
        {
            randDayType=rand.nextInt(100)+1;/*Generate an integer between 1
                                              & 100 for determining the day type
                                            */
            if (randDayType <= 35)//If it is a Good Day
            {
                randGoodDay = rand.nextInt(100) + 1;
                /*Add your code that generates a random integer between 1 &
                  100 and stores it in the variable randGoodDay for determining
                  the demand here
                */
                if (randGoodDay <= 3)
                    dayDemand = 40;
                else if (randGoodDay >= 4 && randGoodDay <= 8)
                    dayDemand = 50;
                else if (randGoodDay >= 9 && randGoodDay <= 23)
                    dayDemand = 60;
                else if (randGoodDay >= 24 && randGoodDay <= 43)
                    dayDemand = 70;
                else if (randGoodDay >= 44 && randGoodDay <= 78)
                    dayDemand = 80;
                else if (randGoodDay >= 79 && randGoodDay <= 93)
                    dayDemand = 90;
                else
                    dayDemand = 100;
            } else if (randDayType > 35 && randDayType <= 80)//Fair Day
            {
                randFairDay = rand.nextInt(100) + 1;

                if (randFairDay <= 3)
                    dayDemand = 40;
                else if (randFairDay >= 4 && randFairDay <= 8)
                    dayDemand = 50;
                else if (randFairDay >= 9 && randFairDay <= 23)
                    dayDemand = 60;
                else if (randFairDay >= 24 && randFairDay <= 43)
                    dayDemand = 70;
                else if (randFairDay >= 44 && randFairDay <= 78)
                    dayDemand = 80;
                else if (randFairDay >= 79 && randFairDay <= 93)
                    dayDemand = 90;
                else
                    dayDemand = 100;
            } else//Poor Day
            {
                randPoorDay = rand.nextInt(100) + 1;

                if (randPoorDay <= 44)
                    dayDemand = 40;
                else if (randPoorDay >= 43 && randPoorDay <= 22)
                    dayDemand = 50;
                else if (randPoorDay >= 21 && randPoorDay <= 16)
                    dayDemand = 60;
                else if (randPoorDay >= 15 && randPoorDay <= 12)
                    dayDemand = 70;
                else if (randPoorDay >= 11 && randPoorDay <= 6)
                    dayDemand = 80;
                else if (randPoorDay >= 5 && randPoorDay <= 0)
                    dayDemand = 90;
                else    //error
                    dayDemand = -1;
            }
            totalProfit += profit(dayDemand, NUM_BUY, priceBuy, priceSell, priceRecycle);
        }

        System.out.println("Number of Days: "+NUM_DAYS);
        System.out.println("Number of Papers Purchased Each Day: "+NUM_BUY);
        System.out.println("Total Profit: "+(int)(totalProfit*100)/100.0);
    }
    /*Calculate the profit of the dat with a penalty for ordering less than demand
     *@dayDemand the demand of the day
     *@numBuy the number of papers ordered that day
     *@priceBuy the price of each paper spent
     *@priceSell the price sold for each paper
     *@priceRecycle the price to recycle each paper
     *@return the total profit of the day including a penalty for ordering less
     */
    public static double profit(double dayDemand,
                                double numBuy,
                                double priceBuy,
                                double priceSell,
                                double priceRecycle)
    {
        double p=priceSell-priceBuy;//profit from each paper
        if(dayDemand>numBuy)
            return numBuy*p-(dayDemand-numBuy)*p;
        return  dayDemand*p+(numBuy-dayDemand)*(priceRecycle-priceBuy);
    }
}