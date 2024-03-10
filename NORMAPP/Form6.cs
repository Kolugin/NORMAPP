using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NORMAPP
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        private OleDbConnection dbCon;
        string ConS = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\NORMDB.mdb";
        private void Form6_Load(object sender, EventArgs e)
        {
            this.Text = "Окно сбора предложений и пожеланий по улучшению и доработке ПО";
            textBox1.Text = "Введите здесь свою Фамилию И. О.";
            textBox2.Text = "Введите здесь ваше предложение по разработке, дополнению, устранению выявленного недостатка в ходе работы с программой...";
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            textBox1.Text = "";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dbCon = new OleDbConnection(ConS);
                dbCon.Open();
                using (dbCon)
                {
                    string Query = "INSERT INTO RAZR (Dat, Inf, FIO) VALUES (@Dat, @Inf, @FIO)";
                    OleDbCommand com = new OleDbCommand(Query, dbCon);
                    com.Parameters.AddWithValue("@Dat", Convert.ToString(DateTime.Now));
                    com.Parameters.AddWithValue("@Inf", Convert.ToString(textBox2.Text));
                    com.Parameters.AddWithValue("@FIO", Convert.ToString(textBox1.Text));
                    com.ExecuteNonQuery();
                }
                dbCon.Close();
                MessageBox.Show("Ваше предложение внесено в реестр предложений и будет рассмотрено в ближайшее время! Спасибо за ваш отзыв!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            catch (Exception g)
            {
                return;
            }
        }
    }
}
