using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

using LiveCharts;
using LiveCharts.Wpf;

namespace Dashboard
{
    public partial class Form1 : Form
    {
        //Deklarasi Variabel dan Database Access
        OleDbConnection koneksi;
        OleDbCommand oleDbCmd = new OleDbCommand();
        String connParam = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\TUGAS KULIAH\TUGAS KULIAH SEMESTER 4\PEMROGRAMAN VISUAL\Dashboard\Dashboard\db_pengirimanbarang.mdb";

        public Form1()
        {
            InitializeComponent();

            //Membuat Koneksi
            OleDbConnection connection = new OleDbConnection(connParam);

            // Define the label that will appear over the piece of the chart
            // in this case we'll show the given value and the percentage e.g 123 (8%)
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            //Chart Pengirim

            OleDbCommand command = new OleDbCommand("select * from q_pengirim", connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();

            reader.Read();
            int Surabaya = Convert.ToInt32(reader[0].ToString());
            int Blitar = Convert.ToInt32(reader[1].ToString());
            int Jakarta = Convert.ToInt32(reader[2].ToString());

            // Define the collection of Values to display in the Pie Chart
            pieChart1.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Surabaya",
                    Values = new ChartValues<double> {Surabaya},
                    DataLabels = true,
                    LabelPoint = labelPoint,

                },
                new PieSeries
                {
                    Title = "Blitar",
                    Values = new ChartValues<double> {Blitar},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Jakarta",
                    Values = new ChartValues<double> {Jakarta},
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
            };

            // Set the legend location to appear in the bottom of the chart
            pieChart1.LegendLocation = LegendLocation.Bottom;

            reader.Close();

            //Chart Penerima

            command = new OleDbCommand("select * from q_penerima", connection);
            reader = command.ExecuteReader();

            reader.Read();
            Surabaya = Convert.ToInt32(reader[0].ToString());
            int Palembang = Convert.ToInt32(reader[1].ToString());
            int Medan = Convert.ToInt32(reader[2].ToString());
            int Bali = Convert.ToInt32(reader[3].ToString());

            // Define the collection of Values to display in the Pie Chart
            pieChart2.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Surabaya",
                    Values = new ChartValues<double> {Surabaya},
                    DataLabels = true,
                    LabelPoint = labelPoint,

                },
                new PieSeries
                {
                    Title = "Palembang",
                    Values = new ChartValues<double> {Palembang},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Medan",
                    Values = new ChartValues<double> {Medan},
                    DataLabels = true,
                    LabelPoint = labelPoint
                },
                new PieSeries
                {
                    Title = "Bali",
                    Values = new ChartValues<double> {Bali},
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
            };

            // Set the legend location to appear in the bottom of the chart
            pieChart2.LegendLocation = LegendLocation.Bottom;

            //Chartasian Chart 1

            //Mengambil data tabel dari Database

            command = new OleDbCommand("select * from q_total_transaksi WHERE id_total_transaksi = 1", connection);
            reader = command.ExecuteReader();

            reader.Read();
            int transaksi_regular = Convert.ToInt32(reader[2].ToString());
            int transaksi_expert = Convert.ToInt32(reader[3].ToString());
            int transaksi_flash = Convert.ToInt32(reader[4].ToString());

            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = reader[1].ToString(),
                    Values = new ChartValues<double> {transaksi_regular,transaksi_expert,transaksi_flash}
                }
            };

        //Chartasian Chart 2

        //Mengambil data tabel dari Database

        command = new OleDbCommand("select * from q_total_transaksi WHERE id_total_transaksi = 2", connection);
            reader = command.ExecuteReader();

            reader.Read();
            transaksi_regular = Convert.ToInt32(reader[2].ToString());
            transaksi_expert = Convert.ToInt32(reader[3].ToString());
            transaksi_flash = Convert.ToInt32(reader[4].ToString());

            cartesianChart2.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = reader[1].ToString(),
                    Values = new ChartValues<double> {transaksi_regular,transaksi_expert,transaksi_flash}
                }
            };

            //Chartasian Chart 3

            //Mengambil data tabel dari Database

            command = new OleDbCommand("select * from q_total_transaksi WHERE id_total_transaksi = 3", connection);
            reader = command.ExecuteReader();

            reader.Read();
            transaksi_regular = Convert.ToInt32(reader[2].ToString());
            transaksi_expert = Convert.ToInt32(reader[3].ToString());
            transaksi_flash = Convert.ToInt32(reader[4].ToString());

            cartesianChart3.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = reader[1].ToString(),
                    Values = new ChartValues<double> {transaksi_regular,transaksi_expert,transaksi_flash}
                }
            };

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_pengirimanbarangDataSet.tb_total_transaksi' table. You can move, or remove it, as needed.
            this.tb_total_transaksiTableAdapter.Fill(this.db_pengirimanbarangDataSet.tb_total_transaksi);
            // TODO: This line of code loads data into the 'db_pengirimanbarangDataSet.tb_penerima' table. You can move, or remove it, as needed.
            this.tb_penerimaTableAdapter.Fill(this.db_pengirimanbarangDataSet.tb_penerima);
            // TODO: This line of code loads data into the 'db_pengirimanbarangDataSet.tb_pengirim' table. You can move, or remove it, as needed.
            this.tb_pengirimTableAdapter.Fill(this.db_pengirimanbarangDataSet.tb_pengirim);

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel4_Paint(object sender, PaintEventArgs e)
        {
                    }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pieChart5_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
                    }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged_1(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {
            
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }
    }
}
