using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace FormsAppsWithDatabase
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1.form2Active = true; //Form2 is active
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Form1.form2Active = false; //Form2 closed by pressing 'X'
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Open file and write contents in richTextBox1
            Stream myStream;
            OpenFileDialog openFile = new OpenFileDialog();

            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = openFile.OpenFile()) != null)
                {
                    string strFilename = openFile.FileName;
                    string fileText = File.ReadAllText(strFilename);
                    richTextBox1.Text = fileText;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Είστε σίγουρος ότι θέλετε να υποβάλλετε οριστικά την αίτησή σας;\nΔεν θα μπορούν να γίνουν αλλαγές σε αυτήν αν συνεχίσετε!", "Οριστική Υποβολή", MessageBoxButtons.YesNo);

            //If user chose no, end method
            if (confirm == DialogResult.No)
                return;

            //If user chose yes, show message to user about successful completion, write all necessary items in a file and close the application
            //Generate random protocol number with 9 digits
            Random rnd = new Random();
            int protocolNumber = rnd.Next(0, 999999999);
            string protocalNumberFormatted = protocolNumber.ToString("000000000");

            //Inform user
            MessageBox.Show("Επιτυχής Ολοκλήρωση της Αίτησης!\n\nΑριθμός πρωτοκόλλου: " + protocalNumberFormatted + "\nΗμερομηνία Καταχώρησης Αίτησης: " + "" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

            //Write file
            string path = Directory.GetCurrentDirectory(); //get current working directory to save the file there!
            string Data = "Ονοματεπώνυμο Αιτούντα: " + Form1.FullName + "\nΑΜΚΑ: " + Form1.AMKA + "\nΚείμενο Αίτησης: " + richTextBox1.Text + "\nΑριθμός Πρωτοκόλλου: " + protocalNumberFormatted + "\nΗμερομηνία Αίτησης: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "ApplicationForm.txt")))
            {
                outputFile.Write(Data);
            }

            //Close the application
            Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Clear richTextBox1's text
            richTextBox1.Clear();
        }
    }
}
