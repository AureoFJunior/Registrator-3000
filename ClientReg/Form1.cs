using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientReg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.Hide();
            
            addItem.Click += AddItem_Click;


        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            panel1.Show();
            /*var panel = this.Controls.OfType<Panel>().FirstOrDefault(p => p.Name == "panel1");
            if (panel != default(Panel)) panel.Visible = visible;*/
        }
    }
}
