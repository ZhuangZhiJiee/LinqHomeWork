using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs.作業
{
    public partial class Frm作業_3s : Form
    {
        List<Student> _students_scores;
        public Frm作業_3s()
        {
            InitializeComponent();

            //hint
            List<Student> students_scores = new List<Student>()
                                         {
                                            new Student{ Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
                                            new Student{ Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 80, Gender = "Female" },
                                            new Student{ Name = "ggg", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "hhh", Class = "CS_102", Chi = 60, Eng = 90, Math = 70, Gender = "Male" },
                                            new Student{ Name = "iii", Class = "CS_101", Chi = 40, Eng = 80, Math = 95, Gender = "Female" },
                                            new Student{ Name = "jjj", Class = "CS_102", Chi = 85, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "kkk", Class = "CS_101", Chi = 65, Eng = 95, Math = 85, Gender = "Female" },
                                            new Student{ Name = "lll", Class = "CS_102", Chi = 87, Eng = 93, Math = 70, Gender = "Female" },
                                            new Student{ Name = "mmm", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "nnn", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ooo", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ppp", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "qqq", Class = "CS_101", Chi = 85, Eng = 80, Math = 50, Gender = "Female" },
                                            new Student{ Name = "rrr", Class = "CS_102", Chi = 80, Eng = 8, Math = 80, Gender = "Female" },
                                            new Student{ Name = "sss", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "ttt", Class = "CS_102", Chi = 60, Eng = 90, Math = 70, Gender = "Male" },
                                            new Student{ Name = "uuu", Class = "CS_101", Chi = 40, Eng = 80, Math = 95, Gender = "Female" },
                                            new Student{ Name = "vvv", Class = "CS_102", Chi = 85, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "www", Class = "CS_101", Chi = 65, Eng = 95, Math = 85, Gender = "Female" },
                                            new Student{ Name = "xxx", Class = "CS_102", Chi = 87, Eng = 93, Math = 70, Gender = "Female" },
                                            new Student{ Name = "yyy", Class = "CS_101", Chi = 65, Eng = 85, Math = 70, Gender = "Female" },
                                            new Student{ Name = "zzz", Class = "CS_102", Chi = 87, Eng = 90, Math = 50, Gender = "Female" },
                                            new Student{ Name = "xyz", Class = "CS_102", Chi = 98, Eng = 90, Math = 90, Gender = "Female" },
                                          };
            _students_scores = students_scores;
          
        }
        NorthwindEntities nw = new NorthwindEntities();
        private void button36_Click(object sender, EventArgs e)
        {
            #region 搜尋 班級學生成績

            // 
            // 共幾個 學員成績 ?						

            // 找出 前面三個 的學員所有科目成績					
            // 找出 後面兩個 的學員所有科目成績					

            // 找出 Name 'aaa','bbb','ccc' 的學員國文英文科目成績						

            // 找出學員 'bbb' 的成績	                          

            // 找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)	

            // 找出 'aaa', 'bbb' 'ccc' 學員 國文數學兩科 科目成績  |				
            // 數學不及格 ... 是誰 
            #endregion
        }

        private void button37_Click(object sender, EventArgs e)
        {
            //個人 sum, min, max, avg
            // 統計 每個學生個人成績 並排序
           
        }

        private void button33_Click(object sender, EventArgs e)
        {

            // split=> 分成 三群 '待加強'(60~69) '佳'(70~89) '優良'(90~100) 
            var q = from s in _students_scores
                    select new
                    {
                        姓名 = s.Name,
                        平均 = new Dictionary<string, int>
                        {
                            { "Chi", s.Chi },
                            { "Eng", s.Eng },
                            { "Math", s.Math }
                        }.Average(a => a.Value)
                    };

            var q2 = from s in q
                     group s by split((int)s.平均) into g
                     select g;

            foreach (var group in q2) 
            {
                TreeNode node = treeView1.Nodes.Add(group.Key);
                foreach (var item in group) 
                {
                    node.Nodes.Add(item.ToString());
                }
            }

            dataGridView1.DataSource = q2.ToList();
            // print 每一群是哪幾個 ? (每一群 sort by 分數 descending)
        }

        private void button38_Click(object sender, EventArgs e)
        {
            
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from n in files
                    group n by filesplit((int)n.Length)into g
                    select g;

            foreach (IGrouping<string, System.IO.FileInfo> group in q)
            {
                TreeNode nodes = treeView1.Nodes.Add(group.Key);
                foreach (System.IO.FileInfo items in group) 
                {
                    nodes.Nodes.Add(items.ToString());
                }
            }

            dataGridView1.DataSource = q.ToList();   
        }
        private string split(int n) 
        {
            if (n >= 60 && n < 70)
            {
                return "待加強";
            }
            else if (n >= 70 && n < 90)
            {
                return "佳";
            }
            else if (n >= 90 && n <= 100)
            {
                return "優良";
            }
            else
                return "差";
        }
        private string filesplit(int lenth)
        {
            if (lenth < 10000)
                return "小";
            else if (lenth < 100000 && lenth > 10000)
                return "中";
            else
                return "大";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();

            var q = from f in files
                     group f by f.CreationTime.Year into g
                     select g;

            foreach (IGrouping<int, System.IO.FileInfo> group in q) 
            {
                TreeNode node = treeView1.Nodes.Add(group.Key.ToString());
                foreach (var item in group) 
                {
                    node.Nodes.Add(item.ToString());
                }  
            }

            dataGridView1.DataSource = q.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;


            var q = nw.Products.AsEnumerable().GroupBy(x => ProductPrice(x.UnitPrice)).Select(p => new { 價格種類 = p.Key,數量 = p.Count(), MyGroup = p });

            dataGridView1.DataSource = q.ToList();

            foreach (var group in q) 
            {
                TreeNode node = treeView2.Nodes.Add(group.價格種類);
                foreach (var item in group.MyGroup) 
                {
                    node.Nodes.Add($"產品名: {item.ProductName} \r 價格: {item.UnitPrice:C0}");
                }
            }
        }
        private string ProductPrice(decimal? price) 
        {
            if (price < 20)
            {
                return "低價";
            }
            else if (price >= 20 && price < 50)
            {
                return "中價";
            }
            else if (price >= 50)
                return "高價";
            else
                return "未標示價格";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var q = nw.Orders.GroupBy(x => x.OrderDate.Value.Year).Select(o => new { 年分=o.Key, 數量 = o.Count(), MyGroup = o });
            dataGridView1.DataSource = q.ToList();

            foreach (var g in q) 
            {
                TreeNode node = treeView1.Nodes.Add(g.MyGroup.Key.ToString());
                foreach (var o in g.MyGroup) 
                {
                    node.Nodes.Add($"訂單編號: {o.OrderID} \r 訂單日期: {o.OrderDate}");
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var q = nw.Orders.AsEnumerable().GroupBy(x => new {年 = x.OrderDate.Value.Year, 月 = x.OrderDate.Value.Month }).
                Select(o => new { 年月= $"{o.Key.年}年{o.Key.月}月", 數量= o.Count(), MyGroup = o});

            foreach (var group in q)
            {
                TreeNode node = treeView1.Nodes.Add(group.年月);
                foreach (var item in group.MyGroup)
                {
                    node.Nodes.Add($"訂單編號: {item.OrderID} \r 訂單日期: {item.OrderDate}");
                }
            }


            dataGridView1.DataSource = q.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var q = nw.Order_Details.AsEnumerable().Select(x => new { 總價 = Math.Round(Convert.ToDouble(x.Quantity) * Convert.ToDouble(x.UnitPrice) * (1 - x.Discount),0)});
            MessageBox.Show(q.Sum(x => x.總價).ToString());
            dataGridView1 .DataSource = q.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = nw.Order_Details.AsEnumerable().Select(x => new
            {
                x.Order.EmployeeID,
                姓名 = x.Order.Employee.FirstName + " " + x.Order.Employee.LastName,
                總價 = Math.Round(x.Quantity * x.UnitPrice * Convert.ToDecimal(1 - x.Discount), 0),
            }).GroupBy(x => new { x.EmployeeID, x.姓名 }).Select(g => new { 員工編號 = g.Key.EmployeeID, 姓名 = g.Key.姓名, 總價合計 = g.Sum(x => x.總價) }).
            OrderByDescending(x => x.總價合計).Take(5);

            dataGridView1.DataSource = q.ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var q = nw.Products.OrderByDescending(x => x.UnitPrice).Select(x => new
            {
                產品編號= x.ProductID,
                產品名稱= x.ProductName,
                類別名稱 = x.Category.CategoryName,
                單價 = x.UnitPrice
            }).Take(5);
            dataGridView1.DataSource = q.ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var q = nw.Products.Where(x => x.UnitPrice >= 300).Select(x => x);
            dataGridView1.DataSource = q.ToList();
            MessageBox.Show($"有{q.Count()}筆");
        }
    }
}
