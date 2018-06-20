using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MazeGame
{
    public partial class Form2 : Form
    {
        List<Player> ls;
        XmlSerializer xs;
        public Form2()
        {
            InitializeComponent();
            ls = new List<Player>();
            xs = new XmlSerializer(typeof (List<Player>));
            txt_name.Text = "Player";
            txt_HP.Text = Globals.HP.ToString();
            txt_time.Text = Globals.time;
            tb_Score.Text = Globals.score.ToString();
        }
        public void LoadData()
        {
            Globals.name = txt_name.Text;
        }

        private void txt_HP_TextChanged(object sender, EventArgs e)
        {
            txt_HP.Text = Globals.HP.ToString();
        }

        private void txt_time_TextChanged(object sender, EventArgs e)
        {
            txt_time.Text = Globals.time;
        }
        private void tb_Score_TextChanged(object sender, EventArgs e)
        {
            tb_Score.Text = Globals.score.ToString();
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("D:\\Player.Xml", FileMode.Create, FileAccess.Write);
            Player pl = new Player();
            Globals.name = txt_name.Text;
            pl.Name = Globals.name;
            pl.Score = Globals.score.ToString();
            ls.Add(pl);
            xs.Serialize(fs, ls);
            fs.Close();
            btn_View.Enabled = true;
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("D:\\Player.Xml", FileMode.Open, FileAccess.Read);
            ls = (List<Player>)xs.Deserialize(fs);
            dataView.DataSource = ls;
            fs.Close();
        }

       
    }

   

}
