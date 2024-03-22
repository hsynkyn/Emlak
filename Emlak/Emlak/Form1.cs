namespace Emlak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Admin" && textBox2.Text == "12345")
            {
                Form2 emlakKayit = new Form2();
                emlakKayit.Show();
                this.Hide();
            }
        }
    }
}
