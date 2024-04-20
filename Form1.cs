using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ПР8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string fn = string.Empty;
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fn = openFileDialog1.FileName;
                this.Text = fn;
                try
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fn);
                    textBox1.Text = sr.ReadToEnd();
                    textBox1.SelectionStart = textBox1.TextLength;
                    sr.Close();
                    button2.Enabled= true;
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Помилка читання файла.\n" + exc.ToString(), "NkEdit",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = $"{textBox1.Text}";
            string pattern = @"\b(?:\d{1,3}\.){3}\d{1,3}\b|\b(?:[0-9a-fA-F]{1,4}:){7}[0-9a-fA-F]{1,4}\b";
            Regex number =new Regex(pattern);
            MatchCollection matches = number.Matches(text);
            listBox1.Items.AddRange(matches.ToArray());
        }
    }
}
