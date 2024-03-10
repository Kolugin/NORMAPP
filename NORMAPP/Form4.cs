using Microsoft.Reporting.WinForms;
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
    public partial class Form4 : Form
    {
        public Form4(int StateP, string a, string TypeEvent, string DescEvent, string user, string ConS)
        {
            InitializeComponent();
            this.StateP = StateP;
            this.a = a;
            this.TypeEvent = TypeEvent;
            this.DescEvent = DescEvent;
            this.user = user;
            this.ConS = ConS;
        }
        private OleDbConnection dbCon;
        public int StateP;
        public string a;
        public string TypeEvent;
        public string DescEvent;
        public string user;
        public string ConS;
        DataTable dataTable = new DataTable();

        public void LoadQ() //запрос
        {
            OleDbCommand cmd = new OleDbCommand(a, dbCon);
            OleDbDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            reader.Close();
            if (StateP >= 0 && StateP <= 3) //------------------------------------Заказчик
            {
                reportViewer1.LocalReport.ReportPath = @"Report1.rdlc";
            }
            if (StateP >= 4 && StateP <= 10)//------------------------------------Заказ
            {
                reportViewer1.LocalReport.ReportPath = @"Report2.rdlc";
            }
            if (StateP >= 11 && StateP <= 13) //------------------------------------Перечень
            {
                reportViewer1.LocalReport.ReportPath = @"Report3.rdlc";
            }

            if (StateP >= 14 && StateP <= 22) // ------------------------------------Заказчик Заказ
            {
                reportViewer1.LocalReport.ReportPath = @"Report4.rdlc";
            }
            if (StateP >= 23 && StateP <= 30) //------------------------------------Заказ Перечень
            {
                reportViewer1.LocalReport.ReportPath = @"Report5.rdlc";
            }
            if (StateP >= 31 && StateP <= 41) //------------------------------------Заказчик Заказ Перечень
            {
                reportViewer1.LocalReport.ReportPath = @"Report6.rdlc"; 
            }

            if (StateP >= 42 && StateP <= 45) //------------------------------------Изделие
            {
                reportViewer1.LocalReport.ReportPath = @"Report7.rdlc";
            }
            if (StateP >= 46 && StateP <= 51) //-----------------------------------Узел/Деталь
            {
                reportViewer1.LocalReport.ReportPath = @"Report8.rdlc";
            }

            if (StateP >= 52 && StateP <= 59) //-----------------------------------Изделие Узел Деталь
            {
                reportViewer1.LocalReport.ReportPath = @"Report9.rdlc";
            }

            if (StateP >= 60 && StateP <= 64) //-----------------------------------Материал
            {
                reportViewer1.LocalReport.ReportPath = @"Report10.rdlc";
            }
            if (StateP >= 65 && StateP <= 66) //-----------------------------------Норма
            {
                reportViewer1.LocalReport.ReportPath = @"Report11.rdlc";
            }
            if (StateP >= 67 && StateP <= 68) //----------------------------------ГОСТ
            {
                reportViewer1.LocalReport.ReportPath = @"Report12.rdlc";
            }

            if (StateP >= 69 && StateP <= 75)
            {
                reportViewer1.LocalReport.ReportPath = @"Report13.rdlc";
            }
            if (StateP >= 76 && StateP <= 84)
            {
                reportViewer1.LocalReport.ReportPath = @"Report14.rdlc";
            }
            if (StateP >= 85 && StateP <= 95)
            {
                reportViewer1.LocalReport.ReportPath = @"Report15.rdlc";
            }
            if (StateP >= 96 && StateP <= 110)
            {
                reportViewer1.LocalReport.ReportPath = @"Report16.rdlc";
            }
            if (StateP >= 111 && StateP <= 121)
            {
                reportViewer1.LocalReport.ReportPath = @"Report17.rdlc";
            }
            if (StateP >= 122 && StateP <= 139)
            {
                reportViewer1.LocalReport.ReportPath = @"Report18.rdlc";
            }

            if (StateP >= 140 && StateP <= 145)
            {
                reportViewer1.LocalReport.ReportPath = @"Report19.rdlc";
            }

            if (StateP >= 146 && StateP <= 148)
            {
                reportViewer1.LocalReport.ReportPath = @"Report20.rdlc";
            }
            if (StateP >= 149 && StateP <= 152)
            {
                reportViewer1.LocalReport.ReportPath = @"Report21.rdlc";
            }

            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataTable);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.RefreshReport();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            dbCon = new OleDbConnection(ConS);
            dbCon.Open();
            using (dbCon)
            {
                try
                {
                    MessageBox.Show(StateP.ToString());
                    MessageBox.Show(a.ToString());
                    LoadQ();
                }
                catch (Exception g)
                {
                    TypeEvent = "Ошибка подключения к БД";
                    DescEvent = "Ошибка подключения к БД. Form4, Load(60)";
                   // Logg();
                    MessageBox.Show("Ошибка при подключении к БД. Обратитесь в поддержку" + Convert.ToString(g), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            dbCon.Close();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
