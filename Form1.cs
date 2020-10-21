using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Discord_Letter_Formatter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            string output = "";
            int count = 0;

            txtOutput.Clear();

            foreach (char c in input)
            {
                if (Char.IsLetterOrDigit(c) || c == ' ')
                {
                    output = convertToDiscordShorthand(c.ToString());
                    txtOutput.Text += output + " ";
                }
                else
                {
                    MessageBox.Show("Discord doesn't support regional indicators for symbols.");
                    break;
                }
                
            }

            foreach(char c in txtOutput.Text)
            {
                count++;
            }

            lblCharCount.Text = count.ToString();

            if(count > 2000)
            {
                lblCharCount.ForeColor = Color.Red;
            }
            else
            {
                lblCharCount.ForeColor = Color.Green;
            }

        }

        public string convertToDiscordShorthand(string input)
        {
            try
            {
                string output = "";

                if(input != "")
                {
                    if(input == " ")
                    {
                        output = input;
                        return output;
                    }
                    else
                    {
                        output = ":regional_indicator_" + input + ":";
                        return output;
                    }
                    
                }
                else
                {
                    MessageBox.Show("Please provide text to convert.");
                    return "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }
    }
}
