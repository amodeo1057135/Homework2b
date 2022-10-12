namespace Homework2b1
{
    public partial class Form1 : Form
    {
        public string csvText = "";
        public Form1()
        {
            InitializeComponent();
            richTextBox1.HideSelection = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (csvText != "")
            {
                string[] lines = csvText.Split("\n");
                for (var lineNum = 0; lineNum < lines.Length; lineNum++)
                {
                    var cells = lines[lineNum].Split(",");
                    richTextBox1.AppendText(string.Join(" ", cells) + "\n");
                }
                richTextBox1.AppendText("Parsed " + lines.Length + " lines.");
            }
            else
            {
                MessageBox.Show("No file selected!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = -1;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    csvText = File.ReadAllText(file);
                    size = csvText.Length;
                    label1.Text = file;
                }
                catch (IOException)
                {
                    Console.WriteLine("Error: can't open file");
                }
            }
            Console.WriteLine(size);
            Console.WriteLine(result);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            csvText = "";
            label1.Text = "Select a CSV File...";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}