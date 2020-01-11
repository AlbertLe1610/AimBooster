using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AimBooster
{
    public partial class Form2 : Form
    {
        Random random;
        public Form2()
        {
            InitializeComponent();
            random = new Random();
            InitComponent();
            timer1.Start();


        }
        private void InitComponent()
        {
            Button button1 = new Button();
            button1.BackgroundImage = Properties.Resources.target;
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Name = "button1";
            button1.Size = new Size(71, 68);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            int w = random.Next(0, panel1.Width - button1.Width);
            int r = random.Next(0, panel1.Height - button1.Height);
            button1.Location = new Point(w, r);
            button1.Click += new EventHandler(button1_Click);
            panel1.Controls.Add(button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            PointCounter();
            Button btn = sender as Button;
            panel1.Controls.Remove(btn);
        }
        private void PointCounter()
        {
          int point = Int32.Parse(lblPoint.Text);
            point++;
            lblPoint.Text = point.ToString();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            int lives = Int32.Parse(lblLives.Text);
            lives--;
            lblLives.Text = lives.ToString();
            if( lives == 0)
            {
                timer1.Stop();
                Form3 form3 = new Form3(lblPoint.Text);
                this.Close();
                form3.ShowDialog();
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int time = Int32.Parse(lblTime.Text);
            time--;
            lblTime.Text = time.ToString();
            InitComponent();
            InitComponent();
            if (time == 0)
            {
                timer1.Stop(); 
                 Form3 form3 = new Form3(lblPoint.Text);
                this.Close();
                form3.ShowDialog();
            }

        }
    }
}

