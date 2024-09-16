using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace Starter
{
    public partial class FrmLINQ_To_XXX : Form
    {
        public FrmLINQ_To_XXX()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            List<int> list = new List<int> {1,2,3,4,5,6,7,8,9,10 };

            

            IEnumerable<IGrouping<string, int>> q = from n in nums
                    group n by n % 2==0?"偶數":"奇數";

            dataGridView1.DataSource = q.ToList();

            foreach (IGrouping<string, int> group in q) 
            {
                TreeNode node = treeView1.Nodes.Add(group.Key.ToString());
                foreach (int item in group) 
                {
                    node.Nodes.Add(item.ToString());
                }
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var q = from n in nums
                    group n by n % 2 == 0 ? "偶數" : "奇數" into g
                    select new { MyKey = g.Key, MyCount = g.Count(), MyGroup =g, MyAvg = g.Average() };

            dataGridView1.DataSource = q.ToList();

            foreach (var group in q)
            {
                TreeNode node = treeView1.Nodes.Add(group.MyKey.ToString()+$"({group.MyCount})");
                foreach (int item in group.MyGroup)
                {
                    node.Nodes.Add(item.ToString());
                }
            }
            chart1.DataSource = q.ToList();
            chart1.Series[0].XValueMember = "MyKey";
            chart1.Series[0].YValueMembers = "MyCount";
            chart1.Series[0].ChartType =System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            chart1.Series[1].XValueMember = "MyKey";
            chart1.Series[1].YValueMembers = "MyAvg";
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var q = from n in nums
                    group n by MyKey(n) into g
                    select new { MyKey = g.Key, MyCount = g.Count(), MyGroup = g, MyAvg = g.Average() };

            dataGridView1.DataSource = q.ToList();

            foreach (var group in q)
            {
                TreeNode node = treeView1.Nodes.Add(group.MyKey.ToString() + $"({group.MyCount})");
                foreach (int item in group.MyGroup)
                {
                    node.Nodes.Add(item.ToString());
                }
            }
        }
        private string MyKey(int n) 
        {
            if (n <= 5)
                return "Small";
            else if (n <= 10)
                return "Mid";
            else
                return "Large";
        }

        private void button38_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from n in files
                    group n by n.Extension into g
                    select new { g.Key, count = g.Count() };

            dataGridView1.DataSource = q.ToList();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ordersTableAdapter1.Fill(nwDataSet1.Orders);

            //var q = from n in nwDataSet1.Orders
            //        group n by n.OrderDate.Year into g
            //        select new { g.Key, count = g.Count()};

            var q = nwDataSet1.Orders.GroupBy(x => x.OrderDate.Year).Select(x => new { Year = x.Key, count = x.Count(),Mygroup = x}) ;

            foreach (var group in q) 
            {
                TreeNode node = treeView1.Nodes.Add(group.Year.ToString());
                foreach (var item in group.Mygroup) 
                {
                    node.Nodes.Add(item.OrderID.ToString());
                }
            }


            dataGridView1.DataSource = q.ToList();  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s = "This is a pen. This is a book. This is an apple";

            Char[] chars = { '.', '?',' ' };
            string[] s2 = s.Split(chars);

            var q = from n in s2
                    where n != ""
                    group n by n.ToUpper() into g
                    select new { 關鍵字 = g.Key, count = g.Count() };
                    
            dataGridView1 .DataSource = q.ToList();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from f in files
                    let s = f.Extension
                    where s == ".log"
                    select f;

            MessageBox.Show("Count: " + q.Count());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int[] nums1 = { 1, 2, 5, 7, 9, 2, 1 };
            int[] nums2 = { 2, 4, 5, 6, 8, 10 };

            var q= nums1.Intersect(nums2);
            q = nums1.Union(nums2);
            q=nums1.Distinct();

            bool result = nums1.Any(x => x > 4);
            result = nums1.All(x => x > 4);

            int n = nums1.FirstOrDefault(x => x > 4);
            n = nums2.ElementAtOrDefault(32);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            categoriesTableAdapter1.Fill(nwDataSet1.Categories);
            productsTableAdapter1.Fill(nwDataSet1.Products);

            var q = from p in nwDataSet1.Products
                    join c in nwDataSet1.Categories
                    on p.CategoryID equals c.CategoryID
                    group p by c.CategoryName into g
                    select new
                    {
                        類別名稱 = g.Key,
                        平均單價 = g.Average(p => p.UnitPrice).ToString("0")
                    };

            //var q2 = nwDataSet1.Products



            dataGridView1.DataSource = q.ToList();
        }
    }
}
