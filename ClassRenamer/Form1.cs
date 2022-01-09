using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace ClassRenamer
{
    public partial class Form1 : Form
    {
        public Mem memory = new Mem();
        Process[] proc = Process.GetProcessesByName("plutonium-bootstrapper-win32");
        public string[] classes = { "02FB4DD4", "02FB4DE4", "02FB4DF4", "02FB4E04", "02FB4E14", "02FB4E24", "02FB4E34", "02FB4E44", "02FB4E54", "02FB4E64" };
        public Form1()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select the class that you would like to rename 1-10 \nType the name that you want for the class \nClick the \"Set Class Name\" button \nNote: this only works for class set 1 and you have to be on a different class set or it will not work", "How to use", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (proc.Length == 0)
            {
                MessageBox.Show("Make sure the game is running", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                memory.OpenProcess(Process.GetProcessesByName("plutonium-bootstrapper-win32").FirstOrDefault().Id);
                MessageBox.Show("Successfully attached to BO2", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (proc.Length == 0)
            {
                MessageBox.Show("Make sure the game is running", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Select a class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                memory.OpenProcess(Process.GetProcessesByName("plutonium-bootstrapper-win32").FirstOrDefault().Id);
                memory.WriteMemory("" + classes[comboBox1.SelectedIndex], "string", textBox1.Text);
                //MessageBox.Show("Successfully changed class name", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            memory.OpenProcess(Process.GetProcessesByName("plutonium-bootstrapper-win32").FirstOrDefault().Id);
            string className = memory.ReadString("plutonium - bootstrapper - win32.exe+" + classes[comboBox1.SelectedIndex],"",16);
            textBox1.Text = className;
        }
    }
}
