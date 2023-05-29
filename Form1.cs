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
using NAudio.CoreAudioApi;
using NAudio;
using System.Reflection.Emit;
using System.Reflection;

namespace humeyrayıldız_project
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            //Showing default sound system options for progress bar(progress bar için varsayılan ses sistemi seçeneklerini göstermek)
            MMDeviceEnumerator en = new MMDeviceEnumerator();
            var devices = en.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            comboBox2.Items.AddRange(devices.ToArray());
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-27C6M49\\WINCCPLUSMIG2014;Initial Catalog=db_product;Integrated Security=True");
        public void productlist()
        {
            //show data added to sql(sql e eklenen verileri gösterme)
            var products = db.Productinformation1.ToList();
            dataGridView1.DataSource = products;
        }

        void enabled()
        {
            txtbuyp.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            txtnamee.Enabled = false;
            txtsellp.Enabled = false;
            maskedTextBox1.Enabled = false;
            comboBox1.Enabled = false;

        }
        void colorreset()
        {
            txtnamee.BackColor = Color.White;
            txtbuyp.BackColor = Color.White;
            txtsellp.BackColor = Color.White;
            maskedTextBox1.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
        }

        db_productEntities db = new db_productEntities();
        
        // Create new grammer words.(grammar kelimeleri oluştur.) 
        private string[] words = { "sienna brooks","sienna","products list", "list","name","stok","stock","brand","mark","case","state","delete","sil","T-shirt",
                                   "buy price","add","ekle","sell price","buy","sell","fiyat","exit","çıkış","date","tarih","available",
                                   "Jacket","Bags","Jeans","Sweatshirt","Dress","Shoes","1","2","3","4","5","6","7","8","9","10","11","12","20","30"};
        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        private void btnspeak_Click(object sender, EventArgs e)
        {
            // Create a new SpeechRecognizer instance.(konuşma tanımlayıcı başlatın)
            
            new System.Globalization.CultureInfo("en-US");

            Choices colors = new Choices();
            colors.Add(words);
            GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = System.Globalization.CultureInfo.GetCultureInfoByIetfLanguageTag("en-US");
            gb.Append(colors);


            // Create the Grammar instance.(grammar örneği oluştur)
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
        //Create a simple handler for the SpeechRecognized event.(işleyici oluştur)
        private void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            richTextBox1.Text = e.Result.Text ;

        }

        private void btnlisten_Click(object sender, EventArgs e)
        {
            //Reading the texts in richtextbox1. (richtextbox1 de çıkan yazıları okuma)
            SpVoice ses = new SpVoice();
            ses.Speak(richTextBox1.Text);
        }

        private void btnproadd_Click(object sender, EventArgs e)
        {
            Productinformation1 t = new Productinformation1();
            t.PRODUCTNAME = txtnamee.Text;
            t.BRAND = textBox2.Text;
            t.BUYPRİCE = decimal.Parse(txtbuyp.Text);
            t.SELLPRİCE = decimal.Parse(txtsellp.Text);
            t.STOCK = textBox3.Text;
            t.DATE = DateTime.Parse(maskedTextBox1.Text);
            t.PRODUCTCASE = true;
            db.Productinformation1.Add(t);
            db.SaveChanges();
            label2.Text = "product saved in database";
            productlist();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtnamee.BackColor==Color.Yellow )
            {
                pictureBox1.Image = null ;
                txtnamee.Text = richTextBox1.Text;
                if (richTextBox1.Text == "T-shirt")
                {
                    pictureBox1.Image = Image.FromFile(@"..\..\resimler\0.jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (richTextBox1.Text == "Jacket")
                {
                    pictureBox1.Image = Image.FromFile(@"..\..\resimler\5.jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (richTextBox1.Text == "Bags")
                {
                    pictureBox1.Image = Image.FromFile(@"..\..\resimler\9.jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (richTextBox1.Text == "Jeans")
                {
                    pictureBox1.Image = Image.FromFile(@"..\..\resimler\12.jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (richTextBox1.Text == "Sweatshirt")
                {
                    pictureBox1.Image = Image.FromFile(@"..\..\resimler\14.jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (richTextBox1.Text == "Dress")
                {
                    pictureBox1.Image = Image.FromFile(@"..\..\resimler\23.jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                if (richTextBox1.Text == "Shoes")
                {
                    pictureBox1.Image = Image.FromFile(@"..\..\resimler\28.jpg");
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                label14.Font = new Font("Siemens AD Sans", 12, FontStyle.Regular);
                label14.ForeColor = Color.Black;
                label14.Text = txtnamee.Text;

                enabled();
                colorreset();
            }
            if (txtbuyp.BackColor == Color.Yellow)
            {
                txtbuyp.Text = richTextBox1.Text;
                label11.Font = new Font("Siemens AD Sans", 12, FontStyle.Regular);
                label11.ForeColor = Color.Black;
                label11.Text ="BUY PRİCE:"+ txtbuyp.Text+ "$";
                enabled();
                colorreset();
            }
            if (txtsellp.BackColor == Color.Yellow)
            {
                txtsellp.Text = richTextBox1.Text;
                label12.Font = new Font("Siemens AD Sans", 12, FontStyle.Regular);
                label12.ForeColor = Color.Black;
                label12.Text ="SELL PRİCE:"+ txtsellp.Text+ "$";
                enabled();
                enabled();
                colorreset();
            }
            if (maskedTextBox1.BackColor == Color.Yellow)
            {
                enabled();
                colorreset();
            }
            if (comboBox1.BackColor == Color.Yellow)
            {
                enabled();
                colorreset();
            }
            if (textBox2.BackColor == Color.Yellow)
            {
                textBox2.Text = richTextBox1.Text;
                label9.Font = new Font("Showcard Gothic", 15, FontStyle.Regular);
                label9.ForeColor = Color.Black;
                label9.Text = textBox2.Text;
                enabled();
                colorreset();
            }
            if (textBox3.BackColor == Color.Yellow)
            {
                textBox3.Text = richTextBox1.Text;
                label10.Font = new Font("Siemens AD Sans", 12, FontStyle.Regular);
                label10.ForeColor = Color.Black;
                label10.Text = "STOCK:"+ textBox3.Text;
                enabled();
                enabled();
                colorreset();
                
            }

            if (richTextBox1.Text== "products list" || richTextBox1.Text=="list")
            {
                productlist();
            }
            if (richTextBox1.Text== "add" || richTextBox1.Text == "ekle")
            {
                Productinformation1 t = new Productinformation1();
                t.PRODUCTNAME = txtnamee.Text;
                t.BRAND = textBox2.Text;
                t.BUYPRİCE = decimal.Parse(txtbuyp.Text);
                t.SELLPRİCE = decimal.Parse(txtsellp.Text);
                t.STOCK = textBox3.Text;
                t.DATE = DateTime.Parse(maskedTextBox1.Text);
                t.PRODUCTCASE = true;
                db.Productinformation1.Add(t);
                db.SaveChanges();
                label2.Text = "Product saved in database";
                productlist();
                txtnamee.Clear();
                txtbuyp.Clear();
                txtsellp.Clear();
                textBox2.Clear();
                textBox3.Clear();
                maskedTextBox1.Clear();
                label10.Text = "";
                label14.Text = "";
                label11.Text = "";
                label12.Text = "";
                label13.Text = "";
                label9.Text = "";
                pictureBox1.Image = null;


            }
            if (richTextBox1.Text == "products name" || richTextBox1.Text == "name")
            {
                label2.Text = "";
                txtnamee.Focus();
                if (txtname.Text == null)
                {
                    label14.Text = "";
                }
                txtnamee.BackColor = Color.Yellow;
                txtnamee.Enabled = true;
            }
            if (richTextBox1.Text == "sell price" || richTextBox1.Text == "sell")
            {
                label2.Text = "";
                txtsellp.Focus();
                if (txtsellp.Text == null)
                {
                    label12.Text = "";
                }
                txtsellp.BackColor = Color.Yellow;
                txtsellp.Enabled = true;
            }
            if (richTextBox1.Text == "buy price" || richTextBox1.Text == "buy" || richTextBox1.Text == "fiyat")
            {
                label2.Text = "";
                txtbuyp.Focus();
                if (txtbuyp.Text == null)
                {
                    label11.Text = "";
                }
                txtbuyp.BackColor = Color.Yellow;
                txtbuyp.Enabled = true;
            }
            if (richTextBox1.Text == "brand" || richTextBox1.Text == "mark")
            {
                label2.Text = "";
                textBox2.Focus();
                if (textBox2.Text == null)
                {
                    label9.Text = "";
                }
                textBox2.BackColor = Color.Yellow;
                textBox2.Enabled = true;
            }
            if (richTextBox1.Text == "case" || richTextBox1.Text == "state" )
            {
                label2.Text = "";
                comboBox1.Focus();
                comboBox1.BackColor = Color.Yellow;
                comboBox1.Enabled = true;
            }
            if (richTextBox1.Text == "stock" || richTextBox1.Text == "stok" || richTextBox1.Text == "available")
            {
                label2.Text = "";
                textBox3.Enabled = true;
                if (textBox3.Text == null)
                {
                    label10.Text = "";
                }
                textBox3.Focus();
                textBox3.BackColor = Color.Yellow;
                
            }
            if (richTextBox1.Text == "date" || richTextBox1.Text == "tarih")
            {
                label2.Text = "";
                maskedTextBox1.Enabled = true;
                if (maskedTextBox1.Text == null)
                {
                    label13.Text = "";
                }
                maskedTextBox1.Focus();
                maskedTextBox1.BackColor = Color.Yellow;

            }

            if (richTextBox1.Text == "exit" )
            {
                Application.Exit();
            }
            
            if (richTextBox1.Text == "delete" || richTextBox1.Text == "sil")
            {
                richTextBox1.Clear();
                //The delete window opens.(silme penceresi açılır.)
                Form formBackgroud = new Form();
                try
                {
                    using (deletepp uu = new deletepp())
                    {
                        formBackgroud.StartPosition = FormStartPosition.Manual;
                        formBackgroud.FormBorderStyle = FormBorderStyle.None;
                        formBackgroud.Opacity = .50d;
                        formBackgroud.BackColor = Color.Black;
                        formBackgroud.WindowState = FormWindowState.Maximized;
                        formBackgroud.TopMost = true;
                        formBackgroud.Location = this.Location;
                        formBackgroud.ShowInTaskbar = false;
                        formBackgroud.Show();
                        uu.Owner = formBackgroud;
                        uu.ShowDialog();

                        formBackgroud.Dispose();
                        
                       
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    formBackgroud.Dispose();
                }
                

                

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            enabled();
            colorreset();
        }

        private void maskedTextBox1_BackColorChanged(object sender, EventArgs e)
        {
            if(maskedTextBox1.BackColor == Color.Yellow)
            {
                maskedTextBox1.Text = DateTime.Now.ToString("dd.MM.yyyy");
                label13.Font = new Font("Siemens AD Sans", 12, FontStyle.Regular);
                label13.ForeColor = Color.Black;
                label13.Text = maskedTextBox1.Text;
                enabled();
            }
           
        }

        private void comboBox1_BackColorChanged(object sender, EventArgs e)
        {
            if (comboBox1.BackColor== Color.Yellow)
            {
                comboBox1.Text = "active";
            }
        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            if (label2.Text == "Product saved in database")
            {
                SpVoice ses = new SpVoice();
                ses.Speak(label2.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            recognizer.RecognizeAsyncStop();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (comboBox2.SelectedItem != null)
            {
                var singledevice = (MMDevice)comboBox2.SelectedItem;
                // progressBar1.Value = (int)(Math.Round(singledevice.AudioMeterInformation.MasterPeakValue * 900));
                circularprogresbar1.ValueSize = (int)(Math.Round(singledevice.AudioMeterInformation.MasterPeakValue * 900));
            }
        }

        //ürünlerin okunması.(reading the products.)
        private void button3_Click(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(button3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(button4.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(button5.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(button6.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(button7.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(button8.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(button9.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            help message = new help();
            message.Show();
        }
        int ts = 0; int k = 9; int j = 5;int je = 12;int s = 14;int d = 23;int sh = 28;

        //sırayla ürün resimlerinin gösterilmesi.(Showing product pictures in order.)
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (txtnamee.Text=="T-SHIRT")
            {
                ts++;
                if (ts == 5)
                {
                    ts = 0;
                }
                pictureBox1.Image = Image.FromFile(@"..\..\resimler\"+ts+".jpg");
            }
            if (txtnamee.Text == "JACKET")
            {
                j++;
                if (j == 9)
                {
                    j = 5;
                }
                pictureBox1.Image = Image.FromFile(@"..\..\resimler\"+j+".jpg");

            }
            if (txtnamee.Text == "BAGS")
            {                
                k++;
                if (k == 12)
                {
                    k = 9;
                }
                pictureBox1.Image = Image.FromFile(@"..\..\resimler\"+k+".jpg");

            }
            if (txtnamee.Text == "JEANS")
            {
                je++;
                if (je == 14)
                {
                    je = 12;
                }
                pictureBox1.Image = Image.FromFile(@"..\..\resimler\"+je+".jpg");
            }
            if (txtnamee.Text == "SWEATSHIRT")
            {
                s++;
                if (s == 23)
                {
                    s = 14;
                }
                pictureBox1.Image = Image.FromFile(@"..\..\resimler\"+s+".jpg");

            }
            if (txtnamee.Text == "DRESS")
            {
                d++;
                if (d == 28)
                {
                    d= 23;
                }
                pictureBox1.Image = Image.FromFile(@"..\..\resimler\"+d+".jpg");

            }
            if (txtnamee.Text == "SHOES")
            {
                sh++;
                if (sh == 31)
                {
                    sh = 28;
                }
                pictureBox1.Image = Image.FromFile(@"..\..\resimler\"+sh+".jpg");

            }

        }
    }
}
