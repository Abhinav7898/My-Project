import java.awt.Color;

import javax.swing.JFrame;

public class Main{
    public static void main(String[] args) {
        JFrame frame = new JFrame("Snake Game"); // Importing Java Frame
        frame.setBounds(10,10,905,700); // Setting the frame size
        frame.setResizable(false);// User cant resize it
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // Creating exit buttons

        GamePanel panel = new GamePanel();
        panel.setBackground(Color.DARK_GRAY); // This will change the background
        frame.add(panel);
        frame.setVisible(true); // This will visible our frame

    }
}