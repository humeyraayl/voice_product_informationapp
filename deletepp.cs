using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeechLib;
using System.Speech.Recognition;
using System.Data.SqlClient;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;

namespace humeyrayıldız_project
{
    public partial class deletepp : Form
    {
        public deletepp()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-27C6M49\\WINCCPLUSMIG2014;Initial Catalog=db_product;Integrated Security=True");
        public void productlist()
        {
            var products = db.Productinformation1.ToList();
            dataGridView1.DataSource = products;
        }
        db_productEntities db = new db_productEntities();

        private string[] words = { "11", "1", "2", "3", "4", "5", "6", "7", "8", "9","10","12","çıkış","close" };

        private void deletepp_Load(object sender, EventArgs e)
        {
            productlist();
            label1.Text = "Say the ID you want to delete";
            timer1.Start();
        }
        
        
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (richTextBox1.Text == "0")
            {
                int id = 0;
                baglan.Open();
                SqlCommand cmd = new SqlCommand("Delete from productinformation1 where ID=(" + id + ")", baglan);
                cmd.ExecuteNonQuery();
                baglan.Close();
                productlist();
            }
            if (richTextBox1.Text == "1")
            {
                int id = 1;
                baglan.Open();
                SqlCommand cmd = new SqlCommand("Delete from productinformation1 where ID=(" + id + ")", baglan);
                cmd.ExecuteNonQuery();
                baglan.Close();
                productlist();
            }
            if (richTextBox1.Text == "2")
            {
                int id = 2;
                baglan.Open();
                SqlCommand cmd = new SqlCommand("Delete from productinformation1 where ID=(" + id + ")", baglan);
                cmd.ExecuteNonQuery();
                baglan.Close();
                productlist();
            }
            if (richTextBox1.Text == "3")
            {
                int id = 3;
                baglan.Open();
                SqlCommand cmd = new SqlCommand("Delete from productinformation1 where ID=(" + id + ")", baglan);
                cmd.ExecuteNonQuery();
                baglan.Close();
                productlist();
            }
            if (richTextBox1.Text == "4")
            {
                int id = 4;
                baglan.Open();
                SqlCommand cmd = new SqlCommand("Delete from productinformation1 where ID=(" + id + ")", baglan);
                cmd.ExecuteNonQuery();
                baglan.Close();
                productlist();
            }
            if (richTextBox1.Text == "5")
            {
                int id = 5;
                baglan.Open();
                SqlCommand cmd = new SqlCommand("Delete from productinformation1 where ID=(" + id + ")", baglan);
                cmd.ExecuteNonQuery();
                baglan.Close();
                productlist();
            }
            if (richTextBox1.Text == "6")
            {
                int id = 6;
                baglan.Open();
                SqlCommand cmd = new SqlCommand("Delete from productinformation1 where ID=(" + id + ")", baglan);
                cmd.ExecuteNonQuery();
                baglan.Close();
                productlist();
            }
            if (richTextBox1.Text == "7")
            {
                int id = 7;
                baglan.Open();
                SqlCommand cmd = new SqlCommand("Delete from productinformation1 where ID=(" + id + ")", baglan);
                cmd.ExecuteNonQuery();
                baglan.Close();
                productlist();
            }
            if (richTextBox1.Text == "8")
            {
                int id = 8;
                baglan.Open();
                SqlCommand cmd = new SqlCommand("Delete from productinformation1 where ID=(" + id + ")", baglan);
                cmd.ExecuteNonQuery();
                baglan.Close();
                productlist();
            }
            if (richTextBox1.Text == "9")
            {
                int id = 9;
                baglan.Open();
                SqlCommand cmd = new SqlCommand("Delete from productinformation1 where ID=(" + id + ")", baglan);
                cmd.ExecuteNonQuery();
                baglan.Close();
                productlist();
            }

            if (richTextBox1.Text == "close")
            {
                timer1.Stop();
                deletepp.ActiveForm.Close();
            }
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
            new System.Globalization.CultureInfo("en-US");

            Choices colors = new Choices();
            colors.Add(words);
            GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = System.Globalization.CultureInfo.GetCultureInfoByIetfLanguageTag("en-US");
            gb.Append(colors);

            Grammar g = new Grammar(gb);
            // load the grammar.(oluşturulan grammari ekle)
            recognizer.LoadGrammar(g);
            try
            {

                recognizer.SetInputToDefaultAudioDevice();
                recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception)
            {
                richTextBox1.Text = "ERROR";

            }
        }
        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            richTextBox1.Text = e.Result.Text;

        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(label1.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
            new System.Globalization.CultureInfo("en-US");

            Choices colors = new Choices();
            colors.Add(words);
            GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = System.Globalization.CultureInfo.GetCultureInfoByIetfLanguageTag("en-US");
            gb.Append(colors);

            Grammar g = new Grammar(gb);
            // load the grammar.(oluşturulan grammari ekle)
            recognizer.LoadGrammar(g);
            try
            {

                recognizer.SetInputToDefaultAudioDevice();
                recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception)
            {
                richTextBox1.Text = "ERROR";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            deletepp.ActiveForm.Close();
        }
    }
}
