using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace lottosorsolas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int> lista = new List<int>();
        public void Form1_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            int r;
            bool van = false;
            for (int i = 0; i < 5; i++)
            {
                r = random.Next(1,90);
                for (int j = 0; j < lista.Count; j++)
                {
                    if (lista[j] == r &&van!=true)
                    {
                        van = true;
                        continue;
                    }
                }
                if (van == false)
                {
                    lista.Add(r);
                    van = false;
                }

            }
            int meret =45;
            int num = 1;
            panel1.Controls.Clear();

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j <15; j++)
                {
                    Button gomb = new Button();
                    gomb.SetBounds(j * meret, i * meret,meret,meret);
                    gomb.BackColor = Color.LightBlue;
                    gomb.FlatAppearance.BorderSize = 0;
                   

                    gomb.Text = $"{num++}";
                    gomb.Click += (o, oe) =>
                    {
                        Button gomb2 = (Button)o;
                        if (gomb2.BackColor == Color.Red)
                        {
                            gomb2.BackColor = Color.LightGray;
                            label2.Text = Regex.Replace(label2.Text, $"{gomb2.Text}, ", "");

                        }
                        else if (gomb2.BackColor == Color.LightGray)
                        {
                            gomb2.BackColor = Color.Red;
                            label2.Text += $"{gomb2.Text}, ";
                        }
                    };

                    panel1.Controls.Add(gomb);

                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string final = Regex.Replace(label2.Text, "Megjátszott ->", "");
            final = Regex.Replace(final, " ", "");
            string[] tomb = final.Split(',');
            for (int i = 0; i < 5; i++)
            {
                label1.Text += $"{lista[i]}, ";
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < tomb.Length; j++)
                {
                    if (tomb[j] == lista[i].ToString())
                    {
                        label3.Text += $"{tomb[j]}, ";
                    }
                }
            }
            if (label3.Text == "Találat ->")
            {
                label3.Text = "Találat -> Nincs találat";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }
    }
}

