using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
            StreamReader text = new StreamReader(openFileDialog2.FileName);
            string txt = text.ReadToEnd();
            string[] a = txt.Split('\n');
           
           MessageBox.Show("Chọn file Văn bản!");
           openFileDialog1.ShowDialog();
           StreamReader sr = new StreamReader(openFileDialog1.FileName);
           string b = sr.ReadToEnd();
           /* Xu ly van ban*/
           #region
           b = b.Replace(",", "");
           //b = b.Replace(". ", " ");
           b = b.Replace(". ", " ");
           b = b.Replace(".", " ");           
           b = b.Replace("...", "");             
           b = b.Replace("'", "");
           b = b.Replace("!", "");
           b = b.Replace("(", "");
           b = b.Replace(")", "");
           b = b.Replace(":", "");
           b = b.Replace(";", "");
           b = b.Replace("?", "");
           b = b.Replace("=", "");
           b = b.Replace("*", "");
           b = b.Replace("/", "");
           b = b.Replace("+", "");
           b = b.Replace("-", "");
           b = b.Replace("_", "");
           b = b.Replace("@", "");
           b = b.Replace("{", "");
           b = b.Replace("}", "");
           b = b.Replace("$", "");
           
           b = b.ToUpper(); //In hoa VB
          // b = b.Replace(" ", "");
           #endregion
           
           string[] vb = b.Split(' ');
           int dem = 0;
         MessageBox.Show("Bắt đầu kiểm tra...");

          float sum=0;
          for (int i = 0; i < a.Length; i++)
          {
              int flash = 0;
              for (int j = 0; j < vb.Length; j++)
                      if (a[i] == vb[j])
                      {
                          flash++;
                      }
              if (flash >= 1)
                  sum++;
          }
          string x=Convert.ToString(sum);
          float KQ = (sum / 7000)*100; 
          string kqsum = Convert.ToString(KQ);
          MessageBox.Show(x, "Số tiếng trong danh sách A xuất hiện trong file B");
          MessageBox.Show(kqsum, "% xuất hiện.");
          txt.Clone();
          sr.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            label2.Location = new Point(label2.Location.X, label2.Location.Y - 1);
            if (label2.Location.Y + label2.Height < 0)
                label2.Location = new Point(label2.Location.X, panel1.Height);

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "Bước 1: Chọn đường dẫn đến file A chứa danh sách\ncác tiếng.\nBước 2: Chọn đường dẫn đến file văn bản B.\n Xem kết quả!";
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
