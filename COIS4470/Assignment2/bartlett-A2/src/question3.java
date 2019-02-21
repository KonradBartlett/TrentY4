public class question3 {
    public static void main(String[] args) {
        int high, low;
        double side[] = new double[6];

        for(int i = 0; i < 1000; i++){
            high = 0;

            for(int s = 0; s < 7; s++){
                low = (int)(Math.random() * 6);
                if(high < low)
                    high = low;
                System.out.println(high);
            }
        side[high]++;
        }
        for(int i = 0; i < side.length; i++){
            System.out.println("Side "+i+": "+(side[i]/10));
        }
    }
}