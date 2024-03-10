using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NORMAPP
{
    public partial class Form1 : Form
    {
        //Переменные, инициализация
        #region
        public Form1()
        {
            InitializeComponent();
        }
        private OleDbConnection dbCon;
        public OleDbConnection DbCon;
        string ConS = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|NORMDB.mdb;Persist Security Info=True;Jet OLEDB:Database Password=KoluginDBF@007@";
        int NPEnter = 0;
        string TypeEvent = "";
        public string a = "";
        public string user = "";
        string DescEvent = "";
        int StateF = 0;
        int exit = 0;
        public string a1 = "";
        public string a2 = "";
        public string a3 = "";
        public string a4 = "";
        public string a5 = "";
        public string a6 = "";
        public string a7 = "";
        public float f1 = 0;
        public float f2 = 0;
        public float f3 = 0;
        public float f4 = 0;
        public float f5 = 0;
        public int i1 = 0;
        public int i2 = 0;
        public int i3 = 0;
        public int lang = 0;
        public string Status = "";
        string q3 = "SELECT Users.N_User FROM Users";
        Stopwatch stwach1 = new Stopwatch();
        #endregion
        private void Form1_Load(object sender, EventArgs e) // Загрузка формы
        {
            MessageBox.Show("В этой версии добавлено: \n - Список заказчиков 800+ строк " +
                "\n - Список ГОСТ 1200+ строк " +
                "\n - Исправлены ошибки в запросах"+
                "\n - Улучшен процесс переписки внутри программы"+
                "\n - Частично внедрена система прав Пользователей" , "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.ActiveControl = button2;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 60000;
            menuStrip1.Visible = false;
            panel1.Visible = true;
            comboBox1.ForeColor = Color.Gray;
            textBox2.ForeColor = Color.Gray;
            if (lang == 0)
            {

            }
            if (lang == 1)
            {

            }
            button1.Text = "Вход";
            button2.Text = "Выход";
            comboBox1.Text = "Выберите ваш логин";
            textBox2.Text = "Введите ваш пароль";
            TypeEvent = "Запуск программы";
            DescEvent = "Программа успешно запущена";
            Status = "Online";
            Logg();
            dbCon = new OleDbConnection(ConS);
            dbCon.Open();
            using (dbCon)
            {
                OleDbCommand cmd = new OleDbCommand(q3, dbCon);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    toolStripTextBox1.Items.Add(reader.GetString(0));
                    comboBox1.Items.Add(reader.GetString(0));
                }
                reader.Close();
            }
            dbCon.Close();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) //Закрытие формы
        {
            Exet();
            if (exit == 1)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void предложениеПоУлучшениюToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Form6 f6 = new Form6();
           f6.Show();
        }
        public void Visibl()
        {
            panel1.Visible = false;
            panel1.Enabled = false;
            menuStrip1.Visible = true;
            tabControl1.Visible = true;
        }
        public void Exet()
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                exit = 1;
                DbCon = new OleDbConnection(ConS);
                DbCon.Open();
                Status = "Offline";
                TypeEvent = "Выход из программы " + user;
                DescEvent = "Пользователь " + user + " вышел из программы";
                Logg();
                using (DbCon)
                {
                    try
                    {
                        OleDbCommand com5 = new OleDbCommand("UPDATE Users SET Users.Online_User ='" + Convert.ToString(Status) + "' WHERE ((([Users].[N_User])='" + Convert.ToString(user) + "'))", DbCon);
                        com5.ExecuteNonQuery();
                        DbCon.Close();
                    }
                    catch (Exception ex)
                    {
                        exit = 0;
                        MessageBox.Show($"Ошибка: {ex.Message}");
                        DbCon.Close();
                        return;
                    }
                }
            }
            if (result == DialogResult.No)
            {
                exit = 0;
                return;
            }
        } // Процедура выхода из программы
        public void LoadDB() // Процедура загрузки таблицы
        {
           stwach1.Reset();
           using (dbCon = new OleDbConnection(ConS))
           {
               dbCon.Open();
               try
               {
                   OleDbCommand cmd = new OleDbCommand(a, dbCon);
                   OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                   DataTable dt = new DataTable(); 

                   if (StateF == 0 || (StateF >= 12 && StateF <= 15))
                   {
                       stwach1.Start();
                       dataGridView1.DataSource = dt;
                       ad.Fill(dt);
                       dataGridView1.Columns[0].HeaderText = "Код Заказчика БД";
                       dataGridView1.Columns[1].HeaderText = "Код Заказчика";
                       dataGridView1.Columns[2].HeaderText = "Имя Заказчика";
                       dataGridView1.Columns[3].HeaderText = "Тип Заказчика";
                       dataGridView1.Columns[4].HeaderText = "Описание/Пометки Заказчика";
                       stwach1.Stop();
               } // Вывод таблицы заказчиков+
                    if (StateF == 1 || (StateF >= 16 && StateF <= 22))
                    {
                        stwach1.Start();
                        dataGridView1.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView1.Columns[0].HeaderText = "Код Заказа БД";
                        dataGridView1.Columns[1].HeaderText = "Код Заказа";
                        dataGridView1.Columns[2].HeaderText = "Код Заказчика БД";
                        dataGridView1.Columns[3].HeaderText = "Имя Заказа";
                        dataGridView1.Columns[4].HeaderText = "Тип Заказа";
                        dataGridView1.Columns[5].HeaderText = "Дата Заказа";
                        dataGridView1.Columns[6].HeaderText = "Описание/Пометки Заказа";
                        stwach1.Stop();
                    } // Вывод Таблицы заказов+
                    if (StateF == 2 || (StateF >= 23 && StateF <= 25))
                    {
                        stwach1.Start();
                        dataGridView1.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView1.Columns[0].HeaderText = "Код Строки Перечня БД";
                        dataGridView1.Columns[1].HeaderText = "Код Заказа БД";
                        dataGridView1.Columns[2].HeaderText = "Имя Строки Перечня";
                        dataGridView1.Columns[3].HeaderText = "Количество Шт.";
                        dataGridView1.Columns[4].HeaderText = "Описание/Пометки Строки";
                        stwach1.Stop();
                    } // Вывод Таблицы Перечня Заказа+
                    if (StateF == 3 || (StateF >= 35 && StateF <= 38))
                    {
                        stwach1.Start();
                        dataGridView2.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView2.Columns[0].HeaderText = "Код Изделия БД";
                        dataGridView2.Columns[1].HeaderText = "Код Изделия";
                        dataGridView2.Columns[2].HeaderText = "Имя Изделия";
                        dataGridView2.Columns[3].HeaderText = "Тип Изделия";
                        dataGridView2.Columns[4].HeaderText = "ГОСТ Изделия";
                        dataGridView2.Columns[5].HeaderText = "Масса кг.";
                        dataGridView2.Columns[6].HeaderText = "Длинна мм.";
                        dataGridView2.Columns[7].HeaderText = "Ширина мм.";
                        dataGridView2.Columns[8].HeaderText = "Высота мм.";
                        dataGridView2.Columns[9].HeaderText = "Описание/Пометки Изделия";
                        stwach1.Stop();
                    } // Вывод Изделия
                    if (StateF == 4 || (StateF >= 39 && StateF <= 44))
                    {
                        stwach1.Start();
                        dataGridView2.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView2.Columns[0].HeaderText = "Код Узла/Детали БД";
                        dataGridView2.Columns[1].HeaderText = "Код Узла/Детали";
                        dataGridView2.Columns[2].HeaderText = "Порядковый № Вложенности";
                        dataGridView2.Columns[3].HeaderText = "№ Узла/Детали";
                        dataGridView2.Columns[4].HeaderText = "Имя Узла/Детали";
                        dataGridView2.Columns[5].HeaderText = "Тип Узла/Детали";
                        dataGridView2.Columns[6].HeaderText = "ГОСТ Узла/Детали";
                        dataGridView2.Columns[7].HeaderText = "Действие";
                        dataGridView2.Columns[8].HeaderText = "Кол-во шт.";
                        dataGridView2.Columns[9].HeaderText = "Масса кг.";
                        dataGridView2.Columns[10].HeaderText = "Длинна мм.";
                        dataGridView2.Columns[11].HeaderText = "Ширина мм.";
                        dataGridView2.Columns[12].HeaderText = "Высота мм.";
                        dataGridView2.Columns[13].HeaderText = "Описание/Пометки Узла/Детали";
                        stwach1.Stop();
                    } // Вывод Узла/Детали
                    if (StateF == 5 || (StateF >= 50 && StateF <= 54))
                    {
                        stwach1.Start();
                        dataGridView3.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView3.Columns[0].HeaderText = "Код Материала БД";
                        dataGridView3.Columns[1].HeaderText = "Код Материала";
                        dataGridView3.Columns[2].HeaderText = "Имя Материала";
                        dataGridView3.Columns[3].HeaderText = "ГОСТ Материала";
                        dataGridView3.Columns[4].HeaderText = "Марка Материала";
                        dataGridView3.Columns[5].HeaderText = "Тип Материала";
                        dataGridView3.Columns[6].HeaderText = "Описание/Пометки Материала";
                        stwach1.Stop();
                    } // Вывод Материала
                    if (StateF == 6 || (StateF >= 55 && StateF <= 56))
                    {
                        stwach1.Start();
                        dataGridView3.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView3.Columns[0].HeaderText = "Код Нормы БД";
                        dataGridView3.Columns[1].HeaderText = "Тип Нормы";
                        dataGridView3.Columns[2].HeaderText = "ГОСТ Нормы";
                        dataGridView3.Columns[3].HeaderText = "Кол-во материала 1";
                        dataGridView3.Columns[4].HeaderText = "Кол-во материала 2";
                        dataGridView3.Columns[5].HeaderText = "Кол-во упаковки";
                        dataGridView3.Columns[6].HeaderText = "Ед. изм.";
                        dataGridView3.Columns[7].HeaderText = "Описание/Пометки Нормы";
                        stwach1.Stop();
                    } // Вывод Нормы
                    if (StateF == 7 || (StateF >= 57 && StateF <= 58))
                    {
                        stwach1.Start();
                        dataGridView3.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView3.Columns[0].HeaderText = "Код ГОСТ БД";
                        dataGridView3.Columns[1].HeaderText = "Имя ГОСТа";
                        dataGridView3.Columns[2].HeaderText = "Описание/Пометки ГОСТа";
                        stwach1.Stop();
                    } // Вывод ГОСТ
                    if (StateF == 8 || (StateF >= 71 && StateF <= 76))
                    {
                        stwach1.Start();
                        dataGridView5.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView5.Columns[0].HeaderText = "Код Строки Связи БД";
                        dataGridView5.Columns[1].HeaderText = "Код Строки Перечня БД";
                        dataGridView5.Columns[2].HeaderText = "Код Изделия БД";
                        dataGridView5.Columns[3].HeaderText = "Код Узла/Детали БД";
                        dataGridView5.Columns[4].HeaderText = "Код Материала БД";
                        dataGridView5.Columns[5].HeaderText = "Код Нормы БД";
                        stwach1.Stop();
                    } // Вывод Связей БД
                    if (StateF == 9 || (StateF >= 79 && StateF <= 81))
                    {
                        stwach1.Start();
                        dataGridView4.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView4.Columns[0].HeaderText = "Код Пользователя БД";
                        dataGridView4.Columns[1].HeaderText = "Имя Пользоватея";
                        dataGridView4.Columns[2].HeaderText = "Пароль Пользователя";
                        dataGridView4.Columns[3].HeaderText = "Тип Пользователя";
                        dataGridView4.Columns[4].HeaderText = "Права Пользователя";
                        dataGridView4.Columns[5].HeaderText = "Статус";

                        stwach1.Stop();
                    } // Вывод Всех Пользователей
                    if (StateF == 10 || (StateF >= 82 && StateF <= 85))
                    {
                        stwach1.Start();
                        dataGridView4.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView4.Columns[0].HeaderText = "Код Лога БД";
                        dataGridView4.Columns[1].HeaderText = "Дата";
                        dataGridView4.Columns[2].HeaderText = "Тип";
                        dataGridView4.Columns[3].HeaderText = "Описание";
                        stwach1.Stop();
                    } // Вывод Всех Логов
                    if (StateF == 11)
                    {
                        stwach1.Start();
                        dataGridView4.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView4.Columns[0].HeaderText = "Код Предложения БД";
                        dataGridView4.Columns[1].HeaderText = "Дата";
                        dataGridView4.Columns[2].HeaderText = "Информация";
                        dataGridView4.Columns[3].HeaderText = "Кто Предложил";
                        stwach1.Stop();
                    }                                   // Вывод Всех Предложений
                    //--------------------------------------------------------ПОИСК ПРО Заказчик Заказ Перечень+
                    if (StateF == 26)
                    {
                        stwach1.Start();
                        dataGridView1.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView1.Columns[0].HeaderText = "Имя Заказчика";
                        dataGridView1.Columns[1].HeaderText = "Имя Заказа";
                        dataGridView1.Columns[2].HeaderText = "Тип Заказа";
                        dataGridView1.Columns[3].HeaderText = "Дата Заказа";
                        dataGridView1.Columns[4].HeaderText = "Описание/Пометки Заказа";
                        stwach1.Stop();
                    }
                    if (StateF == 27)
                    {
                        stwach1.Start();
                        dataGridView1.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView1.Columns[0].HeaderText = "Имя Заказа";
                        dataGridView1.Columns[1].HeaderText = "Тип Заказа";
                        dataGridView1.Columns[2].HeaderText = "Дата Заказа";
                        dataGridView1.Columns[3].HeaderText = "Имя Строки Перечня";
                        dataGridView1.Columns[4].HeaderText = "Количество Шт.";
                        stwach1.Stop();
                    }
                    if (StateF == 28)
                    {
                        stwach1.Start();
                        dataGridView1.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView1.Columns[0].HeaderText = "Код Заказчика";
                        dataGridView1.Columns[1].HeaderText = "Имя Заказчика";
                        dataGridView1.Columns[2].HeaderText = "Код Заказа";
                        dataGridView1.Columns[3].HeaderText = "Имя Заказа";
                        dataGridView1.Columns[4].HeaderText = "Тип Заказа";
                        dataGridView1.Columns[5].HeaderText = "Дата Заказа";
                        dataGridView1.Columns[6].HeaderText = "Имя Строки Перечня";
                        dataGridView1.Columns[7].HeaderText = "Количество Шт.";
                        stwach1.Stop();
                    }
                    //------------------------------------Добавление Заказа, Заказчика, Перечня++++++
                    if (StateF == 29)
                    {
                        stwach1.Start();
                        OleDbCommand com = new OleDbCommand(a, dbCon);
                        com.Parameters.AddWithValue("@ID_Cust", a1);
                        com.Parameters.AddWithValue("@Name_Cust", a2);
                        com.Parameters.AddWithValue("@Type_Cust", a3);
                        com.Parameters.AddWithValue("@Desc_Cust", a4);
                        com.ExecuteNonQuery();
                        stwach1.Stop();
                        Logg();
                        return;
                    }
                    if (StateF == 30)
                    {
                        stwach1.Start();
                        OleDbCommand com = new OleDbCommand(a, dbCon);
                        com.Parameters.AddWithValue("@ID_CustDB", Convert.ToInt32(a1));
                        com.Parameters.AddWithValue("@ID_Order", a2);
                        com.Parameters.AddWithValue("@Name_Order", a3);
                        com.Parameters.AddWithValue("@Date_Order", a4);
                        com.Parameters.AddWithValue("@Type_Order", a5);
                        com.Parameters.AddWithValue("@Desc_Order", a6);
                        com.ExecuteNonQuery();
                        stwach1.Stop();
                        Logg();
                        return;
                    }
                    if (StateF == 31)
                    {
                        stwach1.Start();
                        OleDbCommand com = new OleDbCommand(a, dbCon);
                        com.Parameters.AddWithValue("@ID_OrderDB", Convert.ToInt32(a1));
                        com.Parameters.AddWithValue("@Name_Item", a2);
                        com.Parameters.AddWithValue("@Count_Item", Convert.ToInt32(a3));
                        com.Parameters.AddWithValue("@Desc_Item", a4);
                        com.ExecuteNonQuery();
                        stwach1.Stop();
                        Logg();
                        return;
                    }
                    //------------------------------------Удаление Заказа, Заказчика, Перечня+
                    if (StateF == 32)
                    {
                        Delete();
                        TypeEvent = "Удаление данных из БД";
                        DescEvent = "Пользователь " + user + " Удалил данные из таблицы Заказчик";
                        Logg();
                        return;
                    }
                    if (StateF == 33)
                    {
                        Delete();
                        TypeEvent = "Удаление данных из БД";
                        DescEvent = "Пользователь " + user + " Удалил данные из таблицы Заказы";
                        Logg();
                        return;
                    }
                    if (StateF == 34)
                    {
                        Delete();
                        TypeEvent = "Удаление данных из БД";
                        DescEvent = "Пользователь " + user + " Удалил данные из таблицы Перечень Заказа";
                        Logg();
                        return;
                    }
                    //---------------------------------------ПОИСК ПРО ИЗДЕЛИЕ УЗЕЛ ДЕТАЛЬ+
                    if (StateF == 45)
                    {
                        stwach1.Start();
                        dataGridView2.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView2.Columns[0].HeaderText = "Код Изделия";
                        dataGridView2.Columns[1].HeaderText = "Имя Изделия";
                        dataGridView2.Columns[2].HeaderText = "ГОСТ Изделия";
                        dataGridView2.Columns[3].HeaderText = "№ Вложенности Узла/Детали";
                        dataGridView2.Columns[4].HeaderText = "Порядковый № Узла/Детали";
                        dataGridView2.Columns[5].HeaderText = "Имя Узла/Детали";
                        dataGridView2.Columns[6].HeaderText = "Тип Узла/Детали";
                        dataGridView2.Columns[7].HeaderText = "ГОСТ Узла/Детали";
                        dataGridView2.Columns[8].HeaderText = "Кол-во шт.";
                        stwach1.Stop();
                    }
                    //----------------------------------------Добавление Изделия Узла Детали+
                    if (StateF == 46)
                    {
                        stwach1.Start();
                        OleDbCommand com = new OleDbCommand(a, dbCon);
                        com.Parameters.AddWithValue("@ID_Spec0", a1);
                        com.Parameters.AddWithValue("@Name_Spec0", a2);
                        com.Parameters.AddWithValue("@Type_Spec0", a3);
                        com.Parameters.AddWithValue("@GOST_Spec0", a4);
                        com.Parameters.AddWithValue("@Mass_Spec0", f1);
                        com.Parameters.AddWithValue("@L_Spec0", f2);
                        com.Parameters.AddWithValue("@W_Spec0", f3);
                        com.Parameters.AddWithValue("@H_Spec0", f4);
                        com.Parameters.AddWithValue("@Desc_Spec0", a5);
                        com.ExecuteNonQuery();
                        stwach1.Stop();
                        Logg();
                        return;
                    }
                    if (StateF == 47)
                    {

                        stwach1.Start();
                        OleDbCommand com = new OleDbCommand(a, dbCon);
                        com.Parameters.AddWithValue("@ID_Spec1", a1);
                        com.Parameters.AddWithValue("@PNV_Spec1", a2);
                        com.Parameters.AddWithValue("@PN_Spec1", i1);
                        com.Parameters.AddWithValue("@Name_Spec1", a3);
                        com.Parameters.AddWithValue("@Type_Spec1", a4);
                        com.Parameters.AddWithValue("@GOST_Spec1", a5);
                        com.Parameters.AddWithValue("@Action_Spec1", a6);
                        com.Parameters.AddWithValue("@Num_Spec1", i2);
                        com.Parameters.AddWithValue("@Mass_Spec1", f1);
                        com.Parameters.AddWithValue("@L_Spec1", f2);
                        com.Parameters.AddWithValue("@W_Spec1", f3);
                        com.Parameters.AddWithValue("@H_Spec1", f4);
                        com.Parameters.AddWithValue("@Desc_Spec1", a7);
                        com.ExecuteNonQuery();
                        stwach1.Stop();
                        Logg();
                        return;
                    }
                    //------------------------------------Удаление Изделия Узла/Детали+
                    if (StateF == 48)
                    {
                        Delete();
                        TypeEvent = "Удаление данных из БД";
                        DescEvent = "Пользователь " + user + " Удалил данные из таблицы Изделие";
                        Logg();
                        return;
                    }
                    if (StateF == 49)
                    {
                        Delete();
                        TypeEvent = "Удаление данных из БД";
                        DescEvent = "Пользователь " + user + " Удалил данные из таблицы Изделие";
                        Logg();
                        return;
                    }
                    //--------------------------------------ПОИСК ПРО Материал НОРМ ГОСТ+
                    if (StateF == 59)
                    {
                        stwach1.Start();
                        dataGridView3.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView3.Columns[0].HeaderText = "Тип Нормы";
                        dataGridView3.Columns[1].HeaderText = "ГОСТ Нормы";
                        dataGridView3.Columns[2].HeaderText = "Кол-во материала 1";
                        dataGridView3.Columns[3].HeaderText = "Кол-во материала 2";
                        dataGridView3.Columns[4].HeaderText = "Кол-во упаковки";
                        dataGridView3.Columns[5].HeaderText = "Ед. изм.";
                        dataGridView3.Columns[6].HeaderText = "Имя Материала";
                        dataGridView3.Columns[7].HeaderText = "ГОСТ Материала";
                        dataGridView3.Columns[8].HeaderText = "Марка Материала";
                        dataGridView3.Columns[9].HeaderText = "Тип Материала";
                        stwach1.Stop();
                    }
                    if (StateF == 60)
                    {
                        stwach1.Start();
                        dataGridView3.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView3.Columns[0].HeaderText = "Код Узла/Детали";
                        dataGridView3.Columns[1].HeaderText = "Имя Узла/Детали";
                        dataGridView3.Columns[2].HeaderText = "Тип Узла/Детали";
                        dataGridView3.Columns[3].HeaderText = "ГОСТ Узла/Детали";
                        dataGridView3.Columns[4].HeaderText = "Код Материала";
                        dataGridView3.Columns[5].HeaderText = "Имя Материала";
                        dataGridView3.Columns[6].HeaderText = "ГОСТ Материала";
                        dataGridView3.Columns[7].HeaderText = "Марка Материала";
                        dataGridView3.Columns[8].HeaderText = "Тип Материала";
                        stwach1.Stop();
                    }
                    if (StateF == 61)
                    {
                        stwach1.Start();
                        dataGridView3.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView3.Columns[0].HeaderText = "Код Узла/Детали";
                        dataGridView3.Columns[1].HeaderText = "Имя Узла/Детали";
                        dataGridView3.Columns[2].HeaderText = "Тип Узла/Детали";
                        dataGridView3.Columns[3].HeaderText = "ГОСТ Узла/Детали";
                        dataGridView3.Columns[4].HeaderText = "Код Материала";
                        dataGridView3.Columns[5].HeaderText = "Имя Материала";
                        dataGridView3.Columns[6].HeaderText = "ГОСТ Материала";
                        dataGridView3.Columns[7].HeaderText = "Марка Материала";
                        dataGridView3.Columns[8].HeaderText = "Тип Материала";
                        dataGridView3.Columns[9].HeaderText = "Тип Нормы";
                        dataGridView3.Columns[10].HeaderText = "ГОСТ Нормы";
                        dataGridView3.Columns[11].HeaderText = "Кол-во материала 1";
                        dataGridView3.Columns[12].HeaderText = "Кол-во материала 2";
                        dataGridView3.Columns[13].HeaderText = "Кол-во упаковки";
                        dataGridView3.Columns[14].HeaderText = "Ед. изм.";
                        stwach1.Stop();
                    }
                    if (StateF == 62)
                    {
                        stwach1.Start();
                        dataGridView3.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView3.Columns[0].HeaderText = "Код Изделия";
                        dataGridView3.Columns[1].HeaderText = "Имя Изделия";
                        dataGridView3.Columns[2].HeaderText = "Тип Изделия";
                        dataGridView3.Columns[3].HeaderText = "ГОСТ Изделия";
                        dataGridView3.Columns[4].HeaderText = "Код Узла/Детали";
                       // dataGridView3.Columns[5].HeaderText = "№ Вложенности Узла/Детали";
                        //dataGridView3.Columns[6].HeaderText = "Порядковый № Узла/Детали";
                        dataGridView3.Columns[5].HeaderText = "Имя Узла/Детали";
                        dataGridView3.Columns[6].HeaderText = "Тип Узла/Детали";
                        dataGridView3.Columns[7].HeaderText = "ГОСТ Узла/Детали";
                        dataGridView3.Columns[8].HeaderText = "Кол-во шт Узла/Детали";
                        dataGridView3.Columns[9].HeaderText = "Код Материала";
                        dataGridView3.Columns[10].HeaderText = "Имя Материала";
                        dataGridView3.Columns[11].HeaderText = "ГОСТ Материала";
                        dataGridView3.Columns[12].HeaderText = "Марка Материала";
                        dataGridView3.Columns[13].HeaderText = "Тип Материала";
                        dataGridView3.Columns[14].HeaderText = "Тип Нормы";
                        dataGridView3.Columns[15].HeaderText = "ГОСТ Нормы";
                        dataGridView3.Columns[16].HeaderText = "Кол-во материала 1";
                        dataGridView3.Columns[17].HeaderText = "Кол-во материала 2";
                        dataGridView3.Columns[18].HeaderText = "Кол-во упаковки";
                        dataGridView3.Columns[19].HeaderText = "Ед. изм.";
                        stwach1.Stop();
                    }
                    if (StateF == 63)
                    {
                        stwach1.Start();
                        dataGridView3.DataSource = dt;
                        ad.Fill(dt);
                        
                        dataGridView3.Columns[0].HeaderText = "Код Узла/Детали";
                        dataGridView3.Columns[1].HeaderText = "№ Вложенности Узла/Детали";
                        dataGridView3.Columns[2].HeaderText = "Порядковый № Узла/Детали";
                        dataGridView3.Columns[3].HeaderText = "Имя Узла/Детали";
                        dataGridView3.Columns[4].HeaderText = "Код Материала";
                        dataGridView3.Columns[5].HeaderText = "Имя Материала";
                        dataGridView3.Columns[6].HeaderText = "ГОСТ Материала";
                        dataGridView3.Columns[7].HeaderText = "Марка Материала";
                        dataGridView3.Columns[8].HeaderText = "Тип Материала";
                        dataGridView3.Columns[9].HeaderText = "Тип Нормы";
                        dataGridView3.Columns[10].HeaderText = "Кол-во материала 1";
                        dataGridView3.Columns[11].HeaderText = "Кол-во материала 2";
                        dataGridView3.Columns[12].HeaderText = "Кол-во упаковки";
                        dataGridView3.Columns[13].HeaderText = "Ед. изм.";
                        stwach1.Stop();
                    }
                    if (StateF == 64)
                    {
                        stwach1.Start();
                        dataGridView3.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView3.Columns[0].HeaderText = "Код Изделия";
                        dataGridView3.Columns[1].HeaderText = "Код Узла/Детали";
                        dataGridView3.Columns[2].HeaderText = "Имя Материала";
                        dataGridView3.Columns[3].HeaderText = "Кол-во материала 1";
                        dataGridView3.Columns[4].HeaderText = "Кол-во материала 2";
                        dataGridView3.Columns[5].HeaderText = "Кол-во упаковки";
                        dataGridView3.Columns[6].HeaderText = "Ед. изм.";
                        stwach1.Stop();
                    }
                    //------------------------------------Добавление Материала Нормы ГОСТ+
                    if (StateF == 65)
                    {
                        stwach1.Start();
                        OleDbCommand com = new OleDbCommand(a, dbCon);
                        com.Parameters.AddWithValue("@ID_Mat", a1);
                        com.Parameters.AddWithValue("@Name_Mat", a2);
                        com.Parameters.AddWithValue("@GOST_Mat", a3);
                        com.Parameters.AddWithValue("@Brand_Mat", a4);
                        com.Parameters.AddWithValue("@Type_Mat", a5);
                        com.Parameters.AddWithValue("@Desc_Mat", a6);
                        com.ExecuteNonQuery();
                        stwach1.Stop();
                        Logg();
                        return;
                    }
                    if (StateF == 66)
                    {
                        stwach1.Start();
                        OleDbCommand com = new OleDbCommand(a, dbCon);
                        com.Parameters.AddWithValue("@Type_Norm", a1);
                        com.Parameters.AddWithValue("@GOST_Norm", a2);
                        com.Parameters.AddWithValue("@Num_M1", f1);
                        com.Parameters.AddWithValue("@Num_M2", f2);
                        com.Parameters.AddWithValue("@Num_P", f3);
                        com.Parameters.AddWithValue("@Unit_M1M2P", a3);
                        com.Parameters.AddWithValue("@Desc_NormM", a4);
                        com.ExecuteNonQuery();
                        stwach1.Stop();
                        Logg();
                        return;
                    }
                    if (StateF == 67)
                    {
                        stwach1.Start();
                        OleDbCommand com = new OleDbCommand(a, dbCon);
                        com.Parameters.AddWithValue("@Name_GOST", a1);
                        com.Parameters.AddWithValue("@Desc_GOST", a2);
                        com.ExecuteNonQuery();
                        stwach1.Stop();
                        Logg();
                        return;
                    }
                    //------------------------------------Удаление Материала Нормы ГОСТ+
                    if (StateF == 68)
                    {
                        Delete();
                        TypeEvent = "Удаление данных из БД";
                        DescEvent = "Пользователь " + user + " Удалил данные из таблицы Материалы";
                        Logg();
                        return;
                    }
                    if (StateF == 69)
                    {
                        Delete();
                        TypeEvent = "Удаление данных из БД";
                        DescEvent = "Пользователь " + user + " Удалил данные из таблицы Нормы";
                        Logg();
                        return;
                    }
                    if (StateF == 70)
                    {
                        Delete();
                        TypeEvent = "Удаление данных из БД";
                        DescEvent = "Пользователь " + user + " Удалил данные из таблицы ГОСТ";
                        Logg();
                        return;
                    }
                    //-------------------------------------Добавление Связи+
                    if (StateF == 77)
                    {
                        stwach1.Start();
                        OleDbCommand com = new OleDbCommand(a, dbCon);
                        com.Parameters.AddWithValue("@ID_ItemDB", a1);
                        com.Parameters.AddWithValue("@ID_SpecDB0", a2);
                        com.Parameters.AddWithValue("@ID_SpecDB1", a3);
                        com.Parameters.AddWithValue("@ID_MatDB", a4);
                        com.Parameters.AddWithValue("@ID_NormMDB", a5);
                        com.ExecuteNonQuery();
                        stwach1.Stop();
                        Logg();
                        return;
                    }
                    //-----------------------------------Удаление Связи+
                    if (StateF == 78)
                    {
                        Delete();
                        TypeEvent = "Удаление данных из БД";
                        DescEvent = "Пользователь " + user + " Удалил данные из таблицы Связей";
                        Logg();
                        return;
                    }
                    //------------------------------------Добавление Пользователя
                    if (StateF == 86)
                    {
                        stwach1.Start();
                        OleDbCommand com = new OleDbCommand(a, dbCon);
                        com.Parameters.AddWithValue("@N_User", a1);
                        com.Parameters.AddWithValue("@P_User", a2);
                        com.Parameters.AddWithValue("@Type_User", a3);
                        com.Parameters.AddWithValue("@Right_User", a4);
                        com.ExecuteNonQuery();
                        stwach1.Stop();
                        Logg();
                        return;
                    }
                    //-----------------------------------Удаление Пользователя
                    if (StateF == 87)
                    {
                        Delete();
                        TypeEvent = "Удаление данных из БД";
                        DescEvent = "Пользователь " + user + " Удалил данные из таблицы Пользователи";
                        Logg();
                        return;
                    }
                    //-----------------------------------Удаление ЛОГА
                    if (StateF == 88)
                    {
                        Delete();
                        MessageBox.Show("Информация успешно Удалена!. Время затраченное на операцию, составляет: " + stwach1.Elapsed, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TypeEvent = "Удаление данных из БД";
                        DescEvent = "Пользователь " + user + " Удалил данные из таблицы Лога";
                        Logg();
                        return;
                    }
                    //----------------------------------Чат
                    if (StateF == 89)
                    {
                        stwach1.Start();
                        OleDbCommand com = new OleDbCommand(a, dbCon);
                        com.Parameters.AddWithValue("@Data_M", Convert.ToString(DateTime.Now));
                        com.Parameters.AddWithValue("@From_M", Convert.ToString(user));
                        com.Parameters.AddWithValue("@To_M", toolStripTextBox1.Text);
                        com.Parameters.AddWithValue("@Mes", toolStripTextBox2.Text);
                        com.ExecuteNonQuery();
                        stwach1.Stop();
                        MessageBox.Show("Информация успешно добавлена!. Время затраченное на операцию, составляет: " + stwach1.Elapsed, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TypeEvent = "Добавление данных в БД";
                        DescEvent = "Пользователь " + user + " добавил данные в таблицу Чат";
                        Logg();
                        return;
                    }
                    if (StateF == 90)
                    {
                        stwach1.Start();
                        dataGridView6.DataSource = dt;
                        ad.Fill(dt);
                        dataGridView6.Columns[0].HeaderText = "Код Сообщения БД";
                        dataGridView6.Columns[1].HeaderText = "Дата Сообщения";
                        dataGridView6.Columns[2].HeaderText = "От Кого";
                        dataGridView6.Columns[3].HeaderText = "Кому";
                        dataGridView6.Columns[4].HeaderText = "Текст Сообщения";
                        stwach1.Stop();
                        ///MessageBox.Show("Время затраченное на операцию, составляет: " + stwach1.Elapsed, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TypeEvent = "Просмотр и обновление сообщений";
                        DescEvent = "Пользователь " + user + " Просматривает сообщения";
                        Logg();
                    }
                    
                }
                catch (Exception e)
                {
                    TypeEvent = "Ошибка подключения к БД";
                    DescEvent = "Ошибка ХЗ " + Convert.ToString(e);
                    Logg();
                    return;
                }
            }
            dbCon.Close();
        }
        public void Delete()
        {
            stwach1.Start();
            OleDbCommand com = new OleDbCommand(a, dbCon);
            com.ExecuteNonQuery();
            stwach1.Stop();
            MessageBox.Show("Информация успешно Удалена!. Время затраченное на операцию, составляет: " + stwach1.Elapsed, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } // Процедура удаления
        private void чтоЕщеМожноСюдаПрикрутитьВДальнейшемToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В дальнейшем на эту программу можно прикрутить: нормирование зп, операций, труда, режим обучения пользователя данной программой, перевод на несколько языков, поддержку чертежей, пару видов калькуляторов, улучшить текущую производительность.......", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
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
                    com.Parameters.AddWithValue("@Desc_Log", Convert.ToString(DescEvent) + " " + a);
                    com.ExecuteNonQuery();
                }
                dbCon.Close();
                TypeEvent = "";
                DescEvent = "";
                return;
            }
            catch (Exception g)
            {
                MessageBox.Show(g.ToString());
            }
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e) // Выход
        {
            Application.Exit();
        }
        private void timer1_Tick(object sender, EventArgs e) // Таймер
        {
            NPEnter = 0;
            timer1.Stop();
            button1.Enabled = true;
        }
        private void Retrn2() // Процедура закрытия формы 2
        {
            Form2 form2 = new Form2(StateF, a, TypeEvent, DescEvent, user, ConS);
            form2.FormClosing += (sender1, e1) =>
            {
                this.a = form2.a;
                this.TypeEvent = form2.TypeEvent;
                this.DescEvent = form2.DescEvent;
                this.user = form2.user;
                this.StateF = form2.StateF;
                this.ConS = form2.ConS;
                LoadDB();
                MessageBox.Show("Время затраченное на загрузку таблицы, составляет: " + stwach1.Elapsed, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show(StateF.ToString());
            };
            form2.ShowDialog();
        }
        private void Retrn3() // Процедура закрытия формы 3
        {
            Form3 form3 = new Form3(StateF, a, TypeEvent, DescEvent, user, a1, a2, a3, a4, a5, a6, a7, f1, f2, f3, f4, f5, i1, i2, i3, ConS);
            form3.FormClosing += (sender1, e1) =>
            {
                this.a = form3.a;
                this.TypeEvent = form3.TypeEvent;
                this.DescEvent = form3.DescEvent;
                this.user = form3.user;
                this.StateF = form3.StateF;
                this.a1 = form3.a1;
                this.a2 = form3.a2;
                this.a3 = form3.a3;
                this.a4 = form3.a4;
                this.a5 = form3.a5;
                this.a6 = form3.a6;
                this.a7 = form3.a7;
                this.f1 = form3.f1;
                this.f2 = form3.f2;
                this.f3 = form3.f3;
                this.f4 = form3.f4;
                this.f5 = form3.f5;
                this.i1 = form3.i1;
                this.i2 = form3.i2;
                this.i3 = form3.i3;
                LoadDB();
                MessageBox.Show("Информация успешно добавлена!. Время затраченное на операцию, составляет: " + stwach1.Elapsed, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show(a);
            };
            form3.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e) // Вход
        {
            if (NPEnter >= 5)
            {
                TypeEvent = "Блокировка входа";
                DescEvent = "Попыток входа было не менее 5!";
                Logg();
                MessageBox.Show("Попыток входа было не менее 5! Попробуйте войти через 1 минуту!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NPEnter = 0;
                button1.Enabled = false;
                timer1.Start();
            }

            if ((comboBox1.Text != "" && textBox2.Text != "") && (comboBox1.ForeColor == Color.Black && textBox2.ForeColor == Color.Black))
            {
                Status = "Online";
                string s1 = comboBox1.Text;
                user = comboBox1.Text;
                string s2 = textBox2.Text;
                string q = "SELECT COUNT(*) FROM Users WHERE (N_User = \"" + s1 + "\" AND P_User = \"" + s2 + "\")";
                string q2 = "SELECT Type_User FROM Users WHERE (N_User = \"" + s1 + "\" AND P_User = \"" + s2 + "\")";
                string q4 = "SELECT Users.Right_User FROM Users WHERE ((Users.N_User) ='" + Convert.ToString(user) + "')";
                string q5 = "UPDATE Users SET Users.Online_User ='" + Convert.ToString(Status) + "' WHERE ((([Users].[N_User])='" + Convert.ToString(user) + "'))";
                if (comboBox1.Text != textBox2.Text && (comboBox1.ForeColor == Color.Black && textBox2.ForeColor == Color.Black))
                {
                    try
                    {
                        dbCon = new OleDbConnection(ConS);
                        DbCon = new OleDbConnection(ConS);
                        dbCon.Open();
                        DbCon.Open();
                        using (DbCon)
                        {
                            try
                            {
                                OleDbCommand com5 = new OleDbCommand(q5, DbCon);
                                com5.ExecuteNonQuery();
                                DbCon.Close();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ошибка: {ex.Message}");
                            }
                        }
                        using (dbCon)
                        {
                            OleDbCommand com = new OleDbCommand(q, dbCon);
                            string res = com.ExecuteScalar().ToString();
                            com.ExecuteNonQuery();
                            if (res != "0")
                            {
                                OleDbCommand com2 = new OleDbCommand(q2, dbCon);
                                string res2 = com2.ExecuteScalar().ToString();
                                com2.ExecuteNonQuery();
                                if (res2 == "Admin"|| res2 == "User")
                                {
                                    OleDbCommand com4 = new OleDbCommand(q4, dbCon);
                                    string res3 = com4.ExecuteScalar().ToString();
                                    com4.ExecuteNonQuery();
                                    if (res3 == "00000")
                                    {
                                        tabPage1.Parent = null;
                                        tabPage2.Parent = null;
                                        tabPage3.Parent = null;
                                        tabPage4.Parent = null;
                                        tabPage5.Parent = null;
                                    }
                                    if (res3 == "00001")
                                    {
                                        tabPage1.Parent = null;
                                        tabPage2.Parent = null;
                                        tabPage3.Parent = null;
                                        tabPage4.Parent = null;
                                        tabPage5.Parent = tabControl1;
                                    }
                                    if (res3 == "00010")
                                    {
                                        tabPage1.Parent = null;
                                        tabPage2.Parent = null;
                                        tabPage3.Parent = null;
                                        tabPage4.Parent = tabControl1;
                                        tabPage5.Parent = null;
                                    }
                                    if (res3 == "00011")
                                    {
                                        tabPage1.Parent = null;
                                        tabPage2.Parent = null;
                                        tabPage3.Parent = null;
                                        tabPage4.Parent = tabControl1;
                                        tabPage5.Parent = tabControl1;
                                    }
                                    if (res3 == "00100")
                                    {
                                        tabPage1.Parent = null;
                                        tabPage2.Parent = null;
                                        tabPage3.Parent = tabControl1;
                                        tabPage4.Parent = null;
                                        tabPage5.Parent = null;
                                    }
                                    if (res3 == "00101")
                                    {
                                        tabPage1.Parent = null;
                                        tabPage2.Parent = null;
                                        tabPage3.Parent = tabControl1;
                                        tabPage4.Parent = null;
                                        tabPage5.Parent = tabControl1;
                                    }
                                    if (res3 == "00110")
                                    {
                                        tabPage1.Parent = null;
                                        tabPage2.Parent = null;
                                        tabPage3.Parent = tabControl1;
                                        tabPage4.Parent = tabControl1;
                                        tabPage5.Parent = null;
                                    }
                                    if (res3 == "00111")
                                    {
                                        tabPage1.Parent = null;
                                        tabPage2.Parent = null;
                                        tabPage3.Parent = tabControl1;
                                        tabPage4.Parent = tabControl1;
                                        tabPage5.Parent = tabControl1;
                                    }
                                    if (res3 == "01000")
                                    {
                                        tabPage1.Parent = null;
                                        tabPage2.Parent = tabControl1;
                                        tabPage3.Parent = null;
                                        tabPage4.Parent = null;
                                        tabPage5.Parent = null;
                                    }
                                    if (res3 == "01001")
                                    {
                                        tabPage1.Parent = null;
                                        tabPage2.Parent = tabControl1;
                                        tabPage3.Parent = null;
                                        tabPage4.Parent = null;
                                        tabPage5.Parent = tabControl1;
                                    }
                                    if (res3 == "01010")
                                    {
                                        tabPage1.Parent = null;
                                        tabPage2.Parent = tabControl1;
                                        tabPage3.Parent = null;
                                        tabPage4.Parent = tabControl1;
                                        tabPage5.Parent = null;
                                    }
                                    if (res3 == "01011")
                                    {
                                        tabPage1.Parent = null;
                                        tabPage2.Parent = tabControl1;
                                        tabPage3.Parent = null;
                                        tabPage4.Parent = tabControl1;
                                        tabPage5.Parent = tabControl1;
                                    }
                                    if (res3 == "01100")
                                    {
                                        tabPage1.Parent = null;
                                        tabPage2.Parent = tabControl1;
                                        tabPage3.Parent = tabControl1;
                                        tabPage4.Parent = null;
                                        tabPage5.Parent = null;
                                    }
                                    if (res3 == "01101")
                                    {
                                        tabPage1.Parent = null;
                                        tabPage2.Parent = tabControl1;
                                        tabPage3.Parent = tabControl1;
                                        tabPage4.Parent = null;
                                        tabPage5.Parent = tabControl1;
                                    }
                                    if (res3 == "01110")
                                    {
                                        tabPage1.Parent = null;
                                        tabPage2.Parent = tabControl1;
                                        tabPage3.Parent = tabControl1;
                                        tabPage4.Parent = tabControl1;
                                        tabPage5.Parent = null;
                                    }
                                    if (res3 == "01111")
                                    {
                                        tabPage1.Parent = null;
                                        tabPage2.Parent = tabControl1;
                                        tabPage3.Parent = tabControl1;
                                        tabPage4.Parent = tabControl1;
                                        tabPage5.Parent = tabControl1;
                                    }
                                    if (res3 == "10000")
                                    {
                                        tabPage1.Parent = tabControl1;
                                        tabPage2.Parent = null;
                                        tabPage3.Parent = null;
                                        tabPage4.Parent = null;
                                        tabPage5.Parent = null;
                                    }
                                    if (res3 == "10001")
                                    {
                                        tabPage1.Parent = tabControl1;
                                        tabPage2.Parent = null;
                                        tabPage3.Parent = null;
                                        tabPage4.Parent = null;
                                        tabPage5.Parent = tabControl1;
                                    }
                                    if (res3 == "10010")
                                    {
                                        tabPage1.Parent = tabControl1;
                                        tabPage2.Parent = null;
                                        tabPage3.Parent = null;
                                        tabPage4.Parent = tabControl1;
                                        tabPage5.Parent = null;
                                    }
                                    if (res3 == "10011")
                                    {
                                        tabPage1.Parent = tabControl1;
                                        tabPage2.Parent = null;
                                        tabPage3.Parent = null;
                                        tabPage4.Parent = tabControl1;
                                        tabPage5.Parent = tabControl1;
                                    }
                                    if (res3 == "10100")
                                    {
                                        tabPage1.Parent = tabControl1;
                                        tabPage2.Parent = null;
                                        tabPage3.Parent = tabControl1;
                                        tabPage4.Parent = null;
                                        tabPage5.Parent = null;
                                    }
                                    if (res3 == "10101")
                                    {
                                        tabPage1.Parent = tabControl1;
                                        tabPage2.Parent = null;
                                        tabPage3.Parent = tabControl1;
                                        tabPage4.Parent = null;
                                        tabPage5.Parent = tabControl1;
                                    }
                                    if (res3 == "10110")
                                    {
                                        tabPage1.Parent = tabControl1;
                                        tabPage2.Parent = null;
                                        tabPage3.Parent = tabControl1;
                                        tabPage4.Parent = tabControl1;
                                        tabPage5.Parent = null;
                                    }
                                    if (res3 == "10111")
                                    {
                                        tabPage1.Parent = tabControl1;
                                        tabPage2.Parent = null;
                                        tabPage3.Parent = tabControl1;
                                        tabPage4.Parent = tabControl1;
                                        tabPage5.Parent = tabControl1;
                                    }
                                    if (res3 == "11000")
                                    {
                                        tabPage1.Parent = tabControl1;
                                        tabPage2.Parent = tabControl1;
                                        tabPage3.Parent = null;
                                        tabPage4.Parent = null;
                                        tabPage5.Parent = null;
                                    }
                                    if (res3 == "11001")
                                    {
                                        tabPage1.Parent = tabControl1;
                                        tabPage2.Parent = tabControl1;
                                        tabPage3.Parent = null;
                                        tabPage4.Parent = null;
                                        tabPage5.Parent = tabControl1;
                                    }
                                    if (res3 == "11010")
                                    {
                                        tabPage1.Parent = tabControl1;
                                        tabPage2.Parent = tabControl1;
                                        tabPage3.Parent = null;
                                        tabPage4.Parent = tabControl1;
                                        tabPage5.Parent = null;
                                    }
                                    if (res3 == "11011")
                                    {
                                        tabPage1.Parent = tabControl1;
                                        tabPage2.Parent = tabControl1;
                                        tabPage3.Parent = null;
                                        tabPage4.Parent = tabControl1;
                                        tabPage5.Parent = tabControl1;
                                    }
                                    if (res3 == "11100")
                                    {
                                        tabPage1.Parent = tabControl1;
                                        tabPage2.Parent = tabControl1;
                                        tabPage3.Parent = tabControl1;
                                        tabPage4.Parent = null;
                                        tabPage5.Parent = null;
                                    }
                                    if (res3 == "11101")
                                    {
                                        tabPage1.Parent = tabControl1;
                                        tabPage2.Parent = tabControl1;
                                        tabPage3.Parent = tabControl1;
                                        tabPage4.Parent = null;
                                        tabPage5.Parent = tabControl1;
                                    }
                                    if (res3 == "11110")
                                    {
                                        tabPage1.Parent = tabControl1;
                                        tabPage2.Parent = tabControl1;
                                        tabPage3.Parent = tabControl1;
                                        tabPage4.Parent = tabControl1;
                                        tabPage5.Parent = null;
                                    }
                                    if (res3 == "11111")
                                    {
                                        tabPage1.Parent = tabControl1;
                                        tabPage2.Parent = tabControl1;
                                        tabPage3.Parent = tabControl1;
                                        tabPage4.Parent = tabControl1;
                                        tabPage5.Parent = tabControl1;
                                    }
                                }
                                if (res2 == "Admin")
                                {
                                    TypeEvent = "Вход Пользователя " + user;
                                    DescEvent = "Пользователь " + user + " выполнил вход в систему успешно! " +q + " " +q2 ;
                                    Logg();
                                    MessageBox.Show("Добро пожаловать! ADMIN.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Visibl();
                                    tabPage6.Parent = tabControl1;
                                    return;
                                }
                                if (res2 == "User")
                                {
                                    TypeEvent = "Вход Пользователя " + user;
                                    DescEvent = "Пользователь " + user + " выполнил вход в систему успешно! " + q + " " + q2;
                                    Logg();
                                    MessageBox.Show("Добро пожаловать! USER.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Visibl();
                                    tabPage6.Parent = null;
                                    return;
                                }
                            }
                            else
                            {
                                NPEnter++;
                                TypeEvent = "Неверный ввод Логина и Пароля";
                                DescEvent = "Логин и Пароль введены неверно! Пользователь " + user;
                                Logg();
                                MessageBox.Show("Логин и Пароль введены неверно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                comboBox1.Text = "";
                                textBox2.Text = "";
                                if (comboBox1.Text == "")
                                {
                                    TypeEvent = "Неверный ввод Логина и Пароля";
                                    DescEvent = "Введите Логин. Пользователь " + user;
                                    Logg();
                                    MessageBox.Show("Введите Логин!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                if (textBox2.Text == "")
                                {
                                    TypeEvent = "Неверный ввод Логина и Пароля";
                                    DescEvent = "Введите Пароль. Пользователь " + user;
                                    Logg();
                                    MessageBox.Show("Введите пароль!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                return;
                            }
                        }
                    }
                    catch(Exception e2)
                    {
                        TypeEvent = "Ошибка подключения к БД";
                        DescEvent = "Ошибка подключения к БД. Form1, button1_Click(400), catch" +e2;
                        Logg();
                        MessageBox.Show("Ошибка соединения с БД!" + e2, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (comboBox1.Text == textBox2.Text && (comboBox1.ForeColor == Color.Black && textBox2.ForeColor == Color.Black))
                {
                    TypeEvent = "Неверный ввод Логина и Пароля";
                    DescEvent = "Логин и пароль не могут совпадать! (407)";
                    Logg();
                    MessageBox.Show("Логин и пароль не могут совпадать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    NPEnter++;
                    comboBox1.Text = "";
                    textBox2.Text = "";
                    return;
                }
            }
            if (comboBox1.Text == textBox2.Text && (comboBox1.ForeColor == Color.Black && textBox2.ForeColor == Color.Black))
            {
                TypeEvent = "Неверный ввод Логина и Пароля";
                DescEvent = "Логин и пароль не могут совпадать! (419)";
                Logg();
                MessageBox.Show("Логин и пароль не могут совпадать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NPEnter++;
                comboBox1.Text = "";
                textBox2.Text = "";
                return;
            }
        }
        private void button2_Click(object sender, EventArgs e) // Выход
        {
            Application.Exit();
        }
        //----------------------------------------------------------------События Тексбоксов
        #region
        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox1.ForeColor = Color.Black;
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
            textBox2.UseSystemPasswordChar = true;
        }
        #endregion
        private void сменаПользователяToolStripMenuItem_Click(object sender, EventArgs e) // Смена пользователя
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;
            dataGridView4.DataSource = null;
            dataGridView5.DataSource = null;
            panel1.Visible = true;
            panel1.Enabled = true;
            menuStrip1.Visible = false;
            tabControl1.Visible = false;
            Status = "Offline";
            DbCon = new OleDbConnection(ConS);
            string q5 = "UPDATE Users SET Users.Online_User ='" + Convert.ToString(Status) + "' WHERE ((([Users].[N_User])='" + Convert.ToString(user) + "'))";
            DbCon.Open();
            using (DbCon)
            {
                try
                {
                    OleDbCommand com5 = new OleDbCommand(q5, DbCon);
                    com5.ExecuteNonQuery();
                    DbCon.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");

                }
            }
            button1.Text = "Вход";
            button2.Text = "Выход";
            comboBox1.Text = "Введите ваш логин";
            comboBox1.ForeColor = Color.Gray;
            textBox2.Text = "Введите ваш пароль";
            textBox2.ForeColor = Color.Gray;
            textBox2.UseSystemPasswordChar = false;
            TypeEvent = "Смена Пользователя " + user;
            DescEvent = "Пользователь " + user + " вышел из своего профиля";
            Logg();
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e) // О программе
        {
            AboutBox1 AB1 = new AboutBox1();
            AB1.ShowDialog();
        }
        //---------------------------------------------------------------------------------------------------------------------Вывод Всех++++++++=
        private void AllordersToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех Заказчиков+
        {
            StateF = 0;
            a = @"SELECT * FROM S_Cust ORDER BY S_Cust.ID_CustDB";
            LoadDB();
            TypeEvent = "Просмотр Заказчиков " + user;
            DescEvent = "Пользователь " + user + " просматривает таблицу Заказчики (Все Заказчики)";
            Logg();
            MessageBox.Show("Время затраченное на загрузку таблицы, составляет: "+ stwach1.Elapsed,"Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void всеЗаказыToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех Заказов+
        {
            StateF = 1;
            a = @"SELECT * FROM S_Order ORDER BY S_Order.ID_OrderDB";
            LoadDB();
            TypeEvent = "Просмотр Заказов " + user;
            DescEvent = "Пользователь " + user + " просматривает таблицу Заказов (Все Заказаы)";
            Logg();
            MessageBox.Show("Время затраченное на загрузку таблицы, составляет: " + stwach1.Elapsed, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void весьПереченьToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всего Перечня+
        {
            StateF = 2;
            a = @"SELECT * FROM S_Items ORDER BY S_Items.ID_ItemDB";
            LoadDB();
            TypeEvent = "Просмотр Перчня Заказа " + user;
            DescEvent = "Пользователь " + user + " просматривает таблицу Перечень Заказа (Весь Перечень)";
            Logg();
            MessageBox.Show("Время затраченное на загрузку таблицы, составляет: " + stwach1.Elapsed, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void всеИзделияToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех Изделий+
        {
            StateF = 3;
            a = @"SELECT * FROM S_Spec0 ORDER BY S_Spec0.ID_SpecDB0";
            LoadDB();
            TypeEvent = "Просмотр Перечня Изделий " + user;
            DescEvent = "Пользователь " + user + " просматривает таблицу Изделий (Весь Перечень)";
            Logg();
            MessageBox.Show("Время затраченное на загрузку таблицы, составляет: " + stwach1.Elapsed, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void всеУзлыДеталиToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех Узлов/Деталей+
        {
            StateF = 4;
            a = @"SELECT * FROM S_Spec1 ORDER BY S_Spec1.ID_SpecDB1";
            LoadDB();
            TypeEvent = "Просмотр Перчня Узлов/Деталей " + user;
            DescEvent = "Пользователь " + user + " просматривает таблицу Узлов/Деталей (Весь Перечень)";
            Logg();
            MessageBox.Show("Время затраченное на загрузку таблицы, составляет: " + stwach1.Elapsed, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void всеМатериалыToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех Материалов+
        {
            StateF = 5;
            a = @"SELECT * FROM S_Mat ORDER BY S_Mat.ID_MatDB";
            LoadDB();
            TypeEvent = "Просмотр Перчня Узлов/Деталей " + user;
            DescEvent = "Пользователь " + user + " просматривает таблицу Узлов/Деталей (Весь Перечень)";
            Logg();
            MessageBox.Show("Время затраченное на загрузку таблицы, составляет: " + stwach1.Elapsed, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void всеНормыToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех Норм+
        {
            StateF = 6;
            a = @"SELECT * FROM S_NormM ORDER BY S_NormM.ID_NormMDB";
            LoadDB();
            TypeEvent = "Просмотр Перчня Узлов/Деталей " + user;
            DescEvent = "Пользователь " + user + " просматривает таблицу Узлов/Деталей (Весь Перечень)";
            Logg();
            MessageBox.Show("Время затраченное на загрузку таблицы, составляет: " + stwach1.Elapsed, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void всеГОСТыToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех ГОСТ+
        {
            StateF = 7;
            a = @"SELECT * FROM S_GOST";
            LoadDB();
            TypeEvent = "Просмотр Перчня Узлов/Деталей " + user;
            DescEvent = "Пользователь " + user + " просматривает таблицу Узлов/Деталей (Весь Перечень)";
            Logg();
            MessageBox.Show("Время затраченное на загрузку таблицы, составляет: " + stwach1.Elapsed, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void всеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 8;
            a = @"SELECT * FROM SNM1";
            LoadDB();
            TypeEvent = "Просмотр Таблицы Связей " + user;
            DescEvent = "Пользователь " + user + " просматривает таблицу Связей (Весь Перечень)";
            Logg();
            MessageBox.Show("Время затраченное на загрузку таблицы, составляет: " + stwach1.Elapsed, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } // Вывод всех Связей БД
        private void всеПользователиToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех Пользователей+
        {
            StateF = 9;
            a = @"SELECT * FROM Users";
            LoadDB();
            TypeEvent = "Просмотр Перчня Пользователей " + user;
            DescEvent = "Пользователь " + user + " просматривает таблицу Пользователи (Весь Перечень)";
            Logg();
            MessageBox.Show("Время затраченное на загрузку таблицы, составляет: " + stwach1.Elapsed, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void всеЛогиToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех ЛОГОВ+
        {
            StateF = 10;
            a = @"SELECT * FROM Logs";
            LoadDB();
            TypeEvent = "Просмотр Перчня Логов " + user;
            DescEvent = "Пользователь " + user + " просматривает таблицу Логов (Весь Перечень)";
            Logg();
            MessageBox.Show("Время затраченное на загрузку таблицы, составляет: " + stwach1.Elapsed, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void предложенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 11;
            a = @"SELECT * FROM RAZR";
            LoadDB();
            TypeEvent = "Просмотр Сведений об Предложениях по Разработке " + user;
            DescEvent = "Пользователь " + user + " просматривает таблицу Сведений по Разработке (Весь Перечень)";
            Logg();
            MessageBox.Show("Время затраченное на загрузку таблицы, составляет: " + stwach1.Elapsed, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } // Вывод всех предложений
        //----------------------------------------------------------------------------------------------------------------------------ЗАКАЗЧИКИ по чем-то+
        private void поКодуБДЗаказчикаToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех Заказчиков по Коду БД+
        {
            StateF = 12;
            Retrn2();
            TypeEvent = "Поиск Заказчика " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Заказчики";
            Logg();
        }
        private void поКодуЗаказчикаToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех Заказчиков по коду Заказчика+
        {
            StateF = 13;
            Retrn2();
            TypeEvent = "Поиск Заказчика " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Заказчики";
            Logg();
        }
        private void поИмениЗаказчикаToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех Заказчиков по имени Заказчика+
        {
            StateF = 14;
            Retrn2();
            TypeEvent = "Поиск Заказчика " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Заказчики";
            Logg();
        }
        private void поТипуЗаказчикаToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех Заказчиков по Типу Заказчика
        {
            StateF = 15;
            Retrn2();
            TypeEvent = "Поиск Заказчика " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Заказчики";
            Logg();
        }
        //---------------------------------------------------------------------------------------------------------------------------------Заказы+
        private void поКодуБДЗаказаToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех Заказов по Коду БД Заказа+
        {
            StateF = 16;
            Retrn2();
            TypeEvent = "Поиск Заказов " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Заказов";
            Logg();
        }
        private void поКодуБДЗаказчикаToolStripMenuItem1_Click(object sender, EventArgs e) // Вывод всех Заказов по Коду БД Заказчика+
        {
            StateF = 17;
            Retrn2();
            TypeEvent = "Поиск Заказов " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Заказов";
            Logg();
        }
        private void поКодуБДЗаказчикаЗаказаToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех Заказов по Коду БД Заказчика+
        {
            StateF = 18;
            Retrn2();
            TypeEvent = "Поиск Заказов " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Заказов";
            Logg();
        }
        private void поКодуЗаказаToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех Заказов по Коду Заказа+
        {
            StateF = 19;
            Retrn2();
            TypeEvent = "Поиск Заказов " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Заказов";
            Logg();
        }
        private void поИмениЗаказаToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех Заказов по Имени Заказа+
        {
            StateF = 20;
            Retrn2();
            TypeEvent = "Поиск Заказов " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Заказов";
            Logg();
        }
        private void поТипуЗаказаToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех Заказов по Типу Заказа+
        {
            StateF = 21;
            Retrn2();
            TypeEvent = "Поиск Заказов " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Заказов";
            Logg();
        }
        private void поДатеЗаказаToolStripMenuItem_Click(object sender, EventArgs e) // Вывод всех Заказов по Дате Заказа+
        {
            StateF = 22;
            Retrn2();
            TypeEvent = "Поиск Заказов " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Заказов";
            Logg();
        }
        //---------------------------------------------------------------------------------------------------------------------------------Перечень заказа+
        private void поКодуБДСтрокиПеречняToolStripMenuItem_Click(object sender, EventArgs e) // Вывод Перечня по Коду Строки Перечня БД+
        {
            StateF = 23;
            Retrn2();
            TypeEvent = "Поиск по Перчню Заказа " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Перечня Заказа";
            Logg();
        }
        private void поКодуБДЗаказаToolStripMenuItem1_Click(object sender, EventArgs e) // Вывод Перечня по Коду БД Заказа+
        {
            StateF = 24;
            Retrn2();
            TypeEvent = "Поиск по Перчню Заказа " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Перечня Заказа";
            Logg();
        }
        private void поИмениСтрокиПеречняToolStripMenuItem_Click(object sender, EventArgs e) // Вывод Перечня по Коду Строки Перечня+
        {
            StateF = 25;
            Retrn2();
            TypeEvent = "Поиск по Перчню Заказа " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Перечня Заказа";
            Logg();
        }
        //---------------------------Поиск ПРО Заказ Заказчки Перечень+
        private void заказчикИЗаказToolStripMenuItem_Click(object sender, EventArgs e)//+
        {
            StateF = 26;
            Retrn2();
            TypeEvent = "Поиск в режиме ПРО " + user;
            DescEvent = "Пользователь " + user + " производит Поиск и Просмотр в Режиме ПРО";
            Logg();
        }
        private void заказИПереченьToolStripMenuItem_Click(object sender, EventArgs e)//+
        {
            StateF = 27;
            Retrn2();
            TypeEvent = "Поиск в режиме ПРО " + user;
            DescEvent = "Пользователь " + user + " производит Поиск и Просмотр в Режиме ПРО";
            Logg();
        }
        private void заказчикЗаказПереченьToolStripMenuItem_Click(object sender, EventArgs e)//+
        {
            StateF = 28;
            Retrn2();
            TypeEvent = "Поиск в режиме ПРО " + user;
            DescEvent = "Пользователь " + user + " производит Поиск и Просмотр в Режиме ПРО";
            Logg();
        }
        //--------------------------Добавление нового Заказчика Заказа Перечня+
        private void заказчикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 29;
            Retrn3();
        }
        private void заказToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StateF = 30;
            Retrn3();
        }
        private void сформироватьПереченьЗаказаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 31;
            Retrn3();
        }
        //---------------------------УДАЛЕНИЕ ЗАКАЗА ЗАКАЗЧИКА ПЕРЕЧНЯ+
        private void поКодуБДЗаказчикаToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            StateF = 32;
            Retrn2();
        }
        private void поКодуБДЗаказаToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            StateF = 33;
            Retrn2();
        }
        private void поКодуБДСтрокиПеречняToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StateF = 34;
            Retrn2();
        }
        //-----------------------------------------------------------------Изделие Узел/Деталь
        //-----------------------------------------------------------------Изделие+
        private void поКодуИзделияБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 35;
            Retrn2();
            TypeEvent = "Поиск по Изделиям " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Изделий";
            Logg();
        }
        private void поКодуИзделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 36;
            Retrn2();
            TypeEvent = "Поиск по Изделиям " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Изделий";
            Logg();
        }
        private void поИмениИзделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 37;
            Retrn2();
            TypeEvent = "Поиск по Изделиям " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Изделий";
            Logg();
        }
        private void поТипуИзделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 38;
            Retrn2();
            TypeEvent = "Поиск по Изделиям " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Изделий";
            Logg();
        }
        //-----------------------------------------------------------------Узел/Деталь+
        private void поКодуУзлаДеталиБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 39;
            Retrn2();
            TypeEvent = "Поиск по Узлам/Деталям " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Узлов Деталей";
            Logg();
        }
        private void поКодуУзлаДеталиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 40;
            Retrn2();
            TypeEvent = "Поиск по Узлам/Деталям " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Узлов Деталей";
            Logg();
        }
        private void поВложенностиУзлаДеталиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 41;
            Retrn2();
            TypeEvent = "Поиск по Узлам/Деталям " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Узлов Деталей";
            Logg();
        }
        private void поПорядковомуУзлаДеталиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 42;
            Retrn2();
            TypeEvent = "Поиск по Узлам/Деталям " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Узлов Деталей";
            Logg();
        }
        private void поИмениУзлаДеталиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 43;
            Retrn2();
            TypeEvent = "Поиск по Узлам/Деталям " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Узлов Деталей";
            Logg();
        }
        private void поТипуУзлаДеталиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 44;
            Retrn2();
            TypeEvent = "Поиск по Узлам/Деталям " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Узлов Деталей";
            Logg();
        }
        //------------------------------------------------------ПОИСК ПРО Изделие Узел Деталь+
        private void изделиеУзелДетальToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StateF = 45;
            Retrn2();
            TypeEvent = "Поиск в режиме ПРО " + user;
            DescEvent = "Пользователь " + user + " производит Поиск и Просмотр в Режиме ПРО";
            Logg();
        }
        //-------------------------------------------------Добавление Изделия Узел/Деталь+
        private void изделиеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StateF = 46;
            Retrn3();
        }
        private void узелДетальToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StateF = 47;
            Retrn3();
        }
        //-------------------------------------------------Удаление Изделия Узел/Деталь+
        private void поКодуИзделияБДToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StateF = 48;
            Retrn2();
        }
        private void поКодуУзлаДеталиБДToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StateF = 49;
            Retrn2();
        }
        //----------------------------------------------------Материалы
        private void поКодуМатериалаБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 50;
            Retrn2();
            TypeEvent = "Поиск по Материалам " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Материалы";
            Logg();
        }
        private void поКодуМатериалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 51;
            Retrn2();
            TypeEvent = "Поиск по Материалам " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Материалы";
            Logg();
        }
        private void поИмениМатериалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 52;
            Retrn2();
            TypeEvent = "Поиск по Материалам " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Материалы";
            Logg();
        }
        private void поМаркеМатериалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 53;
            Retrn2();
            TypeEvent = "Поиск по Материалам " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Материалы";
            Logg();
        }
        private void поТипуМатериалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 54;
            Retrn2();
            TypeEvent = "Поиск по Материалам " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Материалы";
            Logg();
        }
        //----------------------------------------НОРМЫ
        private void поКодуНормыБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 55;
            Retrn2();
            TypeEvent = "Поиск по Нормам " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Нормы";
            Logg();
        }
        private void поТипуНормыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 56;
            Retrn2();
            TypeEvent = "Поиск по Нормам " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Нормы";
            Logg();
        }
        //==============================================ГОСТ
        private void поКодуГОСТБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 57;
            Retrn2();
            TypeEvent = "Поиск по ГОСТ " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице ГОСТ";
            Logg();
        }
        private void поИмениГОСТToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 58;
            Retrn2();
            TypeEvent = "Поиск по ГОСТ " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице ГОСТ";
            Logg();
        }
        //========================================ПОИСК ПРО МАТЕРИАЛЫ НОРМЫ ГОСТ
        private void материалыНормыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 59;
            Retrn2();
            TypeEvent = "Поиск в режиме ПРО " + user;
            DescEvent = "Пользователь " + user + " производит Поиск и Просмотр в Режиме ПРО";
            Logg();
        }
        private void узелДетальМатериалыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 60;
            Retrn2();
            TypeEvent = "Поиск в режиме ПРО " + user;
            DescEvent = "Пользователь " + user + " производит Поиск и Просмотр в Режиме ПРО";
            Logg();
        }
        private void узелДетальМатерилыНормыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 61;
            Retrn2();
            TypeEvent = "Поиск в режиме ПРО " + user;
            DescEvent = "Пользователь " + user + " производит Поиск и Просмотр в Режиме ПРО";
            Logg();
        }
        private void изделиеУзелДетальМатериалыНормыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 62;
            Retrn2();
            TypeEvent = "Поиск в режиме ПРО " + user;
            DescEvent = "Пользователь " + user + " производит Поиск и Просмотр в Режиме ПРО";
            Logg();
        }
        private void материальнаяВедомостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 63;
            Retrn2();
            TypeEvent = "Поиск в режиме ПРО " + user;
            DescEvent = "Пользователь " + user + " производит Поиск и Просмотр в Режиме ПРО";
            Logg();
        }
        private void материальнаяВедомость2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 64;
            Retrn2();
            TypeEvent = "Поиск в режиме ПРО " + user;
            DescEvent = "Пользователь " + user + " производит Поиск и Просмотр в Режиме ПРО";
            Logg();
        }
        //==================================================== ДОБАВЛЕНИЕ МАТЕРИАЛОВ НОРМ ГОСТ
        private void материалыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StateF = 65;
            Retrn3();
        }
        private void нормыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StateF = 66;
            Retrn3();
        }
        private void гОСТToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StateF = 67;
            Retrn3();
        }
        //==========================================================УДАЛЕНИЕ МАТЕРИАЛОВ НОРМ ГОСТ
        private void материалыToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            StateF = 68;
            Retrn2();
        }
        private void нормыToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            StateF = 69;
            Retrn2();
        }
        private void гОСТToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            StateF = 70;
            Retrn2();
        }
        //==============================================================Отображение связей
        private void поКодуСтрокиСвязиБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 71;
            Retrn2();
            TypeEvent = "Поиск по Связям " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Связей";
            Logg();
        }
        private void поКодуИзделияБДToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            StateF = 72;
            Retrn2();
            TypeEvent = "Поиск по Связям " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Связей";
            Logg();
        }
        private void поКодуУзлаДеталиБДToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            StateF = 73;
            Retrn2();
            TypeEvent = "Поиск по Связям " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Связей";
            Logg();
        }
        private void поКодуМатериалаБДToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StateF = 74;
            Retrn2();
            TypeEvent = "Поиск по Связям " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Связей";
            Logg();
        }
        private void поКодуНормыБДToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StateF = 75;
            Retrn2();
            TypeEvent = "Поиск по Связям " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Связей";
            Logg();
        }
        private void поКодуПеречняБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 76;
            Retrn2();
            TypeEvent = "Поиск по Связям " + user;
            DescEvent = "Пользователь " + user + " производит поиск по таблице Связей";
            Logg();
        }
        //==================================================================Добавление связи
        private void связиМеждуИзделиемУзломДетальюМатериаломНормойПеречнемToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StateF = 77;
            Retrn3();
        }
        //==================================================================Удаление связи
        private void связиМеждуИзделиемУзломДетальюМатериаломНормойПеречнемToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            StateF = 78;
            Retrn2();
        }
        //---------------------------------------АДМИНПАНЕЛЬ
        //=======================================Просмотр
        private void поКодуПользователяБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 79;
            Retrn2();
        }
        private void поЛогинуПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 80;
            Retrn2();
        }
        private void поТипуПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 81;
            Retrn2();
        }

        private void поКодуЛогаБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 82;
            Retrn2();
        }
        private void поДатеЛогаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 83;
            Retrn2();
        }
        private void поТипуЛогаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 84;
            Retrn2();
        }
        private void поОписаниюЛогаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 85;
            Retrn2();
        }
        //=======================================Добавление
        private void добавлениеПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 86;
            Retrn3();
        }
        //======================================Удаление Админ
        private void пользователяПоКодуБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 87;
            Retrn2();
        }
        private void логаПоКодуБДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 88;
            Retrn2();
        }

        private void отправитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 89;
            a = "INSERT INTO Chat (Data_M, From_M, To_M, Mes) VALUES (@Data_M, @From_M, @To_M, @Mes)";
            if (toolStripTextBox1.Text != "" && toolStripTextBox2.Text != "")
            {
                LoadDB();
                TypeEvent = "Отправка сообщения Пользователем " + user;
                DescEvent = "Пользователь " + user + " отправил сообщение" + a;
                Logg();
            }
            else
            {

            }
        }
        private void входящиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 90;
            a = @"SELECT Chat.* FROM Chat WHERE ((Chat.To_M)='" + Convert.ToString(user) + "') ORDER BY Chat.ID_M DESC";
            LoadDB();
            TypeEvent = "Просмотр входящих " + user;
            DescEvent = "Пользователь " + user + " обновил чат вручную" + a;
            Logg();
        }
        private void ИсходящиеtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateF = 90;
            a = @"SELECT Chat.* FROM Chat WHERE ((Chat.From_M)='" + Convert.ToString(user) + "') ORDER BY Chat.ID_M DESC";
            LoadDB();
            TypeEvent = "Просмотр исходящих " + user;
            DescEvent = "Пользователь " + user + " обновил чат вручную" + a;
            Logg();
        }
    }
}