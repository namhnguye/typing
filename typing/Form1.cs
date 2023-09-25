using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace typing
{
    public partial class TYPING : Form
    {
        int sum = 0;
        const string chars = "abcdefghijklmnopqrstuvwxyz";


        public TYPING()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            word.Text = generateRandomString();
        }
        private string generateRandomString()
        {
            var random = new Random();
            int length = random.Next(4, 8); 
            char[] stringChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(0,26)]; 
            }
            string randomString = new string(stringChars);
            return randomString;
        }
        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (inputTextBox.Text == word.Text)
            {
                sum++;
                sumCountLabel.Text = sum.ToString();
                inputTextBox.Text = "";
                word.Text = generateRandomString();
            }
            else
            {
                // Reset the formatting to default for the entire text
                word.SelectAll();
                word.SelectionColor = word.ForeColor;

                for (int i = 0; i < word.Text.Length && i < inputTextBox.Text.Length; i++)
                {
                    if (inputTextBox.Text[i] != word.Text[i])
                    {
                        // Change the color of mismatched letters
                        word.Select(i, 1);
                        word.SelectionColor = Color.Red;
                    }
                }
                // Deselect text to avoid further coloring
                word.DeselectAll();
            }
        }

        private void sumCountLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
