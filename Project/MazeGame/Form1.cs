using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace MazeGame
{

    public partial class Form1 : Form
    {
        Game igra = new Game();
        string filename = "";
        bool startedgame = false;
        TimeSpan tt = new TimeSpan();
        //bool paused = false;


        public Form1()
        {
            InitializeComponent();
            timer2.Interval = 5000;
            timer1.Interval = 1000;

        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P && startedgame) { StopGame(); } // P e za STOP
            else if (e.KeyCode == Keys.R) { StartGame(); }     // R e za Restart
            else if (e.KeyCode == Keys.S && startedgame) { saveGameDialog(); } // S e za SAVE
            else if (e.KeyCode == Keys.O) { openGameDialog(); }

        }
        private void StopGame()
        {
            textBox3.BackColor = Control.DefaultBackColor;
            timer1.Stop();
            timer2.Stop();
            igra.stopwatch.Stop(); //STOPWATCH STOP
            igra.stopwatch.Reset();
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "100";
            startedgame = false;
            panel1.Enabled = false;
            button1.Enabled = true;
            igra = new Game();


        }
        private void Finish_MouseEnter(object sender, EventArgs e)
        {
            StopGame();
            tt = igra.getTimespan();
            MessageBox.Show("Congratiolations you have finished the game in " + tt.ToString("mm\\:ss") + " and you have hit the blocks only " + igra.hits.ToString() + " times.");

        }
        private void StartGame()
        {
            StopGame();
            moveCursorToStart();
            igra.stopwatch.Start(); //START STOPERICA

            tt = igra.getTimespan();

            textBox1.Text = tt.ToString("mm\\:ss");
            textBox2.Text = igra.hits.ToString();
            textBox3.Text = igra.snake.hp.ToString();

            startedgame = true;
            panel1.Enabled = true;
            button1.Enabled = false;

            timer1.Start();
            timer2.Start();

        }
        private void StartGame(Game ig)
        {
            StopGame();
            igra = ig;
            moveCursorToStart();
            igra.stopwatch.Start(); //START STOPERICA

            tt = igra.getTimespan();
            updateInformation();
            startedgame = true;
            panel1.Enabled = true;
            button1.Enabled = false;

            timer1.Start();
            timer2.Start();

        }
        public void hitBlock()
        {
            
            bool alive = igra.snake.decreaseHP();
            if (!alive)
            {
                tt = igra.getTimespan();
                listBox1.Items.Add("Your snake has died. Your time:" + tt.ToString("mm\\:ss"));
                snakeDied();
            }
            else
            {
                listBox1.Items.Add("You hit your snake in a block! Be careful! -20hp!");
                igra.hits += 1; // TUKA TREBA --HP
                textBox2.Text = igra.hits.ToString();
                textBox3.Text = igra.snake.hp.ToString();
                if (igra.snake.hp <= 20)
                    textBox3.BackColor = Color.Red;
            
                else
                    textBox3.BackColor = DefaultBackColor;


            }
        }
        public void snakeDied()
        {
            StopGame();
            if (MessageBox.Show("Want to try again?", "You have died", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                StartGame();
            }

        }
        private void moveCursorToStart()
        {
            Point startingPoint = panel1.Location;
            startingPoint.Offset(10, 10);
            Cursor.Position = PointToScreen(startingPoint);
        }
        private void label4_MouseEnter(object sender, EventArgs e)
        {
            hitBlock();

        }

        private void button1_Click(object sender, EventArgs e) //START button
        {
            StartGame();
            listBox1.Items.Add("You have started new game!");
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            if (startedgame) // ako e vekje igrata startovana, da se izbegne da se dojde do label preku cheating t.e odnadvoresna strana
                moveCursorToStart();
        }



        private void timer2_Tick(object sender, EventArgs e) // Timer za dodavanje +5 hp na sekoj 5 sekundi
        {

            if (startedgame)
            {
                if (igra.snake.addHP())
                {
                    textBox3.Text = igra.snake.hp.ToString();
                    listBox1.Items.Add("You got rewarded +5hp for your endurance!");
                    if (igra.snake.hp <= 20)
                        textBox3.BackColor = Color.Red;
                    else
                        textBox3.BackColor = Control.DefaultBackColor;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void saveGameDialog()
        {
            timer1.Stop();
            timer2.Stop();
            igra.stopwatch.Stop();
            IFormatter ifrmt = new BinaryFormatter();
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Save your game!",
                Filter = "Maze File (.maze)|*.maze"
            };
            try
            {
                if ((sfd.ShowDialog()) == DialogResult.OK)
                {
                    filename = sfd.FileName;
                }

                FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
                ifrmt.Serialize(fs, igra);
            }
            catch (Exception e)
            {
                MessageBox.Show("Imavme nekakov error. Ve molime predajte ja porakata do nadleznite: " + e.Message);
            }
            StopGame();

        }
        public void openGameDialog()
        {
            StopGame();
            timer1.Stop();
            timer2.Stop();
            IFormatter ifrmt = new BinaryFormatter();
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Open your game!",
                Filter = "Maze File (.maze)|*.maze"
            };
            //try
            //{
            if ((ofd.ShowDialog()) == DialogResult.OK)
            {
                filename = ofd.FileName;
            }
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);

            this.igra = (Game)ifrmt.Deserialize(fs);
            Cursor.Position = igra.snake.position;
            startedgame = true;

            StartGame(igra);
            updateInformation();
            listBox1.Items.Add(String.Format("You loaded saved game {0} .", filename));
            listBox1.Items.Add(String.Format("X:{0} Y:{1} HP:{2} Elapsed time:{3} Hits:{4}", igra.snake.position.X.ToString(), igra.snake.position.Y.ToString(), igra.snake.hp.ToString(), igra.getTimespan().ToString("mm\\:ss"), igra.hits.ToString()).ToString());


            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("Imavme nekakov error. Ve molime predajte ja porakata do nadleznite: " + e.Message);
            //}

        }
        private void updateInformation()
        {
            textBox3.Text = igra.snake.hp.ToString();
            if (igra.snake.hp <= 20)
                textBox3.BackColor = Color.Red;
            else
                textBox3.BackColor = DefaultBackColor;


            textBox1.Text = igra.getTimespan().ToString("mm\\:ss");
            textBox2.Text = igra.hits.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            updateInformation();
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startedgame)
            {
                igra.snake.position = e.Location;

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openGameDialog();
        }

        private void changeBlockColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color c;
            ColorDialog cd = new ColorDialog();
            try
            {
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    c = cd.Color;
                    foreach (Control k in panel1.Controls)
                    {
                        try
                        {
                            if (k.GetType() == typeof(Label))
                            {
                                k.BackColor = c;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error siten imame. Error description:" + ex.Message);
                        }
                    }
                }
                else
                {
                    throw new Exception("Please pick one color!");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        //private void pauseGame()
        //{

        //    if(!paused) // ako ne e pauzirano, togas pauziraj
        //    {
        //        paused = true;

        //    }
        //}

    }
}
