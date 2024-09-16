using LinqLabs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Starter
{
    public partial class FrmHelloLinq : Form
    {
        public FrmHelloLinq()
        {
            InitializeComponent();
        }

        private void btnArray_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3 ,4,5,6,7,8,9};

            //foreach (int i in nums) 
            //{
            //    listBox1.Items.Add(i);
            //}

            //var q = from n in nums
            //        where n%2==0
            //        select n;

            //listBox1.DataSource = q.ToList();

            IEnumerator en = nums.GetEnumerator();
            
            while (en.MoveNext()) 
            {
                listBox1.Items.Add(en.Current);
            }

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int> {1,2,3,4,5,6,7,8,9,10,11,12 };
            
            foreach (int i in list)
            {
                listBox1.Items.Add(i);
            }

            listBox1.Items.Add("==========================================");

            List<int>.Enumerator en = list.GetEnumerator();

            while (en.MoveNext())
            {
                listBox1.Items.Add((en.Current));
            }

            listBox1.Items.Add("==========================================");

            IEnumerable<int> q = from n in list
                    select n;

            listBox1.DataSource = q.ToList();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13,14,15 };

            IEnumerable<int> q = from int n in nums
                                     //where n>5 && n<=
                                     //where n%2==0
                                 where n<3||n>10
                                 select n;

            //foreach (int n in q) 
            //{
            //    listBox1.Items.Add(n);
            //}
            listBox1.DataSource = q.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var q = from n in nums
                    where isEven(n)
                    select n;

            foreach (var n in q) 
            {
                listBox1.Items.Add(n);
            }
        }

        private bool isEven(int n)
        {
            return (n % 2 == 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            var q = from n in nums
                    where isEven(n)
                    select "Hello"+ n.ToString();

            foreach (var n in q)
            {
                listBox1.Items.Add(n);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            IEnumerable<Point> q = from n in nums
                    where n>5
                    select new Point(n,n*n);

            foreach (var n in q)
            {
                listBox1.Items.Add(n);
            }
            List<Point> list = q.ToList();
            dataGridView1.DataSource = list;

            this.chart1.DataSource = list;
            chart1.Series[0].XValueMember = "X";
            chart1.Series[0].YValueMembers = "Y";
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] fruits = { "apple", "pieApple", "banana", "orange", "AppleWatch" };

            var q = from n in fruits
                    select n.ToUpper();
            var q2 = from n in q
                     where n.Contains("APPLE")
                     select n;

            foreach (var n in q2) 
            {
                listBox1.Items.Add(n);
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            productsTableAdapter1.Fill(nwDataSet1.Products);

            var q = from p in nwDataSet1.Products
                    where p.UnitPrice > 30 && p.ProductName.StartsWith("P")
                    select p;

            dataGridView1.DataSource = q.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ordersTableAdapter1.Fill(nwDataSet1.Orders);

            OrderedEnumerableRowCollection<LinqLabs.NWDataSet.OrdersRow> q = from o in nwDataSet1.Orders
                    where o.OrderDate.Year == 1997
                    orderby o.OrderDate.Month
                    select o;
            dataGridView1.DataSource = q.ToList();

            //var q2 = nwDataSet1.Orders.FirstOrDefault().OrderDate.Year.Equals(1997).;
    
        }

        //public static System.Collections.Generic.IEnumerable<TSource> Where<TSource>(this System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, bool> predicate)
        //System.Linq.Enumerable 的成員

    }
}
