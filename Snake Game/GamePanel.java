import javax.swing.ImageIcon;
import javax.swing.JPanel;
import javax.swing.Timer;

import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.util.Random;

public class GamePanel extends JPanel implements ActionListener,KeyListener{
    private int[] snakeXlength = new int[750];
    private int[] snakeYlength = new int[750];
    private int lengthOfSnake = 3;

    // Enemy Position
    int xPos[] = {25,50,75,100,125,150,175,200,225,250,275,300,325,350,375,400,425,450,475,500,525,550,575,600,625,650,675,700,725,750,775,800,825,850};
    int yPos[] = {75,100,125,150,175,200,225,250,275,300,325,350,375,400,425,450,475,500,525,550,575,600,625};

    private Random random = new Random();
    private int enemyXpos,enemyYpos;

    private boolean left = false; 
    private boolean right = true; 
    private boolean up = false; 
    private boolean down = false; 

    private int moves = 0;
    private int score = 0;
    private boolean gameOver = false;

    private ImageIcon snakeTitle = new ImageIcon(getClass().getResource("Image/snaketitle.jpg"));
    private ImageIcon leftMouth = new ImageIcon(getClass().getResource("Image/leftmouth.png"));
    private ImageIcon rightMouth = new ImageIcon(getClass().getResource("Image/rightmouth.png"));
    private ImageIcon upMouth = new ImageIcon(getClass().getResource("Image/upmouth.png"));
    private ImageIcon downMouth = new ImageIcon(getClass().getResource("Image/downmouth.png"));
    private ImageIcon snakeImage = new ImageIcon(getClass().getResource("Image/snakeimage.png"));
    private ImageIcon enemy = new ImageIcon(getClass().getResource("Image/enemy.png"));

    private Timer timer;
    private int delay = 120;
    GamePanel(){
        addKeyListener(this);
        setFocusable(true);
        setFocusTraversalKeysEnabled(true);
        timer = new Timer(delay, this);
        timer.start();

        // Enemy Method
        newEnemy();
    }
    
    @Override
    public void paint(Graphics g){
        super.paint(g);

        // Board and Color
        g.setColor(Color.WHITE); // Boarder color
        g.drawRect(24, 10, 851, 55); // Score Board Rectangle
        g.drawRect(24, 74, 851, 575); // Game Board Rectangle

        snakeTitle.paintIcon(this, g, 25, 11);

        
        g.setColor(Color.BLACK);
        g.fillRect(25, 75, 850, 574);

        // Snake position and Direction
        if(moves==0){
            snakeXlength[0] = 100;
            snakeXlength[1] = 75;
            snakeXlength[2] = 50;

            snakeYlength[0] = 100;
            snakeYlength[1] = 100;
            snakeYlength[2] = 100;
        }
        
            // Snake Head 
        if(left){
            leftMouth.paintIcon(this, g, snakeXlength[0], snakeYlength[0]);
        }
        if(right){
            rightMouth.paintIcon(this, g, snakeXlength[0], snakeYlength[0]);
        }
        if(up){
            upMouth.paintIcon(this, g, snakeXlength[0], snakeYlength[0]);
        }
        if(down){
            downMouth.paintIcon(this, g, snakeXlength[0], snakeYlength[0]);
        }

        // Snake Body
        for(int i=1;i<lengthOfSnake;i++){ // i = 1 because head is shifed in 1st position
            snakeImage.paintIcon(this, g, snakeXlength[i], snakeYlength[i]);
        }

        // Displaying Enemy
        enemy.paintIcon(this, g, enemyXpos, enemyYpos);
        if(gameOver){
            g.setColor(Color.WHITE);
            g.setFont(new Font("Arial",Font.BOLD,50));
            g.drawString("Game Over", 300, 300);

            g.setFont(new Font("Arial",Font.PLAIN,20));
            g.drawString("press SPACE for restart", 320, 350);
        }

        // Score and Length of Snake
        g.setColor(Color.WHITE);
        g.setFont(new Font("Arial",Font.PLAIN,14));
        g.drawString("Score: "+score, 750, 30);
        g.drawString("Length: "+lengthOfSnake, 750, 50);
        g.dispose();
    }
    @Override
    public void actionPerformed(ActionEvent e) {

        for(int i=lengthOfSnake-1;i>0;i--){
            snakeXlength[i] = snakeXlength[i-1];
            snakeYlength[i] = snakeYlength[i-1];
        }
        if(left){
            snakeXlength[0] = snakeXlength[0] - 25;
        }
        if(right){
            snakeXlength[0] = snakeXlength[0] + 25;
        }
        if(up){
            snakeYlength[0] = snakeYlength[0] - 25;
        }
        if(down){
            snakeYlength[0] = snakeYlength[0] + 25;
        }

        if(snakeXlength[0]>850){
            snakeXlength[0] = 25;
        }
        if(snakeXlength[0]<25){
            snakeXlength[0] = 850;
        }
        if(snakeYlength[0]>625){
            snakeYlength[0] = 75;
        }
        if(snakeYlength[0]<75){
            snakeYlength[0] = 625;
        }

        // Colliding Function
        collidesWithEnemy();
        collidesWithBody();
        repaint();
    }
    

    @Override
    public void keyTyped(KeyEvent e) {
        
    }
    @Override
    public void keyPressed(KeyEvent e) {
        if(e.getKeyCode()==KeyEvent.VK_SPACE){
            restart();
        }
        if(e.getKeyCode()==KeyEvent.VK_LEFT && !right){
            left = true;
            right = false;
            down = false;
            up = false;
            moves++;
        }
        if(e.getKeyCode()==KeyEvent.VK_RIGHT && !left){
            left = false;
            right = true;
            down = false;
            up = false;
            moves++;
        }
        if(e.getKeyCode()==KeyEvent.VK_UP && !down){
            left = false;
            right = false;
            down = false;
            up = true;
            moves++;
        }
        if(e.getKeyCode()==KeyEvent.VK_DOWN && !up){
            left = false;
            right = false;
            down = true;
            up = false;
            moves++;
        }
    }
    @Override
    public void keyReleased(KeyEvent e) {
        
    }
    // Enemy Method call
    private void newEnemy() {
        enemyXpos = xPos[random.nextInt(34)];
        enemyYpos = yPos[random.nextInt(23)];

        for(int i=lengthOfSnake-1;i>=0;i--){
            if(snakeXlength[0]== enemyXpos && snakeYlength[0]==enemyYpos){
                newEnemy();
            }
        }
    }

    // Enemy collotion method
    private void collidesWithEnemy() {
        if(snakeXlength[0]== enemyXpos && snakeYlength[0]==enemyYpos){
            newEnemy();
            lengthOfSnake++;
            score++;
        }
    }

    // Body collition method
    private void collidesWithBody(){
        for(int i=lengthOfSnake-1;i>0;i--){
            if(snakeXlength[i]==snakeXlength[0] && snakeYlength[i]==snakeYlength[0]){
                timer.stop();
                gameOver = true;
            }
        }
    }

    // Game Restart method
    private void restart(){
        gameOver = false;
        moves = 0;
        score = 0;
        lengthOfSnake = 3;
        left = false;
        right = true;
        up = false;
        down = false;
        timer.start();
        repaint();
    }
}
