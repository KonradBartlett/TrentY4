public class question2 {
    public static void main(String[] args) {
        int count = 0, hit = 0;
        double x, y;

        for (int i = 0; i < (1000001) ; i++) {
            x = Math.random();
            y = Math.random();
            count++;
            if ( x*x + y*y <= 1 )
                hit++;
            if(i == 100 || i == 1000 || i == 10000 || i == 100000 || i == 1000000)
                System.out.println(i+" darts, Pi: "+4*(double)hit/(double)count );
        }
    }
}