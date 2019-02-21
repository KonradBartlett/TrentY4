import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

public class Q4 extends JFrame {

    private static BufferedImage image = null;

    private static JPanel panel1 = new JPanel();
    private static JPanel panel2 = new JPanel();
    private static JPanel panel3 = new JPanel();
    private static JPanel panel4 = new JPanel();

    public static class setPanel1 extends JComponent {

        private static final long serialVersionUID = 1L;

        setPanel1() {
            setPreferredSize(new Dimension(1000, 1000));
        }

        @Override
        public void paintComponent(Graphics g) {
            super.paintComponent(g);
            g.drawImage(image, 450, 400, null);
        }
    }

    public static class setPanel2 extends JPanel {

        private static final long serialVersionUID = 2L;

        setPanel2(){
            setPreferredSize(new Dimension(2000,1000));
        }

        protected void paintComponent(Graphics g) {
            super.paintComponent(g);
            int width = getWidth();
            int height = getHeight();
            for (int x = 0; x < width; x += image.getWidth()) {
                for (int y = 0; y < height; y += image.getHeight()) {
                    g.drawImage(image, x, y, null);
                }
            }
        }

    }

    public static class setPanel3 extends JComponent {

        private static final long serialVersionUID = 3L;

        setPanel3() {
            setPreferredSize(new Dimension(2000, 1000));
        }

        @Override
        public void paintComponent(Graphics g) {
            Graphics2D g2d = (Graphics2D) g;
            g2d.rotate(3*Math.PI, 500,500);
            super.paintComponent(g);
            g.drawImage(image, -550, 500, null);
        }
    }

    public static class setPanel4 extends JComponent {

        private static final long serialVersionUID = 4L;

        setPanel4() {
            setPreferredSize(new Dimension(2000, 1000));
        }

        @Override
        public void paintComponent(Graphics g) {
            super.paintComponent(g);
            g.drawImage(image, 1000, -6, 1000,1000,null);
        }
    }

    private Q4() {
        setDefaultCloseOperation(EXIT_ON_CLOSE);
        initMenu();
        setLayout(new BorderLayout());
    }



    private class MenuAction implements ActionListener {

        private JPanel panel;

        private MenuAction(JPanel pnl) {
            this.panel = pnl;
        }

        @Override
        public void actionPerformed(ActionEvent e) {
            changePanel(panel);

        }
    }

    private void initMenu() {
        JMenuBar menubar = new JMenuBar();
        JMenu menu = new JMenu("Menu (SRI CLICK HERE)");
        JMenuItem menuItem1 = new JMenuItem("Centered");
        JMenuItem menuItem2 = new JMenuItem("Tiled");
        JMenuItem menuItem3 = new JMenuItem("Flipped");
        JMenuItem menuItem4 = new JMenuItem("Stretched");
        menubar.add(menu);
        menu.add(menuItem1);
        menu.add(menuItem2);
        menu.add(menuItem3);
        menu.add(menuItem4);
        setJMenuBar(menubar);
        menuItem1.addActionListener(new MenuAction(panel1));
        menuItem2.addActionListener(new MenuAction(panel2));
        menuItem3.addActionListener(new MenuAction(panel3));
        menuItem4.addActionListener(new MenuAction(panel4));

    }

    private void changePanel(JPanel panel) {
        getContentPane().removeAll();
        getContentPane().add(panel, BorderLayout.CENTER);
        getContentPane().doLayout();
        update(getGraphics());
    }

    public static void main(String[] args) {

        try {
            image = ImageIO.read(new File("src\\image.png"));
        } catch (IOException e) {
            e.printStackTrace();
        }

        panel1.add(new setPanel1());
        panel2.add(new setPanel2());
        panel3.add(new setPanel3());
        panel4.add(new setPanel4());

        Q4 frame = new Q4();
        frame.add(panel2);
        frame.add(panel3);
        frame.add(panel4);
        frame.add(panel1);
        frame.pack();
        frame.setBounds(1000, 1000, 1000, 1000);
        frame.setLocationRelativeTo(null);
        frame.setResizable(false);
        frame.setVisible(true);

    }
}