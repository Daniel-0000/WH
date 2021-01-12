using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WH.Properties;


namespace WH
{
    public partial class Form1 : Form
    {

        int exp = 0;
        int munny = 0;       

        List<Image> head = new List<Image>();
        List<Image> risk = new List<Image>();

        public class resp
        {
            public List<img> data { get; set; }
        }

        public class img
        {
            public string link { get; set; }
        }

        private resp GetImages(string albumHash, string clientId)
        {
            resp result = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://api.imgur.com/3/album/{albumHash}/images");
                //Add Header 
                WebHeaderCollection webHeaderCollection = request.Headers;
                webHeaderCollection.Add("Authorization", $"Client-ID {clientId}");


                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string json = readStream.ReadToEnd();

                result = JsonConvert.DeserializeObject<resp>(json);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());

            }
            return result;
        }

        private Image GetImageFromUrl(string url)
        {
            Image result;
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                result = System.Drawing.Image.FromStream(receiveStream);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                throw;
            }
            return result;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exp += 10;
            munny += 1;
            textBox1.Text = Convert.ToString(munny);
            textBox2.Text = Convert.ToString(exp);

            if (exp < 100)
                pictureBox3.Image = head[0];
            else if (100 < exp & exp < 1550)
                pictureBox3.Image = head[1];
            else if (1550 < exp & exp < 4000)
                pictureBox3.Image = head[2];
            else if (exp > 7000)
                pictureBox3.Image = head[3];

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }




        private void Form1_Load(object sender, EventArgs e)
        {
            head.Add(Resources._0);
            head.Add(Resources._1);
            head.Add(Resources._2);
            head.Add(Resources._3);

            risk.Add(Resources.download1);
            risk.Add(Resources.download2);
            risk.Add(Resources.download3);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var imgurData = GetImages("RhhOaIU", "5add18c101a7102");

            if (imgurData == null)
            {
                return;
            }
            int randomNum = new Random().Next(8);
            Image image = GetImageFromUrl(imgurData.data[randomNum].link);

            if (image == null)
            {
                return;
            }

            pictureBox2.Image = image;


            //json --> object 
            Console.WriteLine(imgurData);
        }

        private Image GetImageFromUrl(object link)
        {
            throw new NotImplementedException();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (munny >= 20)
            {
                var imgurData = GetImages("oTYTPHk", "5add18c101a7102");

                if (imgurData == null)
                {
                    return;
                }
                int randomNum = new Random().Next(32);
                Image image = GetImageFromUrl(imgurData.data[randomNum].link);

                if (image == null)
                {
                    return;
                }

                pictureBox1.Image = image;

                //json --> object 
                Console.WriteLine(imgurData);
                munny -= 20;
                textBox1.Text = Convert.ToString(munny);

                PictureBox pictureBox = new PictureBox();
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Image = GetImageFromUrl(imgurData.data[randomNum].link);
                flowLayoutPanel1.Controls.Add(pictureBox);
            }
            else
            {
                MessageBox.Show("金幣不足", "乞丐", MessageBoxButtons.OK);
            }

            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string input = richTextBox2.Text;
            try
            {
                //檢查1: 是不是可以轉成數字
                int result = Int32.Parse(input);

                //檢查2: 這個數字是否>=  900000000
                if (result < 900000000)
                {
                    MessageBox.Show("加值失敗");
                    return;
                }

                //檢查3 :長度是否為10
                if (input.Length < 10)
                {
                    MessageBox.Show("加值失敗");
                    return;
                }

                //檢查4 : 第一個字應該是0 
                if (input.Substring(0, 1) != "0")
                {
                    MessageBox.Show("加值失敗");
                    return;
                }

                Console.WriteLine(result);
                MessageBox.Show("加值成功");
                munny += 100;
                exp += 299;
                textBox1.Text = Convert.ToString(munny);
                textBox2.Text = Convert.ToString(exp);
                if (exp < 100)
                    pictureBox3.Image = head[0];
                else if (100 < exp & exp < 1550)
                    pictureBox3.Image = head[1];
                else if (1550 < exp & exp < 4000)
                    pictureBox3.Image = head[2];
                else if (exp > 7000)
                    pictureBox3.Image = head[3];
            }
            catch (FormatException)
            {
                MessageBox.Show("加值失敗");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string input = richTextBox2.Text;
            try
            {
                //檢查1: 是不是可以轉成數字
                int result = Int32.Parse(input);

                //檢查2: 這個數字是否>=  900000000
                if (result < 900000000)
                {
                    MessageBox.Show("加值失敗");
                    return;
                }

                //檢查3 :長度是否為10
                if (input.Length < 10)
                {
                    MessageBox.Show("加值失敗");
                    return;
                }

                //檢查4 : 第一個字應該是0 
                if (input.Substring(0, 1) != "0")
                {
                    MessageBox.Show("加值失敗");
                    return;
                }

                Console.WriteLine(result);
                MessageBox.Show("加值成功");
                munny += 50;
                exp += 123;
                textBox1.Text = Convert.ToString(munny);
                textBox2.Text = Convert.ToString(exp);
                if (exp < 100)
                    pictureBox3.Image = head[0];
                else if (100 < exp & exp < 1550)
                    pictureBox3.Image = head[1];
                else if (1550 < exp & exp < 4000)
                    pictureBox3.Image = head[2];
                else if (exp > 7000)
                    pictureBox3.Image = head[3];
            }
            catch (FormatException)
            {
                MessageBox.Show("加值失敗");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string input = richTextBox2.Text;
            try
            {
                //檢查1: 是不是可以轉成數字
                int result = Int32.Parse(input);

                //檢查2: 這個數字是否>=  900000000
                if (result < 900000000)
                {
                    MessageBox.Show("加值失敗");
                    return;
                }

                //檢查3 :長度是否為10
                if (input.Length < 10)
                {
                    MessageBox.Show("加值失敗");
                    return;
                }

                //檢查4 : 第一個字應該是0 
                if (input.Substring(0, 1) != "0")
                {
                    MessageBox.Show("加值失敗");
                    return;
                }

                Console.WriteLine(result);
                MessageBox.Show("加值成功");
                munny += 150;
                exp += 699;
                textBox1.Text = Convert.ToString(munny);
                textBox2.Text = Convert.ToString(exp);

                if (exp < 100)
                    pictureBox3.Image = head[0];
                else if (100 < exp & exp < 1550)
                    pictureBox3.Image = head[1];
                else if (1550 < exp & exp < 4000)
                    pictureBox3.Image = head[2];
                else if (exp > 7000)
                    pictureBox3.Image = head[3];
            }
            catch (FormatException)
            {
                MessageBox.Show("加值失敗");
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int randomNum = new Random().Next(3);
            pictureBox5.Image = risk[randomNum];
            if (randomNum == 2)
            {
                MessageBox.Show("恭喜獲得獎勵", "冒險", MessageBoxButtons.OK);
                int MUNNY = new Random().Next(100);
                munny += MUNNY;
                int EXP = new Random().Next(50);
                exp += EXP;
                textBox1.Text = Convert.ToString(munny);
                textBox2.Text = Convert.ToString(exp);
            }
            else
            {
                MessageBox.Show("再接再厲", "冒險", MessageBoxButtons.OK);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int randomNum = new Random().Next(3);
            pictureBox5.Image = risk[randomNum];
            if (randomNum == 0)
            {
                MessageBox.Show("恭喜獲得獎勵", "冒險", MessageBoxButtons.OK);
                int MUNNY = new Random().Next(100);
                munny += MUNNY;
                int EXP = new Random().Next(50);
                exp += EXP;
                textBox1.Text = Convert.ToString(munny);
                textBox2.Text = Convert.ToString(exp);
            }
            else
            {
                MessageBox.Show("再接再厲", "冒險", MessageBoxButtons.OK);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int randomNum = new Random().Next(3);
            pictureBox5.Image = risk[randomNum];
            if (randomNum == 1)
            {
                MessageBox.Show("恭喜獲得獎勵", "冒險", MessageBoxButtons.OK);
                int MUNNY = new Random().Next(100);
                munny += MUNNY;
                int EXP = new Random().Next(50);
                exp += EXP;
                textBox1.Text = Convert.ToString(munny);
                textBox2.Text = Convert.ToString(exp);
            }
            else
            {
                MessageBox.Show("再接再厲", "冒險", MessageBoxButtons.OK);
            }
        }
    }
}
