using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// When exit item is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program was made by Carl Hamilton");
        }
        /// <summary>
        /// Selecting the button the web control will display the page in the text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            NavigateToPage();
        }
        /// <summary>
        /// This is the core function to complete navigation and post processing
        /// </summary>

        private void NavigateToPage()
        {
            button1.Enabled = false;
            textBox1.Enabled = false;
            toolStripStatusLabel1.Text = "Navigation Complete";
            webBrowser1.Navigate(textBox1.Text);

        }

        /// <summary>
        /// Function is used when a key is pressed and released
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if( e.KeyChar == (char)ConsoleKey.Enter)
            {
                NavigateToPage();
                button1_Click(null, null);
            }

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if( e.CurrentProgress > 0  && e.MaximumProgress > 0 )
            {
                //Calculate the percentage
                int percentage = (int)(e.CurrentProgress * 100 / e.MaximumProgress);

                if (percentage <= 100)
                {
                    toolStripProgressBar1.ProgressBar.Value = percentage;

                }
            }
            else
            {
                //reset to zero if unable to get usable value
                toolStripProgressBar1.ProgressBar.Value = 0;
            }
            
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {
            

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}


        
