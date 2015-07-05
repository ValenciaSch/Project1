using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_X_x_O
{
    public partial class Statistics : Form
    {
     //  Computer_Game comp;
        public Statistics()
        {
            InitializeComponent();
            //listBox1.Items.Add(" >>>Статистика<<<");
            //for (int i = 0; i < 3; i++)
            //{
            //    listBox1.Items.Add(" Первым ходит");
            //    //listBox1.Items.Add(comp.NameGame[i].ToString() + ": " + comp.CountGame[i].ToString());
            //}
        }
        public Statistics(Computer_Game comp)
        {
            InitializeComponent();
            listBox1.Items.Add(" >>>Статистика<<<");
            for (int i = 0; i < 3; i++)
            {               
                listBox1.Items.Add(comp.NameGame[i].ToString() + ": " + comp.CountGame[i].ToString());
            }
        }
    }
}
