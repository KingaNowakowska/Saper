using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        public int m = 0, horizontal = 0, vertical = 0; // m - mine, mines


        private void button1_Click(object sender, EventArgs a)
        {
            Random generator = new Random();
            int[] x = new int[m];
            int[] y = new int[m];
            int[,] how_many_mines = new int[horizontal, vertical];
            bool up = true, down = true, left = true, right = true;
            for (int i = 0; i < horizontal; i++) //filling the number of mines in the neighborhood with zeros
            {
                for (int j = 0; j < vertical; j++) how_many_mines[i, j] = 0;
            }

            for (int i = 0; i < m; i++)  //location draw min
            {
                x[i] = generator.Next(horizontal);
                y[i] = generator.Next(vertical);
                for (int j = 0; j < m; j++) //A LOOP THAT CHECKS IF THERE ARE NO DUPLICATIONS
                {
                    if (x[i] == x[j]) x[i] = generator.Next(horizontal);
                    else if (y[i] == y[j]) y[i] = generator.Next(vertical);
                }

            }

            
            for (int i = 0; i < m; i++) //check whether it is not located at the borders of the board
            {
                if (x[i] == 0)
                {
                    left = false;
                }
                if (x[i] == horizontal - 1)
                {
                    right = false;
                }
                if (y[i] == 0)
                {
                    up = false;
                }
                if (y[i] == vertical - 1)
                {
                    down = false;
                }

                if (up == true && down == true && left == true && right == true)
                {
                    how_many_mines[x[i] - 1, y[i] - 1]++;  //left, up
                    how_many_mines[x[i], y[i] - 1]++; //middle, up
                    how_many_mines[x[i] + 1, y[i] - 1]++; // right, up
                    how_many_mines[x[i] - 1, y[i]]++; //left, evenly
                    how_many_mines[x[i] + 1, y[i]]++; //right, evenly
                    how_many_mines[x[i] - 1, y[i] + 1]++; //left, down
                    how_many_mines[x[i], y[i] + 1]++; //middle, down
                    how_many_mines[x[i] + 1, y[i] + 1]++; //right, down

                }
                else if (up == false && left == false)
                {
                    how_many_mines[x[i] + 1, y[i]]++;
                    how_many_mines[x[i], y[i] + 1]++;
                    how_many_mines[x[i] + 1, y[i] + 1]++;
                }
                else if (up == false && right == false)
                {
                    how_many_mines[x[i] - 1, y[i]]++; //left, evenly
                    how_many_mines[x[i] - 1, y[i] + 1]++; //left, down
                    how_many_mines[x[i], y[i] + 1]++; //middle, down
                }
                else if (down == false && left == false)
                {
                    how_many_mines[x[i], y[i] - 1]++; //middle, up
                    how_many_mines[x[i] + 1, y[i] - 1]++; // right, up
                    how_many_mines[x[i] + 1, y[i]]++; //right, evenly
                }
                else if (down == false && right == false)
                {
                    how_many_mines[x[i] - 1, y[i] - 1]++;  //left, up
                    how_many_mines[x[i], y[i] - 1]++; //middle, up
                    how_many_mines[x[i] - 1, y[i]]++; //left, evenly
                }
                else if (up == false && left == true && right == true)
                {
                    how_many_mines[x[i] - 1, y[i]]++; //left, evenly
                    how_many_mines[x[i] + 1, y[i]]++; //right, evenly
                    how_many_mines[x[i] - 1, y[i] + 1]++; //left, down
                    how_many_mines[x[i], y[i] + 1]++; //middle, down
                    how_many_mines[x[i] + 1, y[i] + 1]++; //right, down
                }
                else if (down == false && left == true && right == true)
                {
                    how_many_mines[x[i] - 1, y[i] - 1]++;  //left, up
                    how_many_mines[x[i], y[i] - 1]++; //middle, up
                    how_many_mines[x[i] + 1, y[i] - 1]++; // right, up
                    how_many_mines[x[i] - 1, y[i]]++; //left, evenly
                    how_many_mines[x[i] + 1, y[i]]++; //right, evenly
                }
                else if (left == false && up == true && down == true)
                {
                    how_many_mines[x[i], y[i] - 1]++; //middle, up
                    how_many_mines[x[i] + 1, y[i] - 1]++; // right, up
                    how_many_mines[x[i] + 1, y[i]]++; //right, evenly
                    how_many_mines[x[i], y[i] + 1]++; //middle, down
                    how_many_mines[x[i] + 1, y[i] + 1]++; //right, down
                }
                else if (right == false && up == true && down == true)
                {
                    how_many_mines[x[i] - 1, y[i] - 1]++;  //left, up
                    how_many_mines[x[i], y[i] - 1]++; //middle, up
                    how_many_mines[x[i] - 1, y[i]]++; //left, evenly
                    how_many_mines[x[i] - 1, y[i] + 1]++; //left, down
                    how_many_mines[x[i], y[i] + 1]++; //middle, down
                }
                up = true;
                down = true;
                left = true;
                right = true;
            }

            List<Button> lista_p = new List<Button>();
            int c = 0,z = 0;
            int[] indeks = new int[m];

            for (int i = 0; i < horizontal; i++)
            {
                
                for (int j = 0; j < vertical; j++)
                {
                    
                    Button button = new Button();
                    string name = "b";
                    name += c.ToString();
                    button.Name = name;
                    button.Size = new Size(30, 30);
                    button.Location = new Point(30 * (i + 1), 30 * (j + 1) + 50);
                    lista_p.Add(button);
                    button.Click += (s, e) =>
                    {
                        button.Visible = false;
                        int index = lista_p.IndexOf(button);
                        for(int l = 0; l < z; l++)
                        {
                            if (index == indeks[l])
                            {
                                foreach (Button b in lista_p)
                                {
                                    b.Visible = false;
                                }
                            }
                        }
                        

                    };
                    for(int k = 0; k < m; k++)
                    {
                        if (x[k] == i && y[k] == j)
                        {
                            indeks[z] = c;
                            z++;
                        }
                    }
                    c++;

                        Controls.Add(button);

                }
                
            }


            for (int i = 0; i < horizontal; i++)
            {
                for (int j = 0; j < vertical; j++)
                {
                    PictureBox p = new PictureBox();
                    p.Size = new Size(30, 30);
                    p.SizeMode = PictureBoxSizeMode.StretchImage;
                    p.Location = new Point(30 * (i + 1), 30 * (j + 1) + 50);
                    Controls.Add(p);

                    {
                        if (how_many_mines[i, j] == 0)
                        {
                            p.Image = Properties.Resources._0;
                        }
                        else if (how_many_mines[i, j] == 1)
                        {
                            p.Image = Properties.Resources._1;
                        }
                        else if (how_many_mines[i, j] == 2)
                        {
                            p.Image = Properties.Resources._2;
                        }
                        else if (how_many_mines[i, j] == 3)
                        {
                            p.Image = Properties.Resources._3;
                        }
                        else if (how_many_mines[i, j] == 4)
                        {
                            p.Image = Properties.Resources._4;
                        }
                        else if (how_many_mines[i, j] == 5)
                        {
                            p.Image = Properties.Resources._5;
                        }
                        else if (how_many_mines[i, j] == 6)
                        {
                            p.Image = Properties.Resources._6;
                        }
                        else if (how_many_mines[i, j] == 7)
                        {
                            p.Image = Properties.Resources._7;
                        }
                        else if (how_many_mines[i, j] == 8)
                        {
                            p.Image = Properties.Resources._8;
                        }
                        for (int k = 0; k < m; k++)
                        {
                            if (x[k] == i && y[k] == j)
                            {
                                p.Image = Properties.Resources.mina;

                            }
                        }
                    }


                }

            }

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            m = 3;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            m = 5;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            m = 7;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string n = textBox1.Text;
            bool ifNumber = int.TryParse(n, out _);
            if (ifNumber == true)
            {
                if (int.Parse(n) < horizontal * vertical)
                {
                    
                    if (int.Parse(n) == 0)
                    {
                        MessageBox.Show("Ilość min nie może być równa 0!", "Błąd!");
                        textBox1.Text = "";
                    }
                    else m = int.Parse(n);
                }
                else
                {
                    MessageBox.Show("Ilość min nie może być większa od ilości pól!", "Błąd!");
                    textBox1.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Ilość min musi być liczbą naturalną!", "Błąd!");
                textBox1.Text = "";
            }
 
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            comboBox1.SelectedIndex = -1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            string horizontal1 = textBox2.Text;
            string vertical1= textBox3.Text;
            bool ifNumber1 = int.TryParse(horizontal1, out _);
            bool ifNumber2 = int.TryParse(vertical1, out _);
            if (ifNumber1 == true && ifNumber2 == true)
            {
                if (int.Parse(horizontal1) >= 5 && int.Parse(horizontal1) <= 10 && int.Parse(vertical1) >= 8 && int.Parse(vertical1) <= 20)
                {

                    if (int.Parse(horizontal1) == 0 || int.Parse(vertical1) == 0)
                    {
                        MessageBox.Show("Ilość wierszy/kolumn nie może być równa 0!", "Błąd!");
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                    else
                    {
                        horizontal = int.Parse(horizontal1);
                        vertical = int.Parse(vertical1);
                        
                    }

                }
                else
                {
                    MessageBox.Show("Podano niewłasciwą ilość pól!", "Błąd!");
                    textBox1.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Ilość wierszy/kolumn musi być liczbą naturalną!", "Błąd!");
                textBox1.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                horizontal = 5;
                vertical = 8;
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                horizontal = 7;
                vertical = 10;
            }
            else if(comboBox1.SelectedIndex == 2)
            {
                horizontal = 10;
                vertical = 15;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            m = 10;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }
        protected void button_Click(object sender, EventArgs e, List<Button> lista_p)
        {
            Button button = sender as Button;
            button.Visible = false;

        }
        
    }

}

