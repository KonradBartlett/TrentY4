import java.awt.*;
import java.awt.event.*;

public class Q1 extends  Frame implements KeyListener {

    int x = 0;
    int y = 0;

    public Q1(){

        setSize(500,500);
        setResizable(false);
        setMaximumSize(new Dimension(500,500));
        setMinimumSize(new Dimension(500,500));
        setLocationRelativeTo(null);

        addKeyListener(this);

        addWindowListener(new WindowAdapter() {
            @Override
            public void windowClosing(WindowEvent e) {
                System.exit(0);
            }
        });
    }


    public void paint(Graphics g){

        g.setColor(Color.black);

        g.fillRect(x,y,30,30);

        g.fillRect(x-494,y,30,30);
        g.fillRect(x+494,y,30,30);

        g.fillRect(x,y-471,30,30);
        g.fillRect(x,y+471,30,30);

        g.fillRect(x-494, y - 471, 30,30);
        g.fillRect(x-494, y + 471,30,30);
        g.fillRect(x+494,y-471,30,30);
        g.fillRect(x+494, y+471,30,30);

        System.out.println("X: " + x + " Y: " + y);

        if(x == -27){
            x = 467;
        } else if(x == 497){
            x = 3;
        }

        if(y == 497){
            y = 26;
        } else if(y == -30){
            y = 441;
        }
    }



    @Override
    public void keyTyped(KeyEvent ke) {
    }

    @Override
    public void keyPressed(KeyEvent ke) {

        int keyCode = ke.getKeyCode();

        switch(keyCode) {
            case KeyEvent.VK_W:
                y = y - 1;
                break;

            case KeyEvent.VK_A:
                x = x - 1;
                break;

            case KeyEvent.VK_S:
                y = y + 1;
                break;

            case KeyEvent.VK_D:
                x = x + 1;
                break;

            default:
                break;
        }
        repaint();
    }

    @Override
    public void keyReleased(KeyEvent ke) {
    }

    public static void main(String[] args) {

        new Q1().show();
    }
}
