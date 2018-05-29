﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        Stopwatch stopwatch;
        Game igra;
        string filename = "";
        bool startedgame;
        bool paused = false;
        string status = "Stopped..";

        public Form1()
        {
            InitializeComponent();
            timer2.Interval = 5000;
            timer1.Interval = 1000;
            stopwatch = new Stopwatch();
            igra = new Game();
            startedgame = false;
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && startedgame) { StopGame(); } // P e za STOP
            else if (e.KeyCode == Keys.R) { StartGame(); }     // R e za Restart
            else if (e.KeyCode == Keys.S && startedgame) { saveGameDialog(); } // S e za SAVE
            else if (e.KeyCode == Keys.O) { openGameDialog(); } // O e za open
            else if (e.KeyCode == Keys.P && startedgame) { PauseGame(); } // K e za PauseGame
        }
        private void StopGame()
        {
            textBox3.BackColor = DefaultBackColor;
            stopwatch.Stop(); //STOPWATCH STOP
            igra.ts += stopwatch.Elapsed;
            stopwatch.Reset();
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "100";
            startedgame = false;
            enablePanel2Controls();
            igra = new Game();
            status = "Stopped...";
            timer1.Stop();
            timer2.Stop();
            updateInformation();


        }
        private void Finish_MouseEnter(object sender, EventArgs e)
        {

            MessageBox.Show("Congratiolations you have finished the game in " + igra.getTimespan(stopwatch).ToString("mm\\:ss") + " and you have hit the blocks only " + igra.hits.ToString() + " times.");
            StopGame();
        }
        private void StartGame()
        {
            StopGame();
            status = "Running game..";
            moveCursorToStart();
            stopwatch.Start(); //START STOPERICA
            updateInformation();
            startedgame = true;
            panel1.Enabled = true;
            disablePanel2Controls();
            timer1.Start();
            timer2.Start();
        }
        private void StartGame(Game ig)
        {
            StopGame();
            igra = ig;
            status = "Running game..";
            moveCursorToStart();
            stopwatch.Start(); //START STOPERICa
            updateInformation();
            startedgame = true;
            panel1.Enabled = true;
            disablePanel2Controls();

            timer1.Start();
            timer2.Start();

        }
        public void hitBlock()
        {

            bool alive = igra.snake.decreaseHP();
            if (!alive)
            {

                listBox1.Items.Add("Your snake has died. Your time:" + igra.getTimespan(stopwatch).ToString("mm\\:ss"));
                igra.addEvent("Your snake has died. Your time:" + igra.getTimespan(stopwatch).ToString("mm\\:ss"));
                snakeDied();
            }
            else
            {
                listBox1.Items.Add("You hit your snake in a block! Be careful! -20hp!");
                igra.addEvent("You hit your snake in a block! Be careful! -20hp!");
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
            else
            {
                Close();
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
            if(startedgame)
                hitBlock();
        }
        private void button1_Click(object sender, EventArgs e) //START button
        {
            StartGame();
            listBox1.Items.Add("You have started new game!");
        }
        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            if (startedgame && paused == false)// ako e vekje igrata startovana, da se izbegne da se dojde do label preku cheating t.e odnadvoresna strana
                moveCursorToStart();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void saveGameDialog()
        {
            startedgame = false;
            timer1.Stop();
            timer2.Stop();
            stopwatch.Stop();
            igra.ts += stopwatch.Elapsed;
            stopwatch.Reset();
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
                else
                {
                    
                    throw new Exception("Nevalidni argumenti za save opcijata..");
                }
                FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
                ifrmt.Serialize(fs, igra);
                fs.Close();
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
            try
            {
                if ((ofd.ShowDialog()) == DialogResult.OK)
                {
                    filename = ofd.FileName;
                }
                FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);

                this.igra = (Game)ifrmt.Deserialize(fs);
                fs.Close();
    

                StartGame(igra);
                startedgame = true;
                updateInformation();
                listBox1.Items.Clear();
                listBox1.Items.Add(String.Format("You loaded saved game {0} .", filename));
                listBox1.Items.Add(String.Format("X:{0} Y:{1} HP:{2} Elapsed time:{3} Hits:{4}", igra.snake.position.X.ToString(), igra.snake.position.Y.ToString(), igra.snake.hp.ToString(), igra.getTimespan(stopwatch).ToString("mm\\:ss"), igra.hits.ToString()).ToString());
                foreach (string item in igra.eventlog.ToString().Split('\n'))
                {
                    listBox1.Items.Add(item);
                }
                listBox1.Update();
                // Locating cursor to previosly saved position
                Point startingPoint = panel1.Location;
                startingPoint.Offset(igra.snake.position.X, igra.snake.position.Y);
                Cursor.Position = PointToScreen(startingPoint);
            }
            catch (Exception e)
            {
                MessageBox.Show("Imavme nekakov error. Ve molime predajte ja porakata do nadleznite: " + e.Message);
            }

        }
        private void updateInformation()
        {
            if (startedgame && !paused)
            {
                status = "Game is running";
            }
            if (startedgame && paused)
            {
                status = "Paused game..";
            }
            if (!startedgame)
            {
                status = "Stopped..";
            }
            textBox1.Text = igra.getTimespan(stopwatch).ToString("mm\\:ss");
            textBox2.Text = igra.hits.ToString();
            statuslabel.Text = status.ToString();
            textBox3.Text = igra.snake.hp.ToString();
            if (igra.snake.hp <= 20)
                textBox3.BackColor = Color.Red;
            else
                textBox3.BackColor = DefaultBackColor;
        }
        private void disablePanel2Controls()
        {
            panel2.Enabled = false;
            panel1.Enabled = true;
        }
        private void enablePanel2Controls()
        {
            panel2.Enabled = true;
            panel1.Enabled = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            updateInformation();
        }
        private void timer2_Tick(object sender, EventArgs e) // Timer za dodavanje +5 hp na sekoj 5 sekundi
        {
            if (startedgame && paused == false)
            {
                if (igra.snake.addHP())
                {
                    textBox3.Text = igra.snake.hp.ToString();
                    listBox1.Items.Add("You got rewarded +5hp for your endurance!");
                    igra.addEvent("You got rewarded +5hp for your endurance!");
                    if (igra.snake.hp <= 20)
                        textBox3.BackColor = Color.Red;
                    else
                        textBox3.BackColor = Control.DefaultBackColor;
                }
            }
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startedgame && paused == false)
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
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        } // add tooltip here!!
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveGameDialog();
        }

        private void PauseGame()
        {
            if (startedgame)
            {
                paused = !paused; // ako paused==false --> paused=true
                if (paused)
                {
                    status = "Paused game..";
                    stopwatch.Stop(); // pauzira stoperica vreme
                    enablePanel2Controls();
                }
                else
                {
                    status = "Running game..";
                    Point startingPoint = panel1.Location;
                    startingPoint.Offset(igra.snake.position.X, igra.snake.position.Y);
                    Cursor.Position = PointToScreen(startingPoint);
                    stopwatch.Start();
                    disablePanel2Controls();
                }
            }

        }

    }
}
