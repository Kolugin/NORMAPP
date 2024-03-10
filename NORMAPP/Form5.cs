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
    public partial class Form5 : Form
    {
        public Form5(string a, string TypeEvent, string DescEvent, string user, string ConS)
        {
            InitializeComponent();
            this.a = a;
            this.TypeEvent = TypeEvent;
            this.DescEvent = DescEvent;
            this.user = user;
            this.ConS = ConS;
        }
        private OleDbConnection dbCon;
        public string a;
        public string TypeEvent;
        public string DescEvent;
        public string user;
        public string ConS;
        public int State = 0;

        public void Logg() // ЛОГИ
        {
            try
            {
                dbCon = new OleDbConnection(ConS);
                dbCon.Open();
                using (dbCon)
                {
                    string Query = "INSERT INTO Logs (Date_Log, Type_Log, Desc_Log) VALUES (@Date_Log, @Type_Log, @Desc_Log)";
                    OleDbCommand com = new OleDbCommand(Query, dbCon);
                    com.Parameters.AddWithValue("@Date_Log", Convert.ToString(DateTime.Now));
                    com.Parameters.AddWithValue("@Type_Log", Convert.ToString(TypeEvent));
                    com.Parameters.AddWithValue("@Desc_Log", Convert.ToString(DescEvent));
                    com.ExecuteNonQuery();
                }
                dbCon.Close();
                return;
            }
            catch (Exception g)
            {
                return;
            }
        }
        public void str1()
        {
            if (textBox2.Text != "" && textBox2.ForeColor != Color.Gray && textBox3.Text != "" && textBox3.ForeColor != Color.Gray)
            {
                if (textBox4.ForeColor == Color.Gray)
                {
                    textBox4.Text = "";
                    textBox4.ForeColor = Color.Black;
                }
                State++;
            }
            if (textBox2.Text == "" || textBox2.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Имя Строки 1.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox3.Text == "" || textBox3.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Кол-во шт Строки 1.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void str2()
        {
            if (textBox5.Text != "" && textBox5.ForeColor != Color.Gray && textBox6.Text != "" && textBox6.ForeColor != Color.Gray)
            {
                if (textBox7.ForeColor == Color.Gray)
                {
                    textBox7.Text = "";
                    textBox7.ForeColor = Color.Black;
                }
                State++;
            }
            if (textBox5.Text == "" || textBox5.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Имя Строки 2.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox6.Text == "" || textBox6.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Кол-во шт Строки 2.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void str3()
        {
            if (textBox8.Text != "" && textBox8.ForeColor != Color.Gray && textBox9.Text != "" && textBox9.ForeColor != Color.Gray)
            {
                if (textBox10.ForeColor == Color.Gray)
                {
                    textBox10.Text = "";
                    textBox10.ForeColor = Color.Black;
                }
                State++;
            }
            if (textBox8.Text == "" || textBox8.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Имя Строки 3.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox9.Text == "" || textBox9.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Кол-во шт Строки 3.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void str4()
        {
            if (textBox11.Text != "" && textBox11.ForeColor != Color.Gray && textBox12.Text != "" && textBox12.ForeColor != Color.Gray)
            {
                if (textBox13.ForeColor == Color.Gray)
                {
                    textBox13.Text = "";
                    textBox13.ForeColor = Color.Black;
                }
                State++;
            }
            if (textBox11.Text == "" || textBox11.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Имя Строки 4.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox12.Text == "" || textBox12.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Кол-во шт Строки 4.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void str5()
        {
            if (textBox14.Text != "" && textBox14.ForeColor != Color.Gray && textBox15.Text != "" && textBox15.ForeColor != Color.Gray)
            {
                if (textBox16.ForeColor == Color.Gray)
                {
                    textBox16.Text = "";
                    textBox16.ForeColor = Color.Black;
                }
                State++;
            }
            if (textBox14.Text == "" || textBox14.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Имя Строки 5.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox15.Text == "" || textBox15.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Кол-во шт Строки 5.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void str6()
        {
            if (textBox17.Text != "" && textBox17.ForeColor != Color.Gray && textBox18.Text != "" && textBox18.ForeColor != Color.Gray)
            {
                if (textBox19.ForeColor == Color.Gray)
                {
                    textBox19.Text = "";
                    textBox19.ForeColor = Color.Black;
                }
                State++;
            }
            if (textBox17.Text == "" || textBox17.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Имя Строки 6.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox18.Text == "" || textBox18.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Кол-во шт Строки 6.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void str7()
        {
            if (textBox20.Text != "" && textBox20.ForeColor != Color.Gray && textBox21.Text != "" && textBox21.ForeColor != Color.Gray)
            {
                if (textBox22.ForeColor == Color.Gray)
                {
                    textBox22.Text = "";
                    textBox22.ForeColor = Color.Black;
                }
                State++;
            }
            if (textBox20.Text == "" || textBox20.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Имя Строки 7.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox21.Text == "" || textBox21.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Кол-во шт Строки 7.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void str8()
        {
            if (textBox23.Text != "" && textBox23.ForeColor != Color.Gray && textBox24.Text != "" && textBox24.ForeColor != Color.Gray)
            {
                if (textBox25.ForeColor == Color.Gray)
                {
                    textBox25.Text = "";
                    textBox25.ForeColor = Color.Black;
                }
                State++;
            }
            if (textBox23.Text == "" || textBox23.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Имя Строки 8.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox24.Text == "" || textBox24.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Кол-во шт Строки 8.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void str9()
        {
            if (textBox26.Text != "" && textBox26.ForeColor != Color.Gray && textBox27.Text != "" && textBox27.ForeColor != Color.Gray)
            {
                if (textBox28.ForeColor == Color.Gray)
                {
                    textBox28.Text = "";
                    textBox28.ForeColor = Color.Black;
                }
                State++;
            }
            if (textBox26.Text == "" || textBox26.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Имя Строки 9.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox27.Text == "" || textBox27.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Кол-во шт Строки 9.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void str10()
        {
            if (textBox29.Text != "" && textBox29.ForeColor != Color.Gray && textBox30.Text != "" && textBox30.ForeColor != Color.Gray)
            {
                if (textBox31.ForeColor == Color.Gray)
                {
                    textBox31.Text = "";
                    textBox31.ForeColor = Color.Black;
                }
                State++;
            }
            if (textBox29.Text == "" || textBox29.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Имя Строки 10.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox30.Text == "" || textBox30.ForeColor == Color.Gray)
            {
                MessageBox.Show("Введите Кол-во шт Строки 10.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button1;
            this.Text = "Расширенное формирование перечня";
            textBox1.Text = "Введите код Заказа БД для Связи";
            textBox2.Text = "Введите Имя Строки 1";
            textBox3.Text = "Введите Число 1";
            textBox4.Text = "Введите Описание/Пометки Строки при необходимости";
            textBox5.Text = "Введите Имя Строки 2";
            textBox6.Text = "Введите Число 2";
            textBox7.Text = "Введите Описание/Пометки Строки при необходимости";
            textBox8.Text = "Введите Имя Строки 3";
            textBox9.Text = "Введите Число 3";
            textBox10.Text = "Введите Описание/Пометки Строки при необходимости";
            textBox11.Text = "Введите Имя Строки 4";
            textBox12.Text = "Введите Число 4";
            textBox13.Text = "Введите Описание/Пометки Строки при необходимости";
            textBox14.Text = "Введите Имя Строки 5";
            textBox15.Text = "Введите Число 5";
            textBox16.Text = "Введите Описание/Пометки Строки при необходимости";
            textBox17.Text = "Введите Имя Строки 6";
            textBox18.Text = "Введите Число 6";
            textBox19.Text = "Введите Описание/Пометки Строки при необходимости";
            textBox20.Text = "Введите Имя Строки 7";
            textBox21.Text = "Введите Число 7";
            textBox22.Text = "Введите Описание/Пометки Строки при необходимости";
            textBox23.Text = "Введите Имя Строки 8";
            textBox24.Text = "Введите Число 8";
            textBox25.Text = "Введите Описание/Пометки Строки при необходимости";
            textBox26.Text = "Введите Имя Строки 9";
            textBox27.Text = "Введите Число 9";
            textBox28.Text = "Введите Описание/Пометки Строки при необходимости";
            textBox29.Text = "Введите Имя Строки 10";
            textBox30.Text = "Введите Число 10";
            textBox31.Text = "Введите Описание/Пометки Строки при необходимости";
            textBox1.ForeColor = Color.Gray;
            textBox2.ForeColor = Color.Gray;
            textBox3.ForeColor = Color.Gray;
            textBox4.ForeColor = Color.Gray;
            textBox5.ForeColor = Color.Gray;
            textBox6.ForeColor = Color.Gray;
            textBox7.ForeColor = Color.Gray;
            textBox8.ForeColor = Color.Gray;
            textBox9.ForeColor = Color.Gray;
            textBox10.ForeColor = Color.Gray;
            textBox11.ForeColor = Color.Gray;
            textBox12.ForeColor = Color.Gray;
            textBox13.ForeColor = Color.Gray;
            textBox14.ForeColor = Color.Gray;
            textBox15.ForeColor = Color.Gray;
            textBox16.ForeColor = Color.Gray;
            textBox17.ForeColor = Color.Gray;
            textBox18.ForeColor = Color.Gray;
            textBox19.ForeColor = Color.Gray;
            textBox20.ForeColor = Color.Gray;
            textBox21.ForeColor = Color.Gray;
            textBox22.ForeColor = Color.Gray;
            textBox23.ForeColor = Color.Gray;
            textBox24.ForeColor = Color.Gray;
            textBox25.ForeColor = Color.Gray;
            textBox26.ForeColor = Color.Gray;
            textBox27.ForeColor = Color.Gray;
            textBox28.ForeColor = Color.Gray;
            textBox29.ForeColor = Color.Gray;
            textBox30.ForeColor = Color.Gray;
            textBox31.ForeColor = Color.Gray;
        }
        private void button1_Click(object sender, EventArgs e)// действие по кнопке
        {
            if (textBox1.Text != "" && textBox1.ForeColor != Color.Gray)
            {
                State = 0;
                str1();
                str2();
                str3();
                str4();
                str5();
                str6();
                str7();
                str8();
                str9();
                str10();
                DialogResult res = MessageBox.Show("Вы хотите добавить " + State + " строк из 10. Продолжить?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {
                    if (State == 0)
                    {
                        this.Close();
                    }
                    if (State == 1)
                    {
                        try
                        {
                            dbCon = new OleDbConnection(ConS);
                            dbCon.Open();
                            using (dbCon)
                            {
                                OleDbCommand com = new OleDbCommand(a, dbCon);
                                com.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com.Parameters.AddWithValue("@Name_Item", textBox2.Text);
                                com.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox3.Text));
                                com.Parameters.AddWithValue("@Desc_Item", textBox4.Text);
                                com.ExecuteNonQuery();
                            }
                            dbCon.Close();
                            MessageBox.Show("Информация успешно добавлена!.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TypeEvent = "Добавление данных в БД";
                            DescEvent = "Пользователь " + user + " добавил данные в таблицу Перечень Заказа";
                            Logg();
                        }
                        catch
                        {
                            TypeEvent = "Ошибка подключения к БД";
                            DescEvent = "Ошибка подключения к БД. Form1, LoadDB(168)";
                            Logg();
                            this.Close();
                        }
                    }
                    if (State == 2)
                    {
                        try
                        {
                            dbCon = new OleDbConnection(ConS);
                            dbCon.Open();
                            using (dbCon)
                            {
                                OleDbCommand com1 = new OleDbCommand(a, dbCon);
                                com1.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com1.Parameters.AddWithValue("@Name_Item", textBox2.Text);
                                com1.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox3.Text));
                                com1.Parameters.AddWithValue("@Desc_Item", textBox4.Text);
                                com1.ExecuteNonQuery();
                                OleDbCommand com2 = new OleDbCommand(a, dbCon);
                                com2.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com2.Parameters.AddWithValue("@Name_Item", textBox5.Text);
                                com2.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox6.Text));
                                com2.Parameters.AddWithValue("@Desc_Item", textBox7.Text);
                                com2.ExecuteNonQuery();
                            }
                            dbCon.Close();
                            MessageBox.Show("Информация успешно добавлена!.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TypeEvent = "Добавление данных в БД";
                            DescEvent = "Пользователь " + user + " добавил данные в таблицу Перечень Заказа";
                            Logg();
                        }
                        catch
                        {
                            TypeEvent = "Ошибка подключения к БД";
                            DescEvent = "Ошибка подключения к БД. Form1, LoadDB(168)";
                            Logg();
                            this.Close();
                        }
                    }
                    if (State == 3)
                    {
                        try
                        {
                            dbCon = new OleDbConnection(ConS);
                            dbCon.Open();
                            using (dbCon)
                            {
                                OleDbCommand com1 = new OleDbCommand(a, dbCon);
                                com1.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com1.Parameters.AddWithValue("@Name_Item", textBox2.Text);
                                com1.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox3.Text));
                                com1.Parameters.AddWithValue("@Desc_Item", textBox4.Text);
                                com1.ExecuteNonQuery();
                                OleDbCommand com2 = new OleDbCommand(a, dbCon);
                                com2.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com2.Parameters.AddWithValue("@Name_Item", textBox5.Text);
                                com2.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox6.Text));
                                com2.Parameters.AddWithValue("@Desc_Item", textBox7.Text);
                                com2.ExecuteNonQuery();
                                OleDbCommand com3 = new OleDbCommand(a, dbCon);
                                com3.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com3.Parameters.AddWithValue("@Name_Item", textBox8.Text);
                                com3.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox9.Text));
                                com3.Parameters.AddWithValue("@Desc_Item", textBox10.Text);
                                com3.ExecuteNonQuery();
                            }
                            dbCon.Close();
                            MessageBox.Show("Информация успешно добавлена!.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TypeEvent = "Добавление данных в БД";
                            DescEvent = "Пользователь " + user + " добавил данные в таблицу Перечень Заказа";
                            Logg();
                        }
                        catch
                        {
                            TypeEvent = "Ошибка подключения к БД";
                            DescEvent = "Ошибка подключения к БД. Form1, LoadDB(168)";
                            Logg();
                            this.Close();
                        }
                    }
                    if (State == 4)
                    {
                        try
                        {
                            dbCon = new OleDbConnection(ConS);
                            dbCon.Open();
                            using (dbCon)
                            {
                                OleDbCommand com1 = new OleDbCommand(a, dbCon);
                                com1.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com1.Parameters.AddWithValue("@Name_Item", textBox2.Text);
                                com1.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox3.Text));
                                com1.Parameters.AddWithValue("@Desc_Item", textBox4.Text);
                                com1.ExecuteNonQuery();
                                OleDbCommand com2 = new OleDbCommand(a, dbCon);
                                com2.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com2.Parameters.AddWithValue("@Name_Item", textBox5.Text);
                                com2.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox6.Text));
                                com2.Parameters.AddWithValue("@Desc_Item", textBox7.Text);
                                com2.ExecuteNonQuery();
                                OleDbCommand com3 = new OleDbCommand(a, dbCon);
                                com3.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com3.Parameters.AddWithValue("@Name_Item", textBox8.Text);
                                com3.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox9.Text));
                                com3.Parameters.AddWithValue("@Desc_Item", textBox10.Text);
                                com3.ExecuteNonQuery();
                                OleDbCommand com4 = new OleDbCommand(a, dbCon);
                                com4.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com4.Parameters.AddWithValue("@Name_Item", textBox11.Text);
                                com4.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox12.Text));
                                com4.Parameters.AddWithValue("@Desc_Item", textBox13.Text);
                                com4.ExecuteNonQuery();
                            }
                            dbCon.Close();
                            MessageBox.Show("Информация успешно добавлена!.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TypeEvent = "Добавление данных в БД";
                            DescEvent = "Пользователь " + user + " добавил данные в таблицу Перечень Заказа";
                            Logg();
                        }
                        catch
                        {
                            TypeEvent = "Ошибка подключения к БД";
                            DescEvent = "Ошибка подключения к БД. Form1, LoadDB(168)";
                            Logg();
                            this.Close();
                        }
                    }
                    if (State == 5)
                    {
                        try
                        {
                            dbCon = new OleDbConnection(ConS);
                            dbCon.Open();
                            using (dbCon)
                            {
                                OleDbCommand com1 = new OleDbCommand(a, dbCon);
                                com1.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com1.Parameters.AddWithValue("@Name_Item", textBox2.Text);
                                com1.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox3.Text));
                                com1.Parameters.AddWithValue("@Desc_Item", textBox4.Text);
                                com1.ExecuteNonQuery();
                                OleDbCommand com2 = new OleDbCommand(a, dbCon);
                                com2.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com2.Parameters.AddWithValue("@Name_Item", textBox5.Text);
                                com2.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox6.Text));
                                com2.Parameters.AddWithValue("@Desc_Item", textBox7.Text);
                                com2.ExecuteNonQuery();
                                OleDbCommand com3 = new OleDbCommand(a, dbCon);
                                com3.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com3.Parameters.AddWithValue("@Name_Item", textBox8.Text);
                                com3.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox9.Text));
                                com3.Parameters.AddWithValue("@Desc_Item", textBox10.Text);
                                com3.ExecuteNonQuery();
                                OleDbCommand com4 = new OleDbCommand(a, dbCon);
                                com4.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com4.Parameters.AddWithValue("@Name_Item", textBox11.Text);
                                com4.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox12.Text));
                                com4.Parameters.AddWithValue("@Desc_Item", textBox13.Text);
                                com4.ExecuteNonQuery();
                                OleDbCommand com5 = new OleDbCommand(a, dbCon);
                                com5.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com5.Parameters.AddWithValue("@Name_Item", textBox14.Text);
                                com5.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox15.Text));
                                com5.Parameters.AddWithValue("@Desc_Item", textBox16.Text);
                                com5.ExecuteNonQuery();
                            }
                            dbCon.Close();
                            MessageBox.Show("Информация успешно добавлена!.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TypeEvent = "Добавление данных в БД";
                            DescEvent = "Пользователь " + user + " добавил данные в таблицу Перечень Заказа";
                            Logg();
                        }
                        catch
                        {
                            TypeEvent = "Ошибка подключения к БД";
                            DescEvent = "Ошибка подключения к БД. Form1, LoadDB(168)";
                            Logg();
                            this.Close();
                        }
                    }
                    if (State == 6)
                    {
                        try
                        {
                            dbCon = new OleDbConnection(ConS);
                            dbCon.Open();
                            using (dbCon)
                            {
                                OleDbCommand com1 = new OleDbCommand(a, dbCon);
                                com1.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com1.Parameters.AddWithValue("@Name_Item", textBox2.Text);
                                com1.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox3.Text));
                                com1.Parameters.AddWithValue("@Desc_Item", textBox4.Text);
                                com1.ExecuteNonQuery();
                                OleDbCommand com2 = new OleDbCommand(a, dbCon);
                                com2.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com2.Parameters.AddWithValue("@Name_Item", textBox5.Text);
                                com2.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox6.Text));
                                com2.Parameters.AddWithValue("@Desc_Item", textBox7.Text);
                                com2.ExecuteNonQuery();
                                OleDbCommand com3 = new OleDbCommand(a, dbCon);
                                com3.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com3.Parameters.AddWithValue("@Name_Item", textBox8.Text);
                                com3.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox9.Text));
                                com3.Parameters.AddWithValue("@Desc_Item", textBox10.Text);
                                com3.ExecuteNonQuery();
                                OleDbCommand com4 = new OleDbCommand(a, dbCon);
                                com4.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com4.Parameters.AddWithValue("@Name_Item", textBox11.Text);
                                com4.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox12.Text));
                                com4.Parameters.AddWithValue("@Desc_Item", textBox13.Text);
                                com4.ExecuteNonQuery();
                                OleDbCommand com5 = new OleDbCommand(a, dbCon);
                                com5.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com5.Parameters.AddWithValue("@Name_Item", textBox14.Text);
                                com5.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox15.Text));
                                com5.Parameters.AddWithValue("@Desc_Item", textBox16.Text);
                                com5.ExecuteNonQuery();
                                OleDbCommand com6 = new OleDbCommand(a, dbCon);
                                com6.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com6.Parameters.AddWithValue("@Name_Item", textBox17.Text);
                                com6.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox18.Text));
                                com6.Parameters.AddWithValue("@Desc_Item", textBox19.Text);
                                com6.ExecuteNonQuery();
                            }
                            dbCon.Close();
                            MessageBox.Show("Информация успешно добавлена!.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TypeEvent = "Добавление данных в БД";
                            DescEvent = "Пользователь " + user + " добавил данные в таблицу Перечень Заказа";
                            Logg();
                        }
                        catch
                        {
                            TypeEvent = "Ошибка подключения к БД";
                            DescEvent = "Ошибка подключения к БД. Form1, LoadDB(168)";
                            Logg();
                            this.Close();
                        }
                    }
                    if (State == 7)
                    {
                        try
                        {
                            dbCon = new OleDbConnection(ConS);
                            dbCon.Open();
                            using (dbCon)
                            {
                                OleDbCommand com1 = new OleDbCommand(a, dbCon);
                                com1.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com1.Parameters.AddWithValue("@Name_Item", textBox2.Text);
                                com1.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox3.Text));
                                com1.Parameters.AddWithValue("@Desc_Item", textBox4.Text);
                                com1.ExecuteNonQuery();
                                OleDbCommand com2 = new OleDbCommand(a, dbCon);
                                com2.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com2.Parameters.AddWithValue("@Name_Item", textBox5.Text);
                                com2.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox6.Text));
                                com2.Parameters.AddWithValue("@Desc_Item", textBox7.Text);
                                com2.ExecuteNonQuery();
                                OleDbCommand com3 = new OleDbCommand(a, dbCon);
                                com3.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com3.Parameters.AddWithValue("@Name_Item", textBox8.Text);
                                com3.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox9.Text));
                                com3.Parameters.AddWithValue("@Desc_Item", textBox10.Text);
                                com3.ExecuteNonQuery();
                                OleDbCommand com4 = new OleDbCommand(a, dbCon);
                                com4.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com4.Parameters.AddWithValue("@Name_Item", textBox11.Text);
                                com4.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox12.Text));
                                com4.Parameters.AddWithValue("@Desc_Item", textBox13.Text);
                                com4.ExecuteNonQuery();
                                OleDbCommand com5 = new OleDbCommand(a, dbCon);
                                com5.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com5.Parameters.AddWithValue("@Name_Item", textBox14.Text);
                                com5.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox15.Text));
                                com5.Parameters.AddWithValue("@Desc_Item", textBox16.Text);
                                com5.ExecuteNonQuery();
                                OleDbCommand com6 = new OleDbCommand(a, dbCon);
                                com6.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com6.Parameters.AddWithValue("@Name_Item", textBox17.Text);
                                com6.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox18.Text));
                                com6.Parameters.AddWithValue("@Desc_Item", textBox19.Text);
                                com6.ExecuteNonQuery();
                                OleDbCommand com7 = new OleDbCommand(a, dbCon);
                                com7.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com7.Parameters.AddWithValue("@Name_Item", textBox20.Text);
                                com7.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox21.Text));
                                com7.Parameters.AddWithValue("@Desc_Item", textBox22.Text);
                                com7.ExecuteNonQuery();
                            }
                            dbCon.Close();
                            MessageBox.Show("Информация успешно добавлена!.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TypeEvent = "Добавление данных в БД";
                            DescEvent = "Пользователь " + user + " добавил данные в таблицу Перечень Заказа";
                            Logg();
                        }
                        catch
                        {
                            TypeEvent = "Ошибка подключения к БД";
                            DescEvent = "Ошибка подключения к БД. Form1, LoadDB(168)";
                            Logg();
                            this.Close();
                        }
                    }
                    if (State == 8)
                    {
                        try
                        {
                            dbCon = new OleDbConnection(ConS);
                            dbCon.Open();
                            using (dbCon)
                            {
                                OleDbCommand com1 = new OleDbCommand(a, dbCon);
                                com1.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com1.Parameters.AddWithValue("@Name_Item", textBox2.Text);
                                com1.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox3.Text));
                                com1.Parameters.AddWithValue("@Desc_Item", textBox4.Text);
                                com1.ExecuteNonQuery();
                                OleDbCommand com2 = new OleDbCommand(a, dbCon);
                                com2.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com2.Parameters.AddWithValue("@Name_Item", textBox5.Text);
                                com2.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox6.Text));
                                com2.Parameters.AddWithValue("@Desc_Item", textBox7.Text);
                                com2.ExecuteNonQuery();
                                OleDbCommand com3 = new OleDbCommand(a, dbCon);
                                com3.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com3.Parameters.AddWithValue("@Name_Item", textBox8.Text);
                                com3.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox9.Text));
                                com3.Parameters.AddWithValue("@Desc_Item", textBox10.Text);
                                com3.ExecuteNonQuery();
                                OleDbCommand com4 = new OleDbCommand(a, dbCon);
                                com4.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com4.Parameters.AddWithValue("@Name_Item", textBox11.Text);
                                com4.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox12.Text));
                                com4.Parameters.AddWithValue("@Desc_Item", textBox13.Text);
                                com4.ExecuteNonQuery();
                                OleDbCommand com5 = new OleDbCommand(a, dbCon);
                                com5.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com5.Parameters.AddWithValue("@Name_Item", textBox14.Text);
                                com5.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox15.Text));
                                com5.Parameters.AddWithValue("@Desc_Item", textBox16.Text);
                                com5.ExecuteNonQuery();
                                OleDbCommand com6 = new OleDbCommand(a, dbCon);
                                com6.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com6.Parameters.AddWithValue("@Name_Item", textBox17.Text);
                                com6.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox18.Text));
                                com6.Parameters.AddWithValue("@Desc_Item", textBox19.Text);
                                com6.ExecuteNonQuery();
                                OleDbCommand com7 = new OleDbCommand(a, dbCon);
                                com7.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com7.Parameters.AddWithValue("@Name_Item", textBox20.Text);
                                com7.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox21.Text));
                                com7.Parameters.AddWithValue("@Desc_Item", textBox22.Text);
                                com7.ExecuteNonQuery();
                                OleDbCommand com8 = new OleDbCommand(a, dbCon);
                                com8.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com8.Parameters.AddWithValue("@Name_Item", textBox23.Text);
                                com8.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox24.Text));
                                com8.Parameters.AddWithValue("@Desc_Item", textBox25.Text);
                                com8.ExecuteNonQuery();
                            }
                            dbCon.Close();
                            MessageBox.Show("Информация успешно добавлена!.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TypeEvent = "Добавление данных в БД";
                            DescEvent = "Пользователь " + user + " добавил данные в таблицу Перечень Заказа";
                            Logg();
                        }
                        catch
                        {
                            TypeEvent = "Ошибка подключения к БД";
                            DescEvent = "Ошибка подключения к БД. Form1, LoadDB(168)";
                            Logg();
                            this.Close();
                        }
                    }
                    if (State == 9)
                    {
                        try
                        {
                            dbCon = new OleDbConnection(ConS);
                            dbCon.Open();
                            using (dbCon)
                            {
                                OleDbCommand com1 = new OleDbCommand(a, dbCon);
                                com1.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com1.Parameters.AddWithValue("@Name_Item", textBox2.Text);
                                com1.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox3.Text));
                                com1.Parameters.AddWithValue("@Desc_Item", textBox4.Text);
                                com1.ExecuteNonQuery();
                                OleDbCommand com2 = new OleDbCommand(a, dbCon);
                                com2.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com2.Parameters.AddWithValue("@Name_Item", textBox5.Text);
                                com2.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox6.Text));
                                com2.Parameters.AddWithValue("@Desc_Item", textBox7.Text);
                                com2.ExecuteNonQuery();
                                OleDbCommand com3 = new OleDbCommand(a, dbCon);
                                com3.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com3.Parameters.AddWithValue("@Name_Item", textBox8.Text);
                                com3.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox9.Text));
                                com3.Parameters.AddWithValue("@Desc_Item", textBox10.Text);
                                com3.ExecuteNonQuery();
                                OleDbCommand com4 = new OleDbCommand(a, dbCon);
                                com4.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com4.Parameters.AddWithValue("@Name_Item", textBox11.Text);
                                com4.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox12.Text));
                                com4.Parameters.AddWithValue("@Desc_Item", textBox13.Text);
                                com4.ExecuteNonQuery();
                                OleDbCommand com5 = new OleDbCommand(a, dbCon);
                                com5.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com5.Parameters.AddWithValue("@Name_Item", textBox14.Text);
                                com5.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox15.Text));
                                com5.Parameters.AddWithValue("@Desc_Item", textBox16.Text);
                                com5.ExecuteNonQuery();
                                OleDbCommand com6 = new OleDbCommand(a, dbCon);
                                com6.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com6.Parameters.AddWithValue("@Name_Item", textBox17.Text);
                                com6.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox18.Text));
                                com6.Parameters.AddWithValue("@Desc_Item", textBox19.Text);
                                com6.ExecuteNonQuery();
                                OleDbCommand com7 = new OleDbCommand(a, dbCon);
                                com7.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com7.Parameters.AddWithValue("@Name_Item", textBox20.Text);
                                com7.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox21.Text));
                                com7.Parameters.AddWithValue("@Desc_Item", textBox22.Text);
                                com7.ExecuteNonQuery();
                                OleDbCommand com8 = new OleDbCommand(a, dbCon);
                                com8.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com8.Parameters.AddWithValue("@Name_Item", textBox23.Text);
                                com8.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox24.Text));
                                com8.Parameters.AddWithValue("@Desc_Item", textBox25.Text);
                                com8.ExecuteNonQuery();
                                OleDbCommand com9 = new OleDbCommand(a, dbCon);
                                com9.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com9.Parameters.AddWithValue("@Name_Item", textBox26.Text);
                                com9.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox27.Text));
                                com9.Parameters.AddWithValue("@Desc_Item", textBox28.Text);
                                com9.ExecuteNonQuery();
                            }
                            dbCon.Close();
                            MessageBox.Show("Информация успешно добавлена!.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TypeEvent = "Добавление данных в БД";
                            DescEvent = "Пользователь " + user + " добавил данные в таблицу Перечень Заказа";
                            Logg();
                        }
                        catch
                        {
                            TypeEvent = "Ошибка подключения к БД";
                            DescEvent = "Ошибка подключения к БД. Form1, LoadDB(168)";
                            Logg();
                            this.Close();
                        }
                    }
                    if (State == 10)
                    {
                        try
                        {
                            dbCon = new OleDbConnection(ConS);
                            dbCon.Open();
                            using (dbCon)
                            {
                                OleDbCommand com1 = new OleDbCommand(a, dbCon);
                                com1.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com1.Parameters.AddWithValue("@Name_Item", textBox2.Text);
                                com1.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox3.Text));
                                com1.Parameters.AddWithValue("@Desc_Item", textBox4.Text);
                                com1.ExecuteNonQuery();
                                OleDbCommand com2 = new OleDbCommand(a, dbCon);
                                com2.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com2.Parameters.AddWithValue("@Name_Item", textBox5.Text);
                                com2.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox6.Text));
                                com2.Parameters.AddWithValue("@Desc_Item", textBox7.Text);
                                com2.ExecuteNonQuery();
                                OleDbCommand com3 = new OleDbCommand(a, dbCon);
                                com3.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com3.Parameters.AddWithValue("@Name_Item", textBox8.Text);
                                com3.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox9.Text));
                                com3.Parameters.AddWithValue("@Desc_Item", textBox10.Text);
                                com3.ExecuteNonQuery();
                                OleDbCommand com4 = new OleDbCommand(a, dbCon);
                                com4.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com4.Parameters.AddWithValue("@Name_Item", textBox11.Text);
                                com4.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox12.Text));
                                com4.Parameters.AddWithValue("@Desc_Item", textBox13.Text);
                                com4.ExecuteNonQuery();
                                OleDbCommand com5 = new OleDbCommand(a, dbCon);
                                com5.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com5.Parameters.AddWithValue("@Name_Item", textBox14.Text);
                                com5.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox15.Text));
                                com5.Parameters.AddWithValue("@Desc_Item", textBox16.Text);
                                com5.ExecuteNonQuery();
                                OleDbCommand com6 = new OleDbCommand(a, dbCon);
                                com6.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com6.Parameters.AddWithValue("@Name_Item", textBox17.Text);
                                com6.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox18.Text));
                                com6.Parameters.AddWithValue("@Desc_Item", textBox19.Text);
                                com6.ExecuteNonQuery();
                                OleDbCommand com7 = new OleDbCommand(a, dbCon);
                                com7.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com7.Parameters.AddWithValue("@Name_Item", textBox20.Text);
                                com7.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox21.Text));
                                com7.Parameters.AddWithValue("@Desc_Item", textBox22.Text);
                                com7.ExecuteNonQuery();
                                OleDbCommand com8 = new OleDbCommand(a, dbCon);
                                com8.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com8.Parameters.AddWithValue("@Name_Item", textBox23.Text);
                                com8.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox24.Text));
                                com8.Parameters.AddWithValue("@Desc_Item", textBox25.Text);
                                com8.ExecuteNonQuery();
                                OleDbCommand com9 = new OleDbCommand(a, dbCon);
                                com9.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com9.Parameters.AddWithValue("@Name_Item", textBox26.Text);
                                com9.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox27.Text));
                                com9.Parameters.AddWithValue("@Desc_Item", textBox28.Text);
                                com9.ExecuteNonQuery();
                                OleDbCommand com10 = new OleDbCommand(a, dbCon);
                                com10.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(textBox1.Text));
                                com10.Parameters.AddWithValue("@Name_Item", textBox29.Text);
                                com10.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(textBox30.Text));
                                com10.Parameters.AddWithValue("@Desc_Item", textBox31.Text);
                                com10.ExecuteNonQuery();
                            }
                            dbCon.Close();
                            MessageBox.Show("Информация успешно добавлена!.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TypeEvent = "Добавление данных в БД";
                            DescEvent = "Пользователь " + user + " добавил данные в таблицу Перечень Заказа";
                            Logg();
                        }
                        catch
                        {
                            TypeEvent = "Ошибка подключения к БД";
                            DescEvent = "Ошибка подключения к БД. Form1, LoadDB(168)";
                            Logg();
                            this.Close();
                        }
                    }
                    textBox1.Text = "Введите код Заказа БД для Связи";
                    textBox2.Text = "Введите Имя Строки 1";
                    textBox3.Text = "Введите Число 1";
                    textBox4.Text = "Введите Описание/Пометки Строки при необходимости";
                    textBox5.Text = "Введите Имя Строки 2";
                    textBox6.Text = "Введите Число 2";
                    textBox7.Text = "Введите Описание/Пометки Строки при необходимости";
                    textBox8.Text = "Введите Имя Строки 3";
                    textBox9.Text = "Введите Число 3";
                    textBox10.Text = "Введите Описание/Пометки Строки при необходимости";
                    textBox11.Text = "Введите Имя Строки 4";
                    textBox12.Text = "Введите Число 4";
                    textBox13.Text = "Введите Описание/Пометки Строки при необходимости";
                    textBox14.Text = "Введите Имя Строки 5";
                    textBox15.Text = "Введите Число 5";
                    textBox16.Text = "Введите Описание/Пометки Строки при необходимости";
                    textBox17.Text = "Введите Имя Строки 6";
                    textBox18.Text = "Введите Число 6";
                    textBox19.Text = "Введите Описание/Пометки Строки при необходимости";
                    textBox20.Text = "Введите Имя Строки 7";
                    textBox21.Text = "Введите Число 7";
                    textBox22.Text = "Введите Описание/Пометки Строки при необходимости";
                    textBox23.Text = "Введите Имя Строки 8";
                    textBox24.Text = "Введите Число 8";
                    textBox25.Text = "Введите Описание/Пометки Строки при необходимости";
                    textBox26.Text = "Введите Имя Строки 9";
                    textBox27.Text = "Введите Число 9";
                    textBox28.Text = "Введите Описание/Пометки Строки при необходимости";
                    textBox29.Text = "Введите Имя Строки 10";
                    textBox30.Text = "Введите Число 10";
                    textBox31.Text = "Введите Описание/Пометки Строки при необходимости";
                    textBox1.ForeColor = Color.Gray;
                    textBox2.ForeColor = Color.Gray;
                    textBox3.ForeColor = Color.Gray;
                    textBox4.ForeColor = Color.Gray;
                    textBox5.ForeColor = Color.Gray;
                    textBox6.ForeColor = Color.Gray;
                    textBox7.ForeColor = Color.Gray;
                    textBox8.ForeColor = Color.Gray;
                    textBox9.ForeColor = Color.Gray;
                    textBox10.ForeColor = Color.Gray;
                    textBox11.ForeColor = Color.Gray;
                    textBox12.ForeColor = Color.Gray;
                    textBox13.ForeColor = Color.Gray;
                    textBox14.ForeColor = Color.Gray;
                    textBox15.ForeColor = Color.Gray;
                    textBox16.ForeColor = Color.Gray;
                    textBox17.ForeColor = Color.Gray;
                    textBox18.ForeColor = Color.Gray;
                    textBox19.ForeColor = Color.Gray;
                    textBox20.ForeColor = Color.Gray;
                    textBox21.ForeColor = Color.Gray;
                    textBox22.ForeColor = Color.Gray;
                    textBox23.ForeColor = Color.Gray;
                    textBox24.ForeColor = Color.Gray;
                    textBox25.ForeColor = Color.Gray;
                    textBox26.ForeColor = Color.Gray;
                    textBox27.ForeColor = Color.Gray;
                    textBox28.ForeColor = Color.Gray;
                    textBox29.ForeColor = Color.Gray;
                    textBox30.ForeColor = Color.Gray;
                    textBox31.ForeColor = Color.Gray;
                }
                if (res == DialogResult.No)
                {
                    DialogResult res1 = MessageBox.Show("Ну и не добавляй " + State + " строк из 10. Пока!", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (res1 == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    if (res1 == DialogResult.No)
                    {
                        MessageBox.Show("Ладно, как программа я позволю вам добавить строки)", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            else
            {
                MessageBox.Show("Введите Код Заказа БД для связи (число).", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.ForeColor = Color.Black;
        }
        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox4.ForeColor = Color.Black;
        }
        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox5.ForeColor = Color.Black;
        }
        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.Text = "";
            textBox6.ForeColor = Color.Black;
        }
        private void textBox7_Enter(object sender, EventArgs e)
        {
            textBox7.Text = "";
            textBox7.ForeColor = Color.Black;
        }
        private void textBox8_Enter(object sender, EventArgs e)
        {
            textBox8.Text = "";
            textBox8.ForeColor = Color.Black;
        }
        private void textBox9_Enter(object sender, EventArgs e)
        {
            textBox9.Text = "";
            textBox9.ForeColor = Color.Black;
        }
        private void textBox10_Enter(object sender, EventArgs e)
        {
            textBox10.Text = "";
            textBox10.ForeColor = Color.Black;
        }
        private void textBox11_Enter(object sender, EventArgs e)
        {
            textBox11.Text = "";
            textBox11.ForeColor = Color.Black;
        }
        private void textBox12_Enter(object sender, EventArgs e)
        {
            textBox12.Text = "";
            textBox12.ForeColor = Color.Black;
        }
        private void textBox13_Enter(object sender, EventArgs e)
        {
            textBox13.Text = "";
            textBox13.ForeColor = Color.Black;
        }
        private void textBox14_Enter(object sender, EventArgs e)
        {
            textBox14.Text = "";
            textBox14.ForeColor = Color.Black;
        }
        private void textBox15_Enter(object sender, EventArgs e)
        {
            textBox15.Text = "";
            textBox15.ForeColor = Color.Black;
        }
        private void textBox16_Enter(object sender, EventArgs e)
        {
            textBox16.Text = "";
            textBox16.ForeColor = Color.Black;
        }
        private void textBox17_Enter(object sender, EventArgs e)
        {
            textBox17.Text = "";
            textBox17.ForeColor = Color.Black;
        }
        private void textBox18_Enter(object sender, EventArgs e)
        {
            textBox18.Text = "";
            textBox18.ForeColor = Color.Black;
        }
        private void textBox19_Enter(object sender, EventArgs e)
        {
            textBox19.Text = "";
            textBox19.ForeColor = Color.Black;
        }
        private void textBox20_Enter(object sender, EventArgs e)
        {
            textBox20.Text = "";
            textBox20.ForeColor = Color.Black;
        }
        private void textBox21_Enter(object sender, EventArgs e)
        {
            textBox21.Text = "";
            textBox21.ForeColor = Color.Black;
        }
        private void textBox22_Enter(object sender, EventArgs e)
        {
            textBox22.Text = "";
            textBox22.ForeColor = Color.Black;
        }
        private void textBox23_Enter(object sender, EventArgs e)
        {
            textBox23.Text = "";
            textBox23.ForeColor = Color.Black;
        }
        private void textBox24_Enter(object sender, EventArgs e)
        {
            textBox24.Text = "";
            textBox24.ForeColor = Color.Black;
        }
        private void textBox25_Enter(object sender, EventArgs e)
        {
            textBox25.Text = "";
            textBox25.ForeColor = Color.Black;
        }
        private void textBox26_Enter(object sender, EventArgs e)
        {
            textBox26.Text = "";
            textBox26.ForeColor = Color.Black;
        }
        private void textBox27_Enter(object sender, EventArgs e)
        {
            textBox27.Text = "";
            textBox27.ForeColor = Color.Black;
        }
        private void textBox28_Enter(object sender, EventArgs e)
        {
            textBox28.Text = "";
            textBox28.ForeColor = Color.Black;
        }
        private void textBox29_Enter(object sender, EventArgs e)
        {
            textBox29.Text = "";
            textBox29.ForeColor = Color.Black;
        }
        private void textBox30_Enter(object sender, EventArgs e)
        {
            textBox30.Text = "";
            textBox30.ForeColor = Color.Black;
        }
        private void textBox31_Enter(object sender, EventArgs e)
        {
            textBox31.Text = "";
            textBox31.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы действительно хотите отменить ввод?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                this.Close();
            }
            if (res == DialogResult.No)
            {
                return;
            }

        }
    }
}
