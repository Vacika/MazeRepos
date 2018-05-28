using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGame
{
    public partial class Form1 : Form
    {
        int hits = 0;
        bool startedgame = false;
        TimeSpan ts;
        DateTime start;


        public Form1()
        {
            InitializeComponent();
        }

        private void resetGame()
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            hits = 0;
            startedgame = false;
            panel1.Enabled = false;
            button1.Enabled = true;
            timer1.Stop();

        }
        private void Finish_MouseEnter(object sender, EventArgs e)
        {
            resetGame();
            MessageBox.Show("Congratiolations you have finished the game in " + ts.ToString(@"mm\:ss") + "and you have hit the blocks only " + hits.ToString() + " times.");


        }
        private void MoveToStart()
        {
            Point startingPoint = panel1.Location;
            startingPoint.Offset(10,10);
            Cursor.Position = PointToScreen(startingPoint);
            hits++;
            textBox2.Text = hits.ToString();

        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        private void button1_Click(object sender, EventArgs e) //START button
        {
            resetGame();

            startedgame = true;
            panel1.Enabled = true;
            button1.Enabled = false;

            timer1.Interval = 1000;
            timer1.Start();
            start = DateTime.Now;
            hits--;
            MoveToStart();
       

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ts = DateTime.Now - start;
            textBox1.Text = ts.ToString(@"mm\:ss");
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            if(startedgame) // ako e vekje igrata startovana, da se izbegne da se dojde do label preku cheating t.e odnadvoresna strana
            {
                hits--;
                MoveToStart();
            }
            
            
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && startedgame) resetGame(); // S e za STOP
            else if (e.KeyCode == Keys.R && startedgame) button1_Click(sender, e);     // R e za Restart
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
