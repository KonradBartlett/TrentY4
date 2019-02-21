import java.io.IOException;

import static java.lang.Math.abs;

public class Q2 {

    public static void main(String[] args) throws Exception {

        while (true) {
            System.out.println("Enter point a x");
            int x1 = Integer.valueOf(System.in.read()) - 48;

            System.out.println(x1+ "Enter point a y");
            System.in.read();
            System.in.read();
            int y1 = Integer.valueOf(System.in.read()) - 48;

            System.out.println(y1+"Enter point a z");
            System.in.read();
            System.in.read();
            int z1 = Integer.valueOf(System.in.read()) - 48;

            System.out.println(z1+"Enter point b x");
            System.in.read();
            System.in.read();
            int x2 = Integer.valueOf(System.in.read()) -48;

            System.out.println(x2+"Enter point b y");
            System.in.read();
            System.in.read();
            int y2 = Integer.valueOf(System.in.read()) -48;

            System.out.println(y2+"Enter point b z");
            System.in.read();
            System.in.read();
            int z2 = Integer.valueOf(System.in.read()) - 48;
            System.out.println(z2);

            if (Integer.valueOf(x1) >= 11 || Integer.valueOf(x1) <= -1 || Integer.valueOf(x2) >= 11 || Integer.valueOf(x2) <= -1) {
                System.out.println("Error in input data, values must be of type INT between 0 and 10");
            } else if (Integer.valueOf(y1) >= 11 || Integer.valueOf(y1) <= -1 || Integer.valueOf(y2) >= 11 || Integer.valueOf(y2) <= -1) {
                System.out.println("Error in input data, values must be of type INT between 0 and 10");
            } else if (Integer.valueOf(z1) >= 11 || Integer.valueOf(z1) <= -1 || Integer.valueOf(z2) >= 11 || Integer.valueOf(z2) <= -1) {
                System.out.println("Error in input data, values must be of type INT between 0 and 10");
            } else {
                bresenham(x1, y1, z1, x2, y2, z2);
                System.in.read();
            }
        }
    }

    private static void bresenham(int x1,int y1,int z1,int x2, int y2,int z2) throws Exception{


        int i, dx, dy, dz, l, m, n, x_inc, y_inc, z_inc,
            err_1, err_2, dx2, dy2, dz2;
        int[] pixel = new int[3];

        pixel[0] = x1;
        pixel[1] = y1;
        pixel[2] = z1;
        dx = x2 - x1;
        dy = y2 - y1;
        dz = z2 - z1;
        x_inc = (dx < 0) ? -1 : 1;
        l = abs(dx);
        y_inc = (dy < 0) ? -1 : 1;
        m = abs(dy);
        z_inc = (dz < 0) ? -1 : 1;
        n = abs(dz);
        dx2 = l << 1;
        dy2 = m << 1;
        dz2 = n << 1;

        if ((l >= m) && (l >= n)) {
            err_1 = dy2 - l;
            err_2 = dz2 - l;
            for (i = 0; i < l; i++) {
                System.out.println("(" + String.valueOf(pixel[0]) + ", " + String.valueOf(pixel[1]) + ", " + String.valueOf(pixel[2]) + ")");
                if (err_1 > 0) {
                    pixel[1] += y_inc;
                    err_1 -= dx2;
                }
                if (err_2 > 0) {
                    pixel[2] += z_inc;
                    err_2 -= dx2;
                }
                err_1 += dy2;
                err_2 += dz2;
                pixel[0] += x_inc;
            }
        } else if ((m >= l) && (m >= n)) {
            err_1 = dx2 - m;
            err_2 = dz2 - m;
            for (i = 0; i < m; i++) {
                System.out.println("(" + String.valueOf(pixel[0]) + ", " + String.valueOf(pixel[1]) + ", " + String.valueOf(pixel[2]) + ")");
                if (err_1 > 0) {
                    pixel[0] += x_inc;
                    err_1 -= dy2;
                }
                if (err_2 > 0) {
                    pixel[2] += z_inc;
                    err_2 -= dy2;
                }
                err_1 += dx2;
                err_2 += dz2;
                pixel[1] += y_inc;
            }
        } else {
            err_1 = dy2 - n;
            err_2 = dx2 - n;
            for (i = 0; i < n; i++) {
                System.out.println("(" + String.valueOf(pixel[0]) + ", " + String.valueOf(pixel[1]) + ", " + String.valueOf(pixel[2]) + ")");
                if (err_1 > 0) {
                    pixel[1] += y_inc;
                    err_1 -= dz2;
                }
                if (err_2 > 0) {
                    pixel[0] += x_inc;
                    err_2 -= dz2;
                }
                err_1 += dy2;
                err_2 += dx2;
                pixel[2] += z_inc;
            }
        }
        System.out.println("(" + String.valueOf(pixel[0]) + ", " + String.valueOf(pixel[1]) + ", " + String.valueOf(pixel[2]) + ")");
        System.in.read();
    }
}


