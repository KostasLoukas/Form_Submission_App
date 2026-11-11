using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormsAppsWithDatabase
{
    public partial class Form1 : Form
    {
        //Global Variables between Forms
        public static string FullName = "";
        public static string AMKA = "";
        public static bool form2Active = false; //for not letting multiple instances of Form2 to be active!
        //Form 2 access
        Form Form2;
        //Valid AMKA checker (for textBox1 change)
        private bool textValid = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Hide the rest of the fields on launch, except the AMKA one, until it is validated
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            button2.Visible = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //We do not want the "ΑΜΚΑ" field to be empty!
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                //AMKA validation
                //(Did not remember what else was needed for the AMKA to be valid...)
                if (Regex.IsMatch(textBox1.Text, @"^\d+$") && textBox1.Text.Length == 13)
                {
                    //Show the rest of the fields once AMKA has been validated successfully!
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    label10.Visible = true;
                    label11.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    textBox6.Visible = true;
                    textBox7.Visible = true;
                    textBox8.Visible = true;
                    comboBox1.Visible = true;
                    comboBox2.Visible = true;
                    comboBox3.Visible = true;
                    button2.Visible = true;
                    //AMKA passed the validation
                    textValid = true;
                }
                else
                {
                    MessageBox.Show("Παρακαλώ εισάγετε έναν έγκυρο ΑΜΚΑ.");
                    textBox1.Clear();
                    //Hide fields if wrong AMKA was inserted again!
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    label9.Visible = false;
                    label10.Visible = false;
                    label11.Visible = false;
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    textBox6.Visible = false;
                    textBox7.Visible = false;
                    textBox8.Visible = false;
                    comboBox1.Visible = false;
                    comboBox2.Visible = false;
                    comboBox3.Visible = false;
                    button2.Visible = false;
                    textValid = false;
                    if (form2Active)
                    {
                        Form2.Close();
                        form2Active = false; //Form2 closed because of error (not because user pressed the 'X' button)
                    }
                }
            }
            else
            {
                MessageBox.Show("Παρακαλώ εισάγετε τον ΑΜΚΑ σας.");
                textBox1.Clear();
                //Hide fields if empty AMKA was inserted again
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                button2.Visible = false;
                textValid = false;
                if (form2Active)
                {
                    Form2.Close();
                    form2Active = false; //Form2 closed because of error (not because user pressed the 'X' button)
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textValid)
            {
                if (!form2Active)
                {
                    //Show Form2 and load fields for later use (for writing to file)
                    Form2 = new Form2();
                    Form2.Show();
                    AMKA = textBox1.Text;
                    FullName = textBox2.Text;
                }
            }
            else
            {
                //MessageBox.Show("Παρακαλώ πατήστε πρώτα το κουμπί 'Έλεγχος' για έλεγχο εγκυρότητας του ΑΜΚΑ σας.");
                //Hide fields if AMKA was not validated before pressing "Συνέχεια"
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                button2.Visible = false;
                if (form2Active)
                {
                    Form2.Close();
                    form2Active = false; //Form2 closed because of error (not because user pressed the 'X' button)
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Require validation each time the user changes AMKA!
            textValid = false;

            //Hide fields if AMKA changed
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            button2.Visible = false;
            if (form2Active)
            { 
                Form2.Close();
                form2Active = false; //Form2 closed because of error (not because user pressed the 'X' button)
            }

            
        }

    }
}
