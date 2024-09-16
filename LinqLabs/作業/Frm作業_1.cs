using LinqLabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class Frm作業_1 : Form
    {
        public Frm作業_1()
        {
            InitializeComponent();

            ordersTableAdapter1.Fill(nwDataSet1.Orders);
            order_DetailsTableAdapter1.Fill(nwDataSet1.Order_Details);


            var q = from y in nwDataSet1.Orders
                    select y.OrderDate.Year;
            var q2 = q.Distinct();
            foreach (var i in q2)
            {
                _years.Add(i);
                comboBox1.Items.Add(i);
            }
            comboBox1.Text = _years.FirstOrDefault().ToString();

        }
        int take = 0;
        int page = -1;
        List<int> _years=new List<int>();
        List<int> _orderIDs;
        int index = 0;
        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;

            productsTableAdapter1.Fill(nwDataSet1.Products);

            take = Convert.ToInt32(textBox1.Text);
            page += 1;
            //this.nwDataSet1.Products.Take(10);//Top 10 Skip(10)

            //Distinct()
            var q = from p in nwDataSet1.Products
                    select p;
            dataGridView1.DataSource = q.Skip(take* page).Take(take).ToList();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files =  dir.GetFiles();

            var q = from f in files
                    where f.Extension == ".log"
                    select f;




            //files[0].CreationTime
            this.dataGridView1.DataSource = q.ToList();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from f in files
                    where f.CreationTime.Year == 2019
                    select f;




            //files[0].CreationTime
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from f in files
                    where f.Length>100000
                    select f;




            //files[0].CreationTime
            this.dataGridView1.DataSource = q.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ordersTableAdapter1.Fill(nwDataSet1.Orders);

            var q = from o in nwDataSet1.Orders
                    select o;

            dataGridView1.DataSource = q.ToList();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            _orderIDs=null;
            var q = from o in nwDataSet1.Orders
                    where o.OrderDate.Year == Convert.ToInt32(comboBox1.Text)
                    select o;
            _orderIDs = new List<int>();
            foreach (var i in q) 
            {
                _orderIDs.Add(i.OrderID);
            }

            var q2 = from od in nwDataSet1.Order_Details
                     where od.OrderID == _orderIDs[index]
                     select new
                     {
                         訂單ID = od.OrderID,
                         產品ID = od.ProductID,
                         單價 = od.UnitPrice,
                         數量 = od.Quantity,
                         折扣 = od.Discount
                     };

            dataGridView1.DataSource = q.ToList();
            dataGridView2.DataSource = q2.ToList();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;

            productsTableAdapter1.Fill(nwDataSet1.Products);

            take = Convert.ToInt32(textBox1.Text);
            page -= 1;
            //this.nwDataSet1.Products.Take(10);//Top 10 Skip(10)

            //Distinct()
            var q = from p in nwDataSet1.Products
                    select p;
            dataGridView1.DataSource = q.Skip(take * page).Take(take).ToList();
        }


        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.DataSource = null;
            index = e.RowIndex;
            if (_orderIDs == null)
                return;
            var q = from od in nwDataSet1.Order_Details
                     where od.OrderID == _orderIDs[index]
                     select new
                     {
                         訂單ID = od.OrderID,
                         產品ID = od.ProductID,
                         單價 = od.UnitPrice,
                         數量 = od.Quantity,
                         折扣 = od.Discount
                     };
            dataGridView2.DataSource= q.ToList();
        }
    }
}
