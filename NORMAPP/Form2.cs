using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NORMAPP
{
    public partial class Form2 : Form
    {
        public Form2(int StateF, string a, string TypeEvent, string DescEvent, string user, string ConS)
        {
            InitializeComponent();
            this.StateF = StateF;
            this.a = a;
            this.TypeEvent = TypeEvent;
            this.DescEvent = DescEvent;
            this.user = user;
            this.ConS = ConS;
        }
        private OleDbConnection dbCon;
        public int StateF;
        public string a;
        public string TypeEvent;
        public string DescEvent;
        public string user;
        public int Cap = 0;
        public string ConS;
        public int StateP = 0;
        private void Form2_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button1;
            textBox1.Visible = true;
            textBox2.Visible = false;
            comboBox1.Visible = false;
            comboBox1.ForeColor = Color.Gray;
            comboBox2.Visible = false;
            comboBox2.ForeColor = Color.Gray;
            textBox1.ForeColor = Color.Gray;
            textBox2.ForeColor = Color.Gray;
            //-------------------------------Заказчик++++++++++++++++++++++++++++++++
            if (StateF == 12)
            {
                this.Text = "Поиск Заказчика по Коду Заказчика БД";
                textBox1.Text = "Введите Код Заказчика БД";
                StateP = 0;
            }
            if (StateF == 13)
            {
                this.Text = "Поиск Заказчика по Коду Заказчика";
                textBox1.Text = "Введите Код Заказчика";
                StateP = 1;
            }
            if (StateF == 14)
            {
                this.Text = "Поиск Заказчкика по Имени Заказчика";
                textBox1.Text = "Введите Имя Заказчика либо фразу";
                StateP = 2;
            }
            if (StateF == 15)
            {
                textBox1.Visible = false;
                comboBox1.Visible = true;
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(new string[] { "Юрлицо", "Физлицо", "Другое" });
                this.Text = "Поиск Заказчика по Типу Заказчика";
                comboBox1.Text = "Выберите Тип Заказчика";
                StateP = 3;
            }
            //-------------------------------Заказ+++++++++++++++++++++++++++++++++++
            if (StateF == 16)
            {
                this.Text = "Поиск Заказа по Коду Заказа БД";
                textBox1.Text = "Введите Код Заказа БД";
                StateP = 4;
            }
            if (StateF == 17)
            {
                this.Text = "Поиск Заказа по Коду Заказчика БД";
                textBox1.Text = "Введите Код Заказчика БД";
                StateP = 5;
            }
            if (StateF == 18)
            {
                textBox2.Visible = true;
                this.Text = "Поиск Заказа по Кодам Заказчика и Заказа БД";
                textBox1.Text = "Введите Код Заказчика БД";
                textBox2.Text = "Введите Код Заказа БД";
                StateP = 6;
            }
            if (StateF == 19)
            {
                this.Text = "Поиск Заказа по Коду Заказа";
                textBox1.Text = "Введите Код Заказа";
                StateP = 7;
            }
            if (StateF == 20)
            {
                this.Text = "Поиск Заказа по Имени Заказа";
                textBox1.Text = "Введите Имя Заказа либо фразу";
                StateP = 8;
            }
            if (StateF == 21)
            {
                textBox1.Visible = false;
                comboBox1.Visible = true;
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(new string[] { "Изготовление", "Ремонт/ТО", "Прочее" });
                this.Text = "Поиск Заказа по Типу Заказа";
                comboBox1.Text = "Выберите Тип Заказа";
                StateP = 9;
            }
            if (StateF == 22)
            {
                textBox1.Text = "Введите Дату Заказа в формате День.Месяц.Год (01.05.1997)";
                this.Text = "Поиск Заказа по Дате Заказа";
                StateP = 10;
            }
            //-------------------------------Перечень заказа+++++++++++++++++++++++++++++
            if (StateF == 23)
            {
                textBox1.Text = "Введите Код Строки Перчня БД";
                this.Text = "Поиск Строки Перечня по Коду Строки БД";
                StateP = 11;
            }
            if (StateF == 24)
            {
                textBox1.Text = "Введите Код Заказа БД";
                this.Text = "Поиск Строки Перечня по Коду Заказа БД";
                StateP = 12;
            }
            if (StateF == 25)
            {
                textBox1.Text = "Введите Имя Строки";
                this.Text = "Поиск Строки Перечня по Названию Строки БД";
                StateP = 13;
            }
            // ==============================ПОИСК ПРО+++++++++++++++++++++
            if (StateF == 26)
            {
                Visible3();
                comboBox1.Items.AddRange(new string[]
                { "1.1.1 Заказчик и Заказ по Коду Заказчика БД",
                    "1.2.1 Заказчик и Заказ по Коду Заказа БД",
                    "1.3.1 Заказчик и Заказ по Коду Заказчика",
                    "1.4.1 Заказчик и Заказ по Коду Заказа",
                    "1.5.1 Заказчик и Заказ по Имени Заказчика",
                    "1.6.1 Заказчик и Заказ по Типу Заказчика",
                    "1.7.1 Заказчик и Заказ по Имени Заказа",
                    "1.8.1 Заказчик и Заказ по Типу Заказа",
                    "1.9.1 Заказчик и Заказ по Дате Заказа"
                });
                comboBox1.Text = "Выберите тип запроса и нажмите Далее";
                this.Text = "Поиск и Просмотр по БД в продвинутом режиме";
            }
            if (StateF == 27)
            {
                Visible3();
                comboBox1.Items.AddRange(new string[]
                {
                    "2.1.1 Заказ и Перечень по Коду Заказа БД",
                    "2.2.1 Заказ и Перечень по Коду Заказчика БД",
                    "2.3.1 Заказ и Перечень по Коду Заказа",
                    "2.4.1 Заказ и Перечень по Имени Заказа",
                    "2.5.1 Заказ и Перечень по Типу Заказа",
                    "2.6.1 Заказ и Перечень по Дате Заказа",
                    "2.7.1 Заказ и Перечень по Коду Строки Перечня БД",
                    "2.8.1 Заказ и Перечень по Имени Строки Перечня"
                });
                comboBox1.Text = "Выберите тип запроса и нажмите Далее";
                this.Text = "Поиск и Просмотр по БД в продвинутом режиме";
            }
            if (StateF == 28)
            {
                Visible3();
                comboBox1.Items.AddRange(new string[]
                {
                    "3.1.1 Заказчик, Заказ, Перечень по Коду Заказчика БД",
                    "3.2.1 Заказчик, Заказ, Перечень по Коду Заказчика",
                    "3.3.1 Заказчик, Заказ, Перечень по Имени Заказчика",
                    "3.4.1 Заказчик, Заказ, Перечень по Типу Заказчика",
                    "3.5.1 Заказчик, Заказ, Перечень по Коду Заказа БД",
                    "3.6.1 Заказчик, Заказ, Перечень по Коду Заказа",
                    "3.7.1 Заказчик, Заказ, Перечень по Имени Заказа",
                    "3.8.1 Заказчик, Заказ, Перечень по Типу Заказа",
                    "3.9.1 Заказчик, Заказ, Перечень по Дате Заказа",
                    "3.10.1 Заказчик, Заказ, Перечень по Коду Строки Перечня БД",
                    "3.11.1 Заказчик, Заказ, Перечень по Имени Строки Перечня"
                });
                comboBox1.Text = "Выберите тип запроса и нажмите Далее";
                this.Text = "Поиск и Просмотр по БД в продвинутом режиме";
            }
            //-------------------------------Удаление Заказа Заказчика Перечня+++++++++++++
            if (StateF == 32)
            {
                button2.Visible = false;
                textBox1.Text = "Введите Код Заказчика БД для Удаления";
                this.Text = "Удаление Заказчика";
            }
            if (StateF == 33)
            {
                button2.Visible = false;
                textBox1.Text = "Введите Код Заказа БД для Удаления";
                this.Text = "Удаление Заказа";
            }
            if (StateF == 34)
            {
                button2.Visible = false;
                textBox1.Text = "Введите Код Строки Перечня Заказа БД для Удаления";
                this.Text = "Удаление Перечня Заказа";
            }
            //-----------------------------Изделие+++++++++++++++++++++
            if (StateF == 35)
            {
                this.Text = "Поиск Изделия по Коду Изделия БД";
                textBox1.Text = "Введите Код Изделия БД";
                StateP = 42;
            }
            if (StateF == 36)
            {
                this.Text = "Поиск Изделия по Коду Изделия";
                textBox1.Text = "Введите Код Изделия";
                StateP = 43;
            }
            if (StateF == 37)
            {
                this.Text = "Поиск Изделия по Имени Изделия";
                textBox1.Text = "Введите Имя Изделия";
                StateP = 44;
            }
            if (StateF == 38)
            {
                textBox1.Visible = false;
                comboBox1.Visible = true;
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(new string[] { "Изделие", "Узел", "Деталь", "Стандартное Изделие", "Другое" });
                this.Text = "Поиск Изделия по Типу Изделия";
                comboBox1.Text = "Выберите Тип Изделия";
                StateP = 45;
            }
            //-----------------------------Узел Деталь+++++++++++++++++++++
            if (StateF == 39)
            {
                this.Text = "Поиск Узла/Детали по Коду Узла/Детали БД";
                textBox1.Text = "Введите Код Узла/Детали БД";
                StateP = 46;
            }
            if (StateF == 40)
            {
                this.Text = "Поиск Узла/Детали по Коду Узла/Детали";
                textBox1.Text = "Введите Код Узла/Детали";
                StateP = 47;
            }
            if (StateF == 41)
            {
                this.Text = "Поиск Узла/Детали по № Вложенности Узла/Детали";
                textBox1.Text = "Введите № Вложенности Узла/Детали (1.2.3)";
                StateP = 48;
            }
            if (StateF == 42)
            {
                this.Text = "Поиск Узла/Детали по Порядковому № Узла/Детали";
                textBox1.Text = "Введите Порядковый № Узла/Детали (25)";
                StateP = 49;
            }
            if (StateF == 43)
            {
                this.Text = "Поиск Узла/Детали по Имени Узла/Детали";
                textBox1.Text = "Введите Имя Узла/Детали";
                StateP = 50;
            }
            if (StateF == 44)
            {
                textBox1.Visible = false;
                comboBox1.Visible = true;
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(new string[] { "Узел", "Деталь", "Стандартное Изделие", "Другое" });
                this.Text = "Поиск Узла/Детали по Типу Узла/Детали";
                comboBox1.Text = "Выберите Тип Узла/Детали";
                StateP = 51;
            }
            // ==============================ПОИСК ПРО ИЗДЕЛИЕ УЗЕЛ ДЕТАЛЬ+
            if (StateF == 45)
            {
                Visible3();
                comboBox1.Items.AddRange(new string[]
                { "4.1.1 Изделие и Узел/Деталь по Коду Изделия БД",
                    "4.2.1 Изделие и Узел/Деталь по Коду Изделия",
                    "4.3.1 Изделие и Узел/Деталь по Имени Изделия",
                    "4.4.1 Изделие и Узел/Деталь по Типу Изделия",
                    "4.5.1 Изделие и Узел/Деталь по Коду Узла/Детали БД",
                    "4.6.1 Изделие и Узел/Деталь по Коду Узла/Детали",
                    "4.7.1 Изделие и Узел/Деталь по Имени Узла/Детали",
                    "4.8.1 Изделие и Узел/Деталь по Типу Узла/Детали"
                });
                comboBox1.Text = "Выберите тип запроса и нажмите Далее";
                this.Text = "Поиск и Просмотр по БД в продвинутом режиме";
            }
            //===================================Удаление Изделия узла детали+
            if (StateF == 48)
            {
                button2.Visible = false;
                textBox1.Text = "Введите Код Изделия БД для Удаления";
                this.Text = "Удаление Изделия";
            }
            if (StateF == 49)
            {
                button2.Visible = false;
                textBox1.Text = "Введите Код Узла/Детали БД для Удаления";
                this.Text = "Удаление Узла/Детали";
            }
            //=================================Поиск по материалам нормам ГОСТ+
            if (StateF == 50)
            {
                this.Text = "Поиск Материала по Коду Материала БД";
                textBox1.Text = "Введите Код Материала БД";
                StateP = 60;
            }
            if (StateF == 51)
            {
                this.Text = "Поиск Материала по Коду Материала";
                textBox1.Text = "Введите Код Материала";
                StateP = 61;
            }
            if (StateF == 52)
            {
                this.Text = "Поиск Материала по Имени Материала";
                textBox1.Text = "Введите Имя Материала";
                StateP = 62;
            }
            if (StateF == 53)
            {
                this.Text = "Поиск Материала по Марке Материала";
                textBox1.Text = "Введите Марку Материала";
                StateP = 63;
            }
            if (StateF == 54)
            {
                textBox1.Visible = false;
                comboBox1.Visible = true;
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(new string[] { 
                    "Металлы",
                    "Метизы",
                    "Подшипники",
                    "РезТехИзд",
                    "ЭлектроОбор",
                    "Литье/ковка",
                    "Сварка",
                    "ГСМ",
                    "Лакокрасочные",
                    "ДревСтружМат",
                    "Сборочная",
                    "Прочее"});
                this.Text = "Поиск Материала по Типу Материала";
                comboBox1.Text = "Выберите Тип Материала";
                StateP = 64;
            }
            //=================================нормы
            if (StateF == 55)
            {
                this.Text = "Поиск Нормы по Коду Нормы БД";
                textBox1.Text = "Введите Код Нормы БД";
                StateP = 65;
            }
            if (StateF == 56)
            {
                textBox1.Visible = false;
                comboBox1.Visible = true;
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(new string[] {"Изготовительная","Ремонтная","Прочее"});
                this.Text = "Поиск Нормы по Типу Нормы";
                comboBox1.Text = "Выберите Тип Нормы";
                StateP = 66;
            }
            //=================================ГОСТ
            if (StateF == 57)
            {
                this.Text = "Поиск ГОСТ по Коду ГОСТ БД";
                textBox1.Text = "Введите Код ГОСТ БД";
                StateP = 67;
            }
            if (StateF == 58)
            {
                this.Text = "Поиск ГОСТ по Имени ГОСТ";
                textBox1.Text = "Введите Имя ГОСТ";
                StateP = 68;
            }
            //============================ПОИСК ПРО Материал норма гост+
            if (StateF == 59)
            {
                Visible3();
                comboBox1.Items.AddRange(new string[]
                { "5.1.1 Материал и Нормы по Коду Материала БД",
                    "5.2.1 Материал и Нормы по Коду Материала",
                    "5.3.1 Материал и Нормы по Имени Материала",
                    "5.4.1 Материал и Нормы по Марке Материала",
                    "5.5.1 Материал и Нормы по Типу Материала",
                    "5.6.1 Материал и Нормы по Коду Нормы БД",
                    "5.7.1 Материал и Нормы по Типу Нормы"
                });
                comboBox1.Text = "Выберите тип запроса и нажмите Далее";
                this.Text = "Поиск и Просмотр по БД в продвинутом режиме";
            }
            if (StateF == 60)
            {
                Visible3();
                comboBox1.Items.AddRange(new string[]
                {"6.1.1 Узел/Деталь и Материал по Коду Узла/Детали БД",
                    "6.2.1 Узел/Деталь и Материал по Коду Узла/Детали",
                    "6.3.1 Узел/Деталь и Материал по Имени Узла/Детали",
                    "6.4.1 Узел/Деталь и Материал по Типу Узла/Детали",
                    "6.5.1 Узел/Деталь и Материал по Коду Материала БД",
                    "6.6.1 Узел/Деталь и Материал по Коду Материала",
                    "6.7.1 Узел/Деталь и Материал по Имени Материала",
                    "6.8.1 Узел/Деталь и Материал по Марке Материала",
                    "6.9.1 Узел/Деталь и Материал по Типу Материала"
                });
                comboBox1.Text = "Выберите тип запроса и нажмите Далее";
                this.Text = "Поиск и Просмотр по БД в продвинутом режиме";
            }
            if (StateF == 61)
            {
                Visible3();
                comboBox1.Items.AddRange(new string[]
                {"7.1.1 Узел/Деталь, Материал, Норма по Коду Узла/Детали БД",
                    "7.2.1 Узел/Деталь, Материал, Норма по Коду Узла/Детали",
                    "7.3.1 Узел/Деталь, Материал, Норма по Имени Узла/Детали",
                    "7.4.1 Узел/Деталь, Материал, Норма по Типу Узла/Детали",
                    "7.5.1 Узел/Деталь, Материал, Норма по Коду Материала БД",
                    "7.6.1 Узел/Деталь, Материал, Норма по Коду Материала",
                    "7.7.1 Узел/Деталь, Материал, Норма по Имени Материала",
                    "7.8.1 Узел/Деталь, Материал, Норма по Марке Материала",
                    "7.9.1 Узел/Деталь, Материал, Норма по Типу Материала",
                    "7.10.1 Узел/Деталь, Материал, Норма по Коду Нормы БД",
                    "7.11.1 Узел/Деталь, Материал, Норма по Типу Нормы"
                });
                comboBox1.Text = "Выберите тип запроса и нажмите Далее";
                this.Text = "Поиск и Просмотр по БД в продвинутом режиме";
            }
            if (StateF == 62)
            {
                Visible3();
                comboBox1.Items.AddRange(new string[]
                {"8.1.1 Изделие, Узел/Деталь, Материал, Норма по Коду Изделия БД",
                    "8.2.1 Изделие, Узел/Деталь, Материал, Норма по Коду Изделия",
                    "8.3.1 Изделие, Узел/Деталь, Материал, Норма по Имени Изделия",
                    "8.4.1 Изделие, Узел/Деталь, Материал, Норма по Типу Изделия",
                    "8.5.1 Изделие, Узел/Деталь, Материал, Норма по Коду Узла/Детали БД",
                    "8.6.1 Изделие, Узел/Деталь, Материал, Норма по Коду Узла/Детали",
                    "8.7.1 Изделие, Узел/Деталь, Материал, Норма по Имени Узла/Детали",
                    "8.8.1 Изделие, Узел/Деталь, Материал, Норма по Типу Узла/Детали",
                    "8.9.1 Изделие, Узел/Деталь, Материал, Норма по Коду Материала БД",
                    "8.10.1 Изделие, Узел/Деталь, Материал, Норма по Коду Материала",
                    "8.11.1 Изделие, Узел/Деталь, Материал, Норма по Имени Материала",
                    "8.12.1 Изделие, Узел/Деталь, Материал, Норма по Марке Материала",
                    "8.13.1 Изделие, Узел/Деталь, Материал, Норма по Типу Материала",
                    "8.14.1 Изделие, Узел/Деталь, Материал, Норма по Коду Нормы БД",
                    "8.15.1 Изделие, Узел/Деталь, Материал, Норма по Типу Нормы"
                });
                comboBox1.Text = "Выберите тип запроса и нажмите Далее";
                this.Text = "Поиск и Просмотр по БД в продвинутом режиме";
            }
            if (StateF == 63)
            {
                Visible3();
                comboBox1.Items.AddRange(new string[]
                {"9.1.1 Ведомость по Коду Узла/Детали БД",
                    "9.2.1 Ведомость по Коду Узла/Детали",
                    "9.3.1 Ведомость по Имени Узла/Детали",
                    "9.4.1 Ведомость по Типу Узла/Детали",
                    "9.5.1 Ведомость по Коду Материала БД",
                    "9.6.1 Ведомость по Коду Материала",
                    "9.7.1 Ведомость по Имени Материала",
                    "9.8.1 Ведомость по Марке Материала",
                    "9.9.1 Ведомость по Типу Материала",
                    "9.10.1 Ведомость по Коду Нормы БД",
                    "9.11.1 Ведомость по Типу Нормы"
                });
                comboBox1.Text = "Выберите тип запроса и нажмите Далее";
                this.Text = "Поиск и Просмотр по БД в продвинутом режиме";
            }
            if (StateF == 64)
            {
                Visible3();
                comboBox1.Items.AddRange(new string[]
                {"10.1.1 Ведомость по Коду Строки Перечня БД",
                    "10.2.1 Ведомость по Коду Заказа БД",
                    "10.3.1 Ведомость по Имени Строки Перечня",
                    "10.4.1 Ведомость по Коду Изделия БД",
                    "10.5.1 Ведомость по Коду Изделия",
                    "10.6.1 Ведомость по Имени Изделия",
                    "10.7.1 Ведомость по Типу Изделия",
                    "10.8.1 Ведомость по Коду Узла/Детали БД",
                    "10.9.1 Ведомость по Коду Узла/Детали",
                    "10.10.1 Ведомость по Имени Узла/Детали",
                    "10.11.1 Ведомость по Типу Узла/Детали",
                    "10.12.1 Ведомость по Коду Материала БД",
                    "10.13.1 Ведомость по Коду Материала",
                    "10.14.1 Ведомость по Имени Материала",
                    "10.15.1 Ведомость по Марке Материала",
                    "10.16.1 Ведомость по Типу Материала",
                    "10.17.1 Ведомость по Коду Нормы БД",
                    "10.18.1 Ведомость по Типу Нормы"
                });
                comboBox1.Text = "Выберите тип запроса и нажмите Далее";
                this.Text = "Поиск и Просмотр по БД в продвинутом режиме";
            }
            //-------------------------------Удаление Материала НОРМЫ ГОСТ+
            if (StateF == 68)
            {
                button2.Visible = false;
                textBox1.Text = "Введите Код Материала БД для Удаления";
                this.Text = "Удаление Материала";
            }
            if (StateF == 69)
            {
                button2.Visible = false;
                textBox1.Text = "Введите Код Нормы БД для Удаления";
                this.Text = "Удаление Нормы";
            }
            if (StateF == 70)
            {
                button2.Visible = false;
                textBox1.Text = "Введите Код ГОСТ БД для Удаления";
                this.Text = "Удаление ГОСТ";
            }
            //=============================Поиск по связям+
            if (StateF == 71)
            {
                this.Text = "Поиск Связей по Коду Строки Связи БД";
                textBox1.Text = "Введите Код Строки Связи БД";
                StateP = 140;
            }
            if (StateF == 72)
            {
                this.Text = "Поиск Связей по Коду Изделия БД";
                textBox1.Text = "Введите Код Изделия БД";
                StateP = 141;
            }
            if (StateF == 73)
            {
                this.Text = "Поиск Связей по Коду Узла/Детали БД";
                textBox1.Text = "Введите Код Узла/Детали БД";
                StateP = 142;
            }
            if (StateF == 74)
            {
                this.Text = "Поиск Связей по Коду Материала БД";
                textBox1.Text = "Введите Код Материала БД";
                StateP = 143;
            }
            if (StateF == 75)
            {
                this.Text = "Поиск Связей по Коду Нормы БД";
                textBox1.Text = "Введите Код Нормы БД";
                StateP = 144;
            }
            if (StateF == 76)
            {
                this.Text = "Поиск Связей по Коду Перечня БД";
                textBox1.Text = "Введите Код Перечня БД";
                StateP = 145;
            }
            //===========================Удаление Связи
            if (StateF == 78)
            {
                button2.Visible = false;
                textBox1.Text = "Введите Код Связи БД для Удаления";
                this.Text = "Удаление Связи";
            }
            //==========================Поиск по Пользователю
            if (StateF == 79)
            {
                this.Text = "Поиск Пользователя по Коду Пользователя БД";
                textBox1.Text = "Введите Код Пользователя БД";
                StateP = 146;
            }
            if (StateF == 80)
            {
                this.Text = "Поиск Пользователя по Логину Пользователя";
                textBox1.Text = "Введите Логин Пользователя";
                StateP = 147;
            }
            if (StateF == 81)
            {
                textBox1.Visible = false;
                comboBox1.Visible = true;
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(new string[] { "ADMIN", "USER", "USER1","USER2", "USER3", "USER4", "USER5" });
                this.Text = "Поиск Пользователя по Типу Пользователя";
                comboBox1.Text = "Выберите Тип Пользователя";
                StateP = 148;
            }
            //==========================Поиск по Логу
            if (StateF == 82)
            {
                this.Text = "Поиск Лога по Коду Лога БД";
                textBox1.Text = "Введите Код Лога БД";
                StateP = 149;
            }
            if (StateF == 83)
            {
                this.Text = "Поиск Лога по Дате Лога";
                textBox1.Text = "Введите Дату Лога";
                StateP = 150;
            }
            if (StateF == 84)
            {
                textBox1.Visible = false;
                comboBox1.Visible = true;
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(new string[] { "Ошибка", "Добавление", "Удаление", "Редактирование", "Вход", "Выход", "Запуск", "Печать" });
                this.Text = "Поиск Лога по Типу Лога";
                comboBox1.Text = "Выберите Тип Лога";
                StateP = 151;
            }
            if (StateF == 85)
            {
                this.Text = "Поиск Лога по Описанию Лога";
                textBox1.Text = "Введите Описание Лога";
                StateP = 152;
            }
            //=======================Удаление Лога и Пользователя
            if (StateF == 87)
            {
                button2.Visible = false;
                textBox1.Text = "Введите Код Пользователя БД для Удаления";
                this.Text = "Удаление Пользователя";
            }
            if (StateF == 88)
            {
                button2.Visible = false;
                textBox1.Text = "Введите Код Лога БД для Удаления";
                this.Text = "Удаление Лога";
            }

        }
        public void Error(Exception g1)
        {
            TypeEvent = "Ошибка";
            DescEvent = "Ошибка при выполнении запроса к БД";
            MessageBox.Show("Ошибка при выполнении запроса к БД. Обратитесь в поддержку " + Convert.ToString(g1), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }
        public void Visible1()
        {
            button2.Visible = true;
            comboBox1.Visible = false;
            textBox1.Visible = true;
            button1.Text = "Принять";
        }
        public void Visible2()
        {
            button2.Visible = true;
            comboBox2.Visible = true;
            comboBox1.Visible = false;
            textBox1.Visible = false;
            comboBox2.Items.Clear();
            button1.Text = "Принять";
        }
        public void Visible3()
        {
            comboBox1.Visible = true;
            textBox1.Visible = false;
            button2.Visible = false;
            button1.Text = "Далее";
            comboBox1.Items.Clear();
        }
        private void button1_Click(object sender, EventArgs e) // По нажатии ВВОД
        {
            //-------------------------------Заказчик++++++++
            if (StateF == 12)
            {
                if (textBox1.Text != "Введите Код Заказчика БД" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Cust.* FROM S_Cust WHERE (((S_Cust.ID_CustDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Заказчика БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 13)
            {
                if (textBox1.Text != "Введите Код Заказчика" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Cust.* FROM S_Cust WHERE (((S_Cust.ID_Cust)='" + Convert.ToString(textBox1.Text) + "'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Заказчика!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 14)
            {
                if (textBox1.Text != "Введите Имя Заказчика либо фразу" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Cust.* FROM S_Cust WHERE (((S_Cust.Name_Cust) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Имя Заказчика либо фразу!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 15)
            {
                if (comboBox1.Text != "Выберите Тип Заказчика" && comboBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Cust.* FROM S_Cust WHERE (((S_Cust.Type_Cust)='" + Convert.ToString(comboBox1.Text) + "'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Заказа БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //-------------------------------Заказ++++++++++++++++++++++++
            if (StateF == 16)
            {
                if (textBox1.Text != "Введите Код Заказа БД" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Order.* FROM S_Order WHERE (((S_Order.ID_OrderDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Заказа БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 17)
            {
                if (textBox1.Text != "Введите Код Заказчика БД" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Order.* FROM S_Order WHERE (((S_Order.ID_CustDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Заказчика БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 18)
            {
                if (textBox1.Text != "Введите Код Заказчика БД" && textBox1.Text != "" && textBox2.Text != "Введите Код Заказа БД" && textBox2.Text != "") 
                {
                    try
                    {
                        a = @"SELECT S_Order.* FROM S_Order WHERE (((S_Order.ID_CustDB)=" + Convert.ToInt32(textBox1.Text) + ") AND ((S_Order.ID_OrderDB)=" + Convert.ToInt32(textBox2.Text) + "));";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    if (textBox1.Text == "" || textBox1.Text == "Введите Код Заказчика БД")
                    {
                        MessageBox.Show("Введите Код Заказчика БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (textBox2.Text == "" || textBox2.Text == "Введите Код Заказа БД")
                    {
                        MessageBox.Show("Введите Код Заказа БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

            }
            if (StateF == 19)
            {
                if (textBox1.Text != "Введите Код Заказа" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Order.* FROM S_Order WHERE (((S_Order.ID_Order)='" + Convert.ToString(textBox1.Text) + "'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Заказа!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 20)
            {
                if (textBox1.Text != "Введите Имя Заказа" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Order.* FROM S_Order WHERE (((S_Order.Name_Order) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        this.Close();
                    }
                    catch(Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Имя Заказа либо фразу!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 21)
            {
                if (comboBox1.Text != "Выберите Тип Заказа" && comboBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Order.* FROM S_Order WHERE (((S_Order.Type_Order)='" + Convert.ToString(comboBox1.Text) + "'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Выберите Тип Заказа!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 22)
            {
                if (textBox1.Text != "Введите Дату Заказа в формате День.Месяц.Год (01.05.1997)" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Order.* FROM S_Order WHERE (((S_Order.Date_Order)='" + Convert.ToString(textBox1.Text) + "'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Дату Заказа в формате День.Месяц.Год (01.05.1997)!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //-------------------------------Перечень заказа++++++++++++++++++++++++++++++
            if (StateF == 23)
            {
                if (textBox1.Text != "Введите Код Строки Перчня БД" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Items.* FROM S_Items WHERE (((S_Items.ID_ItemDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Строки Перчня БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 24)
            {
                if (textBox1.Text != "Введите Код Заказа БД" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Items.* FROM S_Items WHERE (((S_Items.ID_OrderDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Заказа БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 25)
            {
                if (textBox1.Text != "Введите Имя Строки" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Items.* FROM S_Items WHERE (((S_Items.Name_Item) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Имя Строки!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //-----------------------------ПОИСК ПРО++++++++++++++++
            if (StateF == 26)
            {
                if (comboBox1.SelectedItem == "1.1.1 Заказчик и Заказ по Коду Заказчика БД" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 14;
                        textBox1.Text = "Введите Код Заказчика БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Заказчика БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.Name_Cust, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Cust INNER JOIN S_Order ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Cust.ID_CustDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Заказчика БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "1.2.1 Заказчик и Заказ по Коду Заказа БД" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 15;
                        textBox1.Text = "Введите Код Заказа БД";
                    }
                    if (Cap >=2)
                    {
                        if (textBox1.Text != "Введите Код Заказа БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.Name_Cust, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Cust INNER JOIN S_Order ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.ID_OrderDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Заказа БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "1.3.1 Заказчик и Заказ по Коду Заказчика" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 16;
                        textBox1.Text = "Введите Код Заказчика";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Заказчика" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.Name_Cust, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Cust INNER JOIN S_Order ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Cust.ID_Cust)='" + Convert.ToString(textBox1.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Заказчика!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "1.4.1 Заказчик и Заказ по Коду Заказа" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 17;
                        textBox1.Text = "Введите Код Заказа";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Заказа" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.Name_Cust, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Cust INNER JOIN S_Order ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.ID_Order)='" + Convert.ToString(textBox1.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Заказа!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "1.5.1 Заказчик и Заказ по Имени Заказчика" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 18;
                        textBox1.Text = "Введите Имя Заказчика";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Заказчика" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.Name_Cust, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Cust INNER JOIN S_Order ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Cust.Name_Cust) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Заказчика!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "1.6.1 Заказчик и Заказ по Типу Заказчика" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[] { "Юрлицо", "Физлицо", "Другое" });
                        StateP = 19;
                        comboBox2.Text = "Выберите Тип Заказчика";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Заказчика" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.Name_Cust, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Cust INNER JOIN S_Order ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Cust.Type_Cust)='" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Заказчика!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "1.7.1 Заказчик и Заказ по Имени Заказа" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 20;
                        textBox1.Text = "Введите Имя Заказа";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Заказа" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.Name_Cust, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Cust INNER JOIN S_Order ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.Name_Order) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Заказа!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "1.8.1 Заказчик и Заказ по Типу Заказа" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[] { "Ремонт/ТО", "Изготовление", "Другое" });
                        StateP = 21;
                        comboBox2.Text = "Выберите Тип Заказа";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Заказа" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.Name_Cust, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Cust INNER JOIN S_Order ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.Type_Order)='" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Заказа!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "1.9.1 Заказчик и Заказ по Дате Заказа" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 22;
                        textBox1.Text = "Введите Дату Заказа в формате День.Месяц.Год (01.05.1997)";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Дату Заказа в формате День.Месяц.Год (01.05.1997)" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.Name_Cust, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Cust INNER JOIN S_Order ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.Date_Order)='" + Convert.ToString(textBox1.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Дату Заказа в формате День.Месяц.Год (01.05.1997)!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            if (StateF == 27)
            {
                if (comboBox1.SelectedItem == "2.1.1 Заказ и Перечень по Коду Заказа БД" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 23;
                        textBox1.Text = "Введите Код Заказа БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Заказа БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB WHERE (((S_Order.ID_OrderDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Заказа БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "2.2.1 Заказ и Перечень по Коду Заказчика БД" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 24;
                        textBox1.Text = "Введите Код Заказчика БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Заказчика БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB WHERE (((S_Order.ID_CustDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Заказчика БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "2.3.1 Заказ и Перечень по Коду Заказа" && comboBox1.ForeColor == Color.Black) //ОК
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 25;
                        textBox1.Text = "Введите Код Заказа";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Заказа" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB WHERE (((S_Order.ID_Order)='" + Convert.ToString(textBox1.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Заказа!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "2.4.1 Заказ и Перечень по Имени Заказа" && comboBox1.ForeColor == Color.Black) // OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 26;
                        textBox1.Text = "Введите Имя Заказа";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Заказа" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB WHERE (((S_Order.Name_Order) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Заказа!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "2.5.1 Заказ и Перечень по Типу Заказа" && comboBox1.ForeColor == Color.Black) // OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        StateP = 27;
                        comboBox2.Items.AddRange(new string[] { "Ремонт/ТО", "Изготовление", "Другое" });
                        comboBox2.Text = "Выберите Тип Заказа";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Заказа" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB WHERE (((S_Order.Type_Order)='" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Заказа!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "2.6.1 Заказ и Перечень по Дате Заказа" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 28;
                        textBox1.Text = "Введите Дату Заказа в формате День.Месяц.Год (01.05.1997)";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Дату Заказа в формате День.Месяц.Год (01.05.1997)" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB WHERE (((S_Order.Date_Order)='" + Convert.ToString(textBox1.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Дату Заказа в формате День.Месяц.Год (01.05.1997)!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "2.7.1 Заказ и Перечень по Коду Строки Перечня БД" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 29;
                        textBox1.Text = "Введите Код Строки Перечня БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Строки Перечня БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB WHERE (((S_Items.ID_ItemDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Строки Перечня БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "2.8.1 Заказ и Перечень по Имени Строки Перечня" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 30;
                        textBox1.Text = "Введите Имя Строки Перечня";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Строки Перечня" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB WHERE (((S_Items.Name_Item) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Строки Перечня либо часть имени!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            if (StateF == 28)
            {
                if (comboBox1.SelectedItem == "3.1.1 Заказчик, Заказ, Перечень по Коду Заказчика БД" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 31;
                        textBox1.Text = "Введите Код Заказчика БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Заказчика БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Cust.ID_CustDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Заказчика БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "3.2.1 Заказчик, Заказ, Перечень по Коду Заказчика" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 32;
                        textBox1.Text = "Введите Код Заказчика";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Заказчика" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Cust.ID_Cust)='" + Convert.ToString(textBox1.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Заказчика!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "3.3.1 Заказчик, Заказ, Перечень по Имени Заказчика" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 33;
                        textBox1.Text = "Введите Имя Заказчика";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Заказчика" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Cust.Name_Cust) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Заказчика!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "3.4.1 Заказчик, Заказ, Перечень по Типу Заказчика" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        StateP = 34;
                        comboBox2.Items.AddRange(new string[] { "Юрлицо", "Физлицо", "Другое" });
                        comboBox2.Text = "Выберите Тип Заказчика";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Заказчика" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Cust.Type_Cust)='" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Заказчика!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "3.5.1 Заказчик, Заказ, Перечень по Коду Заказа БД" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 35;
                        textBox1.Text = "Введите Код Заказа БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Заказа БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.ID_OrderDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Заказа БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "3.6.1 Заказчик, Заказ, Перечень по Коду Заказа" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 36;
                        textBox1.Text = "Введите Код Заказа";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Заказа" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.ID_Order)='" + Convert.ToString(textBox1.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Заказа!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "3.7.1 Заказчик, Заказ, Перечень по Имени Заказа" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 37;
                        textBox1.Text = "Введите Имя Заказа";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Заказа" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.Name_Order) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Заказа!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "3.8.1 Заказчик, Заказ, Перечень по Типу Заказа" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        StateP = 38;
                        comboBox2.Items.AddRange(new string[] { "Ремонт/ТО", "Изготовление", "Другое" });
                        comboBox2.Text = "Выберите Тип Заказа";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Заказа" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.Type_Order)='" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Заказа!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "3.9.1 Заказчик, Заказ, Перечень по Дате Заказа" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 39;
                        textBox1.Text = "Введите Дату Заказа в формате День.Месяц.Год (01.05.1997)";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Дату Заказа в формате День.Месяц.Год (01.05.1997)" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.Date_Order)='" + Convert.ToString(textBox1.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Дату Заказа в формате День.Месяц.Год (01.05.1997)!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "3.10.1 Заказчик, Заказ, Перечень по Коду Строки Перечня БД" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 40;
                        textBox1.Text = "Введите Код Строки Перечня БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Строки Перечня Бд" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Items.ID_ItemDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Строки Перечня БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "3.11.1 Заказчик, Заказ, Перечень по Имени Строки Перечня" && comboBox1.ForeColor == Color.Black)//ОК
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 41;
                        textBox1.Text = "Введите Имя Строки Перечня";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Строки Перечня" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Items.Name_Item) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Строки Перечня!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            //------------------------------Удаление Заказчика Заказа Перечня+
            if (StateF == 32)
            {
                if (textBox1.Text != "Введите Код Заказчика БД для Удаления" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"DELETE S_Cust.ID_CustDB, S_Cust.ID_Cust, S_Cust.Name_Cust, S_Cust.Type_Cust, S_Cust.Desc_Cust FROM S_Cust WHERE (((S_Cust.ID_CustDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Заказчика БД для Удаления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 33)
            {
                if (textBox1.Text != "Введите Код Заказа БД для Удаления" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"DELETE S_Order.ID_OrderDB, S_Order.ID_CustDB, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Order WHERE (((S_Order.ID_OrderDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Заказа БД для Удаления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 34)
            {
                if (textBox1.Text != "Введите Код Строки Перечня Заказа БД для Удаления" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"DELETE S_Items.ID_ItemDB, S_Items.ID_OrderDB, S_Items.Name_Item, S_Items.Count_Item, S_Items.Desc_Item FROM S_Items WHERE (((S_Items.ID_ItemDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Строки Перечня Заказа БД для Удаления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //-----------------------------Изделие Узел Деталь+
            if (StateF == 35)
            {
                if (textBox1.Text != "Введите Код Изделия БД" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Spec0.* FROM S_Spec0 WHERE (((S_Spec0.ID_SpecDB0)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Изделия БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 36)
            {
                if (textBox1.Text != "Введите Код Изделия" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Spec0.* FROM S_Spec0 WHERE (((S_Spec0.ID_Spec0)='" + Convert.ToString(textBox1.Text) + "'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Изделия!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 37)
            {
                if (textBox1.Text != "Введите Имя Изделия" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Spec0.* FROM S_Spec0 WHERE (((S_Spec0.Name_Spec0)LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Имя Изделия!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 38)
            {
                if (comboBox1.Text != "Выберите Тип Изделия" && comboBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Spec0.* FROM S_Spec0 WHERE (((S_Spec0.Type_Spec0)='" + Convert.ToString(comboBox1.Text) + "'))";
                        this.Close();

                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Выберите Тип Изделия!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (StateF == 39)
            {
                if (textBox1.Text != "Введите Код Узла/Детали БД" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Spec1.* FROM S_Spec1 WHERE (((S_Spec1.ID_SpecDB1)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Узла/Детали БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 40)
            {
                if (textBox1.Text != "Введите Код Узла/Детали" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Spec1.* FROM S_Spec1 WHERE (((S_Spec1.ID_Spec1)='" + Convert.ToString(textBox1.Text) + "'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 41)
            {
                if (textBox1.Text != "Введите № Вложенности Узла/Детали (1.2.3)" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Spec1.* FROM S_Spec1 WHERE (((S_Spec1.PNV_Spec1)='" + Convert.ToString(textBox1.Text) + "'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите № Вложенности Узла/Детали (1.2.3)", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 42)
            {
                if (textBox1.Text != "Введите Порядковый № Узла/Детали (25)" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Spec1.* FROM S_Spec1 WHERE (((S_Spec1.PN_Spec1)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Порядковый № Узла/Детали (25)!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 43)
            {
                if (textBox1.Text != "Введите Имя Узла/Детали" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Spec1.* FROM S_Spec1 WHERE (((S_Spec1.Name_Spec1) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Имя Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 44)
            {
                if (comboBox1.Text != "Выберите Тип Узла/Детали" && comboBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Spec1.* FROM S_Spec1 WHERE (((S_Spec1.Type_Spec1)='" + Convert.ToString(comboBox1.Text) + "'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Выберите Тип Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //-----------------------------ПОИСК ПРО ИЗДЕЛИЕ УЗЕЛ ДЕТАЛЬ+
            if (StateF == 45)
            {
                if (comboBox1.SelectedItem == "4.1.1 Изделие и Узел/Деталь по Коду Изделия БД" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 52;
                        textBox1.Text = "Введите Код Изделия БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Изделия БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.GOST_Spec0, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN SNM1 ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.ID_SpecDB0)=" + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Изделия БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "4.2.1 Изделие и Узел/Деталь по Коду Изделия" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 53;
                        textBox1.Text = "Введите Код Изделия";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Изделия" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.GOST_Spec0, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN SNM1 ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.ID_Spec0)='" + Convert.ToString(textBox1.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Изделия!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "4.3.1 Изделие и Узел/Деталь по Имени Изделия" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 54;
                        textBox1.Text = "Введите Имя Изделия";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Изделия" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.GOST_Spec0, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN SNM1 ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.Name_Spec0) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Изделия!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "4.4.1 Изделие и Узел/Деталь по Типу Изделия" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[] { "Изделие", "Узел", "Деталь", "Стандартное Изделие", "Другое" });
                        StateP = 55;
                        comboBox2.Text = "Выберите Тип Изделия";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Изделия" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.GOST_Spec0, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN SNM1 ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.Type_Spec0)='" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Изделия!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "4.5.1 Изделие и Узел/Деталь по Коду Узла/Детали БД" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 56;
                        textBox1.Text = "Введите Код Узла/Детали БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Узла/Детали БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.GOST_Spec0, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN SNM1 ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.ID_SpecDB1)=" + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Узла/Детали БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "4.6.1 Изделие и Узел/Деталь по Коду Узла/Детали" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 57;
                        textBox1.Text = "Введите Код Узла/Детали";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Узла/Детали" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.GOST_Spec0, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN SNM1 ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.ID_Spec1)='" + Convert.ToString(textBox1.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "4.7.1 Изделие и Узел/Деталь по Имени Узла/Детали" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 58;
                        textBox1.Text = "Введите Имя Узла/Детали";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Узла/Детали" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.GOST_Spec0, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN SNM1 ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.Name_Spec1) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "4.8.1 Изделие и Узел/Деталь по Типу Узла/Детали" && comboBox1.ForeColor == Color.Black) //OK
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[] { "Узел", "Деталь", "Стандартное Изделие", "Другое" });
                        StateP = 59;
                        comboBox2.Text = "Выберите Тип Узал/Детали";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Узал/Детали" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.GOST_Spec0, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN SNM1 ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.Type_Spec1)='" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            } 
            //---------------------------------Удаление узла детали изделия+
            if (StateF == 48)
            {
                if (textBox1.Text != "Введите Код Изделия БД для Удаления" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"DELETE S_Spec0.ID_SpecDB0, S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec0.Mass_Spec0, S_Spec0.L_Spec0, S_Spec0.W_Spec0, S_Spec0.H_Spec0, S_Spec0.Desc_Spec0 FROM S_Spec0 WHERE (((S_Spec0.ID_SpecDB0)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Изделия БД для Удаления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 49)
            {
                if (textBox1.Text != "Введите Код Узла/Детали БД для Удаления" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"DELETE S_Spec1.ID_SpecDB1, S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Spec1.Mass_Spec1, S_Spec1.L_Spec1, S_Spec1.W_Spec1, S_Spec1.H_Spec1, S_Spec1.Desc_Spec1 FROM S_Spec1 WHERE (((S_Spec1.ID_SpecDB1)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Узла/Детали БД для Удаления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //==============================Материалы НОРМЫ ГОСТ+
            if (StateF == 50)
            {
                if (textBox1.Text != "Введите Код Материала БД" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Mat.* FROM S_Mat WHERE (((S_Mat.ID_MatDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Материала БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 51)
            {
                if (textBox1.Text != "Введите Код Материала" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Mat.* FROM S_Mat WHERE (((S_Mat.ID_Mat)='" + Convert.ToString(textBox1.Text) + "'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 52)
            {
                if (textBox1.Text != "Введите Имя Материала" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Mat.* FROM S_Mat WHERE (((S_Mat.ID_MatDB)LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Имя Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 53)
            {
                if (textBox1.Text != "Введите Марку Материала" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Mat.* FROM S_Mat WHERE (((S_Mat.ID_MatDB)LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Марку Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 54)
            {
                if (comboBox1.Text != "Выберите Тип Материала" && comboBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_Mat.* FROM S_Mat WHERE (((S_Mat.Type_Mat)='" + Convert.ToString(comboBox1.Text) + "'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Выберите Тип Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
               
            if (StateF == 55)
            {
                if (textBox1.Text != "Введите Код Нормы БД" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_NormM.* FROM S_NormM WHERE (((S_NormM.ID_NormMDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Нормы БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 56)
            {
                if (comboBox1.Text != "Выберите Тип Нормы" && comboBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_NormM.* FROM S_NormM WHERE (((S_NormM.Type_NormM)='" + Convert.ToString(comboBox1.Text) + "'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Выберите Тип Нормы БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            
            if (StateF == 57)
            {
                if (textBox1.Text != "Введите Код ГОСТ БД" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_GOST.* FROM S_GOST WHERE (((S_GOST.ID_GOSTDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код ГОСТ БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 58)
            {
                if (textBox1.Text != "Введите Имя ГОСТ" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT S_GOST.* FROM S_GOST WHERE (((S_GOST.Name_GOST)LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Имя ГОСТ!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //===========================Поиск Про Материал норма ГОСТ
            if (StateF == 59) //+
            {
                if (comboBox1.SelectedItem == "5.1.1 Материал и Нормы по Коду Материала БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 69;
                        textBox1.Text = "Введите Код Материала БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Материала БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB WHERE (((S_Mat.ID_MatDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Материала БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "5.2.1 Материал и Нормы по Коду Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 70;
                        textBox1.Text = "Введите Код Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Материала" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB WHERE (((S_Mat.ID_Mat)=" + Convert.ToString(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "5.3.1 Материал и Нормы по Имени Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 71;
                        textBox1.Text = "Введите Имя Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Материала" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB WHERE (((S_Mat.Name_Mat) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "5.4.1 Материал и Нормы по Марке Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 72;
                        textBox1.Text = "Введите Марку Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Марку Материала" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB WHERE (((S_Mat.Brand_Mat)='" + Convert.ToString(textBox1.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Марку Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "5.5.1 Материал и Нормы по Типу Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[]
                            {
                               "Металлы","Метизы",
                                "Подшипники","РезТехИзд",
                                "ЭлектроОбор","Литье/ковка",
                                "Сварка","ГСМ",
                                "Лакокрасочные","ДревСтружМат",
                                "Сборочная","Прочее"
                        });
                        StateP = 73;
                        comboBox2.Text = "Выберите Тип Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Материала" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB WHERE (((S_Mat.Type_Mat)='" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "5.6.1 Материал и Нормы по Коду Нормы БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 74;
                        textBox1.Text = "Введите Код Нормы БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Нормы БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB WHERE (((S_NormM.ID_NormMDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Нормы БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "5.7.1 Материал и Нормы по Типу Нормы" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[]
                            {
                               "Изготовительная","Ремонтная","Прочее"
                        });
                        StateP = 75;
                        comboBox2.Text = "Выберите Тип Нормы";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Нормы" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB WHERE (((S_NormM.Type_NormM)='" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Нормы!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            if (StateF == 60) //+
            {
                if (comboBox1.SelectedItem == "6.1.1 Узел/Деталь и Материал по Коду Узла/Детали БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 76;
                        textBox1.Text = "Введите Код Узла/Детали БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Узла/Детали БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_Spec1 INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.ID_SpecDB1)= " + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Узла/Детали БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "6.2.1 Узел/Деталь и Материал по Коду Узла/Детали" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 77;
                        textBox1.Text = "Введите Код Узла/Детали";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Узла/Детали" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_Spec1 INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.ID_Spec1)= " + Convert.ToString(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "6.3.1 Узел/Деталь и Материал по Имени Узла/Детали" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 78;
                        textBox1.Text = "Введите Имя Узла/Детали";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Узла/Детали" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_Spec1 INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.Name_Spec1) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "6.4.1 Узел/Деталь и Материал по Типу Узла/Детали" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[] { "Узел", "Деталь", "Стандартное Изделие", "Другое" });
                        StateP = 79;
                        comboBox2.Text = "Выберите Тип Узла/Детали";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Узла/Детали" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_Spec1 INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.Type_Spec1)= '" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "6.5.1 Узел/Деталь и Материал по Коду Материала БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 80;
                        textBox1.Text = "Введите Код Материала БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Материала БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_Spec1 INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.ID_MatDB)= " + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Материала БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "6.6.1 Узел/Деталь и Материал по Коду Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 81;
                        textBox1.Text = "Введите Код Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Материала" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_Spec1 INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.ID_Mat)= " + Convert.ToString(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Материала БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "6.7.1 Узел/Деталь и Материал по Имени Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 82;
                        textBox1.Text = "Введите Имя Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Материала" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_Spec1 INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Name_Mat) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "6.8.1 Узел/Деталь и Материал по Марке Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 83;
                        textBox1.Text = "Введите Марку Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Марку Материала" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_Spec1 INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Brand_Mat)='" + Convert.ToString(textBox1.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Марку Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "6.9.1 Узел/Деталь и Материал по Типу Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[] 
                        {
                    "Металлы","Метизы",
                    "Подшипники","РезТехИзд",
                    "ЭлектроОбор","Литье/ковка",
                    "Сварка","ГСМ",
                    "Лакокрасочные","ДревСтружМат",
                    "Сборочная","Прочее"
                        });
                        StateP = 84;
                        comboBox2.Text = "Выберите Тип Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Материала" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_Spec1 INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Type_Mat)= '" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            if (StateF == 61) //++
            {
                if (comboBox1.SelectedItem == "7.1.1 Узел/Деталь, Материал, Норма по Коду Узла/Детали БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 85;
                        textBox1.Text = "Введите Код Узла/Детали БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Узла/Детали БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.ID_SpecDB1)= " + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Узла/Детали БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "7.2.1 Узел/Деталь, Материал, Норма по Коду Узла/Детали" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 86;
                        textBox1.Text = "Введите Код Узла/Детали";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Узла/Детали" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.ID_Spec1)= " + Convert.ToString(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "7.3.1 Узел/Деталь, Материал, Норма по Имени Узла/Детали" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 87;
                        textBox1.Text = "Введите Имя Узла/Детали";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Узла/Детали" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.Name_Spec1) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "7.4.1 Узел/Деталь, Материал, Норма по Типу Узла/Детали" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[] { "Узел", "Деталь", "Стандартное Изделие", "Другое" });
                        StateP = 88;
                        comboBox2.Text = "Выберите Тип Узла/Детали";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Узла/Детали" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.Type_Spec1)= '" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "7.5.1 Узел/Деталь, Материал, Норма по Коду Материала БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 89;
                        textBox1.Text = "Введите Код Материала БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Материала БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.ID_MatDB)= " + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Материала БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "7.6.1 Узел/Деталь, Материал, Норма по Коду Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 90;
                        textBox1.Text = "Введите Код Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Материала" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.ID_Mat)= " + Convert.ToString(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "7.7.1 Узел/Деталь, Материал, Норма по Имени Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 91;
                        textBox1.Text = "Введите Имя Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Материала" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Name_Mat) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "7.8.1 Узел/Деталь, Материал, Норма по Марке Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 92;
                        textBox1.Text = "Введите Марку Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Марку Материала" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Brand_Mat)= '" + Convert.ToString(textBox1.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Марку Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "7.9.1 Узел/Деталь, Материал, Норма по Типу Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[] {
                    "Металлы","Метизы",
                    "Подшипники","РезТехИзд",
                    "ЭлектроОбор","Литье/ковка",
                    "Сварка","ГСМ",
                    "Лакокрасочные","ДревСтружМат",
                    "Сборочная","Прочее"
                        });
                        StateP = 93;
                        comboBox2.Text = "Выберите Тип Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Материала" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Type_Mat)= '" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "7.10.1 Узел/Деталь, Материал, Норма по Коду Нормы БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 94;
                        textBox1.Text = "Введите Код Нормы БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Нормы БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_NormM.ID_NormMDB)= " + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Нормы БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "7.11.1 Узел/Деталь, Материал, Норма по Типу Нормы" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[]
                            {
                               "Изготовительная",
                                "Ремонтная",
                                "Прочее"
                        });
                        StateP = 95;
                        comboBox2.Text = "Выберите Тип Нормы";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Нормы" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_NormM.Type_NormM)= '" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Нормы!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            if (StateF == 62) //++
            {
                if (comboBox1.SelectedItem == "8.1.1 Изделие, Узел/Деталь, Материал, Норма по Коду Изделия БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 96;
                        textBox1.Text = "Введите Код Изделия БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Изделия БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.ID_SpecDB0)= " + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Изделия БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "8.2.1 Изделие, Узел/Деталь, Материал, Норма по Коду Изделия" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 97;
                        textBox1.Text = "Введите Код Изделия";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Изделия" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.ID_Spec0)= " + Convert.ToString(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Изделия!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "8.3.1 Изделие, Узел/Деталь, Материал, Норма по Имени Изделия" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 98;
                        textBox1.Text = "Введите Имя Изделия";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Изделия" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.Name_Spec0) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Изделия!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "8.4.1 Изделие, Узел/Деталь, Материал, Норма по Типу Изделия" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[] { "Изделие", "Узел", "Деталь", "Стандартное Изделие", "Другое" });
                        StateP = 99;
                        comboBox2.Text = "Выберите Тип Изделия";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Изделия" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.Type_Spec0)= '" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Изделия!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "8.5.1 Изделие, Узел/Деталь, Материал, Норма по Коду Узла/Детали БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 100;
                        textBox1.Text = "Введите Код Узла/Детали БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Узла/Детали БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.ID_SpecDB1)=" + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Узла/Детали БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "8.6.1 Изделие, Узел/Деталь, Материал, Норма по Коду Узла/Детали" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 101;
                        textBox1.Text = "Введите Код Узла/Детали";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Узла/Детали" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.ID_Spec1) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "8.7.1 Изделие, Узел/Деталь, Материал, Норма по Имени Узла/Детали" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 102;
                        textBox1.Text = "Введите Имя Узла/Детали";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Узла/Детали" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.Name_Spec1) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "8.8.1 Изделие, Узел/Деталь, Материал, Норма по Типу Узла/Детали" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[] { "Узел", "Деталь", "Стандартное Изделие", "Другое" });
                        StateP = 103;
                        comboBox2.Text = "Выберите Тип Узла/Детали";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Узла/Детали" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.Type_Spec1)= '" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "8.9.1 Изделие, Узел/Деталь, Материал, Норма по Коду Материала БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 104;
                        textBox1.Text = "Введите Код Материла БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Материла БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.ID_MatDB)= " + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Материла БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "8.10.1 Изделие, Узел/Деталь, Материал, Норма по Коду Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 105;
                        textBox1.Text = "Введите Код Материла";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Материла" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.ID_Mat)= " + Convert.ToString(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Материла!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "8.11.1 Изделие, Узел/Деталь, Материал, Норма по Имени Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 106;
                        textBox1.Text = "Введите Имя Материла";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Материла" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Name_Mat) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Материла!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "8.12.1 Изделие, Узел/Деталь, Материал, Норма по Марке Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 107;
                        textBox1.Text = "Введите Марку Материла";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Марку Материла" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Brand_Mat)= '" + Convert.ToString(textBox1.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Марку Материла!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "8.13.1 Изделие, Узел/Деталь, Материал, Норма по Типу Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[] {
                    "Металлы",
                    "Метизы",
                    "Подшипники",
                    "РезТехИзд",
                    "ЭлектроОбор",
                    "Литье/ковка",
                    "Сварка",
                    "ГСМ",
                    "Лакокрасочные",
                    "ДревСтружМат",
                    "Сборочная",
                    "Прочее"});
                        StateP = 108;
                        comboBox2.Text = "Выберите Тип Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Материала" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Type_Mat)= '" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "8.14.1 Изделие, Узел/Деталь, Материал, Норма по Коду Нормы БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 109;
                        textBox1.Text = "Введите Код Нормы БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Нормы БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_NormM.ID_NormMDB)= " + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Нормы БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "8.15.1 Изделие, Узел/Деталь, Материал, Норма по Типу Нормы" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[]
                            {
                               "Изготовительная",
                                "Ремонтная",
                                "Прочее"
                        });
                        StateP = 110;
                        comboBox2.Text = "Выберите Тип Нормы";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Нормы" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_NormM.Type_NormM)= '" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Нормы!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            if (StateF == 63) //++
            {
                if (comboBox1.SelectedItem == "9.1.1 Ведомость по Коду Узла/Детали БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 111;
                        textBox1.Text = "Введите Код Узла/Детали БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Узла/Детали БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_Spec1.ID_SpecDB1)= " + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Узла/Детали БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "9.2.1 Ведомость по Коду Узла/Детали" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 112;
                        textBox1.Text = "Введите Код Узла/Детали";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Узла/Детали" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_Spec1.ID_Spec1)= " + Convert.ToString(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "9.3.1 Ведомость по Имени Узла/Детали" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 113;
                        textBox1.Text = "Введите Имя Узла/Детали";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Узла/Детали" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_Spec1.Name_Spec1) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "9.4.1 Ведомость по Типу Узла/Детали" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[] { "Узел", "Деталь", "Стандартное Изделие", "Другое" });
                        StateP = 114;
                        comboBox2.Text = "Выберите Тип Узла/Детали";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Узла/Детали" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_Spec1.Type_Spec1)= '" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "9.5.1 Ведомость по Коду Материала БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 115;
                        textBox1.Text = "Введите Код Материала БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Материала БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_Mat.ID_MatDB)= " + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Материала БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "9.6.1 Ведомость по Коду Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 116;
                        textBox1.Text = "Введите Код Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Материала" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_Mat.ID_Mat)= " + Convert.ToString(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "9.7.1 Ведомость по Имени Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 117;
                        textBox1.Text = "Введите Имя Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Материала" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_Mat.Name_Mat) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "9.8.1 Ведомость по Марке Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 118;
                        textBox1.Text = "Введите Марку Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Марку Материала" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_Mat.Brand_Mat)= '" + Convert.ToString(textBox1.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Марку Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "9.9.1 Ведомость по Типу Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[] {
                    "Металлы","Метизы",
                    "Подшипники","РезТехИзд",
                    "ЭлектроОбор","Литье/ковка",
                    "Сварка","ГСМ",
                    "Лакокрасочные","ДревСтружМат",
                    "Сборочная","Прочее"
                        });
                        StateP = 119;
                        comboBox2.Text = "Выберите Тип Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Материала" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_Mat.Type_Mat)= '" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "9.10.1 Ведомость по Коду Нормы БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 120;
                        textBox1.Text = "Введите Код Нормы БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Нормы БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_NormM.ID_NormMDB)= " + Convert.ToInt32(textBox1.Text) + "))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Нормы БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "9.11.1 Ведомость по Типу Нормы" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[]
                            {
                               "Изготовительная",
                                "Ремонтная",
                                "Прочее"
                        });
                        StateP = 121;
                        comboBox2.Text = "Выберите Тип Нормы";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Нормы" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_NormM.Type_NormM)= '" + Convert.ToString(comboBox2.Text) + "'))";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Нормы!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            if (StateF == 64)
            {
                if (comboBox1.SelectedItem == "10.1.1 Ведомость по Коду Строки Перечня БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 122;
                        textBox1.Text = "Введите Код Строки Перечня БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Строки Перечня БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1
WHERE (((S_Items.ID_ItemDB)=" + Convert.ToInt32(textBox1.Text) + ")) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Строки Перечня БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "10.2.1 Ведомость по Коду Заказа БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 123;
                        textBox1.Text = "Введите Код Заказа БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Заказа БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1
WHERE (((S_Items.ID_OrderDB)=" + Convert.ToInt32(textBox1.Text) + ")) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Заказа БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "10.3.1 Ведомость по Имени Строки Перечня" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 124;
                        textBox1.Text = "Введите Имя Строки Перечня";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Строки Перечня" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1
WHERE (((S_Items.Name_Item) LIKE'%" + Convert.ToString(textBox1.Text) + "%')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Строки Перечня!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "10.4.1 Ведомость по Коду Изделия БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 125;
                        textBox1.Text = "Введите Код Изделия БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Изделия БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1
WHERE (((S_Spec0.ID_SpecDB0)=" + Convert.ToInt32(textBox1.Text) + ")) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Изделия БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "10.5.1 Ведомость по Коду Изделия" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 126;
                        textBox1.Text = "Введите Код Изделия";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Изделия" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1
WHERE (((S_Spec0.ID_Spec0)=" + Convert.ToString(textBox1.Text) + ")) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Изделия!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "10.6.1 Ведомость по Имени Изделия" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 127;
                        textBox1.Text = "Введите Имя Изделия";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Изделия" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1
WHERE (((S_Spec0.Name_Spec0) LIKE'%" + Convert.ToString(textBox1.Text) + "%')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Изделия!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "10.7.1 Ведомость по Типу Изделия" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[] { "Изделие", "Узел", "Деталь", "Стандартное Изделие", "Другое" });
                        StateP = 128;
                        comboBox2.Text = "Выберите Тип Изделия";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Изделия" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @""; a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1
WHERE (((S_Spec0.Type_Spec0)='" + Convert.ToString(comboBox2.Text) + "')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Изделия!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "10.8.1 Ведомость по Коду Узла/Детали БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 129;
                        textBox1.Text = "Введите Код Узла/Детали БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Узла/Детали БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1
WHERE (((S_Spec1.ID_SpecDB1)=" + Convert.ToInt32(textBox1.Text) + ")) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Узла/Детали БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "10.9.1 Ведомость по Коду Узла/Детали" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 130;
                        textBox1.Text = "Введите Код Узла/Детали";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Узла/Детали" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1
WHERE (((S_Spec1.ID_Spec1)=" + Convert.ToString(textBox1.Text) + ")) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "10.10.1 Ведомость по Имени Узла/Детали" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 131;
                        textBox1.Text = "Введите Имя Узла/Детали";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Узла/Детали" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1
WHERE (((S_Spec1.Name_Spec1) LIKE'%" + Convert.ToString(textBox1.Text) + "%')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "10.11.1 Ведомость по Типу Узла/Детали" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[] { "Узел", "Деталь", "Стандартное Изделие", "Другое" });
                        StateP = 132;
                        comboBox2.Text = "Выберите Тип Узла/Детали";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Узла/Детали" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1
WHERE (((S_Spec1.Type_Spec1)='" + Convert.ToString(comboBox2.Text) + "')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Узла/Детали!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "10.12.1 Ведомость по Коду Материала БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 133;
                        textBox1.Text = "Введите Код Материала БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Материала БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1
WHERE (((S_Mat.ID_MatDB)=" + Convert.ToInt32(textBox1.Text) + ")) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Материала БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "10.13.1 Ведомость по Коду Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 134;
                        textBox1.Text = "Введите Код Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Материала" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1
WHERE (((S_Mat.ID_Mat)=" + Convert.ToString(textBox1.Text) + ")) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "10.14.1 Ведомость по Имени Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 135;
                        textBox1.Text = "Введите Имя Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Имя Материала" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1
WHERE (((S_Mat.Name_Mat) LIKE'%" + Convert.ToString(textBox1.Text) + "%')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Имя Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "10.15.1 Ведомость по Марке Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 136;
                        textBox1.Text = "Введите Марку Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Марку Материала" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1
WHERE (((S_Mat.Brand_Mat)='" + Convert.ToString(textBox1.Text) + "')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Марку Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "10.16.1 Ведомость по Типу Материала" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[] {
                    "Металлы",
                    "Метизы",
                    "Подшипники",
                    "РезТехИзд",
                    "ЭлектроОбор",
                    "Литье/ковка",
                    "Сварка",
                    "ГСМ",
                    "Лакокрасочные",
                    "ДревСтружМат",
                    "Сборочная",
                    "Прочее"});
                        StateP = 137;
                        comboBox2.Text = "Выберите Тип Материала";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Материала" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1
WHERE (((S_Mat.Type_Mat)='" + Convert.ToString(comboBox2.Text) + "')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Материала!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "10.17.1 Ведомость по Коду Нормы БД" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible1();
                        StateP = 138;
                        textBox1.Text = "Введите Код Нормы БД";
                    }
                    if (Cap >= 2)
                    {
                        if (textBox1.Text != "Введите Код Нормы БД" && textBox1.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1
WHERE (((S_NormM.ID_NormMDB)=" + Convert.ToInt32(textBox1.Text) + ")) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите Код Нормы БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                if (comboBox1.SelectedItem == "10.18.1 Ведомость по Типу Нормы" && comboBox1.ForeColor == Color.Black)
                {
                    Cap++;
                    if (Cap == 1)
                    {
                        Visible2();
                        comboBox2.Items.AddRange(new string[]
                            {
                               "Изготовительная",
                                "Ремонтная",
                                "Прочее"
                        });
                        StateP = 139;
                        comboBox2.Text = "Выберите Тип Нормы";
                    }
                    if (Cap >= 2)
                    {
                        if (comboBox2.Text != "Выберите Тип Нормы" && comboBox2.ForeColor == Color.Black)
                        {
                            try
                            {
                                a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1
WHERE (((S_NormM.Type_NormM)='" + Convert.ToString(comboBox2.Text) + "')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                                this.Close();
                            }
                            catch (Exception g1)
                            {
                                Error(g1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите Тип Нормы!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }
            //=================================Удаление Материала Нормы ГОСТ+
            if (StateF == 68)
            {
                if (textBox1.Text != "Введите Код Материала БД для Удаления" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"DELETE S_Mat.ID_MatDB, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_Mat.Desc_Mat FROM S_Mat WHERE (((S_Mat.ID_MatDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Материала БД для Удаления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 69)
            {
                if (textBox1.Text != "Введите Код Нормы БД для Удаления" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"DELETE S_NormM.ID_NormMDB, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P, S_NormM.Desc_NormM FROM S_NormM WHERE (((S_NormM.ID_NormMDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Нормы БД для Удаления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 70)
            {
                if (textBox1.Text != "Введите Код ГОСТ БД для Удаления" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"DELETE S_GOST.ID_GOSTDB, S_GOST.Name_GOST, S_GOST.Desc_GOST FROM S_GOST WHERE (((S_GOST.ID_GOSTDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код ГОСТ БД для Удаления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //=============================Поиск по связям+
            if (StateF == 71)
            {
                if (textBox1.Text != "Введите Код Строки Связи БД" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT SNM1.* FROM SNM1 WHERE (((SNM1.ID)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Строки Связи БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 72)
            {
                if (textBox1.Text != "Введите Код Изделия БД" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT SNM1.* FROM SNM1 WHERE (((SNM1.ID_SpecDB0)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Изделия БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 73)
            {
                if (textBox1.Text != "Введите Код Узла/Детали БД" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT SNM1.* FROM SNM1 WHERE (((SNM1.ID_SpecDB1)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Узла/Детали БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 74)
            {
                if (textBox1.Text != "Введите Код Материала БД" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT SNM1.* FROM SNM1 WHERE (((SNM1.ID_MatDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Материала БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 75)
            {
                if (textBox1.Text != "Введите Код Нормы БД" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT SNM1.* FROM SNM1 WHERE (((SNM1.ID_NormMDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Нормы БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 76)
            {
                if (textBox1.Text != "Введите Код Перечня БД" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT SNM1.* FROM SNM1 WHERE (((SNM1.ID_ItemDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Перечня БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //===========================Удаление Связи
            if (StateF == 78)
            {
                if (textBox1.Text != "Введите Код Связи БД для Удаления" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"DELETE SNM1.ID, SNM1.ID_ItemDB, SNM1.ID_SpecDB0, SNM1.ID_SpecDB1, SNM1.ID_MatDB, SNM1.ID_NormMDB FROM SNM1 WHERE (((SNM1.ID)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Связи БД для Удаления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //===========================Поиск по Пользователю
            if (StateF == 79)
            {
                if (textBox1.Text != "Введите Код Пользователя БД" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT Users.* FROM Users WHERE (((Users.ID_UserDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Пользователя БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 80)
            {
                if (textBox1.Text != "Введите Логин Пользователя" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT Users.* FROM Users WHERE (((Users.N_User)LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Логин Пользователя!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 81)
            {
                if (comboBox1.Text != "Выберите Тип Пользователя" && comboBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT Users.* FROM Users WHERE (((Users.Type_User)='" + Convert.ToString(comboBox1.Text) + "'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Выберите Тип Пользователя!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //===========================Поиск по Логу
            if (StateF == 82)
            {
                if (textBox1.Text != "Введите Код Лога БД" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT Logs.* FROM Logs WHERE (((Logs.ID_LogDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Лога БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 83)
            {
                if (textBox1.Text != "Введите Дату Лога" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT Logs.* FROM Logs WHERE (((Logs.Date_Log)LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Дату Лога!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 84)
            {
                if (comboBox1.Text != "Выберите Тип Лога" && comboBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT Logs.* FROM Logs WHERE (((Logs.Desc_Log)='" + Convert.ToString(comboBox1.Text) + "'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Выберите Тип Лога!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 85)
            {
                if (textBox1.Text != "Введите Описание Лога" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"SELECT Logs.* FROM Logs WHERE (((Logs.Desc_Log)LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Описание Лога!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            //==========================Удаление ЛОГА Пользователя
            if (StateF == 87)
            {
                if (textBox1.Text != "Введите Код Пользователя БД для Удаления" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"DELETE Users.ID_UserDB, Users.N_User, Users.P_User, Users.Type_User FROM Users WHERE (((Users.ID_UserDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Пользователя БД для Удаления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (StateF == 88)
            {
                if (textBox1.Text != "Введите Код Лога БД для Удаления" && textBox1.Text != "")
                {
                    try
                    {
                        a = @"DELETE Logs.ID_LogDB, Logs.Date_Log, Logs.Type_Log, Logs.Desc_log FROM Logs WHERE (((Logs.ID_UserDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        this.Close();
                    }
                    catch (Exception g1)
                    {
                        Error(g1);
                    }
                }
                else
                {
                    MessageBox.Show("Введите Код Лога БД для Удаления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            #region


            //ПЕРЕПИСАТЬ ВСЕ ЧТО НИЖЕ
            //-----------------------------Админпанель
            //-----------------------------Пользователь
            /* if (StateF == 20)
             {
                 if (textBox1.Text != "Введите Код Строки Пользователя БД" && textBox1.Text != "")
                 {
                     try
                     {
                         a = @"SELECT Users.* FROM Users WHERE (((Users.ID_UserDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                         this.Close();
                     }
                     catch (Exception g1)
                     {
                         TypeEvent = "Ошибка";
                         DescEvent = "Ошибка при выполнении запроса к БД";
                         MessageBox.Show("Ошибка при выполнении запроса к БД. Обратитесь в поддержку " + Convert.ToString(g1), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         this.Close();
                     }
                 }
                 else
                 {
                     MessageBox.Show("Введите Код Строки Пользователя БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }
             }
             if (StateF == 21)
             {
                 if (textBox1.Text != "Введите Логин Пользователя" && textBox1.Text != "")
                 {
                     try
                     {
                         a = @"SELECT Users.* FROM Users WHERE (((Users.N_User) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                         this.Close();
                     }
                     catch (Exception g1)
                     {
                         TypeEvent = "Ошибка";
                         DescEvent = "Ошибка при выполнении запроса к БД";
                         MessageBox.Show("Ошибка при выполнении запроса к БД. Обратитесь в поддержку " + Convert.ToString(g1), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         this.Close();
                     }
                 }
                 else
                 {
                     MessageBox.Show("Введите Логин Пользователя!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }
             }
             if (StateF == 22)
             {
                 if (comboBox1.Text != "Выберите Тип Пользователя" && comboBox1.Text != "")
                 {
                     try
                     {
                         a = @"SELECT Users.* FROM Users WHERE (((Users.Type_User)='" + Convert.ToString(comboBox1.Text) + "'))";
                         this.Close();
                     }
                     catch (Exception g1)
                     {
                         TypeEvent = "Ошибка";
                         DescEvent = "Ошибка при выполнении запроса к БД";
                         MessageBox.Show("Ошибка при выполнении запроса к БД. Обратитесь в поддержку " + Convert.ToString(g1), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         this.Close();
                     }
                 }
                 else
                 {
                     MessageBox.Show("Выберите Тип Пользователя!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }
             }
             //---------------------------Логи
             if (StateF == 23)
             {
                 if (textBox1.Text != "Введите Код Строки События БД" && textBox1.Text != "")
                 {
                     try
                     {
                         a = @"SELECT Logs.* FROM Logs WHERE (((Logs.ID_LogDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                         this.Close();
                     }
                     catch (Exception g1)
                     {
                         TypeEvent = "Ошибка";
                         DescEvent = "Ошибка при выполнении запроса к БД";
                         MessageBox.Show("Ошибка при выполнении запроса к БД. Обратитесь в поддержку " + Convert.ToString(g1), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         this.Close();
                     }
                 }
                 else
                 {
                     MessageBox.Show("Введите Код Строки События БД!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }
             }
             if (StateF == 24)
             {
                 if (textBox1.Text != "Введите Дату в формате 01.01.2023" && textBox1.Text != "")
                 {
                     try
                     {
                         a = @"SELECT Logs.* FROM Logs WHERE (((Logs.Data_Log) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                         this.Close();
                     }
                     catch (Exception g1)
                     {
                         TypeEvent = "Ошибка";
                         DescEvent = "Ошибка при выполнении запроса к БД";
                         MessageBox.Show("Ошибка при выполнении запроса к БД. Обратитесь в поддержку " + Convert.ToString(g1), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         this.Close();
                     }
                 }
                 else
                 {
                     MessageBox.Show("Введите Дату в формате 01.01.2023!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }
             }
             if (StateF == 25)
             {
                 if (comboBox1.Text != "Выберите Тип События" && comboBox1.Text != "")
                 {
                     try
                     {
                         a = @"SELECT Logs.* FROM Logs WHERE (((Logs.Type_Log)='" + Convert.ToString(comboBox1.Text) + "'))";
                         this.Close();
                     }
                     catch (Exception g1)
                     {
                         TypeEvent = "Ошибка";
                         DescEvent = "Ошибка при выполнении запроса к БД";
                         MessageBox.Show("Ошибка при выполнении запроса к БД. Обратитесь в поддержку " + Convert.ToString(g1), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         this.Close();
                     }
                 }
                 else
                 {
                     MessageBox.Show("Выберите Тип События!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }
             }
             if (StateF == 26)
             {
                 if (textBox1.Text != "Введите Часть Описания События" && textBox1.Text != "")
                 {
                     try
                     {
                         a = @"SELECT Logs.* FROM Logs WHERE (((Logs.Desc_Log) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                         this.Close();
                     }
                     catch (Exception g1)
                     {
                         TypeEvent = "Ошибка";
                         DescEvent = "Ошибка при выполнении запроса к БД";
                         MessageBox.Show("Ошибка при выполнении запроса к БД. Обратитесь в поддержку " + Convert.ToString(g1), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         this.Close();
                     }
                 }
                 else
                 {
                     MessageBox.Show("Введите Часть Описания События!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }
             }
             //--------------------------------Удаление в АдминПанели
             //-----------------------------Пользователь
             if (StateF == 28)
             {
                 if (textBox1.Text != "Введите Код Пользователя БД для Удаления" && textBox1.Text != "")
                 {
                     try
                     {
                         a = @"DELETE Users.ID_UserDB, Users.N_User, Users.P_User, Users.Type_User FROM Users WHERE (((Users.ID_UserDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                         this.Close();
                     }
                     catch (Exception g1)
                     {
                         TypeEvent = "Ошибка";
                         DescEvent = "Ошибка при выполнении запроса к БД";
                         MessageBox.Show("Ошибка при выполнении запроса к БД. Обратитесь в поддержку " + Convert.ToString(g1), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         this.Close();
                     }
                 }
                 else
                 {
                     MessageBox.Show("Введите Код Пользователя БД для Удаления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }
             }
             if (StateF == 29)
             {
                 if (textBox1.Text != "Введите Логин Пользователя для Удаления" && textBox1.Text != "")
                 {
                     try
                     {
                         a = @"DELETE Users.ID_UserDB, Users.N_User, Users.P_User, Users.Type_User FROM Users WHERE (((Users.N_User) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                         this.Close();
                     }
                     catch (Exception g1)
                     {
                         TypeEvent = "Ошибка";
                         DescEvent = "Ошибка при выполнении запроса к БД";
                         MessageBox.Show("Ошибка при выполнении запроса к БД. Обратитесь в поддержку " + Convert.ToString(g1), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         this.Close();
                     }
                 }
                 else
                 {
                     MessageBox.Show("Введите Логин Пользователя для Удаления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }
             }
             //-------------------------------Логи
             if (StateF == 30)
             {
                 if (textBox1.Text != "Введите Код События БД для Удаления" && textBox1.Text != "")
                 {
                     try
                     {
                         a = @"DELETE Logs.ID_LogDB, Logs.Date_Log, Logs.Type_Log, Logs.Desc_Log FROM Logs WHERE (((Logs.ID_LogDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                         this.Close();
                     }
                     catch (Exception g1)
                     {
                         TypeEvent = "Ошибка";
                         DescEvent = "Ошибка при выполнении запроса к БД";
                         MessageBox.Show("Ошибка при выполнении запроса к БД. Обратитесь в поддержку " + Convert.ToString(g1), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         this.Close();
                     }
                 }
                 else
                 {
                     MessageBox.Show("Введите Код События БД для Удаления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }
             }
             if (StateF == 31)
             {
                 if (textBox1.Text != "Введите Дату События для Удаления" && textBox1.Text != "")
                 {
                     try
                     {
                         a = @"DELETE Logs.ID_LogDB, Logs.Date_Log, Logs.Type_Log, Logs.Desc_Log FROM Logs WHERE (((Logs.Date_Log)='" + Convert.ToString(textBox1.Text) + "'))";
                         this.Close();
                     }
                     catch (Exception g1)
                     {
                         TypeEvent = "Ошибка";
                         DescEvent = "Ошибка при выполнении запроса к БД";
                         MessageBox.Show("Ошибка при выполнении запроса к БД. Обратитесь в поддержку " + Convert.ToString(g1), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         this.Close();
                     }
                 }
                 else
                 {
                     MessageBox.Show("Введите Дату События для Удаления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }
             }
             if (StateF == 32)
             {
                 if (comboBox1.Text != "Выберите Тип События для Удаления" && comboBox1.Text != "")
                 {
                     try
                     {
                         a = @"DELETE Logs.ID_LogDB, Logs.Date_Log, Logs.Type_Log, Logs.Desc_Log FROM Logs WHERE (((Logs.Type_Log) LIKE'%" + Convert.ToString(comboBox1.Text) + "%'))";
                         this.Close();
                     }
                     catch (Exception g1)
                     {
                         TypeEvent = "Ошибка";
                         DescEvent = "Ошибка при выполнении запроса к БД";
                         MessageBox.Show("Ошибка при выполнении запроса к БД. Обратитесь в поддержку " + Convert.ToString(g1), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         this.Close();
                     }
                 }
                 else
                 {
                     MessageBox.Show("Выберите Тип События для Удаления!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                 }
             }*/
            #endregion
        }
        private void button2_Click(object sender, EventArgs e) //Вызов печати (Запросы)
        {
            //------------------------------------Заказчик+++++++++++++++++++++++++++++++++++++
            if (StateP >= 0 && StateP <= 3)
            {
                if (textBox1.Visible == true)
                {
                    if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 0)
                        {
                            a = @"SELECT S_Cust.* FROM S_Cust WHERE (((S_Cust.ID_CustDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 1)
                        {
                            a = @"SELECT S_Cust.* FROM S_Cust WHERE (((S_Cust.ID_Cust)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 2)
                        {
                            a = @"SELECT S_Cust.* FROM S_Cust WHERE (((S_Cust.Name_Cust) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                    }
                }
                if (comboBox1.Visible == true)
                {
                    if (comboBox1.Text == "" || comboBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 3)
                        {
                            a = @"SELECT S_Cust.* FROM S_Cust WHERE (((S_Cust.Type_Cust)='" + Convert.ToString(comboBox1.Text) + "'))";
                        }
                    }
                }
            }
            //------------------------------------Заказ++++++++++++++++++++++++++++++++++++++++++
            if (StateP >= 4 && StateP <= 10)
            {
                if (textBox1.Visible == true && textBox2.Visible == false)
                {
                    if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 4)
                        {
                            a = @"SELECT S_Order.* FROM S_Order WHERE (((S_Order.ID_OrderDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 5)
                        {
                            a = @"SELECT S_Order.* FROM S_Order WHERE (((S_Order.ID_CustDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 7)
                        {
                            a = @"SELECT S_Order.* FROM S_Order WHERE (((S_Order.ID_Order)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 8)
                        {
                            a = @"SELECT S_Order.* FROM S_Order WHERE (((S_Order.Name_Order) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 10)
                        {
                            a = @"SELECT S_Order.* FROM S_Order WHERE (((S_Order.Date_Order)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                    }
                }
                if (textBox1.Visible == true && textBox2.Visible == true)
                {
                    if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray || textBox2.Text == "" || textBox2.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 6)
                        {
                            a = @"SELECT S_Order.* FROM S_Order WHERE (((S_Order.ID_CustDB)=" + Convert.ToInt32(textBox1.Text) + ") AND ((S_Order.ID_OrderDB)=" + Convert.ToInt32(textBox2.Text) + "));";
                        }
                    }
                }
                if (comboBox1.Visible == true)
                {
                    if (comboBox1.Text == "" || comboBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 9)
                        {
                            a = @"SELECT S_Order.* FROM S_Order WHERE (((S_Order.Type_Order)='" + Convert.ToString(comboBox1.Text) + "'))";
                        }
                    }
                }
            }
            //------------------------------------Перечень++++++++++++++++++++++++++++++++++++++++++++++++
            if (StateP >= 11 && StateP <= 13)
            {
                if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                {
                    MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (StateP == 11)
                    {
                        a = @"SELECT S_Items.* FROM S_Items WHERE (((S_Items.ID_ItemDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                    }
                    if (StateP == 12)
                    {
                        a = @"SELECT S_Items.* FROM S_Items WHERE (((S_Items.ID_OrderDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                    }
                    if (StateP == 13)
                    {
                        a = @"SELECT S_Items.* FROM S_Items WHERE (((S_Items.Name_Item) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                    }
                }
            } 
            //------------------------------------Заказчик и заказ+++++++++++++++
            if (StateP >= 14 && StateP <= 22)
            {
                if (textBox1.Visible == true)
                {
                    if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 14)
                        {
                            a = @"SELECT S_Cust.Name_Cust, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Cust INNER JOIN S_Order ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Cust.ID_CustDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 15)
                        {
                            a = @"SELECT S_Cust.Name_Cust, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Cust INNER JOIN S_Order ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.ID_OrderDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 16)
                        {
                            a = @"SELECT S_Cust.Name_Cust, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Cust INNER JOIN S_Order ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Cust.ID_Cust)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 17)
                        {
                            a = @"SELECT S_Cust.Name_Cust, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Cust INNER JOIN S_Order ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.ID_Order)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 18)
                        {
                            a = @"SELECT S_Cust.Name_Cust, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Cust INNER JOIN S_Order ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Cust.Name_Cust) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 20)
                        {
                            a = @"SELECT S_Cust.Name_Cust, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Cust INNER JOIN S_Order ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.Name_Order) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 22)
                        {
                            a = @"SELECT S_Cust.Name_Cust, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Cust INNER JOIN S_Order ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.Date_Order)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                    }
                }
                if (comboBox2.Visible == true)
                {
                    if (comboBox2.Text == "" || comboBox2.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 19)
                        {
                            a = @"SELECT S_Cust.Name_Cust, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Cust INNER JOIN S_Order ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Cust.Type_Cust)='" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                        if (StateP == 21)
                        {
                            a = @"SELECT S_Cust.Name_Cust, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Order.Desc_Order FROM S_Cust INNER JOIN S_Order ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.Type_Order)='" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                    }
                }
            }
            //------------------------------------Заказ и перечень++++++++++++++++
            if (StateP >= 23 && StateP <= 30)
            {
                if (textBox1.Visible == true)
                {
                    if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 23)
                        {
                            a = @"SELECT S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB WHERE (((S_Order.ID_OrderDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 24)
                        {
                            a = @"SELECT S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB WHERE (((S_Order.ID_CustDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 25)
                        {
                            a = @"SELECT S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB WHERE (((S_Order.ID_Order)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 26)
                        {
                            a = @"SELECT S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB WHERE (((S_Order.Name_Order) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 28)
                        {
                            a = @"SELECT S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB WHERE (((S_Order.Date_Order)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 29)
                        {
                            a = @"SELECT S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB WHERE (((S_Items.ID_ItemDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 30)
                        {
                            a = @"SELECT S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB WHERE (((S_Items.Name_Item) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                    }
                }
                if (comboBox2.Visible == true)
                {
                    if (comboBox2.Text == "" || comboBox2.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 27)
                        {
                            a = @"SELECT S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.Name_Item, S_Items.Count_Item FROM S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB WHERE (((S_Order.Type_Order)='" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                    }
                }
            }
            //------------------------------------Заказ Заказчик перечень+++++++++++++++++
            if (StateP >= 31 && StateP <= 41)
            {
                if (textBox1.Visible == true)
                {
                    if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 31)
                        {
                            a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.ID_ItemDB, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Cust.ID_CustDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 32)
                        {
                            a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.ID_ItemDB, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Cust.ID_Cust)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 33)
                        {
                            a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.ID_ItemDB, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Cust.Name_Cust) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 35)
                        {
                            a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.ID_ItemDB, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.ID_OrderDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 36)
                        {
                            a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.ID_ItemDB, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.ID_Order)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 37)
                        {
                            a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.ID_ItemDB, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.Name_Order) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 39)
                        {
                            a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.ID_ItemDB, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.Date_Order)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 40)
                        {
                            a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.ID_ItemDB, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Items.ID_ItemDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 41)
                        {
                            a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.ID_ItemDB, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Items.Name_Item) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                    }
                }
                if (comboBox2.Visible == true)
                {
                    if (comboBox2.Text == "" || comboBox2.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 34)
                        {
                            a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.ID_ItemDB, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Cust.Type_Cust)='" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                        if (StateP == 38)
                        {
                            a = @"SELECT S_Cust.ID_Cust, S_Cust.Name_Cust, S_Order.ID_Order, S_Order.Name_Order, S_Order.Type_Order, S_Order.Date_Order, S_Items.ID_ItemDB, S_Items.Name_Item, S_Items.Count_Item FROM S_Cust INNER JOIN (S_Order INNER JOIN S_Items ON S_Order.ID_OrderDB = S_Items.ID_OrderDB) ON S_Cust.ID_CustDB = S_Order.ID_CustDB WHERE (((S_Order.Type_Order)='" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                    }
                }
            }
            //-------------------------------------Изделие Узел Деталь+++++++++++++++++++
            if (StateP >= 42 && StateP <= 51)
            {
                if (textBox1.Visible == true)
                {
                    if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 42)
                        {
                            a = @"SELECT S_Spec0.* FROM S_Spec0 WHERE (((S_Spec0.ID_SpecDB0)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 43)
                        {
                            a = @"SELECT S_Spec0.* FROM S_Spec0 WHERE (((S_Spec0.ID_Spec0)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 44)
                        {
                            a = @"SELECT S_Spec0.* FROM S_Spec0 WHERE (((S_Spec0.Name_Spec0) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 46)
                        {
                            a = @"SELECT S_Spec1.* FROM S_Spec1 WHERE (((S_Spec1.ID_SpecDB1)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 47)
                        {
                            a = @"SELECT S_Spec1.* FROM S_Spec1 WHERE (((S_Spec1.ID_Spec1)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 48)
                        {
                            a = @"SELECT S_Spec1.* FROM S_Spec1 WHERE (((S_Spec1.PNV_Spec1)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 49)
                        {
                            a = @"SELECT S_Spec1.* FROM S_Spec1 WHERE (((S_Spec1.PN_Spec1)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 50)
                        {
                            a = @"SELECT S_Spec1.* FROM S_Spec1 WHERE (((S_Spec1.Name_Spec1) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                    }
                }
                if (comboBox1.Visible == true)
                {
                    if (comboBox1.Text == "" || comboBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 45)
                        {
                            a = @"SELECT S_Spec0.* FROM S_Spec0 WHERE (((S_Spec0.Type_Spec0)='" + Convert.ToString(comboBox1.Text) + "'))";
                        }
                        if (StateP == 51)
                        {
                            a = @"SELECT S_Spec1.* FROM S_Spec1 WHERE (((S_Spec1.Type_Spec1)='" + Convert.ToString(comboBox1.Text) + "'))";
                        }
                    }
                }
            }
            //-------------------------------------ПОИСК ПРО ИЗДЕЛИЕ УЗЕЛ ДЕТАЛЬ++++++++++++++++++++++++
            if (StateP >= 52 && StateP <= 59)
            {
                if (textBox1.Visible == true)
                {
                    if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 52)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.GOST_Spec0, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN SNM1 ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.ID_SpecDB0)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 53)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.GOST_Spec0, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN SNM1 ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.ID_Spec0)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 54)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.GOST_Spec0, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN SNM1 ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.Name_Spec0) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 56)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.GOST_Spec0, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN SNM1 ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.ID_SpecDB1)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 57)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.GOST_Spec0, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN SNM1 ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.ID_Spec1)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 58)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.GOST_Spec0, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN SNM1 ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.Name_Spec1) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                    }
                }
                if (comboBox2.Visible == true)
                {
                    if (comboBox2.Text == "" || comboBox2.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 55)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.GOST_Spec0, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN SNM1 ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.Type_Spec0)='" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                        if (StateP == 59)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.GOST_Spec0, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN SNM1 ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.Type_Spec1)='" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                    }
                }
            }
            //---------------------------------------Материалы Нормы ГОСТ++++++++++++++++++++++++
            if (StateP >= 60 && StateP <= 64)
            {
                if (textBox1.Visible == true)
                {
                    if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 60)
                        {
                            a = @"SELECT S_Mat.* FROM S_Mat WHERE (((S_Mat.ID_MatDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 61)
                        {
                            a = @"SELECT S_Mat.* FROM S_Mat WHERE (((S_Mat.ID_Mat)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 62)
                        {
                            a = @"SELECT S_Mat.* FROM S_Mat WHERE (((S_Mat.ID_MatDB)LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 63)
                        {
                            a = @"SELECT S_Mat.* FROM S_Mat WHERE (((S_Mat.ID_MatDB)LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                    }
                }
                if (comboBox1.Visible == true)
                {
                    if (comboBox1.Text == "" || comboBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 64)
                        {
                            a = @"SELECT S_Mat.* FROM S_Mat WHERE (((S_Mat.Type_Mat)='" + Convert.ToString(comboBox1.Text) + "'))";
                        }
                    }
                }
            }
            if (StateP >= 65 && StateP <= 66)
            {
                if (textBox1.Visible == true)
                {
                    if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 65)
                        {
                            a = @"SELECT S_NormM.* FROM S_NormM WHERE (((S_NormM.ID_NormMDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                    }
                }
                if (comboBox1.Visible == true)
                {
                    if (comboBox1.Text == "" || comboBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 66)
                        {
                            a = @"SELECT S_NormM.* FROM S_NormM WHERE (((S_NormM.Type_NormM)='" + Convert.ToString(comboBox1.Text) + "'))";
                        }
                    }
                }
            }
            if (StateP >= 67 && StateP <= 68)
            {
                if (textBox1.Visible == true)
                {
                    if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 67)
                        {
                            a = @"SELECT S_GOST.* FROM S_GOST WHERE (((S_GOST.ID_GOSTDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 68)
                        {
                            a = @"SELECT S_GOST.* FROM S_GOST WHERE (((S_GOST.Name_GOST)LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                    }
                }
            }
            //---------------------------------------ПОИСК ПРО Материалы нормы ГОСТ+++++++++++++++++++++++
            if (StateP >= 69 && StateP <= 75)
            {
                if (textBox1.Visible == true)
                {
                    if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 69)
                        {
                            a = @"SELECT S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB WHERE (((S_Mat.ID_MatDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 70)
                        { 
                            a = @"SELECT S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB WHERE (((S_Mat.ID_Mat)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 71)
                        {
                            a = @"SELECT S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB WHERE (((S_Mat.Name_Mat) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 72)
                        {
                            a = @"SELECT S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB WHERE (((S_Mat.Brand_Mat)='" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 74)
                        {
                            a = @"SELECT S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB WHERE (((S_NormM.ID_NormMDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                    }
                }
                if (comboBox2.Visible == true)
                {
                    if (comboBox2.Text == "" || comboBox2.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 73)
                        {
                            a = @"SELECT S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB WHERE (((S_Mat.Type_Mat)='" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                        if (StateP == 75)
                        {
                            a = @"SELECT S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB WHERE (((S_NormM.Type_NormM)='" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                    }
                }
            }
            if (StateP >= 76 && StateP <= 84)
            {
                if (textBox1.Visible == true)
                {
                    if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 76)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_Spec1 INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.ID_SpecDB1)= " + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 77)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_Spec1 INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.ID_Spec1)= '" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 78)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_Spec1 INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.Name_Spec1) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 80)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_Spec1 INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.ID_MatDB)= " + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 81)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_Spec1 INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.ID_Mat)= '" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 82)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_Spec1 INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Name_Mat) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 83)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_Spec1 INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Brand_Mat)= '" + Convert.ToString(textBox1.Text) + "'))";
                        }
                    }
                }
                if (comboBox2.Visible == true)
                {
                    if (comboBox2.Text == "" || comboBox2.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 79)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_Spec1 INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.Type_Spec1)= '" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                        if (StateP == 84)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat FROM S_Spec1 INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Type_Mat)= '" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                    }
                }
            }
            if (StateP >= 85 && StateP <= 95)
            {
                if (textBox1.Visible == true)
                {
                    if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 85)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.ID_SpecDB1)= " + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 86)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.ID_Spec1)= '" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 87)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.Name_Spec1) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 89)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.ID_MatDB)= " + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 90)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.ID_Mat)= '" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 91)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Name_Mat) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 92)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Brand_Mat)= '" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 94)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_NormM.ID_NormMDB)= " + Convert.ToInt32(textBox1.Text) + "))";
                        }
                    }
                }
                if (comboBox2.Visible == true)
                {
                    if (comboBox2.Text == "" || comboBox2.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 88)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.Type_Spec1)= '" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                        if (StateP == 93)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Type_Mat)= '" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                        if (StateP == 95)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_NormM.Type_NormM)= '" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                    }
                }
            }
            if (StateP >= 96 && StateP <= 110) //++
            {
                if (textBox1.Visible == true)
                {
                    if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 96)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM (S_Spec1 INNER JOIN (S_Spec0 INNER JOIN S01 ON S_Spec0.ID_SpecDB0 = S01.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = S01.ID_SpecDB1) INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.ID_SpecDB0)= " + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 97)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM (S_Spec1 INNER JOIN (S_Spec0 INNER JOIN S01 ON S_Spec0.ID_SpecDB0 = S01.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = S01.ID_SpecDB1) INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.ID_Spec0)= '" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 98)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM (S_Spec1 INNER JOIN (S_Spec0 INNER JOIN S01 ON S_Spec0.ID_SpecDB0 = S01.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = S01.ID_SpecDB1) INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.Name_Spec0) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 100)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM (S_Spec1 INNER JOIN (S_Spec0 INNER JOIN S01 ON S_Spec0.ID_SpecDB0 = S01.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = S01.ID_SpecDB1) INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.ID_SpecDB1)=" + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 101)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM (S_Spec1 INNER JOIN (S_Spec0 INNER JOIN S01 ON S_Spec0.ID_SpecDB0 = S01.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = S01.ID_SpecDB1) INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.ID_Spec1) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 102)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM (S_Spec1 INNER JOIN (S_Spec0 INNER JOIN S01 ON S_Spec0.ID_SpecDB0 = S01.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = S01.ID_SpecDB1) INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.Name_Spec1) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 104)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM (S_Spec1 INNER JOIN (S_Spec0 INNER JOIN S01 ON S_Spec0.ID_SpecDB0 = S01.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = S01.ID_SpecDB1) INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.ID_MatDB)= " + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 105)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM (S_Spec1 INNER JOIN (S_Spec0 INNER JOIN S01 ON S_Spec0.ID_SpecDB0 = S01.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = S01.ID_SpecDB1) INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.ID_Mat)= '" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 106)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM (S_Spec1 INNER JOIN (S_Spec0 INNER JOIN S01 ON S_Spec0.ID_SpecDB0 = S01.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = S01.ID_SpecDB1) INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Name_Mat) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 107)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM (S_Spec1 INNER JOIN (S_Spec0 INNER JOIN S01 ON S_Spec0.ID_SpecDB0 = S01.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = S01.ID_SpecDB1) INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Brand_Mat)= '" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 109)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM (S_Spec1 INNER JOIN (S_Spec0 INNER JOIN S01 ON S_Spec0.ID_SpecDB0 = S01.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = S01.ID_SpecDB1) INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_NormM.ID_NormMDB)= " + Convert.ToInt32(textBox1.Text) + "))";
                        }
                    }
                }
                if (comboBox2.Visible == true)
                {
                    if (comboBox2.Text == "" || comboBox2.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 99)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM (S_Spec1 INNER JOIN (S_Spec0 INNER JOIN S01 ON S_Spec0.ID_SpecDB0 = S01.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = S01.ID_SpecDB1) INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.Type_Spec0)= '" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                        if (StateP == 103)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM (S_Spec1 INNER JOIN (S_Spec0 INNER JOIN S01 ON S_Spec0.ID_SpecDB0 = S01.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = S01.ID_SpecDB1) INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.Type_Spec1)= '" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                        if (StateP == 108)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM (S_Spec1 INNER JOIN (S_Spec0 INNER JOIN S01 ON S_Spec0.ID_SpecDB0 = S01.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = S01.ID_SpecDB1) INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Type_Mat)= '" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                        if (StateP == 110)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec0.Name_Spec0, S_Spec0.Type_Spec0, S_Spec0.GOST_Spec0, S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Spec1.Type_Spec1, S_Spec1.GOST_Spec1, S_Spec1.Num_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, S_NormM.GOST_Norm, S_NormM.Num_M1, S_NormM.Num_M2, S_NormM.Num_P, S_NormM.Unit_M1M2P FROM (S_Spec1 INNER JOIN (S_Spec0 INNER JOIN S01 ON S_Spec0.ID_SpecDB0 = S01.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = S01.ID_SpecDB1) INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN SNM1 ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_NormM.Type_NormM)= '" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                    }
                }
            }
            if (StateP >= 111 && StateP <= 121)
            {
                if (textBox1.Visible == true)
                {
                    if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 111)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_Spec1.ID_SpecDB1)= " + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 112)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_Spec1.ID_Spec1)= '" + Convert.ToString(textBox1.Text) + "))";
                        }
                        if (StateP == 113)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_Spec1.Name_Spec1) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 115)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_Mat.ID_MatDB)= " + Convert.ToInt32(textBox1.Text) + "))";
                        }
                        if (StateP == 116)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_Mat.ID_Mat)= '" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 117)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_Mat.Name_Mat) LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                        }
                        if (StateP == 118)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_Mat.Brand_Mat)= '" + Convert.ToString(textBox1.Text) + "'))";
                        }
                        if (StateP == 120)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_NormM.ID_NormMDB)= " + Convert.ToInt32(textBox1.Text) + "))";
                        }
                    }
                }
                if (comboBox2.Visible == true)
                {
                    if (comboBox2.Text == "" || comboBox2.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 114)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_Spec1.Type_Spec1)= '" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                        if (StateP == 119)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_Mat.Type_Mat)= '" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                        if (StateP == 121)
                        {
                            a = @"SELECT S_Spec1.ID_Spec1, S_Spec1.PNV_Spec1, S_Spec1.PN_Spec1, S_Spec1.Name_Spec1, S_Mat.ID_Mat, S_Mat.Name_Mat, S_Mat.GOST_Mat, S_Mat.Brand_Mat, S_Mat.Type_Mat, S_NormM.Type_NormM, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item] AS Num_M1, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item] AS Num_M2, [S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item] AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec0 INNER JOIN (S_Spec1 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0 WHERE (((S_NormM.Type_NormM)= '" + Convert.ToString(comboBox2.Text) + "'))";
                        }
                    }
                }
            }
            if (StateP >= 122 && StateP <= 139)
            {
                if (textBox1.Visible == true)
                {
                    if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 122)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Items.ID_ItemDB)=" + Convert.ToInt32(textBox1.Text) + ")) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                        }
                        if (StateP == 123)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Items.ID_OrderDB)=" + Convert.ToInt32(textBox1.Text) + ")) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                        }
                        if (StateP == 124)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Items.Name_Item) LIKE'%" + Convert.ToString(textBox1.Text) + "%')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                        }
                        if (StateP == 125)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.ID_SpecDB0)=" + Convert.ToInt32(textBox1.Text) + ")) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                        }
                        if (StateP == 126)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.ID_Spec0)='" + Convert.ToString(textBox1.Text) + "')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                        }
                        if (StateP == 127)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.Name_Spec0) LIKE'%" + Convert.ToString(textBox1.Text) + "%')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                        }
                        if (StateP == 129)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.ID_SpecDB1)=" + Convert.ToInt32(textBox1.Text) + ")) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                        }
                        if (StateP == 130)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.ID_Spec1)='" + Convert.ToString(textBox1.Text) + "')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                        }
                        if (StateP == 131)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.Name_Spec1) LIKE'%" + Convert.ToString(textBox1.Text) + "%')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                        }
                        if (StateP == 133)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.ID_MatDB)=" + Convert.ToInt32(textBox1.Text) + ")) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                        }
                        if (StateP == 134)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.ID_Mat)='" + Convert.ToString(textBox1.Text) + "')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                        }
                        if (StateP == 135)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Name_Mat) LIKE'%" + Convert.ToString(textBox1.Text) + "%')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                        }
                        if (StateP == 136)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Brand_Mat)='" + Convert.ToString(textBox1.Text) + "')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                        }
                        if (StateP == 138)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_NormM.ID_NormMDB)=" + Convert.ToInt32(textBox1.Text) + ")) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                        }
                    }
                }
                if (comboBox2.Visible == true)
                {
                    if (comboBox2.Text == "" || comboBox2.ForeColor == Color.Gray)
                    {
                        MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (StateP == 128)
                        {
                            a = @""; a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec0.Type_Spec0)='" + Convert.ToString(comboBox2.Text) + "')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                        }
                        if (StateP == 132)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Spec1.Type_Spec1)='" + Convert.ToString(comboBox2.Text) + "')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                        }
                        if (StateP == 137)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_Mat.Type_Mat)='" + Convert.ToString(comboBox2.Text) + "')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                        }
                        if (StateP == 139)
                        {
                            a = @"SELECT S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M1]*[S_Items]![Count_Item]) AS Num_M1, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_M2]*[S_Items]![Count_Item]) AS Num_M2, Sum([S_Spec1]![Num_Spec1]*[S_NormM]![Num_P]*[S_Items]![Count_Item]) AS Num_P, S_NormM.Unit_M1M2P
FROM S_Spec1 INNER JOIN (S_Spec0 INNER JOIN (S_NormM INNER JOIN (S_Mat INNER JOIN (S_Items INNER JOIN SNM1 ON S_Items.ID_ItemDB = SNM1.ID_ItemDB) ON S_Mat.ID_MatDB = SNM1.ID_MatDB) ON S_NormM.ID_NormMDB = SNM1.ID_NormMDB) ON S_Spec0.ID_SpecDB0 = SNM1.ID_SpecDB0) ON S_Spec1.ID_SpecDB1 = SNM1.ID_SpecDB1 WHERE (((S_NormM.Type_NormM)='" + Convert.ToString(comboBox2.Text) + "')) GROUP BY S_Spec0.ID_Spec0, S_Spec1.ID_Spec1, S_Mat.Name_Mat, S_NormM.Unit_M1M2P";
                        }
                    }
                }
            }
            //----------------------------------------Поиск по связям++++++++++++++++++++
            if (StateP >= 140 && StateP <= 145)
            {
                if (textBox1.Text == "" || textBox1.ForeColor == Color.Gray)
                {
                    MessageBox.Show("Введите нужные данные для вывода на печать!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (StateP == 140)
                    {
                        a = @"SELECT SNM1.* FROM SNM1 WHERE (((SNM1.ID)=" + Convert.ToInt32(textBox1.Text) + "))";
                    }
                    if (StateP == 141)
                    {
                        a = @"SELECT SNM1.* FROM SNM1 WHERE (((SNM1.ID_SpecDB0)=" + Convert.ToInt32(textBox1.Text) + "))";
                    }
                    if (StateP == 142)
                    {
                        a = @"SELECT SNM1.* FROM SNM1 WHERE (((SNM1.ID_SpecDB1)=" + Convert.ToInt32(textBox1.Text) + "))";
                    }
                    if (StateP == 143)
                    {
                        a = @"SELECT SNM1.* FROM SNM1 WHERE (((SNM1.ID_Mat)=" + Convert.ToInt32(textBox1.Text) + "))";
                    }
                    if (StateP == 144)
                    {
                        a = @"SELECT SNM1.* FROM SNM1 WHERE (((SNM1.ID_NormMDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                    }
                    if (StateP == 145)
                    {
                        a = @"SELECT SNM1.* FROM SNM1 WHERE (((SNM1.ID_ItemDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                    }
                }
            }
            //----------------------------------------ПОИСК по ЛОГАМ и Пользователям
            if (StateP >= 146 && StateP <= 148)
            {
                if (textBox1.Visible == true)
                {
                    if (StateP == 146)
                    {
                        a = @"SELECT Users.* FROM Users WHERE (((Users.ID_UserDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                    }
                    if (StateP == 147)
                    {
                        a = @"SELECT Users.* FROM Users WHERE (((Users.N_User)LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                    }
                }
                if (comboBox2.Visible == true)
                {
                    if (StateP == 148)
                    {
                        a = @"SELECT Users.* FROM Users WHERE (((Users.Type_User)='" + Convert.ToString(comboBox1.Text) + "'))";
                    }
                }
            }
            if (StateP >= 149 && StateP <= 152)
            {
                if (textBox1.Visible == true)
                {
                    if (StateP == 149)
                    {
                        a = @"SELECT Logs.* FROM Logs WHERE (((Logs.ID_LogDB)=" + Convert.ToInt32(textBox1.Text) + "))";
                    }
                    if (StateP == 150)
                    {
                        a = @"SELECT Logs.* FROM Logs WHERE (((Logs.Date_Log)LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                    }
                    if (StateP == 152)
                    {
                        a = @"SELECT Logs.* FROM Logs WHERE (((Logs.Desc_Log)LIKE'%" + Convert.ToString(textBox1.Text) + "%'))";
                    }
                }
                if (comboBox2.Visible == true)
                {
                    if (StateP == 151)
                    {
                        a = @"SELECT Logs.* FROM Logs WHERE (((Logs.Desc_Log)='" + Convert.ToString(comboBox1.Text) + "'))";
                    }
                }
            }

            //MessageBox.Show(StateP.ToString());
            //MessageBox.Show(a.ToString());

            Form4 f4 = new Form4(StateP, a, TypeEvent, DescEvent, user, ConS);
            f4.Show();

        }
        //-------------------------------События БОКСОВ
        #region
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
        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.ForeColor = Color.Black;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Text = "";
        }
        private void comboBox2_Enter(object sender, EventArgs e)
        {
            comboBox2.ForeColor = Color.Black;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Text = "";
        }
        #endregion

    }
}
