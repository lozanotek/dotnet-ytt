using System;
using System.Windows.Forms;

using Northwind.Data;

namespace Northwind
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            var path = @"northwind.xml";
            textBox.Text = NorthwindDb.GetData(path);
        }
    }
}
